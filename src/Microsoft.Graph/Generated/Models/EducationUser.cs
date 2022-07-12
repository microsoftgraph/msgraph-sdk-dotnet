using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class EducationUser : Entity, IParsable {
        /// <summary>True if the account is enabled; otherwise, false. This property is required when a user is created. Supports /$filter.</summary>
        public bool? AccountEnabled {
            get { return BackingStore?.Get<bool?>("accountEnabled"); }
            set { BackingStore?.Set("accountEnabled", value); }
        }
        /// <summary>The licenses that are assigned to the user. Not nullable.</summary>
        public List<AssignedLicense> AssignedLicenses {
            get { return BackingStore?.Get<List<AssignedLicense>>("assignedLicenses"); }
            set { BackingStore?.Set("assignedLicenses", value); }
        }
        /// <summary>The plans that are assigned to the user. Read-only. Not nullable.</summary>
        public List<AssignedPlan> AssignedPlans {
            get { return BackingStore?.Get<List<AssignedPlan>>("assignedPlans"); }
            set { BackingStore?.Set("assignedPlans", value); }
        }
        /// <summary>List of assignments for the user. Nullable.</summary>
        public List<EducationAssignment> Assignments {
            get { return BackingStore?.Get<List<EducationAssignment>>("assignments"); }
            set { BackingStore?.Set("assignments", value); }
        }
        /// <summary>The telephone numbers for the user. Note: Although this is a string collection, only one number can be set for this property.</summary>
        public List<string> BusinessPhones {
            get { return BackingStore?.Get<List<string>>("businessPhones"); }
            set { BackingStore?.Set("businessPhones", value); }
        }
        /// <summary>Classes to which the user belongs. Nullable.</summary>
        public List<EducationClass> Classes {
            get { return BackingStore?.Get<List<EducationClass>>("classes"); }
            set { BackingStore?.Set("classes", value); }
        }
        /// <summary>Entity who created the user.</summary>
        public IdentitySet CreatedBy {
            get { return BackingStore?.Get<IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>The name for the department in which the user works. Supports /$filter.</summary>
        public string Department {
            get { return BackingStore?.Get<string>("department"); }
            set { BackingStore?.Set("department", value); }
        }
        /// <summary>The name displayed in the address book for the user. Supports $filter and $orderby.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The type of external source this resource was generated from (automatically determined from externalSourceDetail). Possible values are: sis, lms, or manual.</summary>
        public EducationExternalSource? ExternalSource {
            get { return BackingStore?.Get<EducationExternalSource?>("externalSource"); }
            set { BackingStore?.Set("externalSource", value); }
        }
        /// <summary>The name of the external source this resources was generated from.</summary>
        public string ExternalSourceDetail {
            get { return BackingStore?.Get<string>("externalSourceDetail"); }
            set { BackingStore?.Set("externalSourceDetail", value); }
        }
        /// <summary>The given name (first name) of the user. Supports /$filter.</summary>
        public string GivenName {
            get { return BackingStore?.Get<string>("givenName"); }
            set { BackingStore?.Set("givenName", value); }
        }
        /// <summary>The SMTP address for the user; for example, &apos;jeff@contoso.onmicrosoft.com&apos;. Read-Only. Supports /$filter.</summary>
        public string Mail {
            get { return BackingStore?.Get<string>("mail"); }
            set { BackingStore?.Set("mail", value); }
        }
        /// <summary>Mail address of user. Note: type and postOfficeBox are not supported for educationUser resources.</summary>
        public PhysicalAddress MailingAddress {
            get { return BackingStore?.Get<PhysicalAddress>("mailingAddress"); }
            set { BackingStore?.Set("mailingAddress", value); }
        }
        /// <summary>The mail alias for the user. This property must be specified when a user is created. Supports /$filter.</summary>
        public string MailNickname {
            get { return BackingStore?.Get<string>("mailNickname"); }
            set { BackingStore?.Set("mailNickname", value); }
        }
        /// <summary>The middle name of user.</summary>
        public string MiddleName {
            get { return BackingStore?.Get<string>("middleName"); }
            set { BackingStore?.Set("middleName", value); }
        }
        /// <summary>The primary cellular telephone number for the user.</summary>
        public string MobilePhone {
            get { return BackingStore?.Get<string>("mobilePhone"); }
            set { BackingStore?.Set("mobilePhone", value); }
        }
        /// <summary>The officeLocation property</summary>
        public string OfficeLocation {
            get { return BackingStore?.Get<string>("officeLocation"); }
            set { BackingStore?.Set("officeLocation", value); }
        }
        /// <summary>Additional information used to associate the AAD user with it&apos;s Active Directory counterpart.</summary>
        public EducationOnPremisesInfo OnPremisesInfo {
            get { return BackingStore?.Get<EducationOnPremisesInfo>("onPremisesInfo"); }
            set { BackingStore?.Set("onPremisesInfo", value); }
        }
        /// <summary>Specifies password policies for the user. See standard [user] resource for additional details.</summary>
        public string PasswordPolicies {
            get { return BackingStore?.Get<string>("passwordPolicies"); }
            set { BackingStore?.Set("passwordPolicies", value); }
        }
        /// <summary>Specifies the password profile for the user. The profile contains the user&apos;s password. This property is required when a user is created. See standard [user] resource for additional details.</summary>
        public Microsoft.Graph.Models.PasswordProfile PasswordProfile {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PasswordProfile>("passwordProfile"); }
            set { BackingStore?.Set("passwordProfile", value); }
        }
        /// <summary>The preferred language for the user. Should follow ISO 639-1 Code; for example, &apos;en-US&apos;.</summary>
        public string PreferredLanguage {
            get { return BackingStore?.Get<string>("preferredLanguage"); }
            set { BackingStore?.Set("preferredLanguage", value); }
        }
        /// <summary>The primaryRole property</summary>
        public EducationUserRole? PrimaryRole {
            get { return BackingStore?.Get<EducationUserRole?>("primaryRole"); }
            set { BackingStore?.Set("primaryRole", value); }
        }
        /// <summary>The plans that are provisioned for the user. Read-only. Not nullable.</summary>
        public List<ProvisionedPlan> ProvisionedPlans {
            get { return BackingStore?.Get<List<ProvisionedPlan>>("provisionedPlans"); }
            set { BackingStore?.Set("provisionedPlans", value); }
        }
        /// <summary>The refreshTokensValidFromDateTime property</summary>
        public DateTimeOffset? RefreshTokensValidFromDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("refreshTokensValidFromDateTime"); }
            set { BackingStore?.Set("refreshTokensValidFromDateTime", value); }
        }
        /// <summary>Related records related to the user. Possible relationships are parent, relative, aide, doctor, guardian, child, other, unknownFutureValue</summary>
        public List<RelatedContact> RelatedContacts {
            get { return BackingStore?.Get<List<RelatedContact>>("relatedContacts"); }
            set { BackingStore?.Set("relatedContacts", value); }
        }
        /// <summary>Address where user lives. Note: type and postOfficeBox are not supported for educationUser resources.</summary>
        public PhysicalAddress ResidenceAddress {
            get { return BackingStore?.Get<PhysicalAddress>("residenceAddress"); }
            set { BackingStore?.Set("residenceAddress", value); }
        }
        /// <summary>When set, the grading rubric attached to the assignment.</summary>
        public List<EducationRubric> Rubrics {
            get { return BackingStore?.Get<List<EducationRubric>>("rubrics"); }
            set { BackingStore?.Set("rubrics", value); }
        }
        /// <summary>Schools to which the user belongs. Nullable.</summary>
        public List<EducationSchool> Schools {
            get { return BackingStore?.Get<List<EducationSchool>>("schools"); }
            set { BackingStore?.Set("schools", value); }
        }
        /// <summary>True if the Outlook Global Address List should contain this user; otherwise, false. If not set, this will be treated as true. For users invited through the invitation manager, this property will be set to false.</summary>
        public bool? ShowInAddressList {
            get { return BackingStore?.Get<bool?>("showInAddressList"); }
            set { BackingStore?.Set("showInAddressList", value); }
        }
        /// <summary>If the primary role is student, this block will contain student specific data.</summary>
        public EducationStudent Student {
            get { return BackingStore?.Get<EducationStudent>("student"); }
            set { BackingStore?.Set("student", value); }
        }
        /// <summary>The user&apos;s surname (family name or last name). Supports /$filter.</summary>
        public string Surname {
            get { return BackingStore?.Get<string>("surname"); }
            set { BackingStore?.Set("surname", value); }
        }
        /// <summary>Classes for which the user is a teacher.</summary>
        public List<EducationClass> TaughtClasses {
            get { return BackingStore?.Get<List<EducationClass>>("taughtClasses"); }
            set { BackingStore?.Set("taughtClasses", value); }
        }
        /// <summary>If the primary role is teacher, this block will contain teacher specific data.</summary>
        public EducationTeacher Teacher {
            get { return BackingStore?.Get<EducationTeacher>("teacher"); }
            set { BackingStore?.Set("teacher", value); }
        }
        /// <summary>A two-letter country code ([ISO 3166 Alpha-2]). Required for users who will be assigned licenses. Not nullable. Supports /$filter.</summary>
        public string UsageLocation {
            get { return BackingStore?.Get<string>("usageLocation"); }
            set { BackingStore?.Set("usageLocation", value); }
        }
        /// <summary>The directory user that corresponds to this user.</summary>
        public Microsoft.Graph.Models.User User {
            get { return BackingStore?.Get<Microsoft.Graph.Models.User>("user"); }
            set { BackingStore?.Set("user", value); }
        }
        /// <summary>The user principal name (UPN) for the user. Supports $filter and $orderby. See standard [user] resource for additional details.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>A string value that can be used to classify user types in your directory, such as &apos;Member&apos; and &apos;Guest&apos;. Supports /$filter.</summary>
        public string UserType {
            get { return BackingStore?.Get<string>("userType"); }
            set { BackingStore?.Set("userType", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EducationUser CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationUser();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"accountEnabled", n => { AccountEnabled = n.GetBoolValue(); } },
                {"assignedLicenses", n => { AssignedLicenses = n.GetCollectionOfObjectValues<AssignedLicense>(AssignedLicense.CreateFromDiscriminatorValue).ToList(); } },
                {"assignedPlans", n => { AssignedPlans = n.GetCollectionOfObjectValues<AssignedPlan>(AssignedPlan.CreateFromDiscriminatorValue).ToList(); } },
                {"assignments", n => { Assignments = n.GetCollectionOfObjectValues<EducationAssignment>(EducationAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"businessPhones", n => { BusinessPhones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"classes", n => { Classes = n.GetCollectionOfObjectValues<EducationClass>(EducationClass.CreateFromDiscriminatorValue).ToList(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"department", n => { Department = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"externalSource", n => { ExternalSource = n.GetEnumValue<EducationExternalSource>(); } },
                {"externalSourceDetail", n => { ExternalSourceDetail = n.GetStringValue(); } },
                {"givenName", n => { GivenName = n.GetStringValue(); } },
                {"mail", n => { Mail = n.GetStringValue(); } },
                {"mailingAddress", n => { MailingAddress = n.GetObjectValue<PhysicalAddress>(PhysicalAddress.CreateFromDiscriminatorValue); } },
                {"mailNickname", n => { MailNickname = n.GetStringValue(); } },
                {"middleName", n => { MiddleName = n.GetStringValue(); } },
                {"mobilePhone", n => { MobilePhone = n.GetStringValue(); } },
                {"officeLocation", n => { OfficeLocation = n.GetStringValue(); } },
                {"onPremisesInfo", n => { OnPremisesInfo = n.GetObjectValue<EducationOnPremisesInfo>(EducationOnPremisesInfo.CreateFromDiscriminatorValue); } },
                {"passwordPolicies", n => { PasswordPolicies = n.GetStringValue(); } },
                {"passwordProfile", n => { PasswordProfile = n.GetObjectValue<Microsoft.Graph.Models.PasswordProfile>(Microsoft.Graph.Models.PasswordProfile.CreateFromDiscriminatorValue); } },
                {"preferredLanguage", n => { PreferredLanguage = n.GetStringValue(); } },
                {"primaryRole", n => { PrimaryRole = n.GetEnumValue<EducationUserRole>(); } },
                {"provisionedPlans", n => { ProvisionedPlans = n.GetCollectionOfObjectValues<ProvisionedPlan>(ProvisionedPlan.CreateFromDiscriminatorValue).ToList(); } },
                {"refreshTokensValidFromDateTime", n => { RefreshTokensValidFromDateTime = n.GetDateTimeOffsetValue(); } },
                {"relatedContacts", n => { RelatedContacts = n.GetCollectionOfObjectValues<RelatedContact>(RelatedContact.CreateFromDiscriminatorValue).ToList(); } },
                {"residenceAddress", n => { ResidenceAddress = n.GetObjectValue<PhysicalAddress>(PhysicalAddress.CreateFromDiscriminatorValue); } },
                {"rubrics", n => { Rubrics = n.GetCollectionOfObjectValues<EducationRubric>(EducationRubric.CreateFromDiscriminatorValue).ToList(); } },
                {"schools", n => { Schools = n.GetCollectionOfObjectValues<EducationSchool>(EducationSchool.CreateFromDiscriminatorValue).ToList(); } },
                {"showInAddressList", n => { ShowInAddressList = n.GetBoolValue(); } },
                {"student", n => { Student = n.GetObjectValue<EducationStudent>(EducationStudent.CreateFromDiscriminatorValue); } },
                {"surname", n => { Surname = n.GetStringValue(); } },
                {"taughtClasses", n => { TaughtClasses = n.GetCollectionOfObjectValues<EducationClass>(EducationClass.CreateFromDiscriminatorValue).ToList(); } },
                {"teacher", n => { Teacher = n.GetObjectValue<EducationTeacher>(EducationTeacher.CreateFromDiscriminatorValue); } },
                {"usageLocation", n => { UsageLocation = n.GetStringValue(); } },
                {"user", n => { User = n.GetObjectValue<Microsoft.Graph.Models.User>(Microsoft.Graph.Models.User.CreateFromDiscriminatorValue); } },
                {"userPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
                {"userType", n => { UserType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("accountEnabled", AccountEnabled);
            writer.WriteCollectionOfObjectValues<AssignedLicense>("assignedLicenses", AssignedLicenses);
            writer.WriteCollectionOfObjectValues<AssignedPlan>("assignedPlans", AssignedPlans);
            writer.WriteCollectionOfObjectValues<EducationAssignment>("assignments", Assignments);
            writer.WriteCollectionOfPrimitiveValues<string>("businessPhones", BusinessPhones);
            writer.WriteCollectionOfObjectValues<EducationClass>("classes", Classes);
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteStringValue("department", Department);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteEnumValue<EducationExternalSource>("externalSource", ExternalSource);
            writer.WriteStringValue("externalSourceDetail", ExternalSourceDetail);
            writer.WriteStringValue("givenName", GivenName);
            writer.WriteStringValue("mail", Mail);
            writer.WriteObjectValue<PhysicalAddress>("mailingAddress", MailingAddress);
            writer.WriteStringValue("mailNickname", MailNickname);
            writer.WriteStringValue("middleName", MiddleName);
            writer.WriteStringValue("mobilePhone", MobilePhone);
            writer.WriteStringValue("officeLocation", OfficeLocation);
            writer.WriteObjectValue<EducationOnPremisesInfo>("onPremisesInfo", OnPremisesInfo);
            writer.WriteStringValue("passwordPolicies", PasswordPolicies);
            writer.WriteObjectValue<Microsoft.Graph.Models.PasswordProfile>("passwordProfile", PasswordProfile);
            writer.WriteStringValue("preferredLanguage", PreferredLanguage);
            writer.WriteEnumValue<EducationUserRole>("primaryRole", PrimaryRole);
            writer.WriteCollectionOfObjectValues<ProvisionedPlan>("provisionedPlans", ProvisionedPlans);
            writer.WriteDateTimeOffsetValue("refreshTokensValidFromDateTime", RefreshTokensValidFromDateTime);
            writer.WriteCollectionOfObjectValues<RelatedContact>("relatedContacts", RelatedContacts);
            writer.WriteObjectValue<PhysicalAddress>("residenceAddress", ResidenceAddress);
            writer.WriteCollectionOfObjectValues<EducationRubric>("rubrics", Rubrics);
            writer.WriteCollectionOfObjectValues<EducationSchool>("schools", Schools);
            writer.WriteBoolValue("showInAddressList", ShowInAddressList);
            writer.WriteObjectValue<EducationStudent>("student", Student);
            writer.WriteStringValue("surname", Surname);
            writer.WriteCollectionOfObjectValues<EducationClass>("taughtClasses", TaughtClasses);
            writer.WriteObjectValue<EducationTeacher>("teacher", Teacher);
            writer.WriteStringValue("usageLocation", UsageLocation);
            writer.WriteObjectValue<Microsoft.Graph.Models.User>("user", User);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
            writer.WriteStringValue("userType", UserType);
        }
    }
}
