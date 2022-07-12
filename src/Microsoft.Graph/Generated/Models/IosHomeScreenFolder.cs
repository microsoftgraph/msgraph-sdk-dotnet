using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IosHomeScreenFolder : IosHomeScreenItem, IParsable {
        /// <summary>Pages of Home Screen Layout Icons which must be applications or web clips. This collection can contain a maximum of 500 elements.</summary>
        public List<IosHomeScreenFolderPage> Pages {
            get { return BackingStore?.Get<List<IosHomeScreenFolderPage>>("pages"); }
            set { BackingStore?.Set("pages", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IosHomeScreenFolder CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosHomeScreenFolder();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"pages", n => { Pages = n.GetCollectionOfObjectValues<IosHomeScreenFolderPage>(IosHomeScreenFolderPage.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<IosHomeScreenFolderPage>("pages", Pages);
        }
    }
}
