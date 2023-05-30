using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Drives.Item.Items.Item.Workbook.Functions.DateNamespace {
    public class DatePostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The day property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Day {
            get { return BackingStore?.Get<Json?>("day"); }
            set { BackingStore?.Set("day", value); }
        }
#nullable restore
#else
        public Json Day {
            get { return BackingStore?.Get<Json>("day"); }
            set { BackingStore?.Set("day", value); }
        }
#endif
        /// <summary>The month property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Month {
            get { return BackingStore?.Get<Json?>("month"); }
            set { BackingStore?.Set("month", value); }
        }
#nullable restore
#else
        public Json Month {
            get { return BackingStore?.Get<Json>("month"); }
            set { BackingStore?.Set("month", value); }
        }
#endif
        /// <summary>The year property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Json? Year {
            get { return BackingStore?.Get<Json?>("year"); }
            set { BackingStore?.Set("year", value); }
        }
#nullable restore
#else
        public Json Year {
            get { return BackingStore?.Get<Json>("year"); }
            set { BackingStore?.Set("year", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new datePostRequestBody and sets the default values.
        /// </summary>
        public DatePostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static DatePostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DatePostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"day", n => { Day = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"month", n => { Month = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
                {"year", n => { Year = n.GetObjectValue<Json>(Json.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Json>("day", Day);
            writer.WriteObjectValue<Json>("month", Month);
            writer.WriteObjectValue<Json>("year", Year);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
