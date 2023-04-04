using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models.Security {
    public class Incident : Entity, IParsable {
        /// <summary>The list of related alerts. Supports $expand.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Alert>? Alerts {
            get { return BackingStore?.Get<List<Alert>?>("alerts"); }
            set { BackingStore?.Set("alerts", value); }
        }
#nullable restore
#else
        public List<Alert> Alerts {
            get { return BackingStore?.Get<List<Alert>>("alerts"); }
            set { BackingStore?.Set("alerts", value); }
        }
#endif
        /// <summary>Owner of the incident, or null if no owner is assigned. Free editable text.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AssignedTo {
            get { return BackingStore?.Get<string?>("assignedTo"); }
            set { BackingStore?.Set("assignedTo", value); }
        }
#nullable restore
#else
        public string AssignedTo {
            get { return BackingStore?.Get<string>("assignedTo"); }
            set { BackingStore?.Set("assignedTo", value); }
        }
#endif
        /// <summary>The specification for the incident. Possible values are: unknown, falsePositive, truePositive, informationalExpectedActivity, unknownFutureValue.</summary>
        public AlertClassification? Classification {
            get { return BackingStore?.Get<AlertClassification?>("classification"); }
            set { BackingStore?.Set("classification", value); }
        }
        /// <summary>Array of comments created by the Security Operations (SecOps) team when the incident is managed.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<AlertComment>? Comments {
            get { return BackingStore?.Get<List<AlertComment>?>("comments"); }
            set { BackingStore?.Set("comments", value); }
        }
#nullable restore
#else
        public List<AlertComment> Comments {
            get { return BackingStore?.Get<List<AlertComment>>("comments"); }
            set { BackingStore?.Set("comments", value); }
        }
#endif
        /// <summary>Time when the incident was first created.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Array of custom tags associated with an incident.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? CustomTags {
            get { return BackingStore?.Get<List<string>?>("customTags"); }
            set { BackingStore?.Set("customTags", value); }
        }
#nullable restore
#else
        public List<string> CustomTags {
            get { return BackingStore?.Get<List<string>>("customTags"); }
            set { BackingStore?.Set("customTags", value); }
        }
#endif
        /// <summary>Specifies the determination of the incident. Possible values are: unknown, apt, malware, securityPersonnel, securityTesting, unwantedSoftware, other, multiStagedAttack, compromisedUser, phishing, maliciousUserActivity, clean, insufficientData, confirmedUserActivity, lineOfBusinessApplication, unknownFutureValue.</summary>
        public AlertDetermination? Determination {
            get { return BackingStore?.Get<AlertDetermination?>("determination"); }
            set { BackingStore?.Set("determination", value); }
        }
        /// <summary>The incident name.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayName {
            get { return BackingStore?.Get<string?>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#nullable restore
#else
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#endif
        /// <summary>The URL for the incident page in the Microsoft 365 Defender portal.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? IncidentWebUrl {
            get { return BackingStore?.Get<string?>("incidentWebUrl"); }
            set { BackingStore?.Set("incidentWebUrl", value); }
        }
#nullable restore
#else
        public string IncidentWebUrl {
            get { return BackingStore?.Get<string>("incidentWebUrl"); }
            set { BackingStore?.Set("incidentWebUrl", value); }
        }
#endif
        /// <summary>Time when the incident was last updated.</summary>
        public DateTimeOffset? LastUpdateDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastUpdateDateTime"); }
            set { BackingStore?.Set("lastUpdateDateTime", value); }
        }
        /// <summary>Only populated in case an incident is grouped together with another incident, as part of the logic that processes incidents. In such a case, the status property is redirected.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RedirectIncidentId {
            get { return BackingStore?.Get<string?>("redirectIncidentId"); }
            set { BackingStore?.Set("redirectIncidentId", value); }
        }
#nullable restore
#else
        public string RedirectIncidentId {
            get { return BackingStore?.Get<string>("redirectIncidentId"); }
            set { BackingStore?.Set("redirectIncidentId", value); }
        }
#endif
        /// <summary>The severity property</summary>
        public AlertSeverity? Severity {
            get { return BackingStore?.Get<AlertSeverity?>("severity"); }
            set { BackingStore?.Set("severity", value); }
        }
        /// <summary>The status property</summary>
        public IncidentStatus? Status {
            get { return BackingStore?.Get<IncidentStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>The Azure Active Directory tenant in which the alert was created.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? TenantId {
            get { return BackingStore?.Get<string?>("tenantId"); }
            set { BackingStore?.Set("tenantId", value); }
        }
#nullable restore
#else
        public string TenantId {
            get { return BackingStore?.Get<string>("tenantId"); }
            set { BackingStore?.Set("tenantId", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Incident CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Incident();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"alerts", n => { Alerts = n.GetCollectionOfObjectValues<Alert>(Alert.CreateFromDiscriminatorValue)?.ToList(); } },
                {"assignedTo", n => { AssignedTo = n.GetStringValue(); } },
                {"classification", n => { Classification = n.GetEnumValue<AlertClassification>(); } },
                {"comments", n => { Comments = n.GetCollectionOfObjectValues<AlertComment>(AlertComment.CreateFromDiscriminatorValue)?.ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"customTags", n => { CustomTags = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"determination", n => { Determination = n.GetEnumValue<AlertDetermination>(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"incidentWebUrl", n => { IncidentWebUrl = n.GetStringValue(); } },
                {"lastUpdateDateTime", n => { LastUpdateDateTime = n.GetDateTimeOffsetValue(); } },
                {"redirectIncidentId", n => { RedirectIncidentId = n.GetStringValue(); } },
                {"severity", n => { Severity = n.GetEnumValue<AlertSeverity>(); } },
                {"status", n => { Status = n.GetEnumValue<IncidentStatus>(); } },
                {"tenantId", n => { TenantId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Alert>("alerts", Alerts);
            writer.WriteStringValue("assignedTo", AssignedTo);
            writer.WriteEnumValue<AlertClassification>("classification", Classification);
            writer.WriteCollectionOfObjectValues<AlertComment>("comments", Comments);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteCollectionOfPrimitiveValues<string>("customTags", CustomTags);
            writer.WriteEnumValue<AlertDetermination>("determination", Determination);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("incidentWebUrl", IncidentWebUrl);
            writer.WriteDateTimeOffsetValue("lastUpdateDateTime", LastUpdateDateTime);
            writer.WriteStringValue("redirectIncidentId", RedirectIncidentId);
            writer.WriteEnumValue<AlertSeverity>("severity", Severity);
            writer.WriteEnumValue<IncidentStatus>("status", Status);
            writer.WriteStringValue("tenantId", TenantId);
        }
    }
}
