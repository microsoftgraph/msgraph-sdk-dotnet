using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MailTips : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Mail tips for automatic reply if it has been set up by the recipient.</summary>
        public AutomaticRepliesMailTips AutomaticReplies {
            get { return BackingStore?.Get<AutomaticRepliesMailTips>("automaticReplies"); }
            set { BackingStore?.Set("automaticReplies", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>A custom mail tip that can be set on the recipient&apos;s mailbox.</summary>
        public string CustomMailTip {
            get { return BackingStore?.Get<string>("customMailTip"); }
            set { BackingStore?.Set("customMailTip", value); }
        }
        /// <summary>Whether the recipient&apos;s mailbox is restricted, for example, accepting messages from only a predefined list of senders, rejecting messages from a predefined list of senders, or accepting messages from only authenticated senders.</summary>
        public bool? DeliveryRestricted {
            get { return BackingStore?.Get<bool?>("deliveryRestricted"); }
            set { BackingStore?.Set("deliveryRestricted", value); }
        }
        /// <summary>The email address of the recipient to get mailtips for.</summary>
        public Microsoft.Graph.Models.EmailAddress EmailAddress {
            get { return BackingStore?.Get<Microsoft.Graph.Models.EmailAddress>("emailAddress"); }
            set { BackingStore?.Set("emailAddress", value); }
        }
        /// <summary>Errors that occur during the getMailTips action.</summary>
        public MailTipsError Error {
            get { return BackingStore?.Get<MailTipsError>("error"); }
            set { BackingStore?.Set("error", value); }
        }
        /// <summary>The number of external members if the recipient is a distribution list.</summary>
        public int? ExternalMemberCount {
            get { return BackingStore?.Get<int?>("externalMemberCount"); }
            set { BackingStore?.Set("externalMemberCount", value); }
        }
        /// <summary>Whether sending messages to the recipient requires approval. For example, if the recipient is a large distribution list and a moderator has been set up to approve messages sent to that distribution list, or if sending messages to a recipient requires approval of the recipient&apos;s manager.</summary>
        public bool? IsModerated {
            get { return BackingStore?.Get<bool?>("isModerated"); }
            set { BackingStore?.Set("isModerated", value); }
        }
        /// <summary>The mailbox full status of the recipient.</summary>
        public bool? MailboxFull {
            get { return BackingStore?.Get<bool?>("mailboxFull"); }
            set { BackingStore?.Set("mailboxFull", value); }
        }
        /// <summary>The maximum message size that has been configured for the recipient&apos;s organization or mailbox.</summary>
        public int? MaxMessageSize {
            get { return BackingStore?.Get<int?>("maxMessageSize"); }
            set { BackingStore?.Set("maxMessageSize", value); }
        }
        /// <summary>The scope of the recipient. Possible values are: none, internal, external, externalPartner, externalNonParther. For example, an administrator can set another organization to be its &apos;partner&apos;. The scope is useful if an administrator wants certain mailtips to be accessible to certain scopes. It&apos;s also useful to senders to inform them that their message may leave the organization, helping them make the correct decisions about wording, tone and content.</summary>
        public RecipientScopeType? RecipientScope {
            get { return BackingStore?.Get<RecipientScopeType?>("recipientScope"); }
            set { BackingStore?.Set("recipientScope", value); }
        }
        /// <summary>Recipients suggested based on previous contexts where they appear in the same message.</summary>
        public List<Recipient> RecipientSuggestions {
            get { return BackingStore?.Get<List<Recipient>>("recipientSuggestions"); }
            set { BackingStore?.Set("recipientSuggestions", value); }
        }
        /// <summary>The number of members if the recipient is a distribution list.</summary>
        public int? TotalMemberCount {
            get { return BackingStore?.Get<int?>("totalMemberCount"); }
            set { BackingStore?.Set("totalMemberCount", value); }
        }
        /// <summary>
        /// Instantiates a new mailTips and sets the default values.
        /// </summary>
        public MailTips() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static MailTips CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MailTips();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"automaticReplies", n => { AutomaticReplies = n.GetObjectValue<AutomaticRepliesMailTips>(AutomaticRepliesMailTips.CreateFromDiscriminatorValue); } },
                {"customMailTip", n => { CustomMailTip = n.GetStringValue(); } },
                {"deliveryRestricted", n => { DeliveryRestricted = n.GetBoolValue(); } },
                {"emailAddress", n => { EmailAddress = n.GetObjectValue<Microsoft.Graph.Models.EmailAddress>(Microsoft.Graph.Models.EmailAddress.CreateFromDiscriminatorValue); } },
                {"error", n => { Error = n.GetObjectValue<MailTipsError>(MailTipsError.CreateFromDiscriminatorValue); } },
                {"externalMemberCount", n => { ExternalMemberCount = n.GetIntValue(); } },
                {"isModerated", n => { IsModerated = n.GetBoolValue(); } },
                {"mailboxFull", n => { MailboxFull = n.GetBoolValue(); } },
                {"maxMessageSize", n => { MaxMessageSize = n.GetIntValue(); } },
                {"recipientScope", n => { RecipientScope = n.GetEnumValue<RecipientScopeType>(); } },
                {"recipientSuggestions", n => { RecipientSuggestions = n.GetCollectionOfObjectValues<Recipient>(Recipient.CreateFromDiscriminatorValue).ToList(); } },
                {"totalMemberCount", n => { TotalMemberCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AutomaticRepliesMailTips>("automaticReplies", AutomaticReplies);
            writer.WriteStringValue("customMailTip", CustomMailTip);
            writer.WriteBoolValue("deliveryRestricted", DeliveryRestricted);
            writer.WriteObjectValue<Microsoft.Graph.Models.EmailAddress>("emailAddress", EmailAddress);
            writer.WriteObjectValue<MailTipsError>("error", Error);
            writer.WriteIntValue("externalMemberCount", ExternalMemberCount);
            writer.WriteBoolValue("isModerated", IsModerated);
            writer.WriteBoolValue("mailboxFull", MailboxFull);
            writer.WriteIntValue("maxMessageSize", MaxMessageSize);
            writer.WriteEnumValue<RecipientScopeType>("recipientScope", RecipientScope);
            writer.WriteCollectionOfObjectValues<Recipient>("recipientSuggestions", RecipientSuggestions);
            writer.WriteIntValue("totalMemberCount", TotalMemberCount);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
