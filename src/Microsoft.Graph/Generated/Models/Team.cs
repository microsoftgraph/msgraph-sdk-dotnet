using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class Team : Entity, IParsable {
        /// <summary>List of channels either hosted in or shared with the team (incoming channels).</summary>
        public List<Channel> AllChannels {
            get { return BackingStore?.Get<List<Channel>>("allChannels"); }
            set { BackingStore?.Set("allChannels", value); }
        }
        /// <summary>The collection of channels and messages associated with the team.</summary>
        public List<Channel> Channels {
            get { return BackingStore?.Get<List<Channel>>("channels"); }
            set { BackingStore?.Set("channels", value); }
        }
        /// <summary>An optional label. Typically describes the data or business sensitivity of the team. Must match one of a pre-configured set in the tenant&apos;s directory.</summary>
        public string Classification {
            get { return BackingStore?.Get<string>("classification"); }
            set { BackingStore?.Set("classification", value); }
        }
        /// <summary>Timestamp at which the team was created.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>An optional description for the team. Maximum length: 1024 characters.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The name of the team.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Settings to configure use of Giphy, memes, and stickers in the team.</summary>
        public TeamFunSettings FunSettings {
            get { return BackingStore?.Get<TeamFunSettings>("funSettings"); }
            set { BackingStore?.Set("funSettings", value); }
        }
        /// <summary>The group property</summary>
        public Microsoft.Graph.Models.Group Group {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Group>("group"); }
            set { BackingStore?.Set("group", value); }
        }
        /// <summary>Settings to configure whether guests can create, update, or delete channels in the team.</summary>
        public TeamGuestSettings GuestSettings {
            get { return BackingStore?.Get<TeamGuestSettings>("guestSettings"); }
            set { BackingStore?.Set("guestSettings", value); }
        }
        /// <summary>List of channels shared with the team.</summary>
        public List<Channel> IncomingChannels {
            get { return BackingStore?.Get<List<Channel>>("incomingChannels"); }
            set { BackingStore?.Set("incomingChannels", value); }
        }
        /// <summary>The apps installed in this team.</summary>
        public List<TeamsAppInstallation> InstalledApps {
            get { return BackingStore?.Get<List<TeamsAppInstallation>>("installedApps"); }
            set { BackingStore?.Set("installedApps", value); }
        }
        /// <summary>A unique ID for the team that has been used in a few places such as the audit log/Office 365 Management Activity API.</summary>
        public string InternalId {
            get { return BackingStore?.Get<string>("internalId"); }
            set { BackingStore?.Set("internalId", value); }
        }
        /// <summary>Whether this team is in read-only mode.</summary>
        public bool? IsArchived {
            get { return BackingStore?.Get<bool?>("isArchived"); }
            set { BackingStore?.Set("isArchived", value); }
        }
        /// <summary>Members and owners of the team.</summary>
        public List<ConversationMember> Members {
            get { return BackingStore?.Get<List<ConversationMember>>("members"); }
            set { BackingStore?.Set("members", value); }
        }
        /// <summary>Settings to configure whether members can perform certain actions, for example, create channels and add bots, in the team.</summary>
        public TeamMemberSettings MemberSettings {
            get { return BackingStore?.Get<TeamMemberSettings>("memberSettings"); }
            set { BackingStore?.Set("memberSettings", value); }
        }
        /// <summary>Settings to configure messaging and mentions in the team.</summary>
        public TeamMessagingSettings MessagingSettings {
            get { return BackingStore?.Get<TeamMessagingSettings>("messagingSettings"); }
            set { BackingStore?.Set("messagingSettings", value); }
        }
        /// <summary>The async operations that ran or are running on this team.</summary>
        public List<TeamsAsyncOperation> Operations {
            get { return BackingStore?.Get<List<TeamsAsyncOperation>>("operations"); }
            set { BackingStore?.Set("operations", value); }
        }
        /// <summary>The general channel for the team.</summary>
        public Channel PrimaryChannel {
            get { return BackingStore?.Get<Channel>("primaryChannel"); }
            set { BackingStore?.Set("primaryChannel", value); }
        }
        /// <summary>The schedule of shifts for this team.</summary>
        public Microsoft.Graph.Models.Schedule Schedule {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Schedule>("schedule"); }
            set { BackingStore?.Set("schedule", value); }
        }
        /// <summary>Optional. Indicates whether the team is intended for a particular use case.  Each team specialization has access to unique behaviors and experiences targeted to its use case.</summary>
        public TeamSpecialization? Specialization {
            get { return BackingStore?.Get<TeamSpecialization?>("specialization"); }
            set { BackingStore?.Set("specialization", value); }
        }
        /// <summary>Contains summary information about the team, including number of owners, members, and guests.</summary>
        public TeamSummary Summary {
            get { return BackingStore?.Get<TeamSummary>("summary"); }
            set { BackingStore?.Set("summary", value); }
        }
        /// <summary>The template this team was created from. See available templates.</summary>
        public TeamsTemplate Template {
            get { return BackingStore?.Get<TeamsTemplate>("template"); }
            set { BackingStore?.Set("template", value); }
        }
        /// <summary>The ID of the Azure Active Directory tenant.</summary>
        public string TenantId {
            get { return BackingStore?.Get<string>("tenantId"); }
            set { BackingStore?.Set("tenantId", value); }
        }
        /// <summary>The visibility of the group and team. Defaults to Public.</summary>
        public TeamVisibilityType? Visibility {
            get { return BackingStore?.Get<TeamVisibilityType?>("visibility"); }
            set { BackingStore?.Set("visibility", value); }
        }
        /// <summary>A hyperlink that will go to the team in the Microsoft Teams client. This is the URL that you get when you right-click a team in the Microsoft Teams client and select Get link to team. This URL should be treated as an opaque blob, and not parsed.</summary>
        public string WebUrl {
            get { return BackingStore?.Get<string>("webUrl"); }
            set { BackingStore?.Set("webUrl", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Team CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Team();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"allChannels", n => { AllChannels = n.GetCollectionOfObjectValues<Channel>(Channel.CreateFromDiscriminatorValue).ToList(); } },
                {"channels", n => { Channels = n.GetCollectionOfObjectValues<Channel>(Channel.CreateFromDiscriminatorValue).ToList(); } },
                {"classification", n => { Classification = n.GetStringValue(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"funSettings", n => { FunSettings = n.GetObjectValue<TeamFunSettings>(TeamFunSettings.CreateFromDiscriminatorValue); } },
                {"group", n => { Group = n.GetObjectValue<Microsoft.Graph.Models.Group>(Microsoft.Graph.Models.Group.CreateFromDiscriminatorValue); } },
                {"guestSettings", n => { GuestSettings = n.GetObjectValue<TeamGuestSettings>(TeamGuestSettings.CreateFromDiscriminatorValue); } },
                {"incomingChannels", n => { IncomingChannels = n.GetCollectionOfObjectValues<Channel>(Channel.CreateFromDiscriminatorValue).ToList(); } },
                {"installedApps", n => { InstalledApps = n.GetCollectionOfObjectValues<TeamsAppInstallation>(TeamsAppInstallation.CreateFromDiscriminatorValue).ToList(); } },
                {"internalId", n => { InternalId = n.GetStringValue(); } },
                {"isArchived", n => { IsArchived = n.GetBoolValue(); } },
                {"members", n => { Members = n.GetCollectionOfObjectValues<ConversationMember>(ConversationMember.CreateFromDiscriminatorValue).ToList(); } },
                {"memberSettings", n => { MemberSettings = n.GetObjectValue<TeamMemberSettings>(TeamMemberSettings.CreateFromDiscriminatorValue); } },
                {"messagingSettings", n => { MessagingSettings = n.GetObjectValue<TeamMessagingSettings>(TeamMessagingSettings.CreateFromDiscriminatorValue); } },
                {"operations", n => { Operations = n.GetCollectionOfObjectValues<TeamsAsyncOperation>(TeamsAsyncOperation.CreateFromDiscriminatorValue).ToList(); } },
                {"primaryChannel", n => { PrimaryChannel = n.GetObjectValue<Channel>(Channel.CreateFromDiscriminatorValue); } },
                {"schedule", n => { Schedule = n.GetObjectValue<Microsoft.Graph.Models.Schedule>(Microsoft.Graph.Models.Schedule.CreateFromDiscriminatorValue); } },
                {"specialization", n => { Specialization = n.GetEnumValue<TeamSpecialization>(); } },
                {"summary", n => { Summary = n.GetObjectValue<TeamSummary>(TeamSummary.CreateFromDiscriminatorValue); } },
                {"template", n => { Template = n.GetObjectValue<TeamsTemplate>(TeamsTemplate.CreateFromDiscriminatorValue); } },
                {"tenantId", n => { TenantId = n.GetStringValue(); } },
                {"visibility", n => { Visibility = n.GetEnumValue<TeamVisibilityType>(); } },
                {"webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Channel>("allChannels", AllChannels);
            writer.WriteCollectionOfObjectValues<Channel>("channels", Channels);
            writer.WriteStringValue("classification", Classification);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<TeamFunSettings>("funSettings", FunSettings);
            writer.WriteObjectValue<Microsoft.Graph.Models.Group>("group", Group);
            writer.WriteObjectValue<TeamGuestSettings>("guestSettings", GuestSettings);
            writer.WriteCollectionOfObjectValues<Channel>("incomingChannels", IncomingChannels);
            writer.WriteCollectionOfObjectValues<TeamsAppInstallation>("installedApps", InstalledApps);
            writer.WriteStringValue("internalId", InternalId);
            writer.WriteBoolValue("isArchived", IsArchived);
            writer.WriteCollectionOfObjectValues<ConversationMember>("members", Members);
            writer.WriteObjectValue<TeamMemberSettings>("memberSettings", MemberSettings);
            writer.WriteObjectValue<TeamMessagingSettings>("messagingSettings", MessagingSettings);
            writer.WriteCollectionOfObjectValues<TeamsAsyncOperation>("operations", Operations);
            writer.WriteObjectValue<Channel>("primaryChannel", PrimaryChannel);
            writer.WriteObjectValue<Microsoft.Graph.Models.Schedule>("schedule", Schedule);
            writer.WriteEnumValue<TeamSpecialization>("specialization", Specialization);
            writer.WriteObjectValue<TeamSummary>("summary", Summary);
            writer.WriteObjectValue<TeamsTemplate>("template", Template);
            writer.WriteStringValue("tenantId", TenantId);
            writer.WriteEnumValue<TeamVisibilityType>("visibility", Visibility);
            writer.WriteStringValue("webUrl", WebUrl);
        }
    }
}
