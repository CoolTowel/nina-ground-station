﻿#region "copyright"

/*
    Copyright Dale Ghent <daleg@elemental.org>

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/
*/

#endregion "copyright"

using DaleGhent.NINA.GroundStation.Mqtt;
using Newtonsoft.Json;
using NINA.Core.Enum;
using NINA.Core.Model;
using NINA.Core.Utility;
using NINA.Sequencer.Container;
using NINA.Sequencer.SequenceItem;
using NINA.Sequencer.Trigger;
using NINA.Sequencer.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;

namespace DaleGhent.NINA.GroundStation.FailuresToMqttTrigger {

    [ExportMetadata("Name", "Failures to MQTT broker")]
    [ExportMetadata("Description", "Publishes an informative JSON object to an MQTT broker when a sequence instruction fails")]
    [ExportMetadata("Icon", "Mqtt_SVG")]
    [ExportMetadata("Category", "Ground Station")]
    [Export(typeof(ISequenceTrigger))]
    [JsonObject(MemberSerialization.OptIn)]
    public class FailuresToMqttTrigger : SequenceTrigger, IValidatable {
        private MqttCommon mqtt;
        private ISequenceItem previousItem;
        private string topic;
        private int qos = 0;

        [ImportingConstructor]
        public FailuresToMqttTrigger() {
            mqtt = new MqttCommon();
            Topic = Properties.Settings.Default.MqttDefaultTopic;
            QoS = Properties.Settings.Default.MqttDefaultFailureQoSLevel;
        }

        public FailuresToMqttTrigger(FailuresToMqttTrigger copyMe) : this() {
            CopyMetaData(copyMe);
        }

        [JsonProperty]
        public string Topic {
            get => topic;
            set {
                topic = value;
                RaisePropertyChanged();
            }
        }

        [JsonProperty]
        public int QoS {
            get => qos;
            set {
                qos = value;
                RaisePropertyChanged();
            }
        }

        public IList<string> QoSLevels => MqttCommon.QoSLevels;

        public override async Task Execute(ISequenceContainer context, IProgress<ApplicationStatus> progress, CancellationToken ct) {
            var target = Utilities.FindDsoInfo(previousItem.Parent);
            var now = DateTime.Now;

            var itemInfo = new PreviousItem {
                version = 2,
                name = previousItem.Name,
                description = previousItem.Description,
                attempts = previousItem.Attempts,
                date_local = now.ToString("o"),
                date_utc = now.ToUniversalTime().ToString("o"),
                date_unix = Utilities.UnixEpoch(),
                target_info = new List<TargetInfo>(),
                error_list = new List<ErrorItems>()
            };

            if (target != null) {
                itemInfo.target_info.Add(new TargetInfo {
                    target_name = target.Name,
                    target_ra = target.Coordinates.RAString,
                    target_dec = target.Coordinates.DecString
                });
            }

            foreach (var e in PreviousItemIssues) {
                itemInfo.error_list.Add(new ErrorItems { reason = e, });
            }

            string payload = JsonConvert.SerializeObject(itemInfo);

            Logger.Trace($"{this}: {payload}");

            await mqtt.PublishMessage(Topic, payload, QoS, ct);
        }

        public override bool ShouldTrigger(ISequenceItem previousItem, ISequenceItem nextItem) {
            return false;
        }

        public override bool ShouldTriggerAfter(ISequenceItem previousItem, ISequenceItem nextItem) {
            bool shouldTrigger = false;

            if (previousItem == null) {
                Logger.Debug("MqttTrigger: Previous item is null. Asserting false");
                return shouldTrigger; ;
            }

            this.previousItem = previousItem;

            if (this.previousItem.Status == SequenceEntityStatus.FAILED && !this.previousItem.Name.Contains("MQTT")) {
                Logger.Debug($"MqttTrigger: Previous item \"{this.previousItem.Name}\" failed. Asserting true");
                shouldTrigger = true;

                if (this.previousItem is IValidatable validatableItem && validatableItem.Issues.Count > 0) {
                    PreviousItemIssues = validatableItem.Issues;
                    Logger.Debug($"MqttTrigger: Previous item \"{this.previousItem.Name}\" had {PreviousItemIssues.Count} issues: {string.Join(", ", PreviousItemIssues)}");
                }
            } else {
                Logger.Debug($"MqttTrigger: Previous item \"{this.previousItem.Name}\" did not fail. Asserting false");
            }

            return shouldTrigger;
        }

        public IList<string> Issues { get; set; } = new ObservableCollection<string>();

        public bool Validate() {
            var i = new List<string>(mqtt.ValidateSettings());

            if (string.IsNullOrEmpty(Topic)) {
                i.Add("A topic is not defined");
            }

            if (i != Issues) {
                Issues = i;
                RaisePropertyChanged("Issues");
            }

            return i.Count == 0;
        }

        public override object Clone() {
            return new FailuresToMqttTrigger() {
                Icon = Icon,
                Name = Name,
                Topic = Topic,
                QoS = QoS,
                Category = Category,
                Description = Description,
            };
        }

        public override string ToString() {
            return $"Category: {Category}, Item: {nameof(FailuresToMqttTrigger)}, Topic: {Topic}, QoS: {QoS}";
        }

        private IList<string> PreviousItemIssues { get; set; } = new List<string>();

        private class PreviousItem {
            public int version { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string date_local { get; set; }
            public string date_utc { get; set; }
            public long date_unix { get; set; }
            public int attempts { get; set; }
            public List<TargetInfo> target_info { get; set; }
            public List<ErrorItems> error_list { get; set; }
        }

        public class TargetInfo {
            public string target_name { get; set; }
            public string target_ra { get; set; }
            public string target_dec { get; set; }
        }

        public class ErrorItems {
            public string reason { get; set; }
        }
    }
}