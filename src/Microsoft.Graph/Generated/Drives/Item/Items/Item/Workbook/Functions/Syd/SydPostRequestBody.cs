using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Drives.Item.Items.Item.Workbook.Functions.Syd {
    public class SydPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The cost property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Cost {
            get { return BackingStore?.Get<Json?>("cost"); }
            set { BackingStore?.Set("cost", value); }
        }
#nullable restore
#else
        public Json Cost {
            get { return BackingStore?.Get<Json>("cost"); }
            set { BackingStore?.Set("cost", value); }
        }
#endif
        /// <summary>The life property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Life {
            get { return BackingStore?.Get<Json?>("life"); }
            set { BackingStore?.Set("life", value); }
        }
#nullable restore
#else
        public Json Life {
            get { return BackingStore?.Get<Json>("life"); }
            set { BackingStore?.Set("life", value); }
        }
#endif
        /// <summary>The per property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Per {
            get { return BackingStore?.Get<Json?>("per"); }
            set { BackingStore?.Set("per", value); }
        }
#nullable restore
#else
        public Json Per {
            get { return BackingStore?.Get<Json>("per"); }
            set { BackingStore?.Set("per", value); }
        }
#endif
        /// <summary>The salvage property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Salvage {
            get { return BackingStore?.Get<Json?>("salvage"); }
            set { BackingStore?.Set("salvage", value); }
        }
#nullable restore
#else
        public Json Salvage {
            get { return BackingStore?.Get<Json>("salvage"); }
            set { BackingStore?.Set("salvage", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new sydPostRequestBody and sets the default values.
        /// </summary>
        public SydPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static SydPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SydPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"cost", n => { Cost = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"life", n => { Life = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"per", n => { Per = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"salvage", n => { Salvage = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Json>("cost", Cost);
            writer.WriteObjectValue<Json>("life", Life);
            writer.WriteObjectValue<Json>("per", Per);
            writer.WriteObjectValue<Json>("salvage", Salvage);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
