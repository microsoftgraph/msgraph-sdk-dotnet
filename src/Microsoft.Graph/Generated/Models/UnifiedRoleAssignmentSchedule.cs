using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UnifiedRoleAssignmentSchedule : UnifiedRoleScheduleBase, IParsable {
        /// <summary>If the request is from an eligible administrator to activate a role, this parameter will show the related eligible assignment for that activation. Otherwise, it is null. Supports $expand.</summary>
        public UnifiedRoleEligibilitySchedule ActivatedUsing {
            get { return BackingStore?.Get<UnifiedRoleEligibilitySchedule>("activatedUsing"); }
            set { BackingStore?.Set("activatedUsing", value); }
        }
        /// <summary>Type of the assignment which can either be Assigned or Activated. Supports $filter (eq, ne).</summary>
        public string AssignmentType {
            get { return BackingStore?.Get<string>("assignmentType"); }
            set { BackingStore?.Set("assignmentType", value); }
        }
        /// <summary>How the assignments is inherited. It can either be Inherited, Direct, or Group. It can further imply whether the unifiedRoleAssignmentSchedule can be managed by the caller. Supports $filter (eq, ne).</summary>
        public string MemberType {
            get { return BackingStore?.Get<string>("memberType"); }
            set { BackingStore?.Set("memberType", value); }
        }
        /// <summary>The period of the role assignment. It can represent a single occurrence or multiple recurrences.</summary>
        public RequestSchedule ScheduleInfo {
            get { return BackingStore?.Get<RequestSchedule>("scheduleInfo"); }
            set { BackingStore?.Set("scheduleInfo", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UnifiedRoleAssignmentSchedule CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UnifiedRoleAssignmentSchedule();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"activatedUsing", n => { ActivatedUsing = n.GetObjectValue<UnifiedRoleEligibilitySchedule>(UnifiedRoleEligibilitySchedule.CreateFromDiscriminatorValue); } },
                {"assignmentType", n => { AssignmentType = n.GetStringValue(); } },
                {"memberType", n => { MemberType = n.GetStringValue(); } },
                {"scheduleInfo", n => { ScheduleInfo = n.GetObjectValue<RequestSchedule>(RequestSchedule.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<UnifiedRoleEligibilitySchedule>("activatedUsing", ActivatedUsing);
            writer.WriteStringValue("assignmentType", AssignmentType);
            writer.WriteStringValue("memberType", MemberType);
            writer.WriteObjectValue<RequestSchedule>("scheduleInfo", ScheduleInfo);
        }
    }
}
