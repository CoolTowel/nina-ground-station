﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaleGhent.NINA.GroundStation.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UpgradeSettings {
            get {
                return ((bool)(this["UpgradeSettings"]));
            }
            set {
                this["UpgradeSettings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string IFTTTWebhookKey {
            get {
                return ((string)(this["IFTTTWebhookKey"]));
            }
            set {
                this["IFTTTWebhookKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PushoverAppKey {
            get {
                return ((string)(this["PushoverAppKey"]));
            }
            set {
                this["PushoverAppKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PushoverUserKey {
            get {
                return ((string)(this["PushoverUserKey"]));
            }
            set {
                this["PushoverUserKey"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SmtpHostName {
            get {
                return ((string)(this["SmtpHostName"]));
            }
            set {
                this["SmtpHostName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("587")]
        public ushort SmtpHostPort {
            get {
                return ((ushort)(this["SmtpHostPort"]));
            }
            set {
                this["SmtpHostPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SmtpUsername {
            get {
                return ((string)(this["SmtpUsername"]));
            }
            set {
                this["SmtpUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SmtpPassword {
            get {
                return ((string)(this["SmtpPassword"]));
            }
            set {
                this["SmtpPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SmtpFromAddress {
            get {
                return ((string)(this["SmtpFromAddress"]));
            }
            set {
                this["SmtpFromAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SmtpDefaultRecipients {
            get {
                return ((string)(this["SmtpDefaultRecipients"]));
            }
            set {
                this["SmtpDefaultRecipients"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TelegramAccessToken {
            get {
                return ((string)(this["TelegramAccessToken"]));
            }
            set {
                this["TelegramAccessToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TelegramChatId {
            get {
                return ((string)(this["TelegramChatId"]));
            }
            set {
                this["TelegramChatId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Pushover")]
        public global::PushoverClient.NotificationSound PushoverDefaultNotificationSound {
            get {
                return ((global::PushoverClient.NotificationSound)(this["PushoverDefaultNotificationSound"]));
            }
            set {
                this["PushoverDefaultNotificationSound"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Siren")]
        public global::PushoverClient.NotificationSound PushoverDefaultFailureSound {
            get {
                return ((global::PushoverClient.NotificationSound)(this["PushoverDefaultFailureSound"]));
            }
            set {
                this["PushoverDefaultFailureSound"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Normal")]
        public global::PushoverClient.Priority PushoverDefaultNotificationPriority {
            get {
                return ((global::PushoverClient.Priority)(this["PushoverDefaultNotificationPriority"]));
            }
            set {
                this["PushoverDefaultNotificationPriority"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("High")]
        public global::PushoverClient.Priority PushoverDefaultFailurePriority {
            get {
                return ((global::PushoverClient.Priority)(this["PushoverDefaultFailurePriority"]));
            }
            set {
                this["PushoverDefaultFailurePriority"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttBrokerHost {
            get {
                return ((string)(this["MqttBrokerHost"]));
            }
            set {
                this["MqttBrokerHost"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1883")]
        public ushort MqttBrokerPort {
            get {
                return ((ushort)(this["MqttBrokerPort"]));
            }
            set {
                this["MqttBrokerPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttUsername {
            get {
                return ((string)(this["MqttUsername"]));
            }
            set {
                this["MqttUsername"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttPassword {
            get {
                return ((string)(this["MqttPassword"]));
            }
            set {
                this["MqttPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MqttBrokerUseTls {
            get {
                return ((bool)(this["MqttBrokerUseTls"]));
            }
            set {
                this["MqttBrokerUseTls"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttDefaultTopic {
            get {
                return ((string)(this["MqttDefaultTopic"]));
            }
            set {
                this["MqttDefaultTopic"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttClientId {
            get {
                return ((string)(this["MqttClientId"]));
            }
            set {
                this["MqttClientId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Failure running $$FAILED_ITEM$$")]
        public string PushoverFailureTitleText {
            get {
                return ((string)(this["PushoverFailureTitleText"]));
            }
            set {
                this["PushoverFailureTitleText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$$FAILED_ITEM$$ failed after $$FAILED_ATTEMPTS$$ attempts!\r\n\r\nReasons: $$ERROR_LI" +
            "ST$$\r\n")]
        public string PushoverFailureBodyText {
            get {
                return ((string)(this["PushoverFailureBodyText"]));
            }
            set {
                this["PushoverFailureBodyText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$$FAILED_ITEM$$ failed after $$FAILED_ATTEMPTS$$ attempts!\r\n\r\nReasons: $$ERROR_LI" +
            "ST$$\r\n")]
        public string TelegramFailureBodyText {
            get {
                return ((string)(this["TelegramFailureBodyText"]));
            }
            set {
                this["TelegramFailureBodyText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$$FAILED_ITEM$$ failed after $$FAILED_ATTEMPTS$$ attempts!\r\n\r\nReasons: $$ERROR_LI" +
            "ST$$\r\n")]
        public string EmailFailureBodyText {
            get {
                return ((string)(this["EmailFailureBodyText"]));
            }
            set {
                this["EmailFailureBodyText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Failure running $$FAILED_ITEM$$")]
        public string EmailFailureSubjectText {
            get {
                return ((string)(this["EmailFailureSubjectText"]));
            }
            set {
                this["EmailFailureSubjectText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$$FAILED_ITEM$$")]
        public string IftttFailureValue1 {
            get {
                return ((string)(this["IftttFailureValue1"]));
            }
            set {
                this["IftttFailureValue1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$$ERROR_LIST$$")]
        public string IftttFailureValue2 {
            get {
                return ((string)(this["IftttFailureValue2"]));
            }
            set {
                this["IftttFailureValue2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$$DATETIME$$")]
        public string IftttFailureValue3 {
            get {
                return ((string)(this["IftttFailureValue3"]));
            }
            set {
                this["IftttFailureValue3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MqttDefaultFailureQoSLevel {
            get {
                return ((int)(this["MqttDefaultFailureQoSLevel"]));
            }
            set {
                this["MqttDefaultFailureQoSLevel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MqttDefaultQoSLevel {
            get {
                return ((int)(this["MqttDefaultQoSLevel"]));
            }
            set {
                this["MqttDefaultQoSLevel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MqttLwtEnable {
            get {
                return ((bool)(this["MqttLwtEnable"]));
            }
            set {
                this["MqttLwtEnable"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttLwtTopic {
            get {
                return ((string)(this["MqttLwtTopic"]));
            }
            set {
                this["MqttLwtTopic"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttLwtBirthPayload {
            get {
                return ((string)(this["MqttLwtBirthPayload"]));
            }
            set {
                this["MqttLwtBirthPayload"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttLwtLastWillPayload {
            get {
                return ((string)(this["MqttLwtLastWillPayload"]));
            }
            set {
                this["MqttLwtLastWillPayload"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MqttLwtClosePayload {
            get {
                return ((string)(this["MqttLwtClosePayload"]));
            }
            set {
                this["MqttLwtClosePayload"] = value;
            }
        }
    }
}
