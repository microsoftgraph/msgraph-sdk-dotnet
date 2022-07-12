using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AccessReviewInstanceDecisionItemAccessPackageAssignmentPolicyResource : AccessReviewInstanceDecisionItemResource, IParsable {
        /// <summary>Display name of the access package to which access has been granted.</summary>
        public string AccessPackageDisplayName {
            get { return BackingStore?.Get<string>("accessPackageDisplayName"); }
            set { BackingStore?.Set("accessPackageDisplayName", value); }
        }
        /// <summary>Identifier of the access package to which access has been granted.</summary>
        public string AccessPackageId {
            get { return BackingStore?.Get<string>("accessPackageId"); }
            set { BackingStore?.Set("accessPackageId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AccessReviewInstanceDecisionItemAccessPackageAssignmentPolicyResource CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessReviewInstanceDecisionItemAccessPackageAssignmentPolicyResource();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"accessPackageDisplayName", n => { AccessPackageDisplayName = n.GetStringValue(); } },
                {"accessPackageId", n => { AccessPackageId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("accessPackageDisplayName", AccessPackageDisplayName);
            writer.WriteStringValue("accessPackageId", AccessPackageId);
        }
    }
}
