using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ParentalControlSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Specifies the two-letter ISO country codes. Access to the application will be blocked for minors from the countries specified in this list.</summary>
        public List<string> CountriesBlockedForMinors {
            get { return BackingStore?.Get<List<string>>("countriesBlockedForMinors"); }
            set { BackingStore?.Set("countriesBlockedForMinors", value); }
        }
        /// <summary>Specifies the legal age group rule that applies to users of the app. Can be set to one of the following values: ValueDescriptionAllowDefault. Enforces the legal minimum. This means parental consent is required for minors in the European Union and Korea.RequireConsentForPrivacyServicesEnforces the user to specify date of birth to comply with COPPA rules. RequireConsentForMinorsRequires parental consent for ages below 18, regardless of country minor rules.RequireConsentForKidsRequires parental consent for ages below 14, regardless of country minor rules.BlockMinorsBlocks minors from using the app.</summary>
        public string LegalAgeGroupRule {
            get { return BackingStore?.Get<string>("legalAgeGroupRule"); }
            set { BackingStore?.Set("legalAgeGroupRule", value); }
        }
        /// <summary>
        /// Instantiates a new parentalControlSettings and sets the default values.
        /// </summary>
        public ParentalControlSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ParentalControlSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ParentalControlSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"countriesBlockedForMinors", n => { CountriesBlockedForMinors = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"legalAgeGroupRule", n => { LegalAgeGroupRule = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("countriesBlockedForMinors", CountriesBlockedForMinors);
            writer.WriteStringValue("legalAgeGroupRule", LegalAgeGroupRule);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
