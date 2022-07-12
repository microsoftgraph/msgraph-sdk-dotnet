using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class BookingAppointment : Entity, IParsable {
        /// <summary>Additional information that is sent to the customer when an appointment is confirmed.</summary>
        public string AdditionalInformation {
            get { return BackingStore?.Get<string>("additionalInformation"); }
            set { BackingStore?.Set("additionalInformation", value); }
        }
        /// <summary>It lists down the customer properties for an appointment. An appointment will contain a list of customer information and each unit will indicate the properties of a customer who is part of that appointment. Optional.</summary>
        public List<BookingCustomerInformationBase> Customers {
            get { return BackingStore?.Get<List<BookingCustomerInformationBase>>("customers"); }
            set { BackingStore?.Set("customers", value); }
        }
        /// <summary>The time zone of the customer. For a list of possible values, see dateTimeTimeZone.</summary>
        public string CustomerTimeZone {
            get { return BackingStore?.Get<string>("customerTimeZone"); }
            set { BackingStore?.Set("customerTimeZone", value); }
        }
        /// <summary>The length of the appointment, denoted in ISO8601 format.</summary>
        public TimeSpan? Duration {
            get { return BackingStore?.Get<TimeSpan?>("duration"); }
            set { BackingStore?.Set("duration", value); }
        }
        /// <summary>The endDateTime property</summary>
        public DateTimeTimeZone EndDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("endDateTime"); }
            set { BackingStore?.Set("endDateTime", value); }
        }
        /// <summary>The current number of customers in the appointment.</summary>
        public int? FilledAttendeesCount {
            get { return BackingStore?.Get<int?>("filledAttendeesCount"); }
            set { BackingStore?.Set("filledAttendeesCount", value); }
        }
        /// <summary>True indicates that the appointment will be held online. Default value is false.</summary>
        public bool? IsLocationOnline {
            get { return BackingStore?.Get<bool?>("isLocationOnline"); }
            set { BackingStore?.Set("isLocationOnline", value); }
        }
        /// <summary>The URL of the online meeting for the appointment.</summary>
        public string JoinWebUrl {
            get { return BackingStore?.Get<string>("joinWebUrl"); }
            set { BackingStore?.Set("joinWebUrl", value); }
        }
        /// <summary>The maximum number of customers allowed in an appointment. If maximumAttendeesCount of the service is greater than 1, pass valid customer IDs while creating or updating an appointment. To create a customer, use the Create bookingCustomer operation.</summary>
        public int? MaximumAttendeesCount {
            get { return BackingStore?.Get<int?>("maximumAttendeesCount"); }
            set { BackingStore?.Set("maximumAttendeesCount", value); }
        }
        /// <summary>True indicates that the bookingCustomer for this appointment does not wish to receive a confirmation for this appointment.</summary>
        public bool? OptOutOfCustomerEmail {
            get { return BackingStore?.Get<bool?>("optOutOfCustomerEmail"); }
            set { BackingStore?.Set("optOutOfCustomerEmail", value); }
        }
        /// <summary>The amount of time to reserve after the appointment ends, for cleaning up, as an example. The value is expressed in ISO8601 format.</summary>
        public TimeSpan? PostBuffer {
            get { return BackingStore?.Get<TimeSpan?>("postBuffer"); }
            set { BackingStore?.Set("postBuffer", value); }
        }
        /// <summary>The amount of time to reserve before the appointment begins, for preparation, as an example. The value is expressed in ISO8601 format.</summary>
        public TimeSpan? PreBuffer {
            get { return BackingStore?.Get<TimeSpan?>("preBuffer"); }
            set { BackingStore?.Set("preBuffer", value); }
        }
        /// <summary>The regular price for an appointment for the specified bookingService.</summary>
        public double? Price {
            get { return BackingStore?.Get<double?>("price"); }
            set { BackingStore?.Set("price", value); }
        }
        /// <summary>Represents the type of pricing of a booking service.</summary>
        public BookingPriceType? PriceType {
            get { return BackingStore?.Get<BookingPriceType?>("priceType"); }
            set { BackingStore?.Set("priceType", value); }
        }
        /// <summary>The collection of customer reminders sent for this appointment. The value of this property is available only when reading this bookingAppointment by its ID.</summary>
        public List<BookingReminder> Reminders {
            get { return BackingStore?.Get<List<BookingReminder>>("reminders"); }
            set { BackingStore?.Set("reminders", value); }
        }
        /// <summary>An additional tracking ID for the appointment, if the appointment has been created directly by the customer on the scheduling page, as opposed to by a staff member on the behalf of the customer.</summary>
        public string SelfServiceAppointmentId {
            get { return BackingStore?.Get<string>("selfServiceAppointmentId"); }
            set { BackingStore?.Set("selfServiceAppointmentId", value); }
        }
        /// <summary>The ID of the bookingService associated with this appointment.</summary>
        public string ServiceId {
            get { return BackingStore?.Get<string>("serviceId"); }
            set { BackingStore?.Set("serviceId", value); }
        }
        /// <summary>The location where the service is delivered.</summary>
        public Location ServiceLocation {
            get { return BackingStore?.Get<Location>("serviceLocation"); }
            set { BackingStore?.Set("serviceLocation", value); }
        }
        /// <summary>The name of the bookingService associated with this appointment.This property is optional when creating a new appointment. If not specified, it is computed from the service associated with the appointment by the serviceId property.</summary>
        public string ServiceName {
            get { return BackingStore?.Get<string>("serviceName"); }
            set { BackingStore?.Set("serviceName", value); }
        }
        /// <summary>Notes from a bookingStaffMember. The value of this property is available only when reading this bookingAppointment by its ID.</summary>
        public string ServiceNotes {
            get { return BackingStore?.Get<string>("serviceNotes"); }
            set { BackingStore?.Set("serviceNotes", value); }
        }
        /// <summary>True indicates SMS notifications will be sent to the customers for the appointment. Default value is false.</summary>
        public bool? SmsNotificationsEnabled {
            get { return BackingStore?.Get<bool?>("smsNotificationsEnabled"); }
            set { BackingStore?.Set("smsNotificationsEnabled", value); }
        }
        /// <summary>The ID of each bookingStaffMember who is scheduled in this appointment.</summary>
        public List<string> StaffMemberIds {
            get { return BackingStore?.Get<List<string>>("staffMemberIds"); }
            set { BackingStore?.Set("staffMemberIds", value); }
        }
        /// <summary>The startDateTime property</summary>
        public DateTimeTimeZone StartDateTime {
            get { return BackingStore?.Get<DateTimeTimeZone>("startDateTime"); }
            set { BackingStore?.Set("startDateTime", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new BookingAppointment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BookingAppointment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"additionalInformation", n => { AdditionalInformation = n.GetStringValue(); } },
                {"customers", n => { Customers = n.GetCollectionOfObjectValues<BookingCustomerInformationBase>(BookingCustomerInformationBase.CreateFromDiscriminatorValue).ToList(); } },
                {"customerTimeZone", n => { CustomerTimeZone = n.GetStringValue(); } },
                {"duration", n => { Duration = n.GetTimeSpanValue(); } },
                {"endDateTime", n => { EndDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
                {"filledAttendeesCount", n => { FilledAttendeesCount = n.GetIntValue(); } },
                {"isLocationOnline", n => { IsLocationOnline = n.GetBoolValue(); } },
                {"joinWebUrl", n => { JoinWebUrl = n.GetStringValue(); } },
                {"maximumAttendeesCount", n => { MaximumAttendeesCount = n.GetIntValue(); } },
                {"optOutOfCustomerEmail", n => { OptOutOfCustomerEmail = n.GetBoolValue(); } },
                {"postBuffer", n => { PostBuffer = n.GetTimeSpanValue(); } },
                {"preBuffer", n => { PreBuffer = n.GetTimeSpanValue(); } },
                {"price", n => { Price = n.GetDoubleValue(); } },
                {"priceType", n => { PriceType = n.GetEnumValue<BookingPriceType>(); } },
                {"reminders", n => { Reminders = n.GetCollectionOfObjectValues<BookingReminder>(BookingReminder.CreateFromDiscriminatorValue).ToList(); } },
                {"selfServiceAppointmentId", n => { SelfServiceAppointmentId = n.GetStringValue(); } },
                {"serviceId", n => { ServiceId = n.GetStringValue(); } },
                {"serviceLocation", n => { ServiceLocation = n.GetObjectValue<Location>(Location.CreateFromDiscriminatorValue); } },
                {"serviceName", n => { ServiceName = n.GetStringValue(); } },
                {"serviceNotes", n => { ServiceNotes = n.GetStringValue(); } },
                {"smsNotificationsEnabled", n => { SmsNotificationsEnabled = n.GetBoolValue(); } },
                {"staffMemberIds", n => { StaffMemberIds = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"startDateTime", n => { StartDateTime = n.GetObjectValue<DateTimeTimeZone>(DateTimeTimeZone.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("additionalInformation", AdditionalInformation);
            writer.WriteCollectionOfObjectValues<BookingCustomerInformationBase>("customers", Customers);
            writer.WriteStringValue("customerTimeZone", CustomerTimeZone);
            writer.WriteTimeSpanValue("duration", Duration);
            writer.WriteObjectValue<DateTimeTimeZone>("endDateTime", EndDateTime);
            writer.WriteIntValue("filledAttendeesCount", FilledAttendeesCount);
            writer.WriteBoolValue("isLocationOnline", IsLocationOnline);
            writer.WriteStringValue("joinWebUrl", JoinWebUrl);
            writer.WriteIntValue("maximumAttendeesCount", MaximumAttendeesCount);
            writer.WriteBoolValue("optOutOfCustomerEmail", OptOutOfCustomerEmail);
            writer.WriteTimeSpanValue("postBuffer", PostBuffer);
            writer.WriteTimeSpanValue("preBuffer", PreBuffer);
            writer.WriteDoubleValue("price", Price);
            writer.WriteEnumValue<BookingPriceType>("priceType", PriceType);
            writer.WriteCollectionOfObjectValues<BookingReminder>("reminders", Reminders);
            writer.WriteStringValue("selfServiceAppointmentId", SelfServiceAppointmentId);
            writer.WriteStringValue("serviceId", ServiceId);
            writer.WriteObjectValue<Location>("serviceLocation", ServiceLocation);
            writer.WriteStringValue("serviceName", ServiceName);
            writer.WriteStringValue("serviceNotes", ServiceNotes);
            writer.WriteBoolValue("smsNotificationsEnabled", SmsNotificationsEnabled);
            writer.WriteCollectionOfPrimitiveValues<string>("staffMemberIds", StaffMemberIds);
            writer.WriteObjectValue<DateTimeTimeZone>("startDateTime", StartDateTime);
        }
    }
}
