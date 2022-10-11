using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class InferenceClassificationOverride : Entity, IParsable {
        /// <summary>Specifies how incoming messages from a specific sender should always be classified as. The possible values are: focused, other.</summary>
        public InferenceClassificationType? ClassifyAs {
            get { return BackingStore?.Get<InferenceClassificationType?>("classifyAs"); }
            set { BackingStore?.Set("classifyAs", value); }
        }
        /// <summary>The email address information of the sender for whom the override is created.</summary>
        public EmailAddress SenderEmailAddress {
            get { return BackingStore?.Get<EmailAddress>("senderEmailAddress"); }
            set { BackingStore?.Set("senderEmailAddress", value); }
        }
        /// <summary>
        /// Instantiates a new inferenceClassificationOverride and sets the default values.
        /// </summary>
        public InferenceClassificationOverride() : base() {
            OdataType = "#microsoft.graph.inferenceClassificationOverride";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new InferenceClassificationOverride CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new InferenceClassificationOverride();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"classifyAs", n => { ClassifyAs = n.GetEnumValue<InferenceClassificationType>(); } },
                {"senderEmailAddress", n => { SenderEmailAddress = n.GetObjectValue<EmailAddress>(EmailAddress.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<InferenceClassificationType>("classifyAs", ClassifyAs);
            writer.WriteObjectValue<EmailAddress>("senderEmailAddress", SenderEmailAddress);
        }
    }
}
