using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class SharingLink : IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The app the link is associated with.</summary>
        public Identity Application { get; set; }
        /// <summary>If true then the user can only use this link to view the item on the web, and cannot use it to download the contents of the item. Only for OneDrive for Business and SharePoint.</summary>
        public bool? PreventsDownload { get; set; }
        /// <summary>The scope of the link represented by this permission. Value anonymous indicates the link is usable by anyone, organization indicates the link is only usable for users signed into the same tenant.</summary>
        public string Scope { get; set; }
        /// <summary>The type of the link created.</summary>
        public string Type { get; set; }
        /// <summary>For embed links, this property contains the HTML code for an <iframe> element that will embed the item in a webpage.</summary>
        public string WebHtml { get; set; }
        /// <summary>A URL that opens the item in the browser on the OneDrive website.</summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// Instantiates a new sharingLink and sets the default values.
        /// </summary>
        public SharingLink() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"application", (o,n) => { (o as SharingLink).Application = n.GetObjectValue<Identity>(); } },
                {"preventsDownload", (o,n) => { (o as SharingLink).PreventsDownload = n.GetBoolValue(); } },
                {"scope", (o,n) => { (o as SharingLink).Scope = n.GetStringValue(); } },
                {"type", (o,n) => { (o as SharingLink).Type = n.GetStringValue(); } },
                {"webHtml", (o,n) => { (o as SharingLink).WebHtml = n.GetStringValue(); } },
                {"webUrl", (o,n) => { (o as SharingLink).WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Identity>("application", Application);
            writer.WriteBoolValue("preventsDownload", PreventsDownload);
            writer.WriteStringValue("scope", Scope);
            writer.WriteStringValue("type", Type);
            writer.WriteStringValue("webHtml", WebHtml);
            writer.WriteStringValue("webUrl", WebUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
