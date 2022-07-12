using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Phone : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The language property</summary>
        public string Language {
            get { return BackingStore?.Get<string>("language"); }
            set { BackingStore?.Set("language", value); }
        }
        /// <summary>The phone number.</summary>
        public string Number {
            get { return BackingStore?.Get<string>("number"); }
            set { BackingStore?.Set("number", value); }
        }
        /// <summary>The region property</summary>
        public string Region {
            get { return BackingStore?.Get<string>("region"); }
            set { BackingStore?.Set("region", value); }
        }
        /// <summary>The type of phone number. Possible values are: home, business, mobile, other, assistant, homeFax, businessFax, otherFax, pager, radio.</summary>
        public PhoneType? Type {
            get { return BackingStore?.Get<PhoneType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new phone and sets the default values.
        /// </summary>
        public Phone() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Phone CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Phone();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"language", n => { Language = n.GetStringValue(); } },
                {"number", n => { Number = n.GetStringValue(); } },
                {"region", n => { Region = n.GetStringValue(); } },
                {"type", n => { Type = n.GetEnumValue<PhoneType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("language", Language);
            writer.WriteStringValue("number", Number);
            writer.WriteStringValue("region", Region);
            writer.WriteEnumValue<PhoneType>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
