using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class DeviceConfigurationUserStatus : Entity, IParsable {
        /// <summary>Devices count for that user.</summary>
        public int? DevicesCount {
            get { return BackingStore?.Get<int?>("devicesCount"); }
            set { BackingStore?.Set("devicesCount", value); }
        }
        /// <summary>Last modified date time of the policy report.</summary>
        public DateTimeOffset? LastReportedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastReportedDateTime"); }
            set { BackingStore?.Set("lastReportedDateTime", value); }
        }
        /// <summary>The status property</summary>
        public ComplianceStatus? Status {
            get { return BackingStore?.Get<ComplianceStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>User name of the DevicePolicyStatus.</summary>
        public string UserDisplayName {
            get { return BackingStore?.Get<string>("userDisplayName"); }
            set { BackingStore?.Set("userDisplayName", value); }
        }
        /// <summary>UserPrincipalName.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceConfigurationUserStatus CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceConfigurationUserStatus();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"devicesCount", n => { DevicesCount = n.GetIntValue(); } },
                {"lastReportedDateTime", n => { LastReportedDateTime = n.GetDateTimeOffsetValue(); } },
                {"status", n => { Status = n.GetEnumValue<ComplianceStatus>(); } },
                {"userDisplayName", n => { UserDisplayName = n.GetStringValue(); } },
                {"userPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteIntValue("devicesCount", DevicesCount);
            writer.WriteDateTimeOffsetValue("lastReportedDateTime", LastReportedDateTime);
            writer.WriteEnumValue<ComplianceStatus>("status", Status);
            writer.WriteStringValue("userDisplayName", UserDisplayName);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
        }
    }
}
