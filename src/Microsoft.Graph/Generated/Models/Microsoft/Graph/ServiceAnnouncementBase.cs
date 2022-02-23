using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class ServiceAnnouncementBase : Entity, IParsable {
        /// <summary>Additional details about service event. This property doesn't support filters.</summary>
        public List<KeyValuePair> Details { get; set; }
        /// <summary>The end time of the service event.</summary>
        public DateTimeOffset? EndDateTime { get; set; }
        /// <summary>The last modified time of the service event.</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>The start time of the service event.</summary>
        public DateTimeOffset? StartDateTime { get; set; }
        /// <summary>The title of the service event.</summary>
        public string Title { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"details", (o,n) => { (o as ServiceAnnouncementBase).Details = n.GetCollectionOfObjectValues<KeyValuePair>().ToList(); } },
                {"endDateTime", (o,n) => { (o as ServiceAnnouncementBase).EndDateTime = n.GetDateTimeOffsetValue(); } },
                {"lastModifiedDateTime", (o,n) => { (o as ServiceAnnouncementBase).LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"startDateTime", (o,n) => { (o as ServiceAnnouncementBase).StartDateTime = n.GetDateTimeOffsetValue(); } },
                {"title", (o,n) => { (o as ServiceAnnouncementBase).Title = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<KeyValuePair>("details", Details);
            writer.WriteDateTimeOffsetValue("endDateTime", EndDateTime);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
            writer.WriteStringValue("title", Title);
        }
    }
}
