using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class Simulation : Entity, IParsable {
        /// <summary>The social engineering technique used in the attack simulation and training campaign. Supports $filter and $orderby. Possible values are: unknown, credentialHarvesting, attachmentMalware, driveByUrl, linkInAttachment, linkToMalwareFile, unknownFutureValue. For more information on the types of social engineering attack techniques, see simulations.</summary>
        public SimulationAttackTechnique? AttackTechnique {
            get { return BackingStore?.Get<SimulationAttackTechnique?>("attackTechnique"); }
            set { BackingStore?.Set("attackTechnique", value); }
        }
        /// <summary>Attack type of the attack simulation and training campaign. Supports $filter and $orderby. Possible values are: unknown, social, cloud, endpoint, unknownFutureValue.</summary>
        public SimulationAttackType? AttackType {
            get { return BackingStore?.Get<SimulationAttackType?>("attackType"); }
            set { BackingStore?.Set("attackType", value); }
        }
        /// <summary>Unique identifier for the attack simulation automation.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? AutomationId {
            get { return BackingStore?.Get<string?>("automationId"); }
            set { BackingStore?.Set("automationId", value); }
        }
#nullable restore
#else
        public string AutomationId {
            get { return BackingStore?.Get<string>("automationId"); }
            set { BackingStore?.Set("automationId", value); }
        }
#endif
        /// <summary>Date and time of completion of the attack simulation and training campaign. Supports $filter and $orderby.</summary>
        public DateTimeOffset? CompletionDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("completionDateTime"); }
            set { BackingStore?.Set("completionDateTime", value); }
        }
        /// <summary>Identity of the user who created the attack simulation and training campaign.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public EmailIdentity? CreatedBy {
            get { return BackingStore?.Get<EmailIdentity?>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
#nullable restore
#else
        public EmailIdentity CreatedBy {
            get { return BackingStore?.Get<EmailIdentity>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
#endif
        /// <summary>Date and time of creation of the attack simulation and training campaign.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Description of the attack simulation and training campaign.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description {
            get { return BackingStore?.Get<string?>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#nullable restore
#else
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
#endif
        /// <summary>Display name of the attack simulation and training campaign. Supports $filter and $orderby.</summary>
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
        /// <summary>Flag that represents if the attack simulation and training campaign was created from a simulation automation flow. Supports $filter and $orderby.</summary>
        public bool? IsAutomated {
            get { return BackingStore?.Get<bool?>("isAutomated"); }
            set { BackingStore?.Set("isAutomated", value); }
        }
        /// <summary>Identity of the user who most recently modified the attack simulation and training campaign.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public EmailIdentity? LastModifiedBy {
            get { return BackingStore?.Get<EmailIdentity?>("lastModifiedBy"); }
            set { BackingStore?.Set("lastModifiedBy", value); }
        }
#nullable restore
#else
        public EmailIdentity LastModifiedBy {
            get { return BackingStore?.Get<EmailIdentity>("lastModifiedBy"); }
            set { BackingStore?.Set("lastModifiedBy", value); }
        }
#endif
        /// <summary>Date and time of the most recent modification of the attack simulation and training campaign.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>Date and time of the launch/start of the attack simulation and training campaign. Supports $filter and $orderby.</summary>
        public DateTimeOffset? LaunchDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("launchDateTime"); }
            set { BackingStore?.Set("launchDateTime", value); }
        }
        /// <summary>Method of delivery of the phishing payload used in the attack simulation and training campaign. Possible values are: unknown, sms, email, teams, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.PayloadDeliveryPlatform? PayloadDeliveryPlatform {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PayloadDeliveryPlatform?>("payloadDeliveryPlatform"); }
            set { BackingStore?.Set("payloadDeliveryPlatform", value); }
        }
        /// <summary>Report of the attack simulation and training campaign.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SimulationReport? Report {
            get { return BackingStore?.Get<SimulationReport?>("report"); }
            set { BackingStore?.Set("report", value); }
        }
#nullable restore
#else
        public SimulationReport Report {
            get { return BackingStore?.Get<SimulationReport>("report"); }
            set { BackingStore?.Set("report", value); }
        }
#endif
        /// <summary>Status of the attack simulation and training campaign. Supports $filter and $orderby. Possible values are: unknown, draft, running, scheduled, succeeded, failed, cancelled, excluded, unknownFutureValue.</summary>
        public SimulationStatus? Status {
            get { return BackingStore?.Get<SimulationStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Simulation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Simulation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"attackTechnique", n => { AttackTechnique = n.GetEnumValue<SimulationAttackTechnique>(); } },
                {"attackType", n => { AttackType = n.GetEnumValue<SimulationAttackType>(); } },
                {"automationId", n => { AutomationId = n.GetStringValue(); } },
                {"completionDateTime", n => { CompletionDateTime = n.GetDateTimeOffsetValue(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<EmailIdentity>(EmailIdentity.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"isAutomated", n => { IsAutomated = n.GetBoolValue(); } },
                {"lastModifiedBy", n => { LastModifiedBy = n.GetObjectValue<EmailIdentity>(EmailIdentity.CreateFromDiscriminatorValue); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"launchDateTime", n => { LaunchDateTime = n.GetDateTimeOffsetValue(); } },
                {"payloadDeliveryPlatform", n => { PayloadDeliveryPlatform = n.GetEnumValue<PayloadDeliveryPlatform>(); } },
                {"report", n => { Report = n.GetObjectValue<SimulationReport>(SimulationReport.CreateFromDiscriminatorValue); } },
                {"status", n => { Status = n.GetEnumValue<SimulationStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<SimulationAttackTechnique>("attackTechnique", AttackTechnique);
            writer.WriteEnumValue<SimulationAttackType>("attackType", AttackType);
            writer.WriteStringValue("automationId", AutomationId);
            writer.WriteDateTimeOffsetValue("completionDateTime", CompletionDateTime);
            writer.WriteObjectValue<EmailIdentity>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("isAutomated", IsAutomated);
            writer.WriteObjectValue<EmailIdentity>("lastModifiedBy", LastModifiedBy);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteDateTimeOffsetValue("launchDateTime", LaunchDateTime);
            writer.WriteEnumValue<PayloadDeliveryPlatform>("payloadDeliveryPlatform", PayloadDeliveryPlatform);
            writer.WriteObjectValue<SimulationReport>("report", Report);
            writer.WriteEnumValue<SimulationStatus>("status", Status);
        }
    }
}
