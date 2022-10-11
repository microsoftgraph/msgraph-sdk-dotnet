using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class SharedInsight : Entity, IParsable {
        /// <summary>Details about the shared item. Read only.</summary>
        public SharingDetail LastShared {
            get { return BackingStore?.Get<SharingDetail>("lastShared"); }
            set { BackingStore?.Set("lastShared", value); }
        }
        /// <summary>The lastSharedMethod property</summary>
        public Entity LastSharedMethod {
            get { return BackingStore?.Get<Entity>("lastSharedMethod"); }
            set { BackingStore?.Set("lastSharedMethod", value); }
        }
        /// <summary>Used for navigating to the item that was shared. For file attachments, the type is fileAttachment. For linked attachments, the type is driveItem.</summary>
        public Entity Resource {
            get { return BackingStore?.Get<Entity>("resource"); }
            set { BackingStore?.Set("resource", value); }
        }
        /// <summary>Reference properties of the shared document, such as the url and type of the document. Read-only</summary>
        public Microsoft.Graph.Models.ResourceReference ResourceReference {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ResourceReference>("resourceReference"); }
            set { BackingStore?.Set("resourceReference", value); }
        }
        /// <summary>Properties that you can use to visualize the document in your experience. Read-only</summary>
        public Microsoft.Graph.Models.ResourceVisualization ResourceVisualization {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ResourceVisualization>("resourceVisualization"); }
            set { BackingStore?.Set("resourceVisualization", value); }
        }
        /// <summary>The sharingHistory property</summary>
        public List<SharingDetail> SharingHistory {
            get { return BackingStore?.Get<List<SharingDetail>>("sharingHistory"); }
            set { BackingStore?.Set("sharingHistory", value); }
        }
        /// <summary>
        /// Instantiates a new sharedInsight and sets the default values.
        /// </summary>
        public SharedInsight() : base() {
            OdataType = "#microsoft.graph.sharedInsight";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SharedInsight CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SharedInsight();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"lastShared", n => { LastShared = n.GetObjectValue<SharingDetail>(SharingDetail.CreateFromDiscriminatorValue); } },
                {"lastSharedMethod", n => { LastSharedMethod = n.GetObjectValue<Entity>(Entity.CreateFromDiscriminatorValue); } },
                {"resource", n => { Resource = n.GetObjectValue<Entity>(Entity.CreateFromDiscriminatorValue); } },
                {"resourceReference", n => { ResourceReference = n.GetObjectValue<Microsoft.Graph.Models.ResourceReference>(Microsoft.Graph.Models.ResourceReference.CreateFromDiscriminatorValue); } },
                {"resourceVisualization", n => { ResourceVisualization = n.GetObjectValue<Microsoft.Graph.Models.ResourceVisualization>(Microsoft.Graph.Models.ResourceVisualization.CreateFromDiscriminatorValue); } },
                {"sharingHistory", n => { SharingHistory = n.GetCollectionOfObjectValues<SharingDetail>(SharingDetail.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<SharingDetail>("lastShared", LastShared);
            writer.WriteObjectValue<Entity>("lastSharedMethod", LastSharedMethod);
            writer.WriteObjectValue<Entity>("resource", Resource);
            writer.WriteCollectionOfObjectValues<SharingDetail>("sharingHistory", SharingHistory);
        }
    }
}
