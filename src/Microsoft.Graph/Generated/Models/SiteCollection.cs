using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SiteCollection : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The geographic region code for where this site collection resides. Read-only.</summary>
        public string DataLocationCode {
            get { return BackingStore?.Get<string>("dataLocationCode"); }
            set { BackingStore?.Set("dataLocationCode", value); }
        }
        /// <summary>The hostname for the site collection. Read-only.</summary>
        public string Hostname {
            get { return BackingStore?.Get<string>("hostname"); }
            set { BackingStore?.Set("hostname", value); }
        }
        /// <summary>If present, indicates that this is a root site collection in SharePoint. Read-only.</summary>
        public Microsoft.Graph.Models.Root Root {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Root>("root"); }
            set { BackingStore?.Set("root", value); }
        }
        /// <summary>
        /// Instantiates a new siteCollection and sets the default values.
        /// </summary>
        public SiteCollection() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SiteCollection CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SiteCollection();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"dataLocationCode", n => { DataLocationCode = n.GetStringValue(); } },
                {"hostname", n => { Hostname = n.GetStringValue(); } },
                {"root", n => { Root = n.GetObjectValue<Microsoft.Graph.Models.Root>(Microsoft.Graph.Models.Root.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("dataLocationCode", DataLocationCode);
            writer.WriteStringValue("hostname", Hostname);
            writer.WriteObjectValue<Microsoft.Graph.Models.Root>("root", Root);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
