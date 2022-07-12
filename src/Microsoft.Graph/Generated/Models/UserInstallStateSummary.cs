using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties for the installation state summary for a user.</summary>
    public class UserInstallStateSummary : Entity, IParsable {
        /// <summary>The install state of the eBook.</summary>
        public List<DeviceInstallState> DeviceStates {
            get { return BackingStore?.Get<List<DeviceInstallState>>("deviceStates"); }
            set { BackingStore?.Set("deviceStates", value); }
        }
        /// <summary>Failed Device Count.</summary>
        public int? FailedDeviceCount {
            get { return BackingStore?.Get<int?>("failedDeviceCount"); }
            set { BackingStore?.Set("failedDeviceCount", value); }
        }
        /// <summary>Installed Device Count.</summary>
        public int? InstalledDeviceCount {
            get { return BackingStore?.Get<int?>("installedDeviceCount"); }
            set { BackingStore?.Set("installedDeviceCount", value); }
        }
        /// <summary>Not installed device count.</summary>
        public int? NotInstalledDeviceCount {
            get { return BackingStore?.Get<int?>("notInstalledDeviceCount"); }
            set { BackingStore?.Set("notInstalledDeviceCount", value); }
        }
        /// <summary>User name.</summary>
        public string UserName {
            get { return BackingStore?.Get<string>("userName"); }
            set { BackingStore?.Set("userName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UserInstallStateSummary CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UserInstallStateSummary();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deviceStates", n => { DeviceStates = n.GetCollectionOfObjectValues<DeviceInstallState>(DeviceInstallState.CreateFromDiscriminatorValue).ToList(); } },
                {"failedDeviceCount", n => { FailedDeviceCount = n.GetIntValue(); } },
                {"installedDeviceCount", n => { InstalledDeviceCount = n.GetIntValue(); } },
                {"notInstalledDeviceCount", n => { NotInstalledDeviceCount = n.GetIntValue(); } },
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
            writer.WriteCollectionOfObjectValues<DeviceInstallState>("deviceStates", DeviceStates);
            writer.WriteIntValue("failedDeviceCount", FailedDeviceCount);
            writer.WriteIntValue("installedDeviceCount", InstalledDeviceCount);
            writer.WriteIntValue("notInstalledDeviceCount", NotInstalledDeviceCount);
            writer.WriteStringValue("userName", UserName);
        }
    }
}
