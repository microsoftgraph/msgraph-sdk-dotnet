using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CrossTenantAccessPolicyTarget : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The unique identifier of the user, group, or application; one of the following keywords: AllUsers and AllApplications; or for targets that are applications, you may use reserved values.</summary>
        public string Target {
            get { return BackingStore?.Get<string>("target"); }
            set { BackingStore?.Set("target", value); }
        }
        /// <summary>The type of resource that you want to target. The possible values are: user, group, application, unknownFutureValue.</summary>
        public CrossTenantAccessPolicyTargetType? TargetType {
            get { return BackingStore?.Get<CrossTenantAccessPolicyTargetType?>("targetType"); }
            set { BackingStore?.Set("targetType", value); }
        }
        /// <summary>
        /// Instantiates a new crossTenantAccessPolicyTarget and sets the default values.
        /// </summary>
        public CrossTenantAccessPolicyTarget() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CrossTenantAccessPolicyTarget CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CrossTenantAccessPolicyTarget();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"target", n => { Target = n.GetStringValue(); } },
                {"targetType", n => { TargetType = n.GetEnumValue<CrossTenantAccessPolicyTargetType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("target", Target);
            writer.WriteEnumValue<CrossTenantAccessPolicyTargetType>("targetType", TargetType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
