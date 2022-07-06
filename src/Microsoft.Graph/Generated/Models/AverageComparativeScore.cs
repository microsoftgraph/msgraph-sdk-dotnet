using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AverageComparativeScore : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Average score within specified basis.</summary>
        public double? AverageScore {
            get { return BackingStore?.Get<double?>("averageScore"); }
            set { BackingStore?.Set("averageScore", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Scope type. The possible values are: AllTenants, TotalSeats, IndustryTypes.</summary>
        public string Basis {
            get { return BackingStore?.Get<string>("basis"); }
            set { BackingStore?.Set("basis", value); }
        }
        /// <summary>
        /// Instantiates a new averageComparativeScore and sets the default values.
        /// </summary>
        public AverageComparativeScore() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AverageComparativeScore CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AverageComparativeScore();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"averageScore", n => { AverageScore = n.GetDoubleValue(); } },
                {"basis", n => { Basis = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDoubleValue("averageScore", AverageScore);
            writer.WriteStringValue("basis", Basis);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
