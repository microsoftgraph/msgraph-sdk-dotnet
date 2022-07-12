using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WebApp : MobileApp, IParsable {
        /// <summary>The web app URL. This property cannot be PATCHed.</summary>
        public string AppUrl {
            get { return BackingStore?.Get<string>("appUrl"); }
            set { BackingStore?.Set("appUrl", value); }
        }
        /// <summary>Whether or not to use managed browser. This property is only applicable for Android and IOS.</summary>
        public bool? UseManagedBrowser {
            get { return BackingStore?.Get<bool?>("useManagedBrowser"); }
            set { BackingStore?.Set("useManagedBrowser", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WebApp CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WebApp();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appUrl", n => { AppUrl = n.GetStringValue(); } },
                {"useManagedBrowser", n => { UseManagedBrowser = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("appUrl", AppUrl);
            writer.WriteBoolValue("useManagedBrowser", UseManagedBrowser);
        }
    }
}
