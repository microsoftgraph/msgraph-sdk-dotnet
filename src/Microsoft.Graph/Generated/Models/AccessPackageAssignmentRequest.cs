using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class AccessPackageAssignmentRequest : Entity, IParsable {
        /// <summary>The access package associated with the accessPackageAssignmentRequest. An access package defines the collections of resource roles and the policies for how one or more users can get access to those resources. Read-only. Nullable. Supports $expand.</summary>
        public Microsoft.Graph.Models.AccessPackage AccessPackage {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AccessPackage>("accessPackage"); }
            set { BackingStore?.Set("accessPackage", value); }
        }
        /// <summary>For a requestType of UserAdd or AdminAdd, this is an access package assignment requested to be created.  For a requestType of UserRemove, AdminRemove or SystemRemove, this has the id property of an existing assignment to be removed.   Supports $expand.</summary>
        public AccessPackageAssignment Assignment {
            get { return BackingStore?.Get<AccessPackageAssignment>("assignment"); }
            set { BackingStore?.Set("assignment", value); }
        }
        /// <summary>The date of the end of processing, either successful or failure, of a request. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? CompletedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("completedDateTime"); }
            set { BackingStore?.Set("completedDateTime", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The subject who requested or, if a direct assignment, was assigned. Read-only. Nullable. Supports $expand.</summary>
        public AccessPackageSubject Requestor {
            get { return BackingStore?.Get<AccessPackageSubject>("requestor"); }
            set { BackingStore?.Set("requestor", value); }
        }
        /// <summary>One of UserAdd, UserRemove, AdminAdd, AdminRemove or SystemRemove. A request from the user themselves would have requestType of UserAdd or UserRemove. Read-only.</summary>
        public AccessPackageRequestType? RequestType {
            get { return BackingStore?.Get<AccessPackageRequestType?>("requestType"); }
            set { BackingStore?.Set("requestType", value); }
        }
        /// <summary>The range of dates that access is to be assigned to the requestor. Read-only.</summary>
        public EntitlementManagementSchedule Schedule {
            get { return BackingStore?.Get<EntitlementManagementSchedule>("schedule"); }
            set { BackingStore?.Set("schedule", value); }
        }
        /// <summary>The state of the request. The possible values are: submitted, pendingApproval, delivering, delivered, deliveryFailed, denied, scheduled, canceled, partiallyDelivered, unknownFutureValue. Read-only.</summary>
        public AccessPackageRequestState? State {
            get { return BackingStore?.Get<AccessPackageRequestState?>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>More information on the request processing status. Read-only.</summary>
        public string Status {
            get { return BackingStore?.Get<string>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessPackageAssignmentRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageAssignmentRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"accessPackage", n => { AccessPackage = n.GetObjectValue<Microsoft.Graph.Models.AccessPackage>(Microsoft.Graph.Models.AccessPackage.CreateFromDiscriminatorValue); } },
                {"assignment", n => { Assignment = n.GetObjectValue<AccessPackageAssignment>(AccessPackageAssignment.CreateFromDiscriminatorValue); } },
                {"completedDateTime", n => { CompletedDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"requestor", n => { Requestor = n.GetObjectValue<AccessPackageSubject>(AccessPackageSubject.CreateFromDiscriminatorValue); } },
                {"requestType", n => { RequestType = n.GetEnumValue<AccessPackageRequestType>(); } },
                {"schedule", n => { Schedule = n.GetObjectValue<EntitlementManagementSchedule>(EntitlementManagementSchedule.CreateFromDiscriminatorValue); } },
                {"state", n => { State = n.GetEnumValue<AccessPackageRequestState>(); } },
                {"status", n => { Status = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.AccessPackage>("accessPackage", AccessPackage);
            writer.WriteObjectValue<AccessPackageAssignment>("assignment", Assignment);
            writer.WriteDateTimeOffsetValue("completedDateTime", CompletedDateTime);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<AccessPackageSubject>("requestor", Requestor);
            writer.WriteEnumValue<AccessPackageRequestType>("requestType", RequestType);
            writer.WriteObjectValue<EntitlementManagementSchedule>("schedule", Schedule);
            writer.WriteEnumValue<AccessPackageRequestState>("state", State);
            writer.WriteStringValue("status", Status);
        }
    }
}
