using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class MailboxSettings : IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Folder ID of an archive folder for the user.</summary>
        public string ArchiveFolder { get; set; }
        /// <summary>Configuration settings to automatically notify the sender of an incoming email with a message from the signed-in user.</summary>
        public AutomaticRepliesSetting AutomaticRepliesSetting { get; set; }
        /// <summary>The date format for the user's mailbox.</summary>
        public string DateFormat { get; set; }
        /// <summary>If the user has a calendar delegate, this specifies whether the delegate, mailbox owner, or both receive meeting messages and meeting responses. Possible values are: sendToDelegateAndInformationToPrincipal, sendToDelegateAndPrincipal, sendToDelegateOnly.</summary>
        public DelegateMeetingMessageDeliveryOptions? DelegateMeetingMessageDeliveryOptions { get; set; }
        /// <summary>The locale information for the user, including the preferred language and country/region.</summary>
        public LocaleInfo Language { get; set; }
        /// <summary>The time format for the user's mailbox.</summary>
        public string TimeFormat { get; set; }
        /// <summary>The default time zone for the user's mailbox.</summary>
        public string TimeZone { get; set; }
        /// <summary>The purpose of the mailbox. Used to differentiate a mailbox for a single user from a shared mailbox and equipment mailbox in Exchange Online. Read only.</summary>
        public UserPurpose? UserPurpose { get; set; }
        /// <summary>The days of the week and hours in a specific time zone that the user works.</summary>
        public WorkingHours WorkingHours { get; set; }
        /// <summary>
        /// Instantiates a new mailboxSettings and sets the default values.
        /// </summary>
        public MailboxSettings() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"archiveFolder", (o,n) => { (o as MailboxSettings).ArchiveFolder = n.GetStringValue(); } },
                {"automaticRepliesSetting", (o,n) => { (o as MailboxSettings).AutomaticRepliesSetting = n.GetObjectValue<AutomaticRepliesSetting>(); } },
                {"dateFormat", (o,n) => { (o as MailboxSettings).DateFormat = n.GetStringValue(); } },
                {"delegateMeetingMessageDeliveryOptions", (o,n) => { (o as MailboxSettings).DelegateMeetingMessageDeliveryOptions = n.GetEnumValue<DelegateMeetingMessageDeliveryOptions>(); } },
                {"language", (o,n) => { (o as MailboxSettings).Language = n.GetObjectValue<LocaleInfo>(); } },
                {"timeFormat", (o,n) => { (o as MailboxSettings).TimeFormat = n.GetStringValue(); } },
                {"timeZone", (o,n) => { (o as MailboxSettings).TimeZone = n.GetStringValue(); } },
                {"userPurpose", (o,n) => { (o as MailboxSettings).UserPurpose = n.GetEnumValue<UserPurpose>(); } },
                {"workingHours", (o,n) => { (o as MailboxSettings).WorkingHours = n.GetObjectValue<WorkingHours>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("archiveFolder", ArchiveFolder);
            writer.WriteObjectValue<AutomaticRepliesSetting>("automaticRepliesSetting", AutomaticRepliesSetting);
            writer.WriteStringValue("dateFormat", DateFormat);
            writer.WriteEnumValue<DelegateMeetingMessageDeliveryOptions>("delegateMeetingMessageDeliveryOptions", DelegateMeetingMessageDeliveryOptions);
            writer.WriteObjectValue<LocaleInfo>("language", Language);
            writer.WriteStringValue("timeFormat", TimeFormat);
            writer.WriteStringValue("timeZone", TimeZone);
            writer.WriteEnumValue<UserPurpose>("userPurpose", UserPurpose);
            writer.WriteObjectValue<WorkingHours>("workingHours", WorkingHours);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
