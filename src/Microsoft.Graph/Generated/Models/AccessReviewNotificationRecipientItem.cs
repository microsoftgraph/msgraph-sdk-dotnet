using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessReviewNotificationRecipientItem : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Determines the recipient of the notification email.</summary>
        public AccessReviewNotificationRecipientScope NotificationRecipientScope {
            get { return BackingStore?.Get<AccessReviewNotificationRecipientScope>("notificationRecipientScope"); }
            set { BackingStore?.Set("notificationRecipientScope", value); }
        }
        /// <summary>Indicates the type of access review email to be sent. Supported template type is CompletedAdditionalRecipients which sends review completion notifications to the recipients.</summary>
        public string NotificationTemplateType {
            get { return BackingStore?.Get<string>("notificationTemplateType"); }
            set { BackingStore?.Set("notificationTemplateType", value); }
        }
        /// <summary>
        /// Instantiates a new accessReviewNotificationRecipientItem and sets the default values.
        /// </summary>
        public AccessReviewNotificationRecipientItem() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AccessReviewNotificationRecipientItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessReviewNotificationRecipientItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"notificationRecipientScope", n => { NotificationRecipientScope = n.GetObjectValue<AccessReviewNotificationRecipientScope>(AccessReviewNotificationRecipientScope.CreateFromDiscriminatorValue); } },
                {"notificationTemplateType", n => { NotificationTemplateType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AccessReviewNotificationRecipientScope>("notificationRecipientScope", NotificationRecipientScope);
            writer.WriteStringValue("notificationTemplateType", NotificationTemplateType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
