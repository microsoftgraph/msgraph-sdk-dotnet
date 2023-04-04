using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Drives.Item.Items.Item.Workbook.Tables.Item.Sort.Apply {
    public class ApplyPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The fields property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<WorkbookSortField>? Fields {
            get { return BackingStore?.Get<List<WorkbookSortField>?>("fields"); }
            set { BackingStore?.Set("fields", value); }
        }
#nullable restore
#else
        public List<WorkbookSortField> Fields {
            get { return BackingStore?.Get<List<WorkbookSortField>>("fields"); }
            set { BackingStore?.Set("fields", value); }
        }
#endif
        /// <summary>The matchCase property</summary>
        public bool? MatchCase {
            get { return BackingStore?.Get<bool?>("matchCase"); }
            set { BackingStore?.Set("matchCase", value); }
        }
        /// <summary>The method property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Method {
            get { return BackingStore?.Get<string?>("method"); }
            set { BackingStore?.Set("method", value); }
        }
#nullable restore
#else
        public string Method {
            get { return BackingStore?.Get<string>("method"); }
            set { BackingStore?.Set("method", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new applyPostRequestBody and sets the default values.
        /// </summary>
        public ApplyPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ApplyPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ApplyPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"fields", n => { Fields = n.GetCollectionOfObjectValues<WorkbookSortField>(WorkbookSortField.CreateFromDiscriminatorValue)?.ToList(); } },
                {"matchCase", n => { MatchCase = n.GetBoolValue(); } },
                {"method", n => { Method = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<WorkbookSortField>("fields", Fields);
            writer.WriteBoolValue("matchCase", MatchCase);
            writer.WriteStringValue("method", Method);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
