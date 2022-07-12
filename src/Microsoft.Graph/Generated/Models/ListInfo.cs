using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ListInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>If true, indicates that content types are enabled for this list.</summary>
        public bool? ContentTypesEnabled {
            get { return BackingStore?.Get<bool?>("contentTypesEnabled"); }
            set { BackingStore?.Set("contentTypesEnabled", value); }
        }
        /// <summary>If true, indicates that the list is not normally visible in the SharePoint user experience.</summary>
        public bool? Hidden {
            get { return BackingStore?.Get<bool?>("hidden"); }
            set { BackingStore?.Set("hidden", value); }
        }
        /// <summary>An enumerated value that represents the base list template used in creating the list. Possible values include documentLibrary, genericList, task, survey, announcements, contacts, and more.</summary>
        public string Template {
            get { return BackingStore?.Get<string>("template"); }
            set { BackingStore?.Set("template", value); }
        }
        /// <summary>
        /// Instantiates a new listInfo and sets the default values.
        /// </summary>
        public ListInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ListInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ListInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"contentTypesEnabled", n => { ContentTypesEnabled = n.GetBoolValue(); } },
                {"hidden", n => { Hidden = n.GetBoolValue(); } },
                {"template", n => { Template = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("contentTypesEnabled", ContentTypesEnabled);
            writer.WriteBoolValue("hidden", Hidden);
            writer.WriteStringValue("template", Template);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
