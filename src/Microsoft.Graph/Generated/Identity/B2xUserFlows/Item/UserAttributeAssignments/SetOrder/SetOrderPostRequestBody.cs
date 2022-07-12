using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Identity.B2xUserFlows.Item.UserAttributeAssignments.SetOrder {
    /// <summary>Provides operations to call the setOrder method.</summary>
    public class SetOrderPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The newAssignmentOrder property</summary>
        public AssignmentOrder NewAssignmentOrder {
            get { return BackingStore?.Get<AssignmentOrder>("newAssignmentOrder"); }
            set { BackingStore?.Set("newAssignmentOrder", value); }
        }
        /// <summary>
        /// Instantiates a new setOrderPostRequestBody and sets the default values.
        /// </summary>
        public SetOrderPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SetOrderPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SetOrderPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"newAssignmentOrder", n => { NewAssignmentOrder = n.GetObjectValue<AssignmentOrder>(AssignmentOrder.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AssignmentOrder>("newAssignmentOrder", NewAssignmentOrder);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
