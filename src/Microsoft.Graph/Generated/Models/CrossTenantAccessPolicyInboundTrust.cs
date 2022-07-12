using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CrossTenantAccessPolicyInboundTrust : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Specifies whether compliant devices from external Azure AD organizations are trusted.</summary>
        public bool? IsCompliantDeviceAccepted {
            get { return BackingStore?.Get<bool?>("isCompliantDeviceAccepted"); }
            set { BackingStore?.Set("isCompliantDeviceAccepted", value); }
        }
        /// <summary>Specifies whether hybrid Azure AD joined devices from external Azure AD organizations are trusted.</summary>
        public bool? IsHybridAzureADJoinedDeviceAccepted {
            get { return BackingStore?.Get<bool?>("isHybridAzureADJoinedDeviceAccepted"); }
            set { BackingStore?.Set("isHybridAzureADJoinedDeviceAccepted", value); }
        }
        /// <summary>Specifies whether MFA from external Azure AD organizations is trusted.</summary>
        public bool? IsMfaAccepted {
            get { return BackingStore?.Get<bool?>("isMfaAccepted"); }
            set { BackingStore?.Set("isMfaAccepted", value); }
        }
        /// <summary>
        /// Instantiates a new crossTenantAccessPolicyInboundTrust and sets the default values.
        /// </summary>
        public CrossTenantAccessPolicyInboundTrust() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CrossTenantAccessPolicyInboundTrust CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CrossTenantAccessPolicyInboundTrust();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"isCompliantDeviceAccepted", n => { IsCompliantDeviceAccepted = n.GetBoolValue(); } },
                {"isHybridAzureADJoinedDeviceAccepted", n => { IsHybridAzureADJoinedDeviceAccepted = n.GetBoolValue(); } },
                {"isMfaAccepted", n => { IsMfaAccepted = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("isCompliantDeviceAccepted", IsCompliantDeviceAccepted);
            writer.WriteBoolValue("isHybridAzureADJoinedDeviceAccepted", IsHybridAzureADJoinedDeviceAccepted);
            writer.WriteBoolValue("isMfaAccepted", IsMfaAccepted);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
