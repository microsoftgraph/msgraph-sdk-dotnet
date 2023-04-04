using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Drives.Item.Items.Item.Workbook.Functions.Binom_Dist_Range {
    public class Binom_Dist_RangePostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The numberS property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? NumberS {
            get { return BackingStore?.Get<Json?>("numberS"); }
            set { BackingStore?.Set("numberS", value); }
        }
#nullable restore
#else
        public Json NumberS {
            get { return BackingStore?.Get<Json>("numberS"); }
            set { BackingStore?.Set("numberS", value); }
        }
#endif
        /// <summary>The numberS2 property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? NumberS2 {
            get { return BackingStore?.Get<Json?>("numberS2"); }
            set { BackingStore?.Set("numberS2", value); }
        }
#nullable restore
#else
        public Json NumberS2 {
            get { return BackingStore?.Get<Json>("numberS2"); }
            set { BackingStore?.Set("numberS2", value); }
        }
#endif
        /// <summary>The probabilityS property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? ProbabilityS {
            get { return BackingStore?.Get<Json?>("probabilityS"); }
            set { BackingStore?.Set("probabilityS", value); }
        }
#nullable restore
#else
        public Json ProbabilityS {
            get { return BackingStore?.Get<Json>("probabilityS"); }
            set { BackingStore?.Set("probabilityS", value); }
        }
#endif
        /// <summary>The trials property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Trials {
            get { return BackingStore?.Get<Json?>("trials"); }
            set { BackingStore?.Set("trials", value); }
        }
#nullable restore
#else
        public Json Trials {
            get { return BackingStore?.Get<Json>("trials"); }
            set { BackingStore?.Set("trials", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new binom_Dist_RangePostRequestBody and sets the default values.
        /// </summary>
        public Binom_Dist_RangePostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Binom_Dist_RangePostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Binom_Dist_RangePostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"numberS", n => { NumberS = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"numberS2", n => { NumberS2 = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"probabilityS", n => { ProbabilityS = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"trials", n => { Trials = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Json>("numberS", NumberS);
            writer.WriteObjectValue<Json>("numberS2", NumberS2);
            writer.WriteObjectValue<Json>("probabilityS", ProbabilityS);
            writer.WriteObjectValue<Json>("trials", Trials);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
