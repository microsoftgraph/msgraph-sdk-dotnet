using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public class ParticipantEndpoint : Endpoint, IParsable {
        /// <summary>The feedback provided by the user of this endpoint about the quality of the session.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public UserFeedback? Feedback {
            get { return BackingStore?.Get<UserFeedback?>("feedback"); }
            set { BackingStore?.Set("feedback", value); }
        }
#nullable restore
#else
        public UserFeedback Feedback {
            get { return BackingStore?.Get<UserFeedback>("feedback"); }
            set { BackingStore?.Set("feedback", value); }
        }
#endif
        /// <summary>Identity associated with the endpoint.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.IdentitySet? Identity {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentitySet?>("identity"); }
            set { BackingStore?.Set("identity", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.IdentitySet Identity {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentitySet>("identity"); }
            set { BackingStore?.Set("identity", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new ParticipantEndpoint and sets the default values.
        /// </summary>
        public ParticipantEndpoint() : base() {
            OdataType = "#microsoft.graph.callRecords.participantEndpoint";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ParticipantEndpoint CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ParticipantEndpoint();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"feedback", n => { Feedback = n.GetObjectValue<UserFeedback>(UserFeedback.CreateFromDiscriminatorValue); } },
                {"identity", n => { Identity = n.GetObjectValue<Microsoft.Graph.Models.IdentitySet>(Microsoft.Graph.Models.IdentitySet.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<UserFeedback>("feedback", Feedback);
            writer.WriteObjectValue<Microsoft.Graph.Models.IdentitySet>("identity", Identity);
        }
    }
}
