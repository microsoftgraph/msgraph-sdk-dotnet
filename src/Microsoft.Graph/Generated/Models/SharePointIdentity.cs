using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class SharePointIdentity : Identity, IParsable {
        /// <summary>The sign in name of the SharePoint identity.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LoginName {
            get { return BackingStore?.Get<string?>("loginName"); }
            set { BackingStore?.Set("loginName", value); }
        }
#nullable restore
#else
        public string LoginName {
            get { return BackingStore?.Get<string>("loginName"); }
            set { BackingStore?.Set("loginName", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new SharePointIdentity and sets the default values.
        /// </summary>
        public SharePointIdentity() : base() {
            OdataType = "#microsoft.graph.sharePointIdentity";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new SharePointIdentity CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SharePointIdentity();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"loginName", n => { LoginName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("loginName", LoginName);
        }
    }
}
