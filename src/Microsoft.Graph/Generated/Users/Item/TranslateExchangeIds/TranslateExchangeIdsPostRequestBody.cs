using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Users.Item.TranslateExchangeIds {
    /// <summary>Provides operations to call the translateExchangeIds method.</summary>
    public class TranslateExchangeIdsPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The InputIds property</summary>
        public List<string> InputIds {
            get { return BackingStore?.Get<List<string>>("inputIds"); }
            set { BackingStore?.Set("inputIds", value); }
        }
        /// <summary>The SourceIdType property</summary>
        public ExchangeIdFormat? SourceIdType {
            get { return BackingStore?.Get<ExchangeIdFormat?>("sourceIdType"); }
            set { BackingStore?.Set("sourceIdType", value); }
        }
        /// <summary>The TargetIdType property</summary>
        public ExchangeIdFormat? TargetIdType {
            get { return BackingStore?.Get<ExchangeIdFormat?>("targetIdType"); }
            set { BackingStore?.Set("targetIdType", value); }
        }
        /// <summary>
        /// Instantiates a new translateExchangeIdsPostRequestBody and sets the default values.
        /// </summary>
        public TranslateExchangeIdsPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TranslateExchangeIdsPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TranslateExchangeIdsPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"inputIds", n => { InputIds = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"sourceIdType", n => { SourceIdType = n.GetEnumValue<ExchangeIdFormat>(); } },
                {"targetIdType", n => { TargetIdType = n.GetEnumValue<ExchangeIdFormat>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("inputIds", InputIds);
            writer.WriteEnumValue<ExchangeIdFormat>("sourceIdType", SourceIdType);
            writer.WriteEnumValue<ExchangeIdFormat>("targetIdType", TargetIdType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
