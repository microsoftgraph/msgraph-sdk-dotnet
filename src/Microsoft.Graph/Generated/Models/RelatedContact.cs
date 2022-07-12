using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RelatedContact : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Indicates whether the user has been consented to access student data.</summary>
        public bool? AccessConsent {
            get { return BackingStore?.Get<bool?>("accessConsent"); }
            set { BackingStore?.Set("accessConsent", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Name of the contact. Required.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Email address of the contact.</summary>
        public string EmailAddress {
            get { return BackingStore?.Get<string>("emailAddress"); }
            set { BackingStore?.Set("emailAddress", value); }
        }
        /// <summary>Mobile phone number of the contact.</summary>
        public string MobilePhone {
            get { return BackingStore?.Get<string>("mobilePhone"); }
            set { BackingStore?.Set("mobilePhone", value); }
        }
        /// <summary>The relationship property</summary>
        public ContactRelationship? Relationship {
            get { return BackingStore?.Get<ContactRelationship?>("relationship"); }
            set { BackingStore?.Set("relationship", value); }
        }
        /// <summary>
        /// Instantiates a new relatedContact and sets the default values.
        /// </summary>
        public RelatedContact() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static RelatedContact CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RelatedContact();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"accessConsent", n => { AccessConsent = n.GetBoolValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"emailAddress", n => { EmailAddress = n.GetStringValue(); } },
                {"mobilePhone", n => { MobilePhone = n.GetStringValue(); } },
                {"relationship", n => { Relationship = n.GetEnumValue<ContactRelationship>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("accessConsent", AccessConsent);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("emailAddress", EmailAddress);
            writer.WriteStringValue("mobilePhone", MobilePhone);
            writer.WriteEnumValue<ContactRelationship>("relationship", Relationship);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
