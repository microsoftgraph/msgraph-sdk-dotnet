using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the cloudCommunications singleton.</summary>
    public class AudioRoutingGroup : Entity, IParsable {
        /// <summary>The receivers property</summary>
        public List<string> Receivers {
            get { return BackingStore?.Get<List<string>>("receivers"); }
            set { BackingStore?.Set("receivers", value); }
        }
        /// <summary>The routingMode property</summary>
        public Microsoft.Graph.Models.RoutingMode? RoutingMode {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RoutingMode?>("routingMode"); }
            set { BackingStore?.Set("routingMode", value); }
        }
        /// <summary>The sources property</summary>
        public List<string> Sources {
            get { return BackingStore?.Get<List<string>>("sources"); }
            set { BackingStore?.Set("sources", value); }
        }
        /// <summary>
        /// Instantiates a new audioRoutingGroup and sets the default values.
        /// </summary>
        public AudioRoutingGroup() : base() {
            OdataType = "#microsoft.graph.audioRoutingGroup";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AudioRoutingGroup CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AudioRoutingGroup();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"receivers", n => { Receivers = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"routingMode", n => { RoutingMode = n.GetEnumValue<RoutingMode>(); } },
                {"sources", n => { Sources = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfPrimitiveValues<string>("receivers", Receivers);
            writer.WriteEnumValue<RoutingMode>("routingMode", RoutingMode);
            writer.WriteCollectionOfPrimitiveValues<string>("sources", Sources);
        }
    }
}
