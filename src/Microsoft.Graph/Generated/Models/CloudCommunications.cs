using Microsoft.Graph.Models.CallRecords;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the cloudCommunications singleton.</summary>
    public class CloudCommunications : Entity, IParsable {
        /// <summary>The callRecords property</summary>
        public List<CallRecord> CallRecords {
            get { return BackingStore?.Get<List<CallRecord>>("callRecords"); }
            set { BackingStore?.Set("callRecords", value); }
        }
        /// <summary>The calls property</summary>
        public List<Call> Calls {
            get { return BackingStore?.Get<List<Call>>("calls"); }
            set { BackingStore?.Set("calls", value); }
        }
        /// <summary>The onlineMeetings property</summary>
        public List<OnlineMeeting> OnlineMeetings {
            get { return BackingStore?.Get<List<OnlineMeeting>>("onlineMeetings"); }
            set { BackingStore?.Set("onlineMeetings", value); }
        }
        /// <summary>The presences property</summary>
        public List<Presence> Presences {
            get { return BackingStore?.Get<List<Presence>>("presences"); }
            set { BackingStore?.Set("presences", value); }
        }
        /// <summary>
        /// Instantiates a new cloudCommunications and sets the default values.
        /// </summary>
        public CloudCommunications() : base() {
            OdataType = "#microsoft.graph.cloudCommunications";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CloudCommunications CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CloudCommunications();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"callRecords", n => { CallRecords = n.GetCollectionOfObjectValues<CallRecord>(CallRecord.CreateFromDiscriminatorValue)?.ToList(); } },
                {"calls", n => { Calls = n.GetCollectionOfObjectValues<Call>(Call.CreateFromDiscriminatorValue)?.ToList(); } },
                {"onlineMeetings", n => { OnlineMeetings = n.GetCollectionOfObjectValues<OnlineMeeting>(OnlineMeeting.CreateFromDiscriminatorValue)?.ToList(); } },
                {"presences", n => { Presences = n.GetCollectionOfObjectValues<Presence>(Presence.CreateFromDiscriminatorValue)?.ToList(); } },
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
