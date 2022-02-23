using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class SharePointIdentitySet : IdentitySet, IParsable {
        /// <summary>The group associated with this action. Optional.</summary>
        public Identity Group { get; set; }
        /// <summary>The SharePoint group associated with this action. Optional.</summary>
        public SharePointIdentity SiteGroup { get; set; }
        /// <summary>The SharePoint user associated with this action. Optional.</summary>
        public SharePointIdentity SiteUser { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"group", (o,n) => { (o as SharePointIdentitySet).Group = n.GetObjectValue<Identity>(); } },
                {"siteGroup", (o,n) => { (o as SharePointIdentitySet).SiteGroup = n.GetObjectValue<SharePointIdentity>(); } },
                {"siteUser", (o,n) => { (o as SharePointIdentitySet).SiteUser = n.GetObjectValue<SharePointIdentity>(); } },
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
