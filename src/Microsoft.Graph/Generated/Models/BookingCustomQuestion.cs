using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Represents a custom question of the business.</summary>
    public class BookingCustomQuestion : Entity, IParsable {
        /// <summary>The expected answer type. The possible values are: text, radioButton, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.AnswerInputType? AnswerInputType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AnswerInputType?>("answerInputType"); }
            set { BackingStore?.Set("answerInputType", value); }
        }
        /// <summary>List of possible answer values.</summary>
        public List<string> AnswerOptions {
            get { return BackingStore?.Get<List<string>>("answerOptions"); }
            set { BackingStore?.Set("answerOptions", value); }
        }
        /// <summary>Display name of this entity.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new BookingCustomQuestion CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BookingCustomQuestion();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"answerInputType", n => { AnswerInputType = n.GetEnumValue<AnswerInputType>(); } },
                {"answerOptions", n => { AnswerOptions = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<AnswerInputType>("answerInputType", AnswerInputType);
            writer.WriteCollectionOfPrimitiveValues<string>("answerOptions", AnswerOptions);
            writer.WriteStringValue("displayName", DisplayName);
        }
    }
}
