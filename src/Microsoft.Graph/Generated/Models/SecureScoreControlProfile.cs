using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class SecureScoreControlProfile : Entity, IParsable {
        /// <summary>Control action type (Config, Review, Behavior).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ActionType {
            get { return BackingStore?.Get<string?>("actionType"); }
            set { BackingStore?.Set("actionType", value); }
        }
#nullable restore
#else
        public string ActionType {
            get { return BackingStore?.Get<string>("actionType"); }
            set { BackingStore?.Set("actionType", value); }
        }
#endif
        /// <summary>URL to where the control can be actioned.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ActionUrl {
            get { return BackingStore?.Get<string?>("actionUrl"); }
            set { BackingStore?.Set("actionUrl", value); }
        }
#nullable restore
#else
        public string ActionUrl {
            get { return BackingStore?.Get<string>("actionUrl"); }
            set { BackingStore?.Set("actionUrl", value); }
        }
#endif
        /// <summary>GUID string for tenant ID.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AzureTenantId {
            get { return BackingStore?.Get<string?>("azureTenantId"); }
            set { BackingStore?.Set("azureTenantId", value); }
        }
#nullable restore
#else
        public string AzureTenantId {
            get { return BackingStore?.Get<string>("azureTenantId"); }
            set { BackingStore?.Set("azureTenantId", value); }
        }
#endif
        /// <summary>The collection of compliance information associated with secure score control</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.ComplianceInformation>? ComplianceInformation {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ComplianceInformation>?>("complianceInformation"); }
            set { BackingStore?.Set("complianceInformation", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.ComplianceInformation> ComplianceInformation {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.ComplianceInformation>>("complianceInformation"); }
            set { BackingStore?.Set("complianceInformation", value); }
        }
#endif
        /// <summary>Control action category (Identity, Data, Device, Apps, Infrastructure).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ControlCategory {
            get { return BackingStore?.Get<string?>("controlCategory"); }
            set { BackingStore?.Set("controlCategory", value); }
        }
#nullable restore
#else
        public string ControlCategory {
            get { return BackingStore?.Get<string>("controlCategory"); }
            set { BackingStore?.Set("controlCategory", value); }
        }
#endif
        /// <summary>Flag to indicate where the tenant has marked a control (ignored, thirdParty, reviewed) (supports update).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SecureScoreControlStateUpdate>? ControlStateUpdates {
            get { return BackingStore?.Get<List<SecureScoreControlStateUpdate>?>("controlStateUpdates"); }
            set { BackingStore?.Set("controlStateUpdates", value); }
        }
#nullable restore
#else
        public List<SecureScoreControlStateUpdate> ControlStateUpdates {
            get { return BackingStore?.Get<List<SecureScoreControlStateUpdate>>("controlStateUpdates"); }
            set { BackingStore?.Set("controlStateUpdates", value); }
        }
#endif
        /// <summary>Flag to indicate if a control is depreciated.</summary>
        public bool? Deprecated {
            get { return BackingStore?.Get<bool?>("deprecated"); }
            set { BackingStore?.Set("deprecated", value); }
        }
        /// <summary>Resource cost of implemmentating control (low, moderate, high).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ImplementationCost {
            get { return BackingStore?.Get<string?>("implementationCost"); }
            set { BackingStore?.Set("implementationCost", value); }
        }
#nullable restore
#else
        public string ImplementationCost {
            get { return BackingStore?.Get<string>("implementationCost"); }
            set { BackingStore?.Set("implementationCost", value); }
        }
#endif
        /// <summary>Time at which the control profile entity was last modified. The Timestamp type represents date and time</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>max attainable score for the control.</summary>
        public double? MaxScore {
            get { return BackingStore?.Get<double?>("maxScore"); }
            set { BackingStore?.Set("maxScore", value); }
        }
        /// <summary>Microsoft&apos;s stack ranking of control.</summary>
        public int? Rank {
            get { return BackingStore?.Get<int?>("rank"); }
            set { BackingStore?.Set("rank", value); }
        }
        /// <summary>Description of what the control will help remediate.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Remediation {
            get { return BackingStore?.Get<string?>("remediation"); }
            set { BackingStore?.Set("remediation", value); }
        }
#nullable restore
#else
        public string Remediation {
            get { return BackingStore?.Get<string>("remediation"); }
            set { BackingStore?.Set("remediation", value); }
        }
#endif
        /// <summary>Description of the impact on users of the remediation.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RemediationImpact {
            get { return BackingStore?.Get<string?>("remediationImpact"); }
            set { BackingStore?.Set("remediationImpact", value); }
        }
#nullable restore
#else
        public string RemediationImpact {
            get { return BackingStore?.Get<string>("remediationImpact"); }
            set { BackingStore?.Set("remediationImpact", value); }
        }
#endif
        /// <summary>Service that owns the control (Exchange, Sharepoint, Azure AD).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Service {
            get { return BackingStore?.Get<string?>("service"); }
            set { BackingStore?.Set("service", value); }
        }
