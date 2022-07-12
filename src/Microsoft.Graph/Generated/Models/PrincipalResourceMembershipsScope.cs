using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PrincipalResourceMembershipsScope : AccessReviewScope, IParsable {
        /// <summary>Defines the scopes of the principals whose access to resources are reviewed in the access review.</summary>
        public List<AccessReviewScope> PrincipalScopes {
            get { return BackingStore?.Get<List<AccessReviewScope>>("principalScopes"); }
            set { BackingStore?.Set("principalScopes", value); }
        }
        /// <summary>Defines the scopes of the resources for which access is reviewed.</summary>
        public List<AccessReviewScope> ResourceScopes {
            get { return BackingStore?.Get<List<AccessReviewScope>>("resourceScopes"); }
            set { BackingStore?.Set("resourceScopes", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PrincipalResourceMembershipsScope CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PrincipalResourceMembershipsScope();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"principalScopes", n => { PrincipalScopes = n.GetCollectionOfObjectValues<AccessReviewScope>(AccessReviewScope.CreateFromDiscriminatorValue).ToList(); } },
                {"resourceScopes", n => { ResourceScopes = n.GetCollectionOfObjectValues<AccessReviewScope>(AccessReviewScope.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<AccessReviewScope>("principalScopes", PrincipalScopes);
            writer.WriteCollectionOfObjectValues<AccessReviewScope>("resourceScopes", ResourceScopes);
        }
    }
}
