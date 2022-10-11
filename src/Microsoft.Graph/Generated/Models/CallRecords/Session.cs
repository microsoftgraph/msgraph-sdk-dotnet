using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.CallRecords {
    /// <summary>Provides operations to manage the cloudCommunications singleton.</summary>
    public class Session : Entity, IParsable {
        /// <summary>Endpoint that answered the session.</summary>
        public Endpoint Callee {
            get { return BackingStore?.Get<Endpoint>("callee"); }
            set { BackingStore?.Set("callee", value); }
        }
        /// <summary>Endpoint that initiated the session.</summary>
        public Endpoint Caller {
            get { return BackingStore?.Get<Endpoint>("caller"); }
            set { BackingStore?.Set("caller", value); }
        }
        /// <summary>UTC time when the last user left the session. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? EndDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
        /// <summary>Failure information associated with the session if the session failed.</summary>
        public Microsoft.Graph.Models.CallRecords.FailureInfo FailureInfo {
            get { return BackingStore?.Get<Microsoft.Graph.Models.CallRecords.FailureInfo>("failureInfo"); }
            set { BackingStore?.Set("failureInfo", value); }
        }
        /// <summary>List of modalities present in the session. Possible values are: unknown, audio, video, videoBasedScreenSharing, data, screenSharing, unknownFutureValue.</summary>
        public List<Modality?> Modalities {
            get { return BackingStore?.Get<List<Modality?>>("modalities"); }
            set { BackingStore?.Set("modalities", value); }
        }
        /// <summary>The list of segments involved in the session. Read-only. Nullable.</summary>
        public List<Segment> Segments {
            get { return BackingStore?.Get<List<Segment>>("segments"); }
            set { BackingStore?.Set("segments", value); }
        }
        /// <summary>UTC time when the first user joined the session. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? StartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new session and sets the default values.
        /// </summary>
        public Session() : base() {
            OdataType = "#microsoft.graph.callRecords.session";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Session CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Session();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"callee", n => { Callee = n.GetObjectValue<Endpoint>(Endpoint.CreateFromDiscriminatorValue); } },
                {"caller", n => { Caller = n.GetObjectValue<Endpoint>(Endpoint.CreateFromDiscriminatorValue); } },
                {"endDateTime", n => { EndDateTime = n.GetDateTimeOffsetValue(); } },
                {"failureInfo", n => { FailureInfo = n.GetObjectValue<Microsoft.Graph.Models.CallRecords.FailureInfo>(Microsoft.Graph.Models.CallRecords.FailureInfo.CreateFromDiscriminatorValue); } },
                {"modalities", n => { Modalities = n.GetCollectionOfEnumValues<Modality>()?.ToList(); } },
                {"segments", n => { Segments = n.GetCollectionOfObjectValues<Segment>(Segment.CreateFromDiscriminatorValue)?.ToList(); } },
                {"startDateTime", n => { StartDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Endpoint>("callee", Callee);
            writer.WriteObjectValue<Endpoint>("caller", Caller);
            writer.WriteDateTimeOffsetValue("endDateTime", EndDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.CallRecords.FailureInfo>("failureInfo", FailureInfo);
            writer.WriteCollectionOfEnumValues<Modality>("modalities", Modalities);
            writer.WriteCollectionOfObjectValues<Segment>("segments", Segments);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
        }
    }
}
