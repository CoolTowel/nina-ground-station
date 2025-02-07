﻿#region "copyright"

/*
    Copyright Dale Ghent <daleg@elemental.org>

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/
*/

#endregion "copyright"

using DaleGhent.NINA.GroundStation.Mqtt;
using DaleGhent.NINA.GroundStation.Utilities;
using NINA.Core.Utility;
using NINA.Plugin;
using NINA.Plugin.Interfaces;
using NINA.Profile.Interfaces;
using PushoverClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace DaleGhent.NINA.GroundStation {

    [Export(typeof(IPluginManifest))]
    public class GroundStation : PluginBase, ISettings, INotifyPropertyChanged {
        private MqttClient mqttClient;

        [ImportingConstructor]
        public GroundStation() {
            if (Properties.Settings.Default.UpgradeSettings) {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeSettings = false;
                CoreUtil.SaveSettings(Properties.Settings.Default);
            }
        }

        public override Task Initialize() {
            if (MqttLwtEnable) {
                LwtStartWorker();
            }

            Logger.Debug("Init completed");

            return Task.CompletedTask;
        }

        public override async Task Teardown() {
            if (MqttLwtEnable) {
                await LwtStopWorker();
            }

            return;
        }

        private Task LwtStartWorker() {
            return Task.Run(async () => {
                Logger.Info($"Starting MQTT LWT service. Sending to topic {MqttLwtTopic}");

                mqttClient = new MqttClient() {
                    Payload = Utilities.Utilities.ResolveTokens(MqttLwtBirthPayload),
                    LastWillTopic = MqttLwtTopic,
                    LastWillPayload = Utilities.Utilities.ResolveTokens(MqttLwtLastWillPayload),
                    Qos = MqttDefaultFailureQoSLevel,
                };

                var clientOpts = mqttClient.Prepare();

                await mqttClient.Connect(clientOpts, CancellationToken.None);
                await mqttClient.Publish(CancellationToken.None);

                Logger.Debug("Exiting LwtStartWorker task");
            });
        }

        private async Task LwtStopWorker() {
            Logger.Debug("Stopping LWT worker");

            mqttClient.Payload = Utilities.Utilities.ResolveTokens(MqttLwtClosePayload);
            await mqttClient.Publish(CancellationToken.None);

            await mqttClient.Disconnect(CancellationToken.None);

            return;
        }

        public string IFTTTWebhookKey {
            get => Security.Decrypt(Properties.Settings.Default.IFTTTWebhookKey);
            set {
                Properties.Settings.Default.IFTTTWebhookKey = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string IftttFailureValue1 {
            get => Properties.Settings.Default.IftttFailureValue1;
            set {
                Properties.Settings.Default.IftttFailureValue1 = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string IftttFailureValue2 {
            get => Properties.Settings.Default.IftttFailureValue2;
            set {
                Properties.Settings.Default.IftttFailureValue2 = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string IftttFailureValue3 {
            get => Properties.Settings.Default.IftttFailureValue3;
            set {
                Properties.Settings.Default.IftttFailureValue3 = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string PushoverAppKey {
            get => Security.Decrypt(Properties.Settings.Default.PushoverAppKey);
            set {
                Properties.Settings.Default.PushoverAppKey = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string PushoverUserKey {
            get => Security.Decrypt(Properties.Settings.Default.PushoverUserKey);
            set {
                Properties.Settings.Default.PushoverUserKey = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public Priority[] PushoverPriorities => Enum.GetValues(typeof(Priority)).Cast<Priority>().Where(p => p != Priority.Emergency).ToArray();

        public NotificationSound[] PushoverNotificationSounds => Enum.GetValues(typeof(NotificationSound)).Cast<NotificationSound>().Where(p => p != NotificationSound.NotSet).ToArray();

        public NotificationSound PushoverDefaultNotificationSound {
            get => Properties.Settings.Default.PushoverDefaultNotificationSound;
            set {
                Properties.Settings.Default.PushoverDefaultNotificationSound = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public Priority PushoverDefaultNotificationPriority {
            get => Properties.Settings.Default.PushoverDefaultNotificationPriority;
            set {
                Properties.Settings.Default.PushoverDefaultNotificationPriority = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public NotificationSound PushoverDefaultFailureSound {
            get => Properties.Settings.Default.PushoverDefaultFailureSound;
            set {
                Properties.Settings.Default.PushoverDefaultFailureSound = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public Priority PushoverDefaultFailurePriority {
            get => Properties.Settings.Default.PushoverDefaultFailurePriority;
            set {
                Properties.Settings.Default.PushoverDefaultFailurePriority = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string PushoverFailureTitleText {
            get => Properties.Settings.Default.PushoverFailureTitleText;
            set {
                Properties.Settings.Default.PushoverFailureTitleText = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string PushoverFailureBodyText {
            get => Properties.Settings.Default.PushoverFailureBodyText;
            set {
                Properties.Settings.Default.PushoverFailureBodyText = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string SmtpFromAddress {
            get => Properties.Settings.Default.SmtpFromAddress;
            set {
                Properties.Settings.Default.SmtpFromAddress = value.Trim();
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string SmtpDefaultRecipients {
            get => Properties.Settings.Default.SmtpDefaultRecipients;
            set {
                Properties.Settings.Default.SmtpDefaultRecipients = value.Trim();
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string SmtpHostName {
            get => Properties.Settings.Default.SmtpHostName;
            set {
                Properties.Settings.Default.SmtpHostName = value.Trim();
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public ushort SmtpHostPort {
            get => Properties.Settings.Default.SmtpHostPort;
            set {
                Properties.Settings.Default.SmtpHostPort = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string SmtpUsername {
            get => Security.Decrypt(Properties.Settings.Default.SmtpUsername);
            set {
                Properties.Settings.Default.SmtpUsername = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string SmtpPassword {
            get => Security.Decrypt(Properties.Settings.Default.SmtpPassword);
            set {
                Properties.Settings.Default.SmtpPassword = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string EmailFailureSubjectText {
            get => Properties.Settings.Default.EmailFailureSubjectText;
            set {
                Properties.Settings.Default.EmailFailureSubjectText = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string EmailFailureBodyText {
            get => Properties.Settings.Default.EmailFailureBodyText;
            set {
                Properties.Settings.Default.EmailFailureBodyText = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string TelegramAccessToken {
            get => Security.Decrypt(Properties.Settings.Default.TelegramAccessToken);
            set {
                Properties.Settings.Default.TelegramAccessToken = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string TelegramChatId {
            get => Security.Decrypt(Properties.Settings.Default.TelegramChatId);
            set {
                Properties.Settings.Default.TelegramChatId = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string TelegramFailureBodyText {
            get => Properties.Settings.Default.TelegramFailureBodyText;
            set {
                Properties.Settings.Default.TelegramFailureBodyText = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string MqttBrokerHost {
            get => Properties.Settings.Default.MqttBrokerHost;
            set {
                Properties.Settings.Default.MqttBrokerHost = value.Trim();
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public ushort MqttBrokerPort {
            get => Properties.Settings.Default.MqttBrokerPort;
            set {
                Properties.Settings.Default.MqttBrokerPort = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public int MqttDefaultQoSLevel {
            get => Properties.Settings.Default.MqttDefaultQoSLevel;
            set {
                Properties.Settings.Default.MqttDefaultQoSLevel = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public int MqttDefaultFailureQoSLevel {
            get => Properties.Settings.Default.MqttDefaultFailureQoSLevel;
            set {
                Properties.Settings.Default.MqttDefaultFailureQoSLevel = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string MqttDefaultTopic {
            get => Properties.Settings.Default.MqttDefaultTopic;
            set {
                Properties.Settings.Default.MqttDefaultTopic = value.Trim();
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string MqttClientId {
            get => Properties.Settings.Default.MqttClientId;
            set {
                Properties.Settings.Default.MqttClientId = value.Trim();
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public bool MqttBrokerUseTls {
            get => Properties.Settings.Default.MqttBrokerUseTls;
            set {
                Properties.Settings.Default.MqttBrokerUseTls = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);

                MqttBrokerPort = value ? (ushort)8883 : (ushort)1883;

                RaisePropertyChanged();
            }
        }

        public string MqttUsername {
            get => Security.Decrypt(Properties.Settings.Default.MqttUsername);
            set {
                Properties.Settings.Default.MqttUsername = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string MqttPassword {
            get => Security.Decrypt(Properties.Settings.Default.MqttPassword);
            set {
                Properties.Settings.Default.MqttPassword = Security.Encrypt(value.Trim());
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public int MqttMaxReconnectAttempts {
            get => Properties.Settings.Default.MqttMaxReconnectAttempts;
            set {
                Properties.Settings.Default.MqttMaxReconnectAttempts = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public bool MqttLwtEnable {
            get => Properties.Settings.Default.MqttLwtEnable;
            set {
                Properties.Settings.Default.MqttLwtEnable = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();

                if (!mqttClient.IsConnected && value == true) {
                    LwtStartWorker();
                } else if (mqttClient.IsConnected && value == false) {
                    LwtStopWorker();
                }
            }
        }

        public string MqttLwtTopic {
            get {
                if (string.IsNullOrEmpty(Properties.Settings.Default.MqttLwtTopic)) {
                    Properties.Settings.Default.MqttLwtTopic = Properties.Settings.Default.MqttDefaultTopic;
                }

                return Properties.Settings.Default.MqttLwtTopic;
            }
            set {
                Properties.Settings.Default.MqttLwtTopic = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string MqttLwtBirthPayload {
            get => Properties.Settings.Default.MqttLwtBirthPayload;
            set {
                Properties.Settings.Default.MqttLwtBirthPayload = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string MqttLwtLastWillPayload {
            get => Properties.Settings.Default.MqttLwtLastWillPayload;
            set {
                Properties.Settings.Default.MqttLwtLastWillPayload = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public string MqttLwtClosePayload {
            get => Properties.Settings.Default.MqttLwtClosePayload;
            set {
                Properties.Settings.Default.MqttLwtClosePayload = value;
                CoreUtil.SaveSettings(Properties.Settings.Default);
                RaisePropertyChanged();
            }
        }

        public IList<string> QoSLevels => MqttCommon.QoSLevels;

        public string TokenDate => DateTime.Now.ToString("d");
        public string TokenTime => DateTime.Now.ToString("T");
        public string TokenDateTime => DateTime.Now.ToString("G");
        public string TokenDateUtc => DateTime.UtcNow.ToString("d");
        public string TokenTimeUtc => DateTime.UtcNow.ToString("T");
        public string TokenDateTimeUtc => DateTime.UtcNow.ToString("G");
        public string TokenUnixEpoch => Utilities.Utilities.UnixEpoch().ToString();

        public void SetSmtpPassword(SecureString s) {
            SmtpPassword = SecureStringToString(s);
        }

        public void SetMqttPassword(SecureString s) {
            MqttPassword = SecureStringToString(s);
        }

        private string SecureStringToString(SecureString value) {
            IntPtr valuePtr = IntPtr.Zero;
            try {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            } finally {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        public static string GetVersion() {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}