using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class VerifiedDomain : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>For example, Email, OfficeCommunicationsOnline.</summary>
        public string Capabilities {
            get { return BackingStore?.Get<string>("capabilities"); }
            set { BackingStore?.Set("capabilities", value); }
        }
        /// <summary>true if this is the default domain associated with the tenant; otherwise, false.</summary>
        public bool? IsDefault {
            get { return BackingStore?.Get<bool?>("isDefault"); }
            set { BackingStore?.Set("isDefault", value); }
        }
        /// <summary>true if this is the initial domain associated with the tenant; otherwise, false.</summary>
        public bool? IsInitial {
            get { return BackingStore?.Get<bool?>("isInitial"); }
            set { BackingStore?.Set("isInitial", value); }
        }
        /// <summary>The domain name; for example, contoso.onmicrosoft.com.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>For example, Managed.</summary>
        public string Type {
            get { return BackingStore?.Get<string>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new verifiedDomain and sets the default values.
        /// </summary>
        public VerifiedDomain() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static VerifiedDomain CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new VerifiedDomain();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"capabilities", n => { Capabilities = n.GetStringValue(); } },
                {"isDefault", n => { IsDefault = n.GetBoolValue(); } },
                {"isInitial", n => { IsInitial = n.GetBoolValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"type", n => { Type = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("capabilities", Capabilities);
            writer.WriteBoolValue("isDefault", IsDefault);
            writer.WriteBoolValue("isInitial", IsInitial);
            writer.WriteStringValue("name", Name);
            writer.WriteStringValue("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
