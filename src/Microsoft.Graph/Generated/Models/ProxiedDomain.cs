using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Proxied Domain</summary>
    public class ProxiedDomain : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The IP address or FQDN</summary>
        public string IpAddressOrFQDN {
            get { return BackingStore?.Get<string>("ipAddressOrFQDN"); }
            set { BackingStore?.Set("ipAddressOrFQDN", value); }
        }
        /// <summary>Proxy IP or FQDN</summary>
        public string Proxy {
            get { return BackingStore?.Get<string>("proxy"); }
            set { BackingStore?.Set("proxy", value); }
        }
        /// <summary>
        /// Instantiates a new proxiedDomain and sets the default values.
        /// </summary>
        public ProxiedDomain() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ProxiedDomain CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ProxiedDomain();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"ipAddressOrFQDN", n => { IpAddressOrFQDN = n.GetStringValue(); } },
                {"proxy", n => { Proxy = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("ipAddressOrFQDN", IpAddressOrFQDN);
            writer.WriteStringValue("proxy", Proxy);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
