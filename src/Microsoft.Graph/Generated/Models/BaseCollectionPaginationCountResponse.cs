using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class BaseCollectionPaginationCountResponse : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The OdataCount property</summary>
        public long? OdataCount {
            get { return BackingStore?.Get<long?>("@odata.count"); }
            set { BackingStore?.Set("@odata.count", value); }
        }
        /// <summary>The OdataNextLink property</summary>
        public string OdataNextLink {
            get { return BackingStore?.Get<string>("@odata.nextLink"); }
            set { BackingStore?.Set("@odata.nextLink", value); }
        }
        /// <summary>
        /// Instantiates a new BaseCollectionPaginationCountResponse and sets the default values.
        /// </summary>
        public BaseCollectionPaginationCountResponse() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static BaseCollectionPaginationCountResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BaseCollectionPaginationCountResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"@odata.count", n => { OdataCount = n.GetLongValue(); } },
                {"@odata.nextLink", n => { OdataNextLink = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteLongValue("@odata.count", OdataCount);
            writer.WriteStringValue("@odata.nextLink", OdataNextLink);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
