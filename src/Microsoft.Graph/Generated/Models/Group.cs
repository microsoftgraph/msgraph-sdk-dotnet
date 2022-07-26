using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Group : DirectoryObject, IParsable {
        /// <summary>The list of users or groups that are allowed to create post&apos;s or calendar events in this group. If this list is non-empty then only users or groups listed here are allowed to post.</summary>
        public List<DirectoryObject> AcceptedSenders {
            get { return BackingStore?.Get<List<DirectoryObject>>("acceptedSenders"); }
            set { BackingStore?.Set("acceptedSenders", value); }
        }
        /// <summary>Indicates if people external to the organization can send messages to the group. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? AllowExternalSenders {
            get { return BackingStore?.Get<bool?>("allowExternalSenders"); }
            set { BackingStore?.Set("allowExternalSenders", value); }
        }
        /// <summary>Represents the app roles a group has been granted for an application. Supports $expand.</summary>
        public List<AppRoleAssignment> AppRoleAssignments {
            get { return BackingStore?.Get<List<AppRoleAssignment>>("appRoleAssignments"); }
            set { BackingStore?.Set("appRoleAssignments", value); }
        }
        /// <summary>The list of sensitivity label pairs (label ID, label name) associated with a Microsoft 365 group. Returned only on $select.</summary>
        public List<AssignedLabel> AssignedLabels {
            get { return BackingStore?.Get<List<AssignedLabel>>("assignedLabels"); }
            set { BackingStore?.Set("assignedLabels", value); }
        }
        /// <summary>The licenses that are assigned to the group. Returned only on $select. Supports $filter (eq). Read-only.</summary>
        public List<AssignedLicense> AssignedLicenses {
            get { return BackingStore?.Get<List<AssignedLicense>>("assignedLicenses"); }
            set { BackingStore?.Set("assignedLicenses", value); }
        }
        /// <summary>Indicates if new members added to the group will be auto-subscribed to receive email notifications. You can set this property in a PATCH request for the group; do not set it in the initial POST request that creates the group. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? AutoSubscribeNewMembers {
            get { return BackingStore?.Get<bool?>("autoSubscribeNewMembers"); }
            set { BackingStore?.Set("autoSubscribeNewMembers", value); }
        }
        /// <summary>The group&apos;s calendar. Read-only.</summary>
        public Microsoft.Graph.Models.Calendar Calendar {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Calendar>("calendar"); }
            set { BackingStore?.Set("calendar", value); }
        }
        /// <summary>The calendar view for the calendar. Read-only.</summary>
        public List<Event> CalendarView {
            get { return BackingStore?.Get<List<Event>>("calendarView"); }
            set { BackingStore?.Set("calendarView", value); }
        }
        /// <summary>Describes a classification for the group (such as low, medium or high business impact). Valid values for this property are defined by creating a ClassificationList setting value, based on the template definition.Returned by default. Supports $filter (eq, ne, not, ge, le, startsWith).</summary>
        public string Classification {
            get { return BackingStore?.Get<string>("classification"); }
            set { BackingStore?.Set("classification", value); }
        }
        /// <summary>The group&apos;s conversations.</summary>
        public List<Conversation> Conversations {
            get { return BackingStore?.Get<List<Conversation>>("conversations"); }
            set { BackingStore?.Set("conversations", value); }
        }
        /// <summary>Timestamp of when the group was created. The value cannot be modified and is automatically populated when the group is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Supports $filter (eq, ne, not, ge, le, in). Read-only.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The user (or application) that created the group. Note: This is not set if the user is an administrator. Read-only.</summary>
        public DirectoryObject CreatedOnBehalfOf {
            get { return BackingStore?.Get<DirectoryObject>("createdOnBehalfOf"); }
            set { BackingStore?.Set("createdOnBehalfOf", value); }
        }
        /// <summary>An optional description for the group. Returned by default. Supports $filter (eq, ne, not, ge, le, startsWith) and $search.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The display name for the group. Required. Maximum length is 256 characters. Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values), $search, and $orderBy.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The group&apos;s default drive. Read-only.</summary>
        public Microsoft.Graph.Models.Drive Drive {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Drive>("drive"); }
            set { BackingStore?.Set("drive", value); }
        }
        /// <summary>The group&apos;s drives. Read-only.</summary>
        public List<Microsoft.Graph.Models.Drive> Drives {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.Drive>>("drives"); }
            set { BackingStore?.Set("drives", value); }
        }
        /// <summary>The group&apos;s events.</summary>
        public List<Event> Events {
            get { return BackingStore?.Get<List<Event>>("events"); }
            set { BackingStore?.Set("events", value); }
        }
        /// <summary>Timestamp of when the group is set to expire. The value cannot be modified and is automatically populated when the group is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Supports $filter (eq, ne, not, ge, le, in). Read-only.</summary>
        public DateTimeOffset? ExpirationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("expirationDateTime"); }
            set { BackingStore?.Set("expirationDateTime", value); }
        }
        /// <summary>The collection of open extensions defined for the group. Read-only. Nullable.</summary>
        public List<Extension> Extensions {
            get { return BackingStore?.Get<List<Extension>>("extensions"); }
            set { BackingStore?.Set("extensions", value); }
        }
        /// <summary>The collection of lifecycle policies for this group. Read-only. Nullable.</summary>
        public List<GroupLifecyclePolicy> GroupLifecyclePolicies {
            get { return BackingStore?.Get<List<GroupLifecyclePolicy>>("groupLifecyclePolicies"); }
            set { BackingStore?.Set("groupLifecyclePolicies", value); }
        }
        /// <summary>Specifies the group type and its membership. If the collection contains Unified, the group is a Microsoft 365 group; otherwise, it&apos;s either a security group or distribution group. For details, see groups overview.If the collection includes DynamicMembership, the group has dynamic membership; otherwise, membership is static. Returned by default. Supports $filter (eq, not).</summary>
        public List<string> GroupTypes {
            get { return BackingStore?.Get<List<string>>("groupTypes"); }
            set { BackingStore?.Set("groupTypes", value); }
        }
        /// <summary>Indicates whether there are members in this group that have license errors from its group-based license assignment. This property is never returned on a GET operation. You can use it as a $filter argument to get groups that have members with license errors (that is, filter for this property being true).  Supports $filter (eq).</summary>
        public bool? HasMembersWithLicenseErrors {
            get { return BackingStore?.Get<bool?>("hasMembersWithLicenseErrors"); }
            set { BackingStore?.Set("hasMembersWithLicenseErrors", value); }
        }
        /// <summary>true if the group is not displayed in certain parts of the Outlook user interface: in the Address Book, in address lists for selecting message recipients, and in the Browse Groups dialog for searching groups; false otherwise. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? HideFromAddressLists {
            get { return BackingStore?.Get<bool?>("hideFromAddressLists"); }
            set { BackingStore?.Set("hideFromAddressLists", value); }
        }
        /// <summary>true if the group is not displayed in Outlook clients, such as Outlook for Windows and Outlook on the web, false otherwise. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? HideFromOutlookClients {
            get { return BackingStore?.Get<bool?>("hideFromOutlookClients"); }
            set { BackingStore?.Set("hideFromOutlookClients", value); }
        }
        /// <summary>When a group is associated with a team, this property determines whether the team is in read-only mode. To read this property, use the /group/{groupId}/team endpoint or the Get team API. To update this property, use the archiveTeam and unarchiveTeam APIs.</summary>
        public bool? IsArchived {
            get { return BackingStore?.Get<bool?>("isArchived"); }
            set { BackingStore?.Set("isArchived", value); }
        }
        /// <summary>Indicates whether this group can be assigned to an Azure Active Directory role. Optional. This property can only be set while creating the group and is immutable. If set to true, the securityEnabled property must also be set to true and the group cannot be a dynamic group (that is, groupTypes cannot contain DynamicMembership). Only callers in Global administrator and Privileged role administrator roles can set this property. The caller must be assigned the RoleManagement.ReadWrite.Directory permission to set this property or update the membership of such groups. For more, see Using a group to manage Azure AD role assignmentsReturned by default. Supports $filter (eq, ne, not).</summary>
        public bool? IsAssignableToRole {
            get { return BackingStore?.Get<bool?>("isAssignableToRole"); }
            set { BackingStore?.Set("isAssignableToRole", value); }
        }
        /// <summary>Indicates whether the signed-in user is subscribed to receive email conversations. Default value is true. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? IsSubscribedByMail {
            get { return BackingStore?.Get<bool?>("isSubscribedByMail"); }
            set { BackingStore?.Set("isSubscribedByMail", value); }
        }
        /// <summary>Indicates status of the group license assignment to all members of the group. Possible values: QueuedForProcessing, ProcessingInProgress, and ProcessingComplete. Returned only on $select. Read-only.</summary>
        public Microsoft.Graph.Models.LicenseProcessingState LicenseProcessingState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.LicenseProcessingState>("licenseProcessingState"); }
            set { BackingStore?.Set("licenseProcessingState", value); }
        }
        /// <summary>The SMTP address for the group, for example, &apos;serviceadmins@contoso.onmicrosoft.com&apos;. Returned by default. Read-only. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values).</summary>
        public string Mail {
            get { return BackingStore?.Get<string>("mail"); }
            set { BackingStore?.Set("mail", value); }
        }
        /// <summary>Specifies whether the group is mail-enabled. Required. Returned by default. Supports $filter (eq, ne, not, and eq on null values).</summary>
        public bool? MailEnabled {
            get { return BackingStore?.Get<bool?>("mailEnabled"); }
            set { BackingStore?.Set("mailEnabled", value); }
        }
        /// <summary>The mail alias for the group, unique for Microsoft 365 groups in the organization. Maximum length is 64 characters. This property can contain only characters in the ASCII character set 0 - 127 except the following: @ () / [] &apos; ; : . &lt;&gt; , SPACE. Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith).</summary>
        public string MailNickname {
            get { return BackingStore?.Get<string>("mailNickname"); }
            set { BackingStore?.Set("mailNickname", value); }
        }
        /// <summary>Groups and administrative units that this group is a member of. HTTP Methods: GET (supported for all groups). Read-only. Nullable. Supports $expand.</summary>
        public List<DirectoryObject> MemberOf {
            get { return BackingStore?.Get<List<DirectoryObject>>("memberOf"); }
            set { BackingStore?.Set("memberOf", value); }
        }
        /// <summary>Direct members of this group, who can be users, devices, other groups, or service principals. Supports the List members, Add member, and Remove member operations. Nullable. Supports $expand including nested $select. For example, /groups?$filter=startsWith(displayName,&apos;Role&apos;)&amp;$select=id,displayName&amp;$expand=members($select=id,userPrincipalName,displayName).</summary>
        public List<DirectoryObject> Members {
            get { return BackingStore?.Get<List<DirectoryObject>>("members"); }
            set { BackingStore?.Set("members", value); }
        }
        /// <summary>The rule that determines members for this group if the group is a dynamic group (groupTypes contains DynamicMembership). For more information about the syntax of the membership rule, see Membership Rules syntax. Returned by default. Supports $filter (eq, ne, not, ge, le, startsWith).</summary>
        public string MembershipRule {
            get { return BackingStore?.Get<string>("membershipRule"); }
            set { BackingStore?.Set("membershipRule", value); }
        }
        /// <summary>Indicates whether the dynamic membership processing is on or paused. Possible values are On or Paused. Returned by default. Supports $filter (eq, ne, not, in).</summary>
        public string MembershipRuleProcessingState {
            get { return BackingStore?.Get<string>("membershipRuleProcessingState"); }
            set { BackingStore?.Set("membershipRuleProcessingState", value); }
        }
        /// <summary>A list of group members with license errors from this group-based license assignment. Read-only.</summary>
        public List<DirectoryObject> MembersWithLicenseErrors {
            get { return BackingStore?.Get<List<DirectoryObject>>("membersWithLicenseErrors"); }
            set { BackingStore?.Set("membersWithLicenseErrors", value); }
        }
        /// <summary>The onenote property</summary>
        public Microsoft.Graph.Models.Onenote Onenote {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Onenote>("onenote"); }
            set { BackingStore?.Set("onenote", value); }
        }
        /// <summary>Contains the on-premises domain FQDN, also called dnsDomainName synchronized from the on-premises directory. The property is only populated for customers who are synchronizing their on-premises directory to Azure Active Directory via Azure AD Connect.Returned by default. Read-only.</summary>
        public string OnPremisesDomainName {
            get { return BackingStore?.Get<string>("onPremisesDomainName"); }
            set { BackingStore?.Set("onPremisesDomainName", value); }
        }
        /// <summary>Indicates the last time at which the group was synced with the on-premises directory.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Read-only. Supports $filter (eq, ne, not, ge, le, in).</summary>
        public DateTimeOffset? OnPremisesLastSyncDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("onPremisesLastSyncDateTime"); }
            set { BackingStore?.Set("onPremisesLastSyncDateTime", value); }
        }
        /// <summary>Contains the on-premises netBios name synchronized from the on-premises directory. The property is only populated for customers who are synchronizing their on-premises directory to Azure Active Directory via Azure AD Connect.Returned by default. Read-only.</summary>
        public string OnPremisesNetBiosName {
            get { return BackingStore?.Get<string>("onPremisesNetBiosName"); }
            set { BackingStore?.Set("onPremisesNetBiosName", value); }
        }
        /// <summary>Errors when using Microsoft synchronization product during provisioning. Returned by default. Supports $filter (eq, not).</summary>
        public List<OnPremisesProvisioningError> OnPremisesProvisioningErrors {
            get { return BackingStore?.Get<List<OnPremisesProvisioningError>>("onPremisesProvisioningErrors"); }
            set { BackingStore?.Set("onPremisesProvisioningErrors", value); }
        }
        /// <summary>Contains the on-premises SAM account name synchronized from the on-premises directory. The property is only populated for customers who are synchronizing their on-premises directory to Azure Active Directory via Azure AD Connect.Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith). Read-only.</summary>
        public string OnPremisesSamAccountName {
            get { return BackingStore?.Get<string>("onPremisesSamAccountName"); }
            set { BackingStore?.Set("onPremisesSamAccountName", value); }
        }
        /// <summary>Contains the on-premises security identifier (SID) for the group that was synchronized from on-premises to the cloud. Returned by default. Supports $filter (eq including on null values). Read-only.</summary>
        public string OnPremisesSecurityIdentifier {
            get { return BackingStore?.Get<string>("onPremisesSecurityIdentifier"); }
            set { BackingStore?.Set("onPremisesSecurityIdentifier", value); }
        }
        /// <summary>true if this group is synced from an on-premises directory; false if this group was originally synced from an on-premises directory but is no longer synced; null if this object has never been synced from an on-premises directory (default). Returned by default. Read-only. Supports $filter (eq, ne, not, in, and eq on null values).</summary>
        public bool? OnPremisesSyncEnabled {
            get { return BackingStore?.Get<bool?>("onPremisesSyncEnabled"); }
            set { BackingStore?.Set("onPremisesSyncEnabled", value); }
        }
        /// <summary>The owners of the group who can be users or service principals. Nullable. If this property is not specified when creating a Microsoft 365 group, the calling user is automatically assigned as the group owner. Supports $expand including nested $select. For example, /groups?$filter=startsWith(displayName,&apos;Role&apos;)&amp;$select=id,displayName&amp;$expand=owners($select=id,userPrincipalName,displayName).</summary>
        public List<DirectoryObject> Owners {
            get { return BackingStore?.Get<List<DirectoryObject>>("owners"); }
            set { BackingStore?.Set("owners", value); }
        }
        /// <summary>The permissions that have been granted for a group to a specific application. Supports $expand.</summary>
        public List<ResourceSpecificPermissionGrant> PermissionGrants {
            get { return BackingStore?.Get<List<ResourceSpecificPermissionGrant>>("permissionGrants"); }
            set { BackingStore?.Set("permissionGrants", value); }
        }
        /// <summary>The group&apos;s profile photo.</summary>
        public ProfilePhoto Photo {
            get { return BackingStore?.Get<ProfilePhoto>("photo"); }
            set { BackingStore?.Set("photo", value); }
        }
        /// <summary>The profile photos owned by the group. Read-only. Nullable.</summary>
        public List<ProfilePhoto> Photos {
            get { return BackingStore?.Get<List<ProfilePhoto>>("photos"); }
            set { BackingStore?.Set("photos", value); }
        }
        /// <summary>Selective Planner services available to the group. Read-only. Nullable.</summary>
        public PlannerGroup Planner {
            get { return BackingStore?.Get<PlannerGroup>("planner"); }
            set { BackingStore?.Set("planner", value); }
        }
        /// <summary>The preferred data location for the Microsoft 365 group. By default, the group inherits the group creator&apos;s preferred data location. To set this property, the calling user must be assigned one of the following Azure AD roles:  Global Administrator  User Account Administrator Directory Writer  Exchange Administrator  SharePoint Administrator  For more information about this property, see OneDrive Online Multi-Geo. Nullable. Returned by default.</summary>
        public string PreferredDataLocation {
            get { return BackingStore?.Get<string>("preferredDataLocation"); }
            set { BackingStore?.Set("preferredDataLocation", value); }
        }
        /// <summary>The preferred language for a Microsoft 365 group. Should follow ISO 639-1 Code; for example en-US. Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values).</summary>
        public string PreferredLanguage {
            get { return BackingStore?.Get<string>("preferredLanguage"); }
            set { BackingStore?.Set("preferredLanguage", value); }
        }
        /// <summary>Email addresses for the group that direct to the same group mailbox. For example: [&apos;SMTP: bob@contoso.com&apos;, &apos;smtp: bob@sales.contoso.com&apos;]. The any operator is required for filter expressions on multi-valued properties. Returned by default. Read-only. Not nullable. Supports $filter (eq, not, ge, le, startsWith, endsWith, and counting empty collections).</summary>
        public List<string> ProxyAddresses {
            get { return BackingStore?.Get<List<string>>("proxyAddresses"); }
            set { BackingStore?.Set("proxyAddresses", value); }
        }
        /// <summary>The list of users or groups that are not allowed to create posts or calendar events in this group. Nullable</summary>
        public List<DirectoryObject> RejectedSenders {
            get { return BackingStore?.Get<List<DirectoryObject>>("rejectedSenders"); }
            set { BackingStore?.Set("rejectedSenders", value); }
        }
        /// <summary>Timestamp of when the group was last renewed. This cannot be modified directly and is only updated via the renew service action. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Supports $filter (eq, ne, not, ge, le, in). Read-only.</summary>
        public DateTimeOffset? RenewedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("renewedDateTime"); }
            set { BackingStore?.Set("renewedDateTime", value); }
        }
        /// <summary>Specifies whether the group is a security group. Required.Returned by default. Supports $filter (eq, ne, not, in).</summary>
        public bool? SecurityEnabled {
            get { return BackingStore?.Get<bool?>("securityEnabled"); }
            set { BackingStore?.Set("securityEnabled", value); }
        }
        /// <summary>Security identifier of the group, used in Windows scenarios. Returned by default.</summary>
        public string SecurityIdentifier {
            get { return BackingStore?.Get<string>("securityIdentifier"); }
            set { BackingStore?.Set("securityIdentifier", value); }
        }
        /// <summary>Settings that can govern this group&apos;s behavior, like whether members can invite guest users to the group. Nullable.</summary>
        public List<GroupSetting> Settings {
            get { return BackingStore?.Get<List<GroupSetting>>("settings"); }
            set { BackingStore?.Set("settings", value); }
        }
        /// <summary>The list of SharePoint sites in this group. Access the default site with /sites/root.</summary>
        public List<Site> Sites {
            get { return BackingStore?.Get<List<Site>>("sites"); }
            set { BackingStore?.Set("sites", value); }
        }
        /// <summary>The team associated with this group.</summary>
        public Microsoft.Graph.Models.Team Team {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Team>("team"); }
            set { BackingStore?.Set("team", value); }
        }
        /// <summary>Specifies a Microsoft 365 group&apos;s color theme. Possible values are Teal, Purple, Green, Blue, Pink, Orange or Red. Returned by default.</summary>
        public string Theme {
            get { return BackingStore?.Get<string>("theme"); }
            set { BackingStore?.Set("theme", value); }
        }
        /// <summary>The group&apos;s conversation threads. Nullable.</summary>
        public List<ConversationThread> Threads {
            get { return BackingStore?.Get<List<ConversationThread>>("threads"); }
            set { BackingStore?.Set("threads", value); }
        }
        /// <summary>The groups that a group is a member of, either directly and through nested membership. Nullable.</summary>
        public List<DirectoryObject> TransitiveMemberOf {
            get { return BackingStore?.Get<List<DirectoryObject>>("transitiveMemberOf"); }
            set { BackingStore?.Set("transitiveMemberOf", value); }
        }
        /// <summary>The direct and transitive members of a group. Nullable.</summary>
        public List<DirectoryObject> TransitiveMembers {
            get { return BackingStore?.Get<List<DirectoryObject>>("transitiveMembers"); }
            set { BackingStore?.Set("transitiveMembers", value); }
        }
        /// <summary>Count of conversations that have received new posts since the signed-in user last visited the group. This property is the same as unseenConversationsCount.Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public int? UnseenCount {
            get { return BackingStore?.Get<int?>("unseenCount"); }
            set { BackingStore?.Set("unseenCount", value); }
        }
        /// <summary>Specifies the group join policy and group content visibility for groups. Possible values are: Private, Public, or HiddenMembership. HiddenMembership can be set only for Microsoft 365 groups, when the groups are created. It can&apos;t be updated later. Other values of visibility can be updated after group creation. If visibility value is not specified during group creation on Microsoft Graph, a security group is created as Private by default and Microsoft 365 group is Public. Groups assignable to roles are always Private. See group visibility options to learn more. Returned by default. Nullable.</summary>
        public string Visibility {
            get { return BackingStore?.Get<string>("visibility"); }
            set { BackingStore?.Set("visibility", value); }
        }
        /// <summary>
        /// Instantiates a new group and sets the default values.
        /// </summary>
        public Group() : base() {
            OdataType = "#microsoft.graph.group";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Group CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Group();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"acceptedSenders", n => { AcceptedSenders = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"allowExternalSenders", n => { AllowExternalSenders = n.GetBoolValue(); } },
                {"appRoleAssignments", n => { AppRoleAssignments = n.GetCollectionOfObjectValues<AppRoleAssignment>(AppRoleAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"assignedLabels", n => { AssignedLabels = n.GetCollectionOfObjectValues<AssignedLabel>(AssignedLabel.CreateFromDiscriminatorValue).ToList(); } },
                {"assignedLicenses", n => { AssignedLicenses = n.GetCollectionOfObjectValues<AssignedLicense>(AssignedLicense.CreateFromDiscriminatorValue).ToList(); } },
                {"autoSubscribeNewMembers", n => { AutoSubscribeNewMembers = n.GetBoolValue(); } },
                {"calendar", n => { Calendar = n.GetObjectValue<Microsoft.Graph.Models.Calendar>(Microsoft.Graph.Models.Calendar.CreateFromDiscriminatorValue); } },
                {"calendarView", n => { CalendarView = n.GetCollectionOfObjectValues<Event>(Event.CreateFromDiscriminatorValue).ToList(); } },
                {"classification", n => { Classification = n.GetStringValue(); } },
                {"conversations", n => { Conversations = n.GetCollectionOfObjectValues<Conversation>(Conversation.CreateFromDiscriminatorValue).ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdOnBehalfOf", n => { CreatedOnBehalfOf = n.GetObjectValue<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"drive", n => { Drive = n.GetObjectValue<Microsoft.Graph.Models.Drive>(Microsoft.Graph.Models.Drive.CreateFromDiscriminatorValue); } },
                {"drives", n => { Drives = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.Drive>(Microsoft.Graph.Models.Drive.CreateFromDiscriminatorValue).ToList(); } },
                {"events", n => { Events = n.GetCollectionOfObjectValues<Event>(Event.CreateFromDiscriminatorValue).ToList(); } },
                {"expirationDateTime", n => { ExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"extensions", n => { Extensions = n.GetCollectionOfObjectValues<Extension>(Extension.CreateFromDiscriminatorValue).ToList(); } },
                {"groupLifecyclePolicies", n => { GroupLifecyclePolicies = n.GetCollectionOfObjectValues<GroupLifecyclePolicy>(GroupLifecyclePolicy.CreateFromDiscriminatorValue).ToList(); } },
                {"groupTypes", n => { GroupTypes = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"hasMembersWithLicenseErrors", n => { HasMembersWithLicenseErrors = n.GetBoolValue(); } },
                {"hideFromAddressLists", n => { HideFromAddressLists = n.GetBoolValue(); } },
                {"hideFromOutlookClients", n => { HideFromOutlookClients = n.GetBoolValue(); } },
                {"isArchived", n => { IsArchived = n.GetBoolValue(); } },
                {"isAssignableToRole", n => { IsAssignableToRole = n.GetBoolValue(); } },
                {"isSubscribedByMail", n => { IsSubscribedByMail = n.GetBoolValue(); } },
                {"licenseProcessingState", n => { LicenseProcessingState = n.GetObjectValue<Microsoft.Graph.Models.LicenseProcessingState>(Microsoft.Graph.Models.LicenseProcessingState.CreateFromDiscriminatorValue); } },
                {"mail", n => { Mail = n.GetStringValue(); } },
                {"mailEnabled", n => { MailEnabled = n.GetBoolValue(); } },
                {"mailNickname", n => { MailNickname = n.GetStringValue(); } },
                {"memberOf", n => { MemberOf = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"members", n => { Members = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"membershipRule", n => { MembershipRule = n.GetStringValue(); } },
                {"membershipRuleProcessingState", n => { MembershipRuleProcessingState = n.GetStringValue(); } },
                {"membersWithLicenseErrors", n => { MembersWithLicenseErrors = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"onenote", n => { Onenote = n.GetObjectValue<Microsoft.Graph.Models.Onenote>(Microsoft.Graph.Models.Onenote.CreateFromDiscriminatorValue); } },
                {"onPremisesDomainName", n => { OnPremisesDomainName = n.GetStringValue(); } },
                {"onPremisesLastSyncDateTime", n => { OnPremisesLastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"onPremisesNetBiosName", n => { OnPremisesNetBiosName = n.GetStringValue(); } },
                {"onPremisesProvisioningErrors", n => { OnPremisesProvisioningErrors = n.GetCollectionOfObjectValues<OnPremisesProvisioningError>(OnPremisesProvisioningError.CreateFromDiscriminatorValue).ToList(); } },
                {"onPremisesSamAccountName", n => { OnPremisesSamAccountName = n.GetStringValue(); } },
                {"onPremisesSecurityIdentifier", n => { OnPremisesSecurityIdentifier = n.GetStringValue(); } },
                {"onPremisesSyncEnabled", n => { OnPremisesSyncEnabled = n.GetBoolValue(); } },
                {"owners", n => { Owners = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"permissionGrants", n => { PermissionGrants = n.GetCollectionOfObjectValues<ResourceSpecificPermissionGrant>(ResourceSpecificPermissionGrant.CreateFromDiscriminatorValue).ToList(); } },
                {"photo", n => { Photo = n.GetObjectValue<ProfilePhoto>(ProfilePhoto.CreateFromDiscriminatorValue); } },
                {"photos", n => { Photos = n.GetCollectionOfObjectValues<ProfilePhoto>(ProfilePhoto.CreateFromDiscriminatorValue).ToList(); } },
                {"planner", n => { Planner = n.GetObjectValue<PlannerGroup>(PlannerGroup.CreateFromDiscriminatorValue); } },
                {"preferredDataLocation", n => { PreferredDataLocation = n.GetStringValue(); } },
                {"preferredLanguage", n => { PreferredLanguage = n.GetStringValue(); } },
                {"proxyAddresses", n => { ProxyAddresses = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"rejectedSenders", n => { RejectedSenders = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"renewedDateTime", n => { RenewedDateTime = n.GetDateTimeOffsetValue(); } },
                {"securityEnabled", n => { SecurityEnabled = n.GetBoolValue(); } },
                {"securityIdentifier", n => { SecurityIdentifier = n.GetStringValue(); } },
                {"settings", n => { Settings = n.GetCollectionOfObjectValues<GroupSetting>(GroupSetting.CreateFromDiscriminatorValue).ToList(); } },
                {"sites", n => { Sites = n.GetCollectionOfObjectValues<Site>(Site.CreateFromDiscriminatorValue).ToList(); } },
                {"team", n => { Team = n.GetObjectValue<Microsoft.Graph.Models.Team>(Microsoft.Graph.Models.Team.CreateFromDiscriminatorValue); } },
                {"theme", n => { Theme = n.GetStringValue(); } },
                {"threads", n => { Threads = n.GetCollectionOfObjectValues<ConversationThread>(ConversationThread.CreateFromDiscriminatorValue).ToList(); } },
                {"transitiveMemberOf", n => { TransitiveMemberOf = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"transitiveMembers", n => { TransitiveMembers = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"unseenCount", n => { UnseenCount = n.GetIntValue(); } },
                {"visibility", n => { Visibility = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("acceptedSenders", AcceptedSenders);
            writer.WriteBoolValue("allowExternalSenders", AllowExternalSenders);
            writer.WriteCollectionOfObjectValues<AppRoleAssignment>("appRoleAssignments", AppRoleAssignments);
            writer.WriteCollectionOfObjectValues<AssignedLabel>("assignedLabels", AssignedLabels);
            writer.WriteCollectionOfObjectValues<AssignedLicense>("assignedLicenses", AssignedLicenses);
            writer.WriteBoolValue("autoSubscribeNewMembers", AutoSubscribeNewMembers);
            writer.WriteObjectValue<Microsoft.Graph.Models.Calendar>("calendar", Calendar);
            writer.WriteCollectionOfObjectValues<Event>("calendarView", CalendarView);
            writer.WriteStringValue("classification", Classification);
            writer.WriteCollectionOfObjectValues<Conversation>("conversations", Conversations);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<DirectoryObject>("createdOnBehalfOf", CreatedOnBehalfOf);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<Microsoft.Graph.Models.Drive>("drive", Drive);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.Drive>("drives", Drives);
            writer.WriteCollectionOfObjectValues<Event>("events", Events);
            writer.WriteDateTimeOffsetValue("expirationDateTime", ExpirationDateTime);
            writer.WriteCollectionOfObjectValues<Extension>("extensions", Extensions);
            writer.WriteCollectionOfObjectValues<GroupLifecyclePolicy>("groupLifecyclePolicies", GroupLifecyclePolicies);
            writer.WriteCollectionOfPrimitiveValues<string>("groupTypes", GroupTypes);
            writer.WriteBoolValue("hasMembersWithLicenseErrors", HasMembersWithLicenseErrors);
            writer.WriteBoolValue("hideFromAddressLists", HideFromAddressLists);
            writer.WriteBoolValue("hideFromOutlookClients", HideFromOutlookClients);
            writer.WriteBoolValue("isArchived", IsArchived);
            writer.WriteBoolValue("isAssignableToRole", IsAssignableToRole);
            writer.WriteBoolValue("isSubscribedByMail", IsSubscribedByMail);
            writer.WriteObjectValue<Microsoft.Graph.Models.LicenseProcessingState>("licenseProcessingState", LicenseProcessingState);
            writer.WriteStringValue("mail", Mail);
            writer.WriteBoolValue("mailEnabled", MailEnabled);
            writer.WriteStringValue("mailNickname", MailNickname);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("memberOf", MemberOf);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("members", Members);
            writer.WriteStringValue("membershipRule", MembershipRule);
            writer.WriteStringValue("membershipRuleProcessingState", MembershipRuleProcessingState);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("membersWithLicenseErrors", MembersWithLicenseErrors);
            writer.WriteObjectValue<Microsoft.Graph.Models.Onenote>("onenote", Onenote);
            writer.WriteStringValue("onPremisesDomainName", OnPremisesDomainName);
            writer.WriteDateTimeOffsetValue("onPremisesLastSyncDateTime", OnPremisesLastSyncDateTime);
            writer.WriteStringValue("onPremisesNetBiosName", OnPremisesNetBiosName);
            writer.WriteCollectionOfObjectValues<OnPremisesProvisioningError>("onPremisesProvisioningErrors", OnPremisesProvisioningErrors);
            writer.WriteStringValue("onPremisesSamAccountName", OnPremisesSamAccountName);
            writer.WriteStringValue("onPremisesSecurityIdentifier", OnPremisesSecurityIdentifier);
            writer.WriteBoolValue("onPremisesSyncEnabled", OnPremisesSyncEnabled);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("owners", Owners);
            writer.WriteCollectionOfObjectValues<ResourceSpecificPermissionGrant>("permissionGrants", PermissionGrants);
            writer.WriteObjectValue<ProfilePhoto>("photo", Photo);
            writer.WriteCollectionOfObjectValues<ProfilePhoto>("photos", Photos);
            writer.WriteObjectValue<PlannerGroup>("planner", Planner);
            writer.WriteStringValue("preferredDataLocation", PreferredDataLocation);
            writer.WriteStringValue("preferredLanguage", PreferredLanguage);
            writer.WriteCollectionOfPrimitiveValues<string>("proxyAddresses", ProxyAddresses);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("rejectedSenders", RejectedSenders);
            writer.WriteDateTimeOffsetValue("renewedDateTime", RenewedDateTime);
            writer.WriteBoolValue("securityEnabled", SecurityEnabled);
            writer.WriteStringValue("securityIdentifier", SecurityIdentifier);
            writer.WriteCollectionOfObjectValues<GroupSetting>("settings", Settings);
            writer.WriteCollectionOfObjectValues<Site>("sites", Sites);
            writer.WriteObjectValue<Microsoft.Graph.Models.Team>("team", Team);
            writer.WriteStringValue("theme", Theme);
            writer.WriteCollectionOfObjectValues<ConversationThread>("threads", Threads);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("transitiveMemberOf", TransitiveMemberOf);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("transitiveMembers", TransitiveMembers);
            writer.WriteIntValue("unseenCount", UnseenCount);
            writer.WriteStringValue("visibility", Visibility);
        }
    }
}
