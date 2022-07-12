using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.DirectoryRoleTemplates.GetByIds {
    /// <summary>Provides operations to call the getByIds method.</summary>
    public class GetByIdsPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The ids property</summary>
        public List<string> Ids {
            get { return BackingStore?.Get<List<string>>("ids"); }
            set { BackingStore?.Set("ids", value); }
        }
        /// <summary>The types property</summary>
        public List<string> Types {
            get { return BackingStore?.Get<List<string>>("types"); }
            set { BackingStore?.Set("types", value); }
        }
        /// <summary>
        /// Instantiates a new getByIdsPostRequestBody and sets the default values.
        /// </summary>
        public GetByIdsPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static GetByIdsPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GetByIdsPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"ids", n => { Ids = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"types", n => { Types = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("ids", Ids);
            writer.WriteCollectionOfPrimitiveValues<string>("types", Types);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
