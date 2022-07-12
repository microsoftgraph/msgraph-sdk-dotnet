using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Windows81CompliancePolicy : DeviceCompliancePolicy, IParsable {
        /// <summary>Maximum Windows 8.1 version.</summary>
        public string OsMaximumVersion {
            get { return BackingStore?.Get<string>("osMaximumVersion"); }
            set { BackingStore?.Set("osMaximumVersion", value); }
        }
        /// <summary>Minimum Windows 8.1 version.</summary>
        public string OsMinimumVersion {
            get { return BackingStore?.Get<string>("osMinimumVersion"); }
            set { BackingStore?.Set("osMinimumVersion", value); }
        }
        /// <summary>Indicates whether or not to block simple password.</summary>
        public bool? PasswordBlockSimple {
            get { return BackingStore?.Get<bool?>("passwordBlockSimple"); }
            set { BackingStore?.Set("passwordBlockSimple", value); }
        }
        /// <summary>Password expiration in days.</summary>
        public int? PasswordExpirationDays {
            get { return BackingStore?.Get<int?>("passwordExpirationDays"); }
            set { BackingStore?.Set("passwordExpirationDays", value); }
        }
        /// <summary>The number of character sets required in the password.</summary>
        public int? PasswordMinimumCharacterSetCount {
            get { return BackingStore?.Get<int?>("passwordMinimumCharacterSetCount"); }
            set { BackingStore?.Set("passwordMinimumCharacterSetCount", value); }
        }
        /// <summary>The minimum password length.</summary>
        public int? PasswordMinimumLength {
            get { return BackingStore?.Get<int?>("passwordMinimumLength"); }
            set { BackingStore?.Set("passwordMinimumLength", value); }
        }
        /// <summary>Minutes of inactivity before a password is required.</summary>
        public int? PasswordMinutesOfInactivityBeforeLock {
            get { return BackingStore?.Get<int?>("passwordMinutesOfInactivityBeforeLock"); }
            set { BackingStore?.Set("passwordMinutesOfInactivityBeforeLock", value); }
        }
        /// <summary>The number of previous passwords to prevent re-use of. Valid values 0 to 24</summary>
        public int? PasswordPreviousPasswordBlockCount {
            get { return BackingStore?.Get<int?>("passwordPreviousPasswordBlockCount"); }
            set { BackingStore?.Set("passwordPreviousPasswordBlockCount", value); }
        }
        /// <summary>Require a password to unlock Windows device.</summary>
        public bool? PasswordRequired {
            get { return BackingStore?.Get<bool?>("passwordRequired"); }
            set { BackingStore?.Set("passwordRequired", value); }
        }
        /// <summary>Possible values of required passwords.</summary>
        public RequiredPasswordType? PasswordRequiredType {
            get { return BackingStore?.Get<RequiredPasswordType?>("passwordRequiredType"); }
            set { BackingStore?.Set("passwordRequiredType", value); }
        }
        /// <summary>Indicates whether or not to require encryption on a windows 8.1 device.</summary>
        public bool? StorageRequireEncryption {
            get { return BackingStore?.Get<bool?>("storageRequireEncryption"); }
            set { BackingStore?.Set("storageRequireEncryption", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Windows81CompliancePolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Windows81CompliancePolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"osMaximumVersion", n => { OsMaximumVersion = n.GetStringValue(); } },
                {"osMinimumVersion", n => { OsMinimumVersion = n.GetStringValue(); } },
                {"passwordBlockSimple", n => { PasswordBlockSimple = n.GetBoolValue(); } },
                {"passwordExpirationDays", n => { PasswordExpirationDays = n.GetIntValue(); } },
                {"passwordMinimumCharacterSetCount", n => { PasswordMinimumCharacterSetCount = n.GetIntValue(); } },
                {"passwordMinimumLength", n => { PasswordMinimumLength = n.GetIntValue(); } },
                {"passwordMinutesOfInactivityBeforeLock", n => { PasswordMinutesOfInactivityBeforeLock = n.GetIntValue(); } },
                {"passwordPreviousPasswordBlockCount", n => { PasswordPreviousPasswordBlockCount = n.GetIntValue(); } },
                {"passwordRequired", n => { PasswordRequired = n.GetBoolValue(); } },
                {"passwordRequiredType", n => { PasswordRequiredType = n.GetEnumValue<RequiredPasswordType>(); } },
                {"storageRequireEncryption", n => { StorageRequireEncryption = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("osMaximumVersion", OsMaximumVersion);
            writer.WriteStringValue("osMinimumVersion", OsMinimumVersion);
            writer.WriteBoolValue("passwordBlockSimple", PasswordBlockSimple);
            writer.WriteIntValue("passwordExpirationDays", PasswordExpirationDays);
            writer.WriteIntValue("passwordMinimumCharacterSetCount", PasswordMinimumCharacterSetCount);
            writer.WriteIntValue("passwordMinimumLength", PasswordMinimumLength);
            writer.WriteIntValue("passwordMinutesOfInactivityBeforeLock", PasswordMinutesOfInactivityBeforeLock);
            writer.WriteIntValue("passwordPreviousPasswordBlockCount", PasswordPreviousPasswordBlockCount);
            writer.WriteBoolValue("passwordRequired", PasswordRequired);
            writer.WriteEnumValue<RequiredPasswordType>("passwordRequiredType", PasswordRequiredType);
            writer.WriteBoolValue("storageRequireEncryption", StorageRequireEncryption);
        }
    }
}
