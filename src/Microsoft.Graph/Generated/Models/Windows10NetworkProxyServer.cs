using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Network Proxy Server Policy.</summary>
    public class Windows10NetworkProxyServer : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Address to the proxy server. Specify an address in the format [&apos;:&apos;]</summary>
        public string Address {
            get { return BackingStore?.Get<string>("address"); }
            set { BackingStore?.Set("address", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Addresses that should not use the proxy server. The system will not use the proxy server for addresses beginning with what is specified in this node.</summary>
        public List<string> Exceptions {
            get { return BackingStore?.Get<List<string>>("exceptions"); }
            set { BackingStore?.Set("exceptions", value); }
        }
        /// <summary>Specifies whether the proxy server should be used for local (intranet) addresses.</summary>
        public bool? UseForLocalAddresses {
            get { return BackingStore?.Get<bool?>("useForLocalAddresses"); }
            set { BackingStore?.Set("useForLocalAddresses", value); }
        }
        /// <summary>
        /// Instantiates a new windows10NetworkProxyServer and sets the default values.
        /// </summary>
        public Windows10NetworkProxyServer() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Windows10NetworkProxyServer CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Windows10NetworkProxyServer();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"address", n => { Address = n.GetStringValue(); } },
                {"exceptions", n => { Exceptions = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"useForLocalAddresses", n => { UseForLocalAddresses = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("address", Address);
            writer.WriteCollectionOfPrimitiveValues<string>("exceptions", Exceptions);
            writer.WriteBoolValue("useForLocalAddresses", UseForLocalAddresses);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
