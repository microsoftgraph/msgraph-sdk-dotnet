using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class ThreatAssessmentRequest : Entity, IParsable {
        /// <summary>The category property</summary>
        public ThreatCategory? Category {
            get { return BackingStore?.Get<ThreatCategory?>("category"); }
            set { BackingStore?.Set("category", value); }
        }
        /// <summary>The content type of threat assessment. Possible values are: mail, url, file.</summary>
        public ThreatAssessmentContentType? ContentType {
            get { return BackingStore?.Get<ThreatAssessmentContentType?>("contentType"); }
            set { BackingStore?.Set("contentType", value); }
        }
        /// <summary>The threat assessment request creator.</summary>
        public IdentitySet CreatedBy {
            get { return BackingStore?.Get<IdentitySet>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The expectedAssessment property</summary>
        public ThreatExpectedAssessment? ExpectedAssessment {
            get { return BackingStore?.Get<ThreatExpectedAssessment?>("expectedAssessment"); }
            set { BackingStore?.Set("expectedAssessment", value); }
        }
        /// <summary>The source of the threat assessment request. Possible values are: user, administrator.</summary>
        public ThreatAssessmentRequestSource? RequestSource {
            get { return BackingStore?.Get<ThreatAssessmentRequestSource?>("requestSource"); }
            set { BackingStore?.Set("requestSource", value); }
        }
        /// <summary>A collection of threat assessment results. Read-only. By default, a GET /threatAssessmentRequests/{id} does not return this property unless you apply $expand on it.</summary>
        public List<ThreatAssessmentResult> Results {
            get { return BackingStore?.Get<List<ThreatAssessmentResult>>("results"); }
            set { BackingStore?.Set("results", value); }
        }
        /// <summary>The assessment process status. Possible values are: pending, completed.</summary>
        public ThreatAssessmentStatus? Status {
            get { return BackingStore?.Get<ThreatAssessmentStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new threatAssessmentRequest and sets the default values.
        /// </summary>
        public ThreatAssessmentRequest() : base() {
            Type = "#microsoft.graph.threatAssessmentRequest";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ThreatAssessmentRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.emailFileAssessmentRequest" => new EmailFileAssessmentRequest(),
                "#microsoft.graph.fileAssessmentRequest" => new FileAssessmentRequest(),
                "#microsoft.graph.mailAssessmentRequest" => new MailAssessmentRequest(),
                "#microsoft.graph.urlAssessmentRequest" => new UrlAssessmentRequest(),
                _ => new ThreatAssessmentRequest(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"category", n => { Category = n.GetEnumValue<ThreatCategory>(); } },
                {"contentType", n => { ContentType = n.GetEnumValue<ThreatAssessmentContentType>(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"expectedAssessment", n => { ExpectedAssessment = n.GetEnumValue<ThreatExpectedAssessment>(); } },
                {"requestSource", n => { RequestSource = n.GetEnumValue<ThreatAssessmentRequestSource>(); } },
                {"results", n => { Results = n.GetCollectionOfObjectValues<ThreatAssessmentResult>(ThreatAssessmentResult.CreateFromDiscriminatorValue).ToList(); } },
                {"status", n => { Status = n.GetEnumValue<ThreatAssessmentStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ThreatCategory>("category", Category);
            writer.WriteEnumValue<ThreatAssessmentContentType>("contentType", ContentType);
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteEnumValue<ThreatExpectedAssessment>("expectedAssessment", ExpectedAssessment);
            writer.WriteEnumValue<ThreatAssessmentRequestSource>("requestSource", RequestSource);
            writer.WriteCollectionOfObjectValues<ThreatAssessmentResult>("results", Results);
            writer.WriteEnumValue<ThreatAssessmentStatus>("status", Status);
        }
    }
}
