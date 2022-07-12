using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Windows Information Protection AppLearning Summary entity.</summary>
    public class WindowsInformationProtectionAppLearningSummary : Entity, IParsable {
        /// <summary>Application Name</summary>
        public string ApplicationName {
            get { return BackingStore?.Get<string>("applicationName"); }
            set { BackingStore?.Set("applicationName", value); }
        }
        /// <summary>Possible types of Application</summary>
        public Microsoft.Graph.Models.ApplicationType? ApplicationType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ApplicationType?>("applicationType"); }
            set { BackingStore?.Set("applicationType", value); }
        }
        /// <summary>Device Count</summary>
        public int? DeviceCount {
            get { return BackingStore?.Get<int?>("deviceCount"); }
            set { BackingStore?.Set("deviceCount", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WindowsInformationProtectionAppLearningSummary CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WindowsInformationProtectionAppLearningSummary();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"applicationName", n => { ApplicationName = n.GetStringValue(); } },
                {"applicationType", n => { ApplicationType = n.GetEnumValue<ApplicationType>(); } },
                {"deviceCount", n => { DeviceCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("applicationName", ApplicationName);
            writer.WriteEnumValue<ApplicationType>("applicationType", ApplicationType);
            writer.WriteIntValue("deviceCount", DeviceCount);
        }
    }
}