#nullable restore
#else
        public string Service {
            get { return BackingStore?.Get<string>("service"); }
            set { BackingStore?.Set("service", value); }
        }
#endif
        /// <summary>List of threats the control mitigates (accountBreach, dataDeletion, dataExfiltration, dataSpillage,</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Threats {
            get { return BackingStore?.Get<List<string>?>("threats"); }
            set { BackingStore?.Set("threats", value); }
        }
#nullable restore
#else
        public List<string> Threats {
            get { return BackingStore?.Get<List<string>>("threats"); }
            set { BackingStore?.Set("threats", value); }
        }
#endif
        /// <summary>The tier property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Tier {
            get { return BackingStore?.Get<string?>("tier"); }
            set { BackingStore?.Set("tier", value); }
        }
#nullable restore
#else
        public string Tier {
            get { return BackingStore?.Get<string>("tier"); }
            set { BackingStore?.Set("tier", value); }
        }
#endif
        /// <summary>The title property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Title {
            get { return BackingStore?.Get<string?>("title"); }
            set { BackingStore?.Set("title", value); }
        }
#nullable restore
#else
        public string Title {
            get { return BackingStore?.Get<string>("title"); }
            set { BackingStore?.Set("title", value); }
        }
#endif
        /// <summary>The userImpact property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UserImpact {
            get { return BackingStore?.Get<string?>("userImpact"); }
            set { BackingStore?.Set("userImpact", value); }
        }
#nullable restore
#else
        public string UserImpact {
            get { return BackingStore?.Get<string>("userImpact"); }
            set { BackingStore?.Set("userImpact", value); }
        }
#endif
        /// <summary>The vendorInformation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SecurityVendorInformation? VendorInformation {
            get { return BackingStore?.Get<SecurityVendorInformation?>("vendorInformation"); }
            set { BackingStore?.Set("vendorInformation", value); }
        }
#nullable restore
#else
        public SecurityVendorInformation VendorInformation {
            get { return BackingStore?.Get<SecurityVendorInformation>("vendorInformation"); }
            set { BackingStore?.Set("vendorInformation", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new SecureScoreControlProfile CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SecureScoreControlProfile();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"actionType", n => { ActionType = n.GetStringValue(); } },
                {"actionUrl", n => { ActionUrl = n.GetStringValue(); } },
                {"azureTenantId", n => { AzureTenantId = n.GetStringValue(); } },
                {"complianceInformation", n => { ComplianceInformation = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.ComplianceInformation>(Microsoft.Graph.Models.ComplianceInformation.CreateFromDiscriminatorValue)?.ToList(); } },
                {"controlCategory", n => { ControlCategory = n.GetStringValue(); } },
                {"controlStateUpdates", n => { ControlStateUpdates = n.GetCollectionOfObjectValues<SecureScoreControlStateUpdate>(SecureScoreControlStateUpdate.CreateFromDiscriminatorValue)?.ToList(); } },
                {"deprecated", n => { Deprecated = n.GetBoolValue(); } },
                {"implementationCost", n => { ImplementationCost = n.GetStringValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"maxScore", n => { MaxScore = n.GetDoubleValue(); } },
                {"rank", n => { Rank = n.GetIntValue(); } },
                {"remediation", n => { Remediation = n.GetStringValue(); } },
                {"remediationImpact", n => { RemediationImpact = n.GetStringValue(); } },
                {"service", n => { Service = n.GetStringValue(); } },
                {"threats", n => { Threats = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"tier", n => { Tier = n.GetStringValue(); } },
                {"title", n => { Title = n.GetStringValue(); } },
                {"userImpact", n => { UserImpact = n.GetStringValue(); } },
                {"vendorInformation", n => { VendorInformation = n.GetObjectValue<SecurityVendorInformation>(SecurityVendorInformation.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("actionType", ActionType);
            writer.WriteStringValue("actionUrl", ActionUrl);
            writer.WriteStringValue("azureTenantId", AzureTenantId);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.ComplianceInformation>("complianceInformation", ComplianceInformation);
            writer.WriteStringValue("controlCategory", ControlCategory);
            writer.WriteCollectionOfObjectValues<SecureScoreControlStateUpdate>("controlStateUpdates", ControlStateUpdates);
            writer.WriteBoolValue("deprecated", Deprecated);
            writer.WriteStringValue("implementationCost", ImplementationCost);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteDoubleValue("maxScore", MaxScore);
            writer.WriteIntValue("rank", Rank);
            writer.WriteStringValue("remediation", Remediation);
            writer.WriteStringValue("remediationImpact", RemediationImpact);
            writer.WriteStringValue("service", Service);
            writer.WriteCollectionOfPrimitiveValues<string>("threats", Threats);
            writer.WriteStringValue("tier", Tier);
            writer.WriteStringValue("title", Title);
            writer.WriteStringValue("userImpact", UserImpact);
            writer.WriteObjectValue<SecurityVendorInformation>("vendorInformation", VendorInformation);
        }
    }
}
