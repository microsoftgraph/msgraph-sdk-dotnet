using Microsoft.Kiota.Abstractions.Serialization;
using MicrosoftGraphSdk.Models.Microsoft.Graph.CallRecords;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class CloudCommunications : Entity, IParsable {
        public List<CallRecord> CallRecords { get; set; }
        public List<Call> Calls { get; set; }
        public List<OnlineMeeting> OnlineMeetings { get; set; }
        public List<Presence> Presences { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"callRecords", (o,n) => { (o as CloudCommunications).CallRecords = n.GetCollectionOfObjectValues<CallRecord>().ToList(); } },
                {"calls", (o,n) => { (o as CloudCommunications).Calls = n.GetCollectionOfObjectValues<Call>().ToList(); } },
                {"onlineMeetings", (o,n) => { (o as CloudCommunications).OnlineMeetings = n.GetCollectionOfObjectValues<OnlineMeeting>().ToList(); } },
                {"presences", (o,n) => { (o as CloudCommunications).Presences = n.GetCollectionOfObjectValues<Presence>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<CallRecord>("callRecords", CallRecords);
            writer.WriteCollectionOfObjectValues<Call>("calls", Calls);
            writer.WriteCollectionOfObjectValues<OnlineMeeting>("onlineMeetings", OnlineMeetings);
            writer.WriteCollectionOfObjectValues<Presence>("presences", Presences);
        }
    }
}
