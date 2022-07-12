using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ApplicationServicePrincipal : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The application property</summary>
        public Microsoft.Graph.Models.Application Application {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Application>("application"); }
            set { BackingStore?.Set("application", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The servicePrincipal property</summary>
        public Microsoft.Graph.Models.ServicePrincipal ServicePrincipal {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ServicePrincipal>("servicePrincipal"); }
            set { BackingStore?.Set("servicePrincipal", value); }
        }
        /// <summary>
        /// Instantiates a new applicationServicePrincipal and sets the default values.
        /// </summary>
        public ApplicationServicePrincipal() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ApplicationServicePrincipal CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ApplicationServicePrincipal();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"application", n => { Application = n.GetObjectValue<Microsoft.Graph.Models.Application>(Microsoft.Graph.Models.Application.CreateFromDiscriminatorValue); } },
                {"servicePrincipal", n => { ServicePrincipal = n.GetObjectValue<Microsoft.Graph.Models.ServicePrincipal>(Microsoft.Graph.Models.ServicePrincipal.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Microsoft.Graph.Models.Application>("application", Application);
            writer.WriteObjectValue<Microsoft.Graph.Models.ServicePrincipal>("servicePrincipal", ServicePrincipal);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
