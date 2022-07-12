using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class GeoCoordinates : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Optional. The altitude (height), in feet,  above sea level for the item. Read-only.</summary>
        public double? Altitude {
            get { return BackingStore?.Get<double?>("altitude"); }
            set { BackingStore?.Set("altitude", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Optional. The latitude, in decimal, for the item. Writable on OneDrive Personal.</summary>
        public double? Latitude {
            get { return BackingStore?.Get<double?>("latitude"); }
            set { BackingStore?.Set("latitude", value); }
        }
        /// <summary>Optional. The longitude, in decimal, for the item. Writable on OneDrive Personal.</summary>
        public double? Longitude {
            get { return BackingStore?.Get<double?>("longitude"); }
            set { BackingStore?.Set("longitude", value); }
        }
        /// <summary>
        /// Instantiates a new geoCoordinates and sets the default values.
        /// </summary>
        public GeoCoordinates() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static GeoCoordinates CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GeoCoordinates();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"altitude", n => { Altitude = n.GetDoubleValue(); } },
                {"latitude", n => { Latitude = n.GetDoubleValue(); } },
                {"longitude", n => { Longitude = n.GetDoubleValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDoubleValue("altitude", Altitude);
            writer.WriteDoubleValue("latitude", Latitude);
            writer.WriteDoubleValue("longitude", Longitude);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
