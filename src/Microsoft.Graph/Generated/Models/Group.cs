using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Group : DirectoryObject, IParsable {
        /// <summary>The list of users or groups that are allowed to create post&apos;s or calendar events in this group. If this list is non-empty then only users or groups listed here are allowed to post.</summary>
        public List<DirectoryObject> AcceptedSenders { get; set; }
        /// <summary>Indicates if people external to the organization can send messages to the group. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? AllowExternalSenders { get; set; }
        /// <summary>Represents the app roles a group has been granted for an application. Supports $expand.</summary>
        public List<AppRoleAssignment> AppRoleAssignments { get; set; }
        /// <summary>The list of sensitivity label pairs (label ID, label name) associated with a Microsoft 365 group. Returned only on $select. Read-only.</summary>
        public List<AssignedLabel> AssignedLabels { get; set; }
        /// <summary>The licenses that are assigned to the group. Returned only on $select. Supports $filter (eq).Read-only.</summary>
        public List<AssignedLicense> AssignedLicenses { get; set; }
        /// <summary>Indicates if new members added to the group will be auto-subscribed to receive email notifications. You can set this property in a PATCH request for the group; do not set it in the initial POST request that creates the group. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? AutoSubscribeNewMembers { get; set; }
        /// <summary>The group&apos;s calendar. Read-only.</summary>
        public Microsoft.Graph.Models.Calendar Calendar { get; set; }
        /// <summary>The calendar view for the calendar. Read-only.</summary>
        public List<Event> CalendarView { get; set; }
        /// <summary>Describes a classification for the group (such as low, medium or high business impact). Valid values for this property are defined by creating a ClassificationList setting value, based on the template definition.Returned by default. Supports $filter (eq, ne, not, ge, le, startsWith).</summary>
        public string Classification { get; set; }
        /// <summary>The group&apos;s conversations.</summary>
        public List<Conversation> Conversations { get; set; }
        /// <summary>Timestamp of when the group was created. The value cannot be modified and is automatically populated when the group is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Supports $filter (eq, ne, not, ge, le, in). Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The user (or application) that created the group. NOTE: This is not set if the user is an administrator. Read-only.</summary>
        public DirectoryObject CreatedOnBehalfOf { get; set; }
        /// <summary>An optional description for the group. Returned by default. Supports $filter (eq, ne, not, ge, le, startsWith) and $search.</summary>
        public string Description { get; set; }
        /// <summary>The display name for the group. This property is required when a group is created and cannot be cleared during updates. Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values), $search, and $orderBy.</summary>
        public string DisplayName { get; set; }
        /// <summary>The group&apos;s default drive. Read-only.</summary>
        public Microsoft.Graph.Models.Drive Drive { get; set; }
        /// <summary>The group&apos;s drives. Read-only.</summary>
        public List<Microsoft.Graph.Models.Drive> Drives { get; set; }
        /// <summary>The group&apos;s calendar events.</summary>
        public List<Event> Events { get; set; }
        /// <summary>Timestamp of when the group is set to expire. The value cannot be modified and is automatically populated when the group is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Supports $filter (eq, ne, not, ge, le, in). Read-only.</summary>
        public DateTimeOffset? ExpirationDateTime { get; set; }
        /// <summary>The collection of open extensions defined for the group. Read-only. Nullable.</summary>
        public List<Extension> Extensions { get; set; }
        /// <summary>The collection of lifecycle policies for this group. Read-only. Nullable.</summary>
        public List<GroupLifecyclePolicy> GroupLifecyclePolicies { get; set; }
        /// <summary>Specifies the group type and its membership. If the collection contains Unified, the group is a Microsoft 365 group; otherwise, it&apos;s either a security group or distribution group. For details, see groups overview.If the collection includes DynamicMembership, the group has dynamic membership; otherwise, membership is static. Returned by default. Supports $filter (eq, not).</summary>
        public List<string> GroupTypes { get; set; }
        /// <summary>Indicates whether there are members in this group that have license errors from its group-based license assignment. This property is never returned on a GET operation. You can use it as a $filter argument to get groups that have members with license errors (that is, filter for this property being true). See an example. Supports $filter (eq).</summary>
        public bool? HasMembersWithLicenseErrors { get; set; }
        /// <summary>True if the group is not displayed in certain parts of the Outlook UI: the Address Book, address lists for selecting message recipients, and the Browse Groups dialog for searching groups; otherwise, false. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? HideFromAddressLists { get; set; }
        /// <summary>True if the group is not displayed in Outlook clients, such as Outlook for Windows and Outlook on the web; otherwise, false. Default value is false. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? HideFromOutlookClients { get; set; }
        /// <summary>When a group is associated with a team this property deternunes whether the team is in read-only mode.</summary>
        public bool? IsArchived { get; set; }
        /// <summary>Indicates whether this group can be assigned to an Azure Active Directory role or not. Optional. This property can only be set while creating the group and is immutable. If set to true, the securityEnabled property must also be set to true and the group cannot be a dynamic group (that is, groupTypes cannot contain DynamicMembership). Only callers in Global administrator and Privileged role administrator roles can set this property. The caller must be assigned the RoleManagement.ReadWrite.Directory permission to set this property or update the membership of such groups. For more, see Using a group to manage Azure AD role assignmentsReturned by default. Supports $filter (eq, ne, not).</summary>
        public bool? IsAssignableToRole { get; set; }
        /// <summary>Indicates whether the signed-in user is subscribed to receive email conversations. Default value is true. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public bool? IsSubscribedByMail { get; set; }
        /// <summary>Indicates status of the group license assignment to all members of the group. Default value is false. Read-only. Possible values: QueuedForProcessing, ProcessingInProgress, and ProcessingComplete.Returned only on $select. Read-only.</summary>
        public Microsoft.Graph.Models.LicenseProcessingState LicenseProcessingState { get; set; }
        /// <summary>The SMTP address for the group, for example, &apos;serviceadmins@contoso.onmicrosoft.com&apos;. Returned by default. Read-only. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values).</summary>
        public string Mail { get; set; }
        /// <summary>Specifies whether the group is mail-enabled. Required. Returned by default. Supports $filter (eq, ne, not).</summary>
        public bool? MailEnabled { get; set; }
        /// <summary>The mail alias for the group, unique for Microsoft 365 groups in the organization. Maximum length is 64 characters. This property can contain only characters in the ASCII character set 0 - 127 except the following: @ () / [] &apos; ; : . &lt;&gt; , SPACE. Required. Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values).</summary>
        public string MailNickname { get; set; }
        /// <summary>Groups that this group is a member of. HTTP Methods: GET (supported for all groups). Read-only. Nullable. Supports $expand.</summary>
        public List<DirectoryObject> MemberOf { get; set; }
        /// <summary>The members of this group, who can be users, devices, other groups, or service principals. Supports the List members, Add member, and Remove member operations. Nullable. Supports $expand including nested $select. For example, /groups?$filter=startsWith(displayName,&apos;Role&apos;)&amp;$select=id,displayName&amp;$expand=members($select=id,userPrincipalName,displayName).</summary>
        public List<DirectoryObject> Members { get; set; }
        /// <summary>The rule that determines members for this group if the group is a dynamic group (groupTypes contains DynamicMembership). For more information about the syntax of the membership rule, see Membership Rules syntax. Returned by default. Supports $filter (eq, ne, not, ge, le, startsWith).</summary>
        public string MembershipRule { get; set; }
        /// <summary>Indicates whether the dynamic membership processing is on or paused. Possible values are On or Paused. Returned by default. Supports $filter (eq, ne, not, in).</summary>
        public string MembershipRuleProcessingState { get; set; }
        /// <summary>A list of group members with license errors from this group-based license assignment. Read-only.</summary>
        public List<DirectoryObject> MembersWithLicenseErrors { get; set; }
        /// <summary>Read-only.</summary>
        public Microsoft.Graph.Models.Onenote Onenote { get; set; }
        /// <summary>Contains the on-premises domain FQDN, also called dnsDomainName synchronized from the on-premises directory. The property is only populated for customers who are synchronizing their on-premises directory to Azure Active Directory via Azure AD Connect.Returned by default. Read-only.</summary>
        public string OnPremisesDomainName { get; set; }
        /// <summary>Indicates the last time at which the group was synced with the on-premises directory.The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Read-only. Supports $filter (eq, ne, not, ge, le, in).</summary>
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        /// <summary>Contains the on-premises netBios name synchronized from the on-premises directory. The property is only populated for customers who are synchronizing their on-premises directory to Azure Active Directory via Azure AD Connect.Returned by default. Read-only.</summary>
        public string OnPremisesNetBiosName { get; set; }
        /// <summary>Errors when using Microsoft synchronization product during provisioning. Returned by default. Supports $filter (eq, not).</summary>
        public List<OnPremisesProvisioningError> OnPremisesProvisioningErrors { get; set; }
        /// <summary>Contains the on-premises SAM account name synchronized from the on-premises directory. The property is only populated for customers who are synchronizing their on-premises directory to Azure Active Directory via Azure AD Connect.Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith). Read-only.</summary>
        public string OnPremisesSamAccountName { get; set; }
        /// <summary>Contains the on-premises security identifier (SID) for the group that was synchronized from on-premises to the cloud. Returned by default. Supports $filter (eq including on null values). Read-only.</summary>
        public string OnPremisesSecurityIdentifier { get; set; }
        /// <summary>true if this group is synced from an on-premises directory; false if this group was originally synced from an on-premises directory but is no longer synced; null if this object has never been synced from an on-premises directory (default). Returned by default. Read-only. Supports $filter (eq, ne, not, in, and eq on null values).</summary>
        public bool? OnPremisesSyncEnabled { get; set; }
        /// <summary>The owners of the group. Limited to 100 owners. Nullable. If this property is not specified when creating a Microsoft 365 group, the calling user is automatically assigned as the group owner. Supports $expand including nested $select. For example, /groups?$filter=startsWith(displayName,&apos;Role&apos;)&amp;$select=id,displayName&amp;$expand=owners($select=id,userPrincipalName,displayName).</summary>
        public List<DirectoryObject> Owners { get; set; }
        /// <summary>The permission that has been granted for a group to a specific application. Supports $expand.</summary>
        public List<ResourceSpecificPermissionGrant> PermissionGrants { get; set; }
        /// <summary>The group&apos;s profile photo</summary>
        public ProfilePhoto Photo { get; set; }
        /// <summary>The profile photos owned by the group. Read-only. Nullable.</summary>
        public List<ProfilePhoto> Photos { get; set; }
        /// <summary>Entry-point to Planner resource that might exist for a Unified Group.</summary>
        public PlannerGroup Planner { get; set; }
        /// <summary>The preferred data location for the Microsoft 365 group. By default, the group inherits the group creator&apos;s preferred data location. To set this property, the calling user must be assigned one of the following Azure AD roles:  Global Administrator  User Account Administrator Directory Writer  Exchange Administrator  SharePoint Administrator  For more information about this property, see OneDrive Online Multi-Geo. Nullable. Returned by default.</summary>
        public string PreferredDataLocation { get; set; }
        /// <summary>The preferred language for a Microsoft 365 group. Should follow ISO 639-1 Code; for example en-US. Returned by default. Supports $filter (eq, ne, not, ge, le, in, startsWith, and eq on null values).</summary>
        public string PreferredLanguage { get; set; }
        /// <summary>Email addresses for the group that direct to the same group mailbox. For example: [&apos;SMTP: bob@contoso.com&apos;, &apos;smtp: bob@sales.contoso.com&apos;]. The any operator is required to filter expressions on multi-valued properties. Returned by default. Read-only. Not nullable. Supports $filter (eq, not, ge, le, startsWith).</summary>
        public List<string> ProxyAddresses { get; set; }
        /// <summary>The list of users or groups that are not allowed to create posts or calendar events in this group. Nullable</summary>
        public List<DirectoryObject> RejectedSenders { get; set; }
        /// <summary>Timestamp of when the group was last renewed. This cannot be modified directly and is only updated via the renew service action. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Returned by default. Supports $filter (eq, ne, not, ge, le, in). Read-only.</summary>
        public DateTimeOffset? RenewedDateTime { get; set; }
        /// <summary>Specifies whether the group is a security group. Required. Returned by default. Supports $filter (eq, ne, not, in).</summary>
        public bool? SecurityEnabled { get; set; }
        /// <summary>Security identifier of the group, used in Windows scenarios. Returned by default.</summary>
        public string SecurityIdentifier { get; set; }
        /// <summary>Settings that can govern this group&apos;s behavior, like whether members can invite guest users to the group. Nullable.</summary>
        public List<GroupSetting> Settings { get; set; }
        /// <summary>The list of SharePoint sites in this group. Access the default site with /sites/root.</summary>
        public List<Site> Sites { get; set; }
        /// <summary>The team associated with this group.</summary>
        public Microsoft.Graph.Models.Team Team { get; set; }
        /// <summary>Specifies a Microsoft 365 group&apos;s color theme. Possible values are Teal, Purple, Green, Blue, Pink, Orange or Red. Returned by default.</summary>
        public string Theme { get; set; }
        /// <summary>The group&apos;s conversation threads. Nullable.</summary>
        public List<ConversationThread> Threads { get; set; }
        /// <summary>The transitiveMemberOf property</summary>
        public List<DirectoryObject> TransitiveMemberOf { get; set; }
        /// <summary>The transitiveMembers property</summary>
        public List<DirectoryObject> TransitiveMembers { get; set; }
        /// <summary>Count of conversations that have received new posts since the signed-in user last visited the group. Returned only on $select. Supported only on the Get group API (GET /groups/{ID}).</summary>
        public int? UnseenCount { get; set; }
        /// <summary>Specifies the group join policy and group content visibility for groups. Possible values are: Private, Public, or Hiddenmembership. Hiddenmembership can be set only for Microsoft 365 groups, when the groups are created. It can&apos;t be updated later. Other values of visibility can be updated after group creation. If visibility value is not specified during group creation on Microsoft Graph, a security group is created as Private by default and Microsoft 365 group is Public. Groups assignable to roles are always Private. See group visibility options to learn more. Returned by default. Nullable.</summary>
        public string Visibility { get; set; }
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
