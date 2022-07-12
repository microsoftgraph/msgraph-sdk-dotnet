using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class MeetingAttendanceReport : Entity, IParsable {
        /// <summary>List of attendance records of an attendance report. Read-only.</summary>
        public List<AttendanceRecord> AttendanceRecords {
            get { return BackingStore?.Get<List<AttendanceRecord>>("attendanceRecords"); }
            set { BackingStore?.Set("attendanceRecords", value); }
        }
        /// <summary>UTC time when the meeting ended. Read-only.</summary>
        public DateTimeOffset? MeetingEndDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("meetingEndDateTime"); }
            set { BackingStore?.Set("meetingEndDateTime", value); }
        }
        /// <summary>UTC time when the meeting started. Read-only.</summary>
        public DateTimeOffset? MeetingStartDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("meetingStartDateTime"); }
            set { BackingStore?.Set("meetingStartDateTime", value); }
        }
        /// <summary>Total number of participants. Read-only.</summary>
        public int? TotalParticipantCount {
            get { return BackingStore?.Get<int?>("totalParticipantCount"); }
            set { BackingStore?.Set("totalParticipantCount", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MeetingAttendanceReport CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MeetingAttendanceReport();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"attendanceRecords", n => { AttendanceRecords = n.GetCollectionOfObjectValues<AttendanceRecord>(AttendanceRecord.CreateFromDiscriminatorValue).ToList(); } },
                {"meetingEndDateTime", n => { MeetingEndDateTime = n.GetDateTimeOffsetValue(); } },
                {"meetingStartDateTime", n => { MeetingStartDateTime = n.GetDateTimeOffsetValue(); } },
                {"totalParticipantCount", n => { TotalParticipantCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<AttendanceRecord>("attendanceRecords", AttendanceRecords);
            writer.WriteDateTimeOffsetValue("meetingEndDateTime", MeetingEndDateTime);
            writer.WriteDateTimeOffsetValue("meetingStartDateTime", MeetingStartDateTime);
            writer.WriteIntValue("totalParticipantCount", TotalParticipantCount);
        }
    }
}
