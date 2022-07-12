using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EducationFeedback : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>User who created the feedback.</summary>
        public IdentitySet FeedbackBy {
            get { return BackingStore?.Get<IdentitySet>("feedbackBy"); }
            set { BackingStore?.Set("feedbackBy", value); }
        }
        /// <summary>Moment in time when the feedback was given. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? FeedbackDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("feedbackDateTime"); }
            set { BackingStore?.Set("feedbackDateTime", value); }
        }
        /// <summary>Feedback.</summary>
        public EducationItemBody Text {
            get { return BackingStore?.Get<EducationItemBody>("text"); }
            set { BackingStore?.Set("text", value); }
        }
        /// <summary>
        /// Instantiates a new educationFeedback and sets the default values.
        /// </summary>
        public EducationFeedback() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static EducationFeedback CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EducationFeedback();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"feedbackBy", n => { FeedbackBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"feedbackDateTime", n => { FeedbackDateTime = n.GetDateTimeOffsetValue(); } },
                {"text", n => { Text = n.GetObjectValue<EducationItemBody>(EducationItemBody.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IdentitySet>("feedbackBy", FeedbackBy);
            writer.WriteDateTimeOffsetValue("feedbackDateTime", FeedbackDateTime);
            writer.WriteObjectValue<EducationItemBody>("text", Text);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
