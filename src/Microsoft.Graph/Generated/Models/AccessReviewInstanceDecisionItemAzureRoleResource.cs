using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class AccessReviewInstanceDecisionItemAzureRoleResource : AccessReviewInstanceDecisionItemResource, IParsable {
        /// <summary>Details of the scope this role is associated with.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public AccessReviewInstanceDecisionItemResource? Scope {
            get { return BackingStore?.Get<AccessReviewInstanceDecisionItemResource?>("scope"); }
            set { BackingStore?.Set("scope", value); }
        }
#nullable restore
#else
        public AccessReviewInstanceDecisionItemResource Scope {
            get { return BackingStore?.Get<AccessReviewInstanceDecisionItemResource>("scope"); }
            set { BackingStore?.Set("scope", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new AccessReviewInstanceDecisionItemAzureRoleResource and sets the default values.
        /// </summary>
        public AccessReviewInstanceDecisionItemAzureRoleResource() : base() {
            OdataType = "#microsoft.graph.accessReviewInstanceDecisionItemAzureRoleResource";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new AccessReviewInstanceDecisionItemAzureRoleResource CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessReviewInstanceDecisionItemAzureRoleResource();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"scope", n => { Scope = n.GetObjectValue<AccessReviewInstanceDecisionItemResource>(AccessReviewInstanceDecisionItemResource.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<AccessReviewInstanceDecisionItemResource>("scope", Scope);
        }
    }
}
