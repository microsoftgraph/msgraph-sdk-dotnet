using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Users.Item.FindMeetingTimes {
    public class FindMeetingTimesPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The attendees property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<AttendeeBase>? Attendees {
            get { return BackingStore?.Get<List<AttendeeBase>?>("attendees"); }
            set { BackingStore?.Set("attendees", value); }
        }
#nullable restore
#else
        public List<AttendeeBase> Attendees {
            get { return BackingStore?.Get<List<AttendeeBase>>("attendees"); }
            set { BackingStore?.Set("attendees", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The isOrganizerOptional property</summary>
        public bool? IsOrganizerOptional {
            get { return BackingStore?.Get<bool?>("isOrganizerOptional"); }
            set { BackingStore?.Set("isOrganizerOptional", value); }
        }
        /// <summary>The locationConstraint property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.LocationConstraint? LocationConstraint {
            get { return BackingStore?.Get<Microsoft.Graph.Models.LocationConstraint?>("locationConstraint"); }
            set { BackingStore?.Set("locationConstraint", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.LocationConstraint LocationConstraint {
            get { return BackingStore?.Get<Microsoft.Graph.Models.LocationConstraint>("locationConstraint"); }
            set { BackingStore?.Set("locationConstraint", value); }
        }
#endif
        /// <summary>The maxCandidates property</summary>
        public int? MaxCandidates {
            get { return BackingStore?.Get<int?>("maxCandidates"); }
            set { BackingStore?.Set("maxCandidates", value); }
        }
        /// <summary>The meetingDuration property</summary>
        public TimeSpan? MeetingDuration {
            get { return BackingStore?.Get<TimeSpan?>("meetingDuration"); }
            set { BackingStore?.Set("meetingDuration", value); }
        }
        /// <summary>The minimumAttendeePercentage property</summary>
        public double? MinimumAttendeePercentage {
            get { return BackingStore?.Get<double?>("minimumAttendeePercentage"); }
            set { BackingStore?.Set("minimumAttendeePercentage", value); }
        }
        /// <summary>The returnSuggestionReasons property</summary>
        public bool? ReturnSuggestionReasons {
            get { return BackingStore?.Get<bool?>("returnSuggestionReasons"); }
            set { BackingStore?.Set("returnSuggestionReasons", value); }
        }
        /// <summary>The timeConstraint property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.TimeConstraint? TimeConstraint {
            get { return BackingStore?.Get<Microsoft.Graph.Models.TimeConstraint?>("timeConstraint"); }
            set { BackingStore?.Set("timeConstraint", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.TimeConstraint TimeConstraint {
            get { return BackingStore?.Get<Microsoft.Graph.Models.TimeConstraint>("timeConstraint"); }
            set { BackingStore?.Set("timeConstraint", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new findMeetingTimesPostRequestBody and sets the default values.
        /// </summary>
        public FindMeetingTimesPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static FindMeetingTimesPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new FindMeetingTimesPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attendees", n => { Attendees = n.GetCollectionOfObjectValues<AttendeeBase>(AttendeeBase.CreateFromDiscriminatorValue)?.ToList(); } },
                {"isOrganizerOptional", n => { IsOrganizerOptional = n.GetBoolValue(); } },
                {"locationConstraint", n => { LocationConstraint = n.GetObjectValue<Microsoft.Graph.Models.LocationConstraint>(Microsoft.Graph.Models.LocationConstraint.CreateFromDiscriminatorValue); } },
                {"maxCandidates", n => { MaxCandidates = n.GetIntValue(); } },
                {"meetingDuration", n => { MeetingDuration = n.GetTimeSpanValue(); } },
                {"minimumAttendeePercentage", n => { MinimumAttendeePercentage = n.GetDoubleValue(); } },
                {"returnSuggestionReasons", n => { ReturnSuggestionReasons = n.GetBoolValue(); } },
                {"timeConstraint", n => { TimeConstraint = n.GetObjectValue<Microsoft.Graph.Models.TimeConstraint>(Microsoft.Graph.Models.TimeConstraint.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<AttendeeBase>("attendees", Attendees);
            writer.WriteBoolValue("isOrganizerOptional", IsOrganizerOptional);
            writer.WriteObjectValue<Microsoft.Graph.Models.LocationConstraint>("locationConstraint", LocationConstraint);
            writer.WriteIntValue("maxCandidates", MaxCandidates);
            writer.WriteTimeSpanValue("meetingDuration", MeetingDuration);
            writer.WriteDoubleValue("minimumAttendeePercentage", MinimumAttendeePercentage);
            writer.WriteBoolValue("returnSuggestionReasons", ReturnSuggestionReasons);
            writer.WriteObjectValue<Microsoft.Graph.Models.TimeConstraint>("timeConstraint", TimeConstraint);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
