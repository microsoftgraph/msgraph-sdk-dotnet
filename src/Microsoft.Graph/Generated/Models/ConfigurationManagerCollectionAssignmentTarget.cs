using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class ConfigurationManagerCollectionAssignmentTarget : DeviceAndAppManagementAssignmentTarget, IParsable {
        /// <summary>The collection Id that is the target of the assignment.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CollectionId {
            get { return BackingStore?.Get<string?>("collectionId"); }
            set { BackingStore?.Set("collectionId", value); }
        }
#nullable restore
#else
        public string CollectionId {
            get { return BackingStore?.Get<string>("collectionId"); }
            set { BackingStore?.Set("collectionId", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new ConfigurationManagerCollectionAssignmentTarget and sets the default values.
        /// </summary>
        public ConfigurationManagerCollectionAssignmentTarget() : base() {
            OdataType = "#microsoft.graph.configurationManagerCollectionAssignmentTarget";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ConfigurationManagerCollectionAssignmentTarget CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConfigurationManagerCollectionAssignmentTarget();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"collectionId", n => { CollectionId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("collectionId", CollectionId);
        }
    }
}
