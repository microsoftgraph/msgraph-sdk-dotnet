using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>A managed or unmanaged app that is installed on a managed device. Unmanaged apps will only appear for devices marked as corporate owned.</summary>
    public class DetectedApp : Entity, IParsable {
        /// <summary>The number of devices that have installed this application</summary>
        public int? DeviceCount {
            get { return BackingStore?.Get<int?>("deviceCount"); }
            set { BackingStore?.Set("deviceCount", value); }
        }
        /// <summary>Name of the discovered application. Read-only</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The devices that have the discovered application installed</summary>
        public List<ManagedDevice> ManagedDevices {
            get { return BackingStore?.Get<List<ManagedDevice>>("managedDevices"); }
            set { BackingStore?.Set("managedDevices", value); }
        }
        /// <summary>Discovered application size in bytes. Read-only</summary>
        public long? SizeInByte {
            get { return BackingStore?.Get<long?>("sizeInByte"); }
            set { BackingStore?.Set("sizeInByte", value); }
        }
        /// <summary>Version of the discovered application. Read-only</summary>
        public string Version {
            get { return BackingStore?.Get<string>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DetectedApp CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DetectedApp();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deviceCount", n => { DeviceCount = n.GetIntValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"managedDevices", n => { ManagedDevices = n.GetCollectionOfObjectValues<ManagedDevice>(ManagedDevice.CreateFromDiscriminatorValue).ToList(); } },
                {"sizeInByte", n => { SizeInByte = n.GetLongValue(); } },
                {"version", n => { Version = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteIntValue("deviceCount", DeviceCount);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<ManagedDevice>("managedDevices", ManagedDevices);
            writer.WriteLongValue("sizeInByte", SizeInByte);
            writer.WriteStringValue("version", Version);
        }
    }
}
