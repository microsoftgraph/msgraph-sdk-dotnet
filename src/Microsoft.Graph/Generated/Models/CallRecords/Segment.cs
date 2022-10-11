using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.CallRecords {
    /// <summary>Provides operations to manage the cloudCommunications singleton.</summary>
    public class Segment : Entity, IParsable {
        /// <summary>Endpoint that answered this segment.</summary>
        public Endpoint Callee {
            get { return BackingStore?.Get<Endpoint>("callee"); }
            set { BackingStore?.Set("callee", value); }
        }
        /// <summary>Endpoint that initiated this segment.</summary>
        public Endpoint Caller {
            get { return BackingStore?.Get<Endpoint>("caller"); }
            set { BackingStore?.Set("caller", value); }
        }
        /// <summary>UTC time when the segment ended. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? EndDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
        /// <summary>Failure information associated with the segment if it failed.</summary>
        public Microsoft.Graph.Models.CallRecords.FailureInfo FailureInfo {
            get { return BackingStore?.Get<Microsoft.Graph.Models.CallRecords.FailureInfo>("failureInfo"); }
            set { BackingStore?.Set("failureInfo", value); }
        }
        /// <summary>Media associated with this segment.</summary>
        public List<Microsoft.Graph.Models.CallRecords.Media> Media {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.CallRecords.Media>>("media"); }
            set { BackingStore?.Set("media", value); }
        }
        /// <summary>UTC time when the segment started. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? StartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new segment and sets the default values.
        /// </summary>
        public Segment() : base() {
            OdataType = "#microsoft.graph.callRecords.segment";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Segment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Segment();
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
                {"media", n => { Media = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.CallRecords.Media>(Microsoft.Graph.Models.CallRecords.Media.CreateFromDiscriminatorValue)?.ToList(); } },
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
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.CallRecords.Media>("media", Media);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
        }
    }
}
