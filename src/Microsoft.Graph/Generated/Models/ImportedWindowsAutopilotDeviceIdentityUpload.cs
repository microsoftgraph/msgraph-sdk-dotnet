using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ImportedWindowsAutopilotDeviceIdentityUpload : Entity, IParsable {
        /// <summary>DateTime when the entity is created.</summary>
        public DateTimeOffset? CreatedDateTimeUtc {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTimeUtc"); }
            set { BackingStore?.Set("createdDateTimeUtc", value); }
        }
        /// <summary>Collection of all Autopilot devices as a part of this upload.</summary>
        public List<ImportedWindowsAutopilotDeviceIdentity> DeviceIdentities {
            get { return BackingStore?.Get<List<ImportedWindowsAutopilotDeviceIdentity>>("deviceIdentities"); }
            set { BackingStore?.Set("deviceIdentities", value); }
        }
        /// <summary>The status property</summary>
        public ImportedWindowsAutopilotDeviceIdentityUploadStatus? Status {
            get { return BackingStore?.Get<ImportedWindowsAutopilotDeviceIdentityUploadStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ImportedWindowsAutopilotDeviceIdentityUpload CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ImportedWindowsAutopilotDeviceIdentityUpload();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"createdDateTimeUtc", n => { CreatedDateTimeUtc = n.GetDateTimeOffsetValue(); } },
                {"deviceIdentities", n => { DeviceIdentities = n.GetCollectionOfObjectValues<ImportedWindowsAutopilotDeviceIdentity>(ImportedWindowsAutopilotDeviceIdentity.CreateFromDiscriminatorValue).ToList(); } },
                {"status", n => { Status = n.GetEnumValue<ImportedWindowsAutopilotDeviceIdentityUploadStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("createdDateTimeUtc", CreatedDateTimeUtc);
            writer.WriteCollectionOfObjectValues<ImportedWindowsAutopilotDeviceIdentity>("deviceIdentities", DeviceIdentities);
            writer.WriteEnumValue<ImportedWindowsAutopilotDeviceIdentityUploadStatus>("status", Status);
        }
    }
}
