using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SubjectRightsRequestStageDetail : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Describes the error, if any, for the current stage.</summary>
        public PublicError Error {
            get { return BackingStore?.Get<PublicError>("error"); }
            set { BackingStore?.Set("error", value); }
        }
        /// <summary>The stage of the subject rights request. Possible values are: contentRetrieval, contentReview, generateReport, contentDeletion, caseResolved, unknownFutureValue.</summary>
        public SubjectRightsRequestStage? Stage {
            get { return BackingStore?.Get<SubjectRightsRequestStage?>("stage"); }
            set { BackingStore?.Set("stage", value); }
        }
        /// <summary>Status of the current stage. Possible values are: notStarted, current, completed, failed, unknownFutureValue.</summary>
        public SubjectRightsRequestStageStatus? Status {
            get { return BackingStore?.Get<SubjectRightsRequestStageStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new subjectRightsRequestStageDetail and sets the default values.
        /// </summary>
        public SubjectRightsRequestStageDetail() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SubjectRightsRequestStageDetail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SubjectRightsRequestStageDetail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"error", n => { Error = n.GetObjectValue<PublicError>(PublicError.CreateFromDiscriminatorValue); } },
                {"stage", n => { Stage = n.GetEnumValue<SubjectRightsRequestStage>(); } },
                {"status", n => { Status = n.GetEnumValue<SubjectRightsRequestStageStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<PublicError>("error", Error);
            writer.WriteEnumValue<SubjectRightsRequestStage>("stage", Stage);
            writer.WriteEnumValue<SubjectRightsRequestStageStatus>("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
