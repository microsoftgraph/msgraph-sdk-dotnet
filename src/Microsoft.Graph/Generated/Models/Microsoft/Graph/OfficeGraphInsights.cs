using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class OfficeGraphInsights : Entity, IParsable {
        /// <summary>Calculated relationship identifying documents shared with or by the user. This includes URLs, file attachments, and reference attachments to OneDrive for Business and SharePoint files found in Outlook messages and meetings. This also includes URLs and reference attachments to Teams conversations. Ordered by recency of share.</summary>
        public List<SharedInsight> Shared { get; set; }
        /// <summary>Calculated relationship identifying documents trending around a user. Trending documents are calculated based on activity of the user's closest network of people and include files stored in OneDrive for Business and SharePoint. Trending insights help the user to discover potentially useful content that the user has access to, but has never viewed before.</summary>
        public List<Trending> Trending { get; set; }
        /// <summary>Calculated relationship identifying the latest documents viewed or modified by a user, including OneDrive for Business and SharePoint documents, ranked by recency of use.</summary>
        public List<UsedInsight> Used { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"shared", (o,n) => { (o as OfficeGraphInsights).Shared = n.GetCollectionOfObjectValues<SharedInsight>().ToList(); } },
                {"trending", (o,n) => { (o as OfficeGraphInsights).Trending = n.GetCollectionOfObjectValues<Trending>().ToList(); } },
                {"used", (o,n) => { (o as OfficeGraphInsights).Used = n.GetCollectionOfObjectValues<UsedInsight>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<SharedInsight>("shared", Shared);
            writer.WriteCollectionOfObjectValues<Trending>("trending", Trending);
            writer.WriteCollectionOfObjectValues<UsedInsight>("used", Used);
        }
    }
}
