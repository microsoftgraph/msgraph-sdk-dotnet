using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties for the installation state for a device.</summary>
    public class DeviceInstallState : Entity, IParsable {
        /// <summary>Device Id.</summary>
        public string DeviceId {
            get { return BackingStore?.Get<string>("deviceId"); }
            set { BackingStore?.Set("deviceId", value); }
        }
        /// <summary>Device name.</summary>
        public string DeviceName {
            get { return BackingStore?.Get<string>("deviceName"); }
            set { BackingStore?.Set("deviceName", value); }
        }
        /// <summary>The error code for install failures.</summary>
        public string ErrorCode {
            get { return BackingStore?.Get<string>("errorCode"); }
            set { BackingStore?.Set("errorCode", value); }
        }
        /// <summary>Possible values for install state.</summary>
        public Microsoft.Graph.Models.InstallState? InstallState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.InstallState?>("installState"); }
            set { BackingStore?.Set("installState", value); }
        }
        /// <summary>Last sync date and time.</summary>
        public DateTimeOffset? LastSyncDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastSyncDateTime"); }
            set { BackingStore?.Set("lastSyncDateTime", value); }
        }
        /// <summary>OS Description.</summary>
        public string OsDescription {
            get { return BackingStore?.Get<string>("osDescription"); }
            set { BackingStore?.Set("osDescription", value); }
        }
        /// <summary>OS Version.</summary>
        public string OsVersion {
            get { return BackingStore?.Get<string>("osVersion"); }
            set { BackingStore?.Set("osVersion", value); }
        }
        /// <summary>Device User Name.</summary>
        public string UserName {
            get { return BackingStore?.Get<string>("userName"); }
            set { BackingStore?.Set("userName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceInstallState CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceInstallState();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deviceId", n => { DeviceId = n.GetStringValue(); } },
                {"deviceName", n => { DeviceName = n.GetStringValue(); } },
                {"errorCode", n => { ErrorCode = n.GetStringValue(); } },
                {"installState", n => { InstallState = n.GetEnumValue<InstallState>(); } },
                {"lastSyncDateTime", n => { LastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"osDescription", n => { OsDescription = n.GetStringValue(); } },
                {"osVersion", n => { OsVersion = n.GetStringValue(); } },
                {"userName", n => { UserName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("deviceId", DeviceId);
            writer.WriteStringValue("deviceName", DeviceName);
            writer.WriteStringValue("errorCode", ErrorCode);
            writer.WriteEnumValue<InstallState>("installState", InstallState);
            writer.WriteDateTimeOffsetValue("lastSyncDateTime", LastSyncDateTime);
            writer.WriteStringValue("osDescription", OsDescription);
            writer.WriteStringValue("osVersion", OsVersion);
            writer.WriteStringValue("userName", UserName);
        }
    }
}
