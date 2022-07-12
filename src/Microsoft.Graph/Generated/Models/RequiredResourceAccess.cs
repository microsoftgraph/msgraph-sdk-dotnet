using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RequiredResourceAccess : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.</summary>
        public List<Microsoft.Graph.Models.ResourceAccess> ResourceAccess {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ResourceAccess>>("resourceAccess"); }
            set { BackingStore?.Set("resourceAccess", value); }
        }
        /// <summary>The unique identifier for the resource that the application requires access to. This should be equal to the appId declared on the target resource application.</summary>
        public string ResourceAppId {
            get { return BackingStore?.Get<string>("resourceAppId"); }
            set { BackingStore?.Set("resourceAppId", value); }
        }
        /// <summary>
        /// Instantiates a new requiredResourceAccess and sets the default values.
        /// </summary>
        public RequiredResourceAccess() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static RequiredResourceAccess CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RequiredResourceAccess();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"resourceAccess", n => { ResourceAccess = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ResourceAccess>(Microsoft.Graph.Models.ResourceAccess.CreateFromDiscriminatorValue).ToList(); } },
                {"resourceAppId", n => { ResourceAppId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ResourceAccess>("resourceAccess", ResourceAccess);
            writer.WriteStringValue("resourceAppId", ResourceAppId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
