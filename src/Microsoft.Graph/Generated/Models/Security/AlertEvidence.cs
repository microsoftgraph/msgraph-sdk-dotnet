using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models.Security {
    public class AlertEvidence : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The time the evidence was created and added to the alert.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>The remediationStatus property</summary>
        public EvidenceRemediationStatus? RemediationStatus {
            get { return BackingStore?.Get<EvidenceRemediationStatus?>("remediationStatus"); }
            set { BackingStore?.Set("remediationStatus", value); }
        }
        /// <summary>Details about the remediation status.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RemediationStatusDetails {
            get { return BackingStore?.Get<string?>("remediationStatusDetails"); }
            set { BackingStore?.Set("remediationStatusDetails", value); }
        }
#nullable restore
#else
        public string RemediationStatusDetails {
            get { return BackingStore?.Get<string>("remediationStatusDetails"); }
            set { BackingStore?.Set("remediationStatusDetails", value); }
        }
#endif
        /// <summary>The role/s that an evidence entity represents in an alert, e.g., an IP address that is associated with an attacker will have the evidence role &apos;Attacker&apos;.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<EvidenceRole?>? Roles {
            get { return BackingStore?.Get<List<EvidenceRole?>?>("roles"); }
            set { BackingStore?.Set("roles", value); }
        }
#nullable restore
#else
        public List<EvidenceRole?> Roles {
            get { return BackingStore?.Get<List<EvidenceRole?>>("roles"); }
            set { BackingStore?.Set("roles", value); }
        }
#endif
        /// <summary>Array of custom tags associated with an evidence instance, for example to denote a group of devices, high value assets, etc.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Tags {
            get { return BackingStore?.Get<List<string>?>("tags"); }
            set { BackingStore?.Set("tags", value); }
        }
#nullable restore
#else
        public List<string> Tags {
            get { return BackingStore?.Get<List<string>>("tags"); }
            set { BackingStore?.Set("tags", value); }
        }
#endif
        /// <summary>The verdict property</summary>
        public EvidenceVerdict? Verdict {
            get { return BackingStore?.Get<EvidenceVerdict?>("verdict"); }
            set { BackingStore?.Set("verdict", value); }
        }
        /// <summary>
        /// Instantiates a new alertEvidence and sets the default values.
        /// </summary>
        public AlertEvidence() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AlertEvidence CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.security.analyzedMessageEvidence" => new AnalyzedMessageEvidence(),
                "#microsoft.graph.security.cloudApplicationEvidence" => new CloudApplicationEvidence(),
                "#microsoft.graph.security.deviceEvidence" => new DeviceEvidence(),
                "#microsoft.graph.security.fileEvidence" => new FileEvidence(),
                "#microsoft.graph.security.ipEvidence" => new IpEvidence(),
                "#microsoft.graph.security.mailboxEvidence" => new MailboxEvidence(),
                "#microsoft.graph.security.mailClusterEvidence" => new MailClusterEvidence(),
                "#microsoft.graph.security.oauthApplicationEvidence" => new OauthApplicationEvidence(),
                "#microsoft.graph.security.processEvidence" => new ProcessEvidence(),
                "#microsoft.graph.security.registryKeyEvidence" => new RegistryKeyEvidence(),
                "#microsoft.graph.security.registryValueEvidence" => new RegistryValueEvidence(),
                "#microsoft.graph.security.securityGroupEvidence" => new SecurityGroupEvidence(),
                "#microsoft.graph.security.urlEvidence" => new UrlEvidence(),
                "#microsoft.graph.security.userEvidence" => new UserEvidence(),
                _ => new AlertEvidence(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"remediationStatus", n => { RemediationStatus = n.GetEnumValue<EvidenceRemediationStatus>(); } },
                {"remediationStatusDetails", n => { RemediationStatusDetails = n.GetStringValue(); } },
                {"roles", n => { Roles = n.GetCollectionOfEnumValues<EvidenceRole>()?.ToList(); } },
                {"tags", n => { Tags = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"verdict", n => { Verdict = n.GetEnumValue<EvidenceVerdict>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteEnumValue<EvidenceRemediationStatus>("remediationStatus", RemediationStatus);
            writer.WriteStringValue("remediationStatusDetails", RemediationStatusDetails);
            writer.WriteCollectionOfEnumValues<EvidenceRole>("roles", Roles);
            writer.WriteCollectionOfPrimitiveValues<string>("tags", Tags);
            writer.WriteEnumValue<EvidenceVerdict>("verdict", Verdict);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
