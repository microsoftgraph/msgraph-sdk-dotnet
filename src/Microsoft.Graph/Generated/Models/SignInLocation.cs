using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SignInLocation : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Provides the city where the sign-in originated. This is calculated using latitude/longitude information from the sign-in activity.</summary>
        public string City {
            get { return BackingStore?.Get<string>("city"); }
            set { BackingStore?.Set("city", value); }
        }
        /// <summary>Provides the country code info (2 letter code) where the sign-in originated.  This is calculated using latitude/longitude information from the sign-in activity.</summary>
        public string CountryOrRegion {
            get { return BackingStore?.Get<string>("countryOrRegion"); }
            set { BackingStore?.Set("countryOrRegion", value); }
        }
        /// <summary>Provides the latitude, longitude and altitude where the sign-in originated.</summary>
        public Microsoft.Graph.Models.GeoCoordinates GeoCoordinates {
            get { return BackingStore?.Get<Microsoft.Graph.Models.GeoCoordinates>("geoCoordinates"); }
            set { BackingStore?.Set("geoCoordinates", value); }
        }
        /// <summary>Provides the State where the sign-in originated. This is calculated using latitude/longitude information from the sign-in activity.</summary>
        public string State {
            get { return BackingStore?.Get<string>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>
        /// Instantiates a new signInLocation and sets the default values.
        /// </summary>
        public SignInLocation() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SignInLocation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SignInLocation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"city", n => { City = n.GetStringValue(); } },
                {"countryOrRegion", n => { CountryOrRegion = n.GetStringValue(); } },
                {"geoCoordinates", n => { GeoCoordinates = n.GetObjectValue<Microsoft.Graph.Models.GeoCoordinates>(Microsoft.Graph.Models.GeoCoordinates.CreateFromDiscriminatorValue); } },
                {"state", n => { State = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("city", City);
            writer.WriteStringValue("countryOrRegion", CountryOrRegion);
            writer.WriteObjectValue<Microsoft.Graph.Models.GeoCoordinates>("geoCoordinates", GeoCoordinates);
            writer.WriteStringValue("state", State);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
