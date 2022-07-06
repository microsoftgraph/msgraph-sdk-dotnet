using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class BookingQuestionAnswer : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The answer given by the user in case the answerInputType is text.</summary>
        public string Answer {
            get { return BackingStore?.Get<string>("answer"); }
            set { BackingStore?.Set("answer", value); }
        }
        /// <summary>The expected answer type. The possible values are: text, radioButton, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.AnswerInputType? AnswerInputType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.AnswerInputType?>("answerInputType"); }
            set { BackingStore?.Set("answerInputType", value); }
        }
        /// <summary>In case the answerInputType is radioButton, this will consists of a list of possible answer values.</summary>
        public List<string> AnswerOptions {
            get { return BackingStore?.Get<List<string>>("answerOptions"); }
            set { BackingStore?.Set("answerOptions", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates whether it is mandatory to answer the custom question.</summary>
        public bool? IsRequired {
            get { return BackingStore?.Get<bool?>("isRequired"); }
            set { BackingStore?.Set("isRequired", value); }
        }
        /// <summary>The question.</summary>
        public string Question {
            get { return BackingStore?.Get<string>("question"); }
            set { BackingStore?.Set("question", value); }
        }
        /// <summary>The ID of the custom question.</summary>
        public string QuestionId {
            get { return BackingStore?.Get<string>("questionId"); }
            set { BackingStore?.Set("questionId", value); }
        }
        /// <summary>The answers selected by the user.</summary>
        public List<string> SelectedOptions {
            get { return BackingStore?.Get<List<string>>("selectedOptions"); }
            set { BackingStore?.Set("selectedOptions", value); }
        }
        /// <summary>
        /// Instantiates a new bookingQuestionAnswer and sets the default values.
        /// </summary>
        public BookingQuestionAnswer() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static BookingQuestionAnswer CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new BookingQuestionAnswer();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"answer", n => { Answer = n.GetStringValue(); } },
                {"answerInputType", n => { AnswerInputType = n.GetEnumValue<AnswerInputType>(); } },
                {"answerOptions", n => { AnswerOptions = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"isRequired", n => { IsRequired = n.GetBoolValue(); } },
                {"question", n => { Question = n.GetStringValue(); } },
                {"questionId", n => { QuestionId = n.GetStringValue(); } },
                {"selectedOptions", n => { SelectedOptions = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("answer", Answer);
            writer.WriteEnumValue<AnswerInputType>("answerInputType", AnswerInputType);
            writer.WriteCollectionOfPrimitiveValues<string>("answerOptions", AnswerOptions);
            writer.WriteBoolValue("isRequired", IsRequired);
            writer.WriteStringValue("question", Question);
            writer.WriteStringValue("questionId", QuestionId);
            writer.WriteCollectionOfPrimitiveValues<string>("selectedOptions", SelectedOptions);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
