using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CalculatedColumn : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>For dateTime output types, the format of the value. Must be one of dateOnly or dateTime.</summary>
        public string Format {
            get { return BackingStore?.Get<string>("format"); }
            set { BackingStore?.Set("format", value); }
        }
        /// <summary>The formula used to compute the value for this column.</summary>
        public string Formula {
            get { return BackingStore?.Get<string>("formula"); }
            set { BackingStore?.Set("formula", value); }
        }
        /// <summary>The output type used to format values in this column. Must be one of boolean, currency, dateTime, number, or text.</summary>
        public string OutputType {
            get { return BackingStore?.Get<string>("outputType"); }
            set { BackingStore?.Set("outputType", value); }
        }
        /// <summary>
        /// Instantiates a new calculatedColumn and sets the default values.
        /// </summary>
        public CalculatedColumn() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CalculatedColumn CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CalculatedColumn();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"format", n => { Format = n.GetStringValue(); } },
                {"formula", n => { Formula = n.GetStringValue(); } },
                {"outputType", n => { OutputType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("format", Format);
            writer.WriteStringValue("formula", Formula);
            writer.WriteStringValue("outputType", OutputType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
