using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CountryNamedLocation : NamedLocation, IParsable {
        /// <summary>List of countries and/or regions in two-letter format specified by ISO 3166-2.</summary>
        public List<string> CountriesAndRegions {
            get { return BackingStore?.Get<List<string>>("countriesAndRegions"); }
            set { BackingStore?.Set("countriesAndRegions", value); }
        }
        /// <summary>Determines what method is used to decide which country the user is located in. Possible values are clientIpAddress (default) and authenticatorAppGps.</summary>
        public CountryLookupMethodType? CountryLookupMethod {
            get { return BackingStore?.Get<CountryLookupMethodType?>("countryLookupMethod"); }
            set { BackingStore?.Set("countryLookupMethod", value); }
        }
        /// <summary>true if IP addresses that don&apos;t map to a country or region should be included in the named location. Optional. Default value is false.</summary>
        public bool? IncludeUnknownCountriesAndRegions {
            get { return BackingStore?.Get<bool?>("includeUnknownCountriesAndRegions"); }
            set { BackingStore?.Set("includeUnknownCountriesAndRegions", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CountryNamedLocation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CountryNamedLocation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"countriesAndRegions", n => { CountriesAndRegions = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"countryLookupMethod", n => { CountryLookupMethod = n.GetEnumValue<CountryLookupMethodType>(); } },
                {"includeUnknownCountriesAndRegions", n => { IncludeUnknownCountriesAndRegions = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfPrimitiveValues<string>("countriesAndRegions", CountriesAndRegions);
            writer.WriteEnumValue<CountryLookupMethodType>("countryLookupMethod", CountryLookupMethod);
            writer.WriteBoolValue("includeUnknownCountriesAndRegions", IncludeUnknownCountriesAndRegions);
        }
    }
}
