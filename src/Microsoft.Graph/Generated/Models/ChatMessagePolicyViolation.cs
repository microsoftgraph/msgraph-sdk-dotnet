using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ChatMessagePolicyViolation : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The action taken by the DLP provider on the message with sensitive content. Supported values are: NoneNotifySender -- Inform the sender of the violation but allow readers to read the message.BlockAccess -- Block readers from reading the message.BlockAccessExternal -- Block users outside the organization from reading the message, while allowing users within the organization to read the message.</summary>
        public ChatMessagePolicyViolationDlpActionTypes? DlpAction {
            get { return BackingStore?.Get<ChatMessagePolicyViolationDlpActionTypes?>("dlpAction"); }
            set { BackingStore?.Set("dlpAction", value); }
        }
        /// <summary>Justification text provided by the sender of the message when overriding a policy violation.</summary>
        public string JustificationText {
            get { return BackingStore?.Get<string>("justificationText"); }
            set { BackingStore?.Set("justificationText", value); }
        }
        /// <summary>Information to display to the message sender about why the message was flagged as a violation.</summary>
        public ChatMessagePolicyViolationPolicyTip PolicyTip {
            get { return BackingStore?.Get<ChatMessagePolicyViolationPolicyTip>("policyTip"); }
            set { BackingStore?.Set("policyTip", value); }
        }
        /// <summary>Indicates the action taken by the user on a message blocked by the DLP provider. Supported values are: NoneOverrideReportFalsePositiveWhen the DLP provider is updating the message for blocking sensitive content, userAction is not required.</summary>
        public ChatMessagePolicyViolationUserActionTypes? UserAction {
            get { return BackingStore?.Get<ChatMessagePolicyViolationUserActionTypes?>("userAction"); }
            set { BackingStore?.Set("userAction", value); }
        }
        /// <summary>Indicates what actions the sender may take in response to the policy violation. Supported values are: NoneAllowFalsePositiveOverride -- Allows the sender to declare the policyViolation to be an error in the DLP app and its rules, and allow readers to see the message again if the dlpAction had hidden it.AllowOverrideWithoutJustification -- Allows the sender to overriide the DLP violation and allow readers to see the message again if the dlpAction had hidden it, without needing to provide an explanation for doing so. AllowOverrideWithJustification -- Allows the sender to overriide the DLP violation and allow readers to see the message again if the dlpAction had hidden it, after providing an explanation for doing so.AllowOverrideWithoutJustification and AllowOverrideWithJustification are mutually exclusive.</summary>
        public ChatMessagePolicyViolationVerdictDetailsTypes? VerdictDetails {
            get { return BackingStore?.Get<ChatMessagePolicyViolationVerdictDetailsTypes?>("verdictDetails"); }
            set { BackingStore?.Set("verdictDetails", value); }
        }
        /// <summary>
        /// Instantiates a new chatMessagePolicyViolation and sets the default values.
        /// </summary>
        public ChatMessagePolicyViolation() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ChatMessagePolicyViolation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ChatMessagePolicyViolation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"dlpAction", n => { DlpAction = n.GetEnumValue<ChatMessagePolicyViolationDlpActionTypes>(); } },
                {"justificationText", n => { JustificationText = n.GetStringValue(); } },
                {"policyTip", n => { PolicyTip = n.GetObjectValue<ChatMessagePolicyViolationPolicyTip>(ChatMessagePolicyViolationPolicyTip.CreateFromDiscriminatorValue); } },
                {"userAction", n => { UserAction = n.GetEnumValue<ChatMessagePolicyViolationUserActionTypes>(); } },
                {"verdictDetails", n => { VerdictDetails = n.GetEnumValue<ChatMessagePolicyViolationVerdictDetailsTypes>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<ChatMessagePolicyViolationDlpActionTypes>("dlpAction", DlpAction);
            writer.WriteStringValue("justificationText", JustificationText);
            writer.WriteObjectValue<ChatMessagePolicyViolationPolicyTip>("policyTip", PolicyTip);
            writer.WriteEnumValue<ChatMessagePolicyViolationUserActionTypes>("userAction", UserAction);
            writer.WriteEnumValue<ChatMessagePolicyViolationVerdictDetailsTypes>("verdictDetails", VerdictDetails);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
