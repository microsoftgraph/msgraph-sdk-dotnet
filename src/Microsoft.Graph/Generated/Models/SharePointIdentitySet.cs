using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SharePointIdentitySet : IdentitySet, IParsable {
        /// <summary>The group associated with this action. Optional.</summary>
        public Identity Group {
            get { return BackingStore?.Get<Identity>("group"); }
            set { BackingStore?.Set("group", value); }
        }
        /// <summary>The SharePoint group associated with this action. Optional.</summary>
        public SharePointIdentity SiteGroup {
            get { return BackingStore?.Get<SharePointIdentity>("siteGroup"); }
            set { BackingStore?.Set("siteGroup", value); }
        }
        /// <summary>The SharePoint user associated with this action. Optional.</summary>
        public SharePointIdentity SiteUser {
            get { return BackingStore?.Get<SharePointIdentity>("siteUser"); }
            set { BackingStore?.Set("siteUser", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SharePointIdentitySet CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SharePointIdentitySet();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"group", n => { Group = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
                {"siteGroup", n => { SiteGroup = n.GetObjectValue<SharePointIdentity>(SharePointIdentity.CreateFromDiscriminatorValue); } },
                {"siteUser", n => { SiteUser = n.GetObjectValue<SharePointIdentity>(SharePointIdentity.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Identity>("group", Group);
            writer.WriteObjectValue<SharePointIdentity>("siteGroup", SiteGroup);
            writer.WriteObjectValue<SharePointIdentity>("siteUser", SiteUser);
        }
    }
}
