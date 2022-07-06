using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class FolderView : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The method by which the folder should be sorted.</summary>
        public string SortBy {
            get { return BackingStore?.Get<string>("sortBy"); }
            set { BackingStore?.Set("sortBy", value); }
        }
        /// <summary>If true, indicates that items should be sorted in descending order. Otherwise, items should be sorted ascending.</summary>
        public string SortOrder {
            get { return BackingStore?.Get<string>("sortOrder"); }
            set { BackingStore?.Set("sortOrder", value); }
        }
        /// <summary>The type of view that should be used to represent the folder.</summary>
        public string ViewType {
            get { return BackingStore?.Get<string>("viewType"); }
            set { BackingStore?.Set("viewType", value); }
        }
        /// <summary>
        /// Instantiates a new folderView and sets the default values.
        /// </summary>
        public FolderView() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static FolderView CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new FolderView();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"sortBy", n => { SortBy = n.GetStringValue(); } },
                {"sortOrder", n => { SortOrder = n.GetStringValue(); } },
                {"viewType", n => { ViewType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("sortBy", SortBy);
            writer.WriteStringValue("sortOrder", SortOrder);
            writer.WriteStringValue("viewType", ViewType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
