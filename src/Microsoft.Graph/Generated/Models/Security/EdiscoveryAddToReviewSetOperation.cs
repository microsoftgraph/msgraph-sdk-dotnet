using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class EdiscoveryAddToReviewSetOperation : CaseOperation, IParsable {
        /// <summary>eDiscovery review set to which items matching source collection query gets added.</summary>
        public EdiscoveryReviewSet ReviewSet {
            get { return BackingStore?.Get<EdiscoveryReviewSet>("reviewSet"); }
            set { BackingStore?.Set("reviewSet", value); }
        }
        /// <summary>eDiscovery search that gets added to review set.</summary>
        public EdiscoverySearch Search {
            get { return BackingStore?.Get<EdiscoverySearch>("search"); }
            set { BackingStore?.Set("search", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EdiscoveryAddToReviewSetOperation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EdiscoveryAddToReviewSetOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"reviewSet", n => { ReviewSet = n.GetObjectValue<EdiscoveryReviewSet>(EdiscoveryReviewSet.CreateFromDiscriminatorValue); } },
                {"search", n => { Search = n.GetObjectValue<EdiscoverySearch>(EdiscoverySearch.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<EdiscoveryReviewSet>("reviewSet", ReviewSet);
            writer.WriteObjectValue<EdiscoverySearch>("search", Search);
        }
    }
}
