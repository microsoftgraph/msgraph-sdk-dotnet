using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Schedule : Entity, IParsable {
        /// <summary>Indicates whether the schedule is enabled for the team. Required.</summary>
        public bool? Enabled {
            get { return BackingStore?.Get<bool?>("enabled"); }
            set { BackingStore?.Set("enabled", value); }
        }
        /// <summary>The offerShiftRequests property</summary>
        public List<OfferShiftRequest> OfferShiftRequests {
            get { return BackingStore?.Get<List<OfferShiftRequest>>("offerShiftRequests"); }
            set { BackingStore?.Set("offerShiftRequests", value); }
        }
        /// <summary>Indicates whether offer shift requests are enabled for the schedule.</summary>
        public bool? OfferShiftRequestsEnabled {
            get { return BackingStore?.Get<bool?>("offerShiftRequestsEnabled"); }
            set { BackingStore?.Set("offerShiftRequestsEnabled", value); }
        }
        /// <summary>The openShiftChangeRequests property</summary>
        public List<OpenShiftChangeRequest> OpenShiftChangeRequests {
            get { return BackingStore?.Get<List<OpenShiftChangeRequest>>("openShiftChangeRequests"); }
            set { BackingStore?.Set("openShiftChangeRequests", value); }
        }
        /// <summary>The openShifts property</summary>
        public List<OpenShift> OpenShifts {
            get { return BackingStore?.Get<List<OpenShift>>("openShifts"); }
            set { BackingStore?.Set("openShifts", value); }
        }
        /// <summary>Indicates whether open shifts are enabled for the schedule.</summary>
        public bool? OpenShiftsEnabled {
            get { return BackingStore?.Get<bool?>("openShiftsEnabled"); }
            set { BackingStore?.Set("openShiftsEnabled", value); }
        }
        /// <summary>The status of the schedule provisioning. The possible values are notStarted, running, completed, failed.</summary>
        public OperationStatus? ProvisionStatus {
            get { return BackingStore?.Get<OperationStatus?>("provisionStatus"); }
            set { BackingStore?.Set("provisionStatus", value); }
        }
        /// <summary>Additional information about why schedule provisioning failed.</summary>
        public string ProvisionStatusCode {
            get { return BackingStore?.Get<string>("provisionStatusCode"); }
            set { BackingStore?.Set("provisionStatusCode", value); }
        }
        /// <summary>The logical grouping of users in the schedule (usually by role).</summary>
        public List<SchedulingGroup> SchedulingGroups {
            get { return BackingStore?.Get<List<SchedulingGroup>>("schedulingGroups"); }
            set { BackingStore?.Set("schedulingGroups", value); }
        }
        /// <summary>The shifts in the schedule.</summary>
        public List<Shift> Shifts {
            get { return BackingStore?.Get<List<Shift>>("shifts"); }
            set { BackingStore?.Set("shifts", value); }
        }
        /// <summary>The swapShiftsChangeRequests property</summary>
        public List<SwapShiftsChangeRequest> SwapShiftsChangeRequests {
            get { return BackingStore?.Get<List<SwapShiftsChangeRequest>>("swapShiftsChangeRequests"); }
            set { BackingStore?.Set("swapShiftsChangeRequests", value); }
        }
        /// <summary>Indicates whether swap shifts requests are enabled for the schedule.</summary>
        public bool? SwapShiftsRequestsEnabled {
            get { return BackingStore?.Get<bool?>("swapShiftsRequestsEnabled"); }
            set { BackingStore?.Set("swapShiftsRequestsEnabled", value); }
        }
        /// <summary>Indicates whether time clock is enabled for the schedule.</summary>
        public bool? TimeClockEnabled {
            get { return BackingStore?.Get<bool?>("timeClockEnabled"); }
            set { BackingStore?.Set("timeClockEnabled", value); }
        }
        /// <summary>The set of reasons for a time off in the schedule.</summary>
        public List<TimeOffReason> TimeOffReasons {
            get { return BackingStore?.Get<List<TimeOffReason>>("timeOffReasons"); }
            set { BackingStore?.Set("timeOffReasons", value); }
        }
        /// <summary>The timeOffRequests property</summary>
        public List<TimeOffRequest> TimeOffRequests {
            get { return BackingStore?.Get<List<TimeOffRequest>>("timeOffRequests"); }
            set { BackingStore?.Set("timeOffRequests", value); }
        }
        /// <summary>Indicates whether time off requests are enabled for the schedule.</summary>
        public bool? TimeOffRequestsEnabled {
            get { return BackingStore?.Get<bool?>("timeOffRequestsEnabled"); }
            set { BackingStore?.Set("timeOffRequestsEnabled", value); }
        }
        /// <summary>The instances of times off in the schedule.</summary>
        public List<TimeOff> TimesOff {
            get { return BackingStore?.Get<List<TimeOff>>("timesOff"); }
            set { BackingStore?.Set("timesOff", value); }
        }
        /// <summary>Indicates the time zone of the schedule team using tz database format. Required.</summary>
        public string TimeZone {
            get { return BackingStore?.Get<string>("timeZone"); }
            set { BackingStore?.Set("timeZone", value); }
        }
        /// <summary>The workforceIntegrationIds property</summary>
        public List<string> WorkforceIntegrationIds {
            get { return BackingStore?.Get<List<string>>("workforceIntegrationIds"); }
            set { BackingStore?.Set("workforceIntegrationIds", value); }
        }
        /// <summary>
        /// Instantiates a new schedule and sets the default values.
        /// </summary>
        public Schedule() : base() {
            OdataType = "#microsoft.graph.schedule";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Schedule CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Schedule();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"enabled", n => { Enabled = n.GetBoolValue(); } },
                {"offerShiftRequests", n => { OfferShiftRequests = n.GetCollectionOfObjectValues<OfferShiftRequest>(OfferShiftRequest.CreateFromDiscriminatorValue)?.ToList(); } },
                {"offerShiftRequestsEnabled", n => { OfferShiftRequestsEnabled = n.GetBoolValue(); } },
                {"openShiftChangeRequests", n => { OpenShiftChangeRequests = n.GetCollectionOfObjectValues<OpenShiftChangeRequest>(OpenShiftChangeRequest.CreateFromDiscriminatorValue)?.ToList(); } },
                {"openShifts", n => { OpenShifts = n.GetCollectionOfObjectValues<OpenShift>(OpenShift.CreateFromDiscriminatorValue)?.ToList(); } },
                {"openShiftsEnabled", n => { OpenShiftsEnabled = n.GetBoolValue(); } },
                {"provisionStatus", n => { ProvisionStatus = n.GetEnumValue<OperationStatus>(); } },
                {"provisionStatusCode", n => { ProvisionStatusCode = n.GetStringValue(); } },
                {"schedulingGroups", n => { SchedulingGroups = n.GetCollectionOfObjectValues<SchedulingGroup>(SchedulingGroup.CreateFromDiscriminatorValue)?.ToList(); } },
                {"shifts", n => { Shifts = n.GetCollectionOfObjectValues<Shift>(Shift.CreateFromDiscriminatorValue)?.ToList(); } },
                {"swapShiftsChangeRequests", n => { SwapShiftsChangeRequests = n.GetCollectionOfObjectValues<SwapShiftsChangeRequest>(SwapShiftsChangeRequest.CreateFromDiscriminatorValue)?.ToList(); } },
                {"swapShiftsRequestsEnabled", n => { SwapShiftsRequestsEnabled = n.GetBoolValue(); } },
                {"timeClockEnabled", n => { TimeClockEnabled = n.GetBoolValue(); } },
                {"timeOffReasons", n => { TimeOffReasons = n.GetCollectionOfObjectValues<TimeOffReason>(TimeOffReason.CreateFromDiscriminatorValue)?.ToList(); } },
                {"timeOffRequests", n => { TimeOffRequests = n.GetCollectionOfObjectValues<TimeOffRequest>(TimeOffRequest.CreateFromDiscriminatorValue)?.ToList(); } },
                {"timeOffRequestsEnabled", n => { TimeOffRequestsEnabled = n.GetBoolValue(); } },
                {"timesOff", n => { TimesOff = n.GetCollectionOfObjectValues<TimeOff>(TimeOff.CreateFromDiscriminatorValue)?.ToList(); } },
                {"timeZone", n => { TimeZone = n.GetStringValue(); } },
                {"workforceIntegrationIds", n => { WorkforceIntegrationIds = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("enabled", Enabled);
            writer.WriteCollectionOfObjectValues<OfferShiftRequest>("offerShiftRequests", OfferShiftRequests);
            writer.WriteBoolValue("offerShiftRequestsEnabled", OfferShiftRequestsEnabled);
            writer.WriteCollectionOfObjectValues<OpenShiftChangeRequest>("openShiftChangeRequests", OpenShiftChangeRequests);
            writer.WriteCollectionOfObjectValues<OpenShift>("openShifts", OpenShifts);
            writer.WriteBoolValue("openShiftsEnabled", OpenShiftsEnabled);
            writer.WriteCollectionOfObjectValues<SchedulingGroup>("schedulingGroups", SchedulingGroups);
            writer.WriteCollectionOfObjectValues<Shift>("shifts", Shifts);
            writer.WriteCollectionOfObjectValues<SwapShiftsChangeRequest>("swapShiftsChangeRequests", SwapShiftsChangeRequests);
            writer.WriteBoolValue("swapShiftsRequestsEnabled", SwapShiftsRequestsEnabled);
            writer.WriteBoolValue("timeClockEnabled", TimeClockEnabled);
            writer.WriteCollectionOfObjectValues<TimeOffReason>("timeOffReasons", TimeOffReasons);
            writer.WriteCollectionOfObjectValues<TimeOffRequest>("timeOffRequests", TimeOffRequests);
            writer.WriteBoolValue("timeOffRequestsEnabled", TimeOffRequestsEnabled);
            writer.WriteCollectionOfObjectValues<TimeOff>("timesOff", TimesOff);
            writer.WriteStringValue("timeZone", TimeZone);
            writer.WriteCollectionOfPrimitiveValues<string>("workforceIntegrationIds", WorkforceIntegrationIds);
        }
    }
}
