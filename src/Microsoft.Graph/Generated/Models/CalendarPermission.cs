using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class CalendarPermission : Entity, IParsable {
        /// <summary>List of allowed sharing or delegating permission levels for the calendar. Possible values are: none, freeBusyRead, limitedRead, read, write, delegateWithoutPrivateEventAccess, delegateWithPrivateEventAccess, custom.</summary>
        public List<CalendarRoleType?> AllowedRoles {
            get { return BackingStore?.Get<List<CalendarRoleType?>>("allowedRoles"); }
            set { BackingStore?.Set("allowedRoles", value); }
        }
        /// <summary>Represents a sharee or delegate who has access to the calendar. For the &apos;My Organization&apos; sharee, the address property is null. Read-only.</summary>
        public Microsoft.Graph.Models.EmailAddress EmailAddress {
            get { return BackingStore?.Get<Microsoft.Graph.Models.EmailAddress>("emailAddress"); }
            set { BackingStore?.Set("emailAddress", value); }
        }
        /// <summary>True if the user in context (sharee or delegate) is inside the same organization as the calendar owner.</summary>
        public bool? IsInsideOrganization {
            get { return BackingStore?.Get<bool?>("isInsideOrganization"); }
            set { BackingStore?.Set("isInsideOrganization", value); }
        }
        /// <summary>True if the user can be removed from the list of sharees or delegates for the specified calendar, false otherwise. The &apos;My organization&apos; user determines the permissions other people within your organization have to the given calendar. You cannot remove &apos;My organization&apos; as a sharee to a calendar.</summary>
        public bool? IsRemovable {
            get { return BackingStore?.Get<bool?>("isRemovable"); }
            set { BackingStore?.Set("isRemovable", value); }
        }
        /// <summary>Current permission level of the calendar sharee or delegate.</summary>
        public CalendarRoleType? Role {
            get { return BackingStore?.Get<CalendarRoleType?>("role"); }
            set { BackingStore?.Set("role", value); }
        }
        /// <summary>
        /// Instantiates a new calendarPermission and sets the default values.
        /// </summary>
        public CalendarPermission() : base() {
            OdataType = "#microsoft.graph.calendarPermission";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CalendarPermission CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CalendarPermission();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"allowedRoles", n => { AllowedRoles = n.GetCollectionOfEnumValues<CalendarRoleType>()?.ToList(); } },
                {"emailAddress", n => { EmailAddress = n.GetObjectValue<Microsoft.Graph.Models.EmailAddress>(Microsoft.Graph.Models.EmailAddress.CreateFromDiscriminatorValue); } },
                {"isInsideOrganization", n => { IsInsideOrganization = n.GetBoolValue(); } },
                {"isRemovable", n => { IsRemovable = n.GetBoolValue(); } },
                {"role", n => { Role = n.GetEnumValue<CalendarRoleType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfEnumValues<CalendarRoleType>("allowedRoles", AllowedRoles);
            writer.WriteObjectValue<Microsoft.Graph.Models.EmailAddress>("emailAddress", EmailAddress);
            writer.WriteBoolValue("isInsideOrganization", IsInsideOrganization);
            writer.WriteBoolValue("isRemovable", IsRemovable);
            writer.WriteEnumValue<CalendarRoleType>("role", Role);
        }
    }
}
