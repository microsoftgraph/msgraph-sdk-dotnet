using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ConditionalAccessClientApplications : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Service principal IDs excluded from the policy scope.</summary>
        public List<string> ExcludeServicePrincipals {
            get { return BackingStore?.Get<List<string>>("excludeServicePrincipals"); }
            set { BackingStore?.Set("excludeServicePrincipals", value); }
        }
        /// <summary>Service principal IDs included in the policy scope, or ServicePrincipalsInMyTenant.</summary>
        public List<string> IncludeServicePrincipals {
            get { return BackingStore?.Get<List<string>>("includeServicePrincipals"); }
            set { BackingStore?.Set("includeServicePrincipals", value); }
        }
        /// <summary>
        /// Instantiates a new conditionalAccessClientApplications and sets the default values.
        /// </summary>
        public ConditionalAccessClientApplications() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ConditionalAccessClientApplications CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConditionalAccessClientApplications();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"excludeServicePrincipals", n => { ExcludeServicePrincipals = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"includeServicePrincipals", n => { IncludeServicePrincipals = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("excludeServicePrincipals", ExcludeServicePrincipals);
            writer.WriteCollectionOfPrimitiveValues<string>("includeServicePrincipals", IncludeServicePrincipals);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
