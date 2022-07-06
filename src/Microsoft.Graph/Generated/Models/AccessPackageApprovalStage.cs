using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessPackageApprovalStage : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The number of days that a request can be pending a response before it is automatically denied.</summary>
        public TimeSpan? DurationBeforeAutomaticDenial {
            get { return BackingStore?.Get<TimeSpan?>("durationBeforeAutomaticDenial"); }
            set { BackingStore?.Set("durationBeforeAutomaticDenial", value); }
        }
        /// <summary>If escalation is required, the time a request can be pending a response from a primary approver.</summary>
        public TimeSpan? DurationBeforeEscalation {
            get { return BackingStore?.Get<TimeSpan?>("durationBeforeEscalation"); }
            set { BackingStore?.Set("durationBeforeEscalation", value); }
        }
        /// <summary>If escalation is enabled and the primary approvers do not respond before the escalation time, the escalationApprovers are the users who will be asked to approve requests.</summary>
        public List<SubjectSet> EscalationApprovers {
            get { return BackingStore?.Get<List<SubjectSet>>("escalationApprovers"); }
            set { BackingStore?.Set("escalationApprovers", value); }
        }
        /// <summary>The subjects, typically users, who are the fallback escalation approvers.</summary>
        public List<SubjectSet> FallbackEscalationApprovers {
            get { return BackingStore?.Get<List<SubjectSet>>("fallbackEscalationApprovers"); }
            set { BackingStore?.Set("fallbackEscalationApprovers", value); }
        }
        /// <summary>The subjects, typically users, who are the fallback primary approvers.</summary>
        public List<SubjectSet> FallbackPrimaryApprovers {
            get { return BackingStore?.Get<List<SubjectSet>>("fallbackPrimaryApprovers"); }
            set { BackingStore?.Set("fallbackPrimaryApprovers", value); }
        }
        /// <summary>Indicates whether the approver is required to provide a justification for approving a request.</summary>
        public bool? IsApproverJustificationRequired {
            get { return BackingStore?.Get<bool?>("isApproverJustificationRequired"); }
            set { BackingStore?.Set("isApproverJustificationRequired", value); }
        }
        /// <summary>If true, then one or more escalationApprovers are configured in this approval stage.</summary>
        public bool? IsEscalationEnabled {
            get { return BackingStore?.Get<bool?>("isEscalationEnabled"); }
            set { BackingStore?.Set("isEscalationEnabled", value); }
        }
        /// <summary>The subjects, typically users, who will be asked to approve requests. A collection of singleUser, groupMembers, requestorManager, internalSponsors or externalSponsors.</summary>
        public List<SubjectSet> PrimaryApprovers {
            get { return BackingStore?.Get<List<SubjectSet>>("primaryApprovers"); }
            set { BackingStore?.Set("primaryApprovers", value); }
        }
        /// <summary>
        /// Instantiates a new accessPackageApprovalStage and sets the default values.
        /// </summary>
        public AccessPackageApprovalStage() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AccessPackageApprovalStage CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageApprovalStage();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"durationBeforeAutomaticDenial", n => { DurationBeforeAutomaticDenial = n.GetTimeSpanValue(); } },
                {"durationBeforeEscalation", n => { DurationBeforeEscalation = n.GetTimeSpanValue(); } },
                {"escalationApprovers", n => { EscalationApprovers = n.GetCollectionOfObjectValues<SubjectSet>(SubjectSet.CreateFromDiscriminatorValue).ToList(); } },
                {"fallbackEscalationApprovers", n => { FallbackEscalationApprovers = n.GetCollectionOfObjectValues<SubjectSet>(SubjectSet.CreateFromDiscriminatorValue).ToList(); } },
                {"fallbackPrimaryApprovers", n => { FallbackPrimaryApprovers = n.GetCollectionOfObjectValues<SubjectSet>(SubjectSet.CreateFromDiscriminatorValue).ToList(); } },
                {"isApproverJustificationRequired", n => { IsApproverJustificationRequired = n.GetBoolValue(); } },
                {"isEscalationEnabled", n => { IsEscalationEnabled = n.GetBoolValue(); } },
                {"primaryApprovers", n => { PrimaryApprovers = n.GetCollectionOfObjectValues<SubjectSet>(SubjectSet.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteTimeSpanValue("durationBeforeAutomaticDenial", DurationBeforeAutomaticDenial);
            writer.WriteTimeSpanValue("durationBeforeEscalation", DurationBeforeEscalation);
            writer.WriteCollectionOfObjectValues<SubjectSet>("escalationApprovers", EscalationApprovers);
            writer.WriteCollectionOfObjectValues<SubjectSet>("fallbackEscalationApprovers", FallbackEscalationApprovers);
            writer.WriteCollectionOfObjectValues<SubjectSet>("fallbackPrimaryApprovers", FallbackPrimaryApprovers);
            writer.WriteBoolValue("isApproverJustificationRequired", IsApproverJustificationRequired);
            writer.WriteBoolValue("isEscalationEnabled", IsEscalationEnabled);
            writer.WriteCollectionOfObjectValues<SubjectSet>("primaryApprovers", PrimaryApprovers);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
