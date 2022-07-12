using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.IdentityGovernance.AccessReviews.Definitions.Item.Instances.Item.BatchRecordDecisions {
    /// <summary>Provides operations to call the batchRecordDecisions method.</summary>
    public class BatchRecordDecisionsPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The decision property</summary>
        public string Decision {
            get { return BackingStore?.Get<string>("decision"); }
            set { BackingStore?.Set("decision", value); }
        }
        /// <summary>The justification property</summary>
        public string Justification {
            get { return BackingStore?.Get<string>("justification"); }
            set { BackingStore?.Set("justification", value); }
        }
        /// <summary>The principalId property</summary>
        public string PrincipalId {
            get { return BackingStore?.Get<string>("principalId"); }
            set { BackingStore?.Set("principalId", value); }
        }
        /// <summary>The resourceId property</summary>
        public string ResourceId {
            get { return BackingStore?.Get<string>("resourceId"); }
            set { BackingStore?.Set("resourceId", value); }
        }
        /// <summary>
        /// Instantiates a new batchRecordDecisionsPostRequestBody and sets the default values.
        /// </summary>
        public BatchRecordDecisionsPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static BatchRecordDecisionsPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BatchRecordDecisionsPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"decision", n => { Decision = n.GetStringValue(); } },
                {"justification", n => { Justification = n.GetStringValue(); } },
                {"principalId", n => { PrincipalId = n.GetStringValue(); } },
                {"resourceId", n => { ResourceId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("decision", Decision);
            writer.WriteStringValue("justification", Justification);
            writer.WriteStringValue("principalId", PrincipalId);
            writer.WriteStringValue("resourceId", ResourceId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
