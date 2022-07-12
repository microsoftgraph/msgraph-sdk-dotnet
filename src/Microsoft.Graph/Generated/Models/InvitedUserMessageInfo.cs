using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class InvitedUserMessageInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Additional recipients the invitation message should be sent to. Currently only 1 additional recipient is supported.</summary>
        public List<Recipient> CcRecipients {
            get { return BackingStore?.Get<List<Recipient>>("ccRecipients"); }
            set { BackingStore?.Set("ccRecipients", value); }
        }
        /// <summary>Customized message body you want to send if you don&apos;t want the default message.</summary>
        public string CustomizedMessageBody {
            get { return BackingStore?.Get<string>("customizedMessageBody"); }
            set { BackingStore?.Set("customizedMessageBody", value); }
        }
        /// <summary>The language you want to send the default message in. If the customizedMessageBody is specified, this property is ignored, and the message is sent using the customizedMessageBody. The language format should be in ISO 639. The default is en-US.</summary>
        public string MessageLanguage {
            get { return BackingStore?.Get<string>("messageLanguage"); }
            set { BackingStore?.Set("messageLanguage", value); }
        }
        /// <summary>
        /// Instantiates a new invitedUserMessageInfo and sets the default values.
        /// </summary>
        public InvitedUserMessageInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static InvitedUserMessageInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new InvitedUserMessageInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"ccRecipients", n => { CcRecipients = n.GetCollectionOfObjectValues<Recipient>(Recipient.CreateFromDiscriminatorValue).ToList(); } },
                {"customizedMessageBody", n => { CustomizedMessageBody = n.GetStringValue(); } },
                {"messageLanguage", n => { MessageLanguage = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<Recipient>("ccRecipients", CcRecipients);
            writer.WriteStringValue("customizedMessageBody", CustomizedMessageBody);
            writer.WriteStringValue("messageLanguage", MessageLanguage);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
