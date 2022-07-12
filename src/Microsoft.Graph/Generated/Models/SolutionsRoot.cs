using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SolutionsRoot : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The bookingBusinesses property</summary>
        public List<BookingBusiness> BookingBusinesses {
            get { return BackingStore?.Get<List<BookingBusiness>>("bookingBusinesses"); }
            set { BackingStore?.Set("bookingBusinesses", value); }
        }
        /// <summary>The bookingCurrencies property</summary>
        public List<BookingCurrency> BookingCurrencies {
            get { return BackingStore?.Get<List<BookingCurrency>>("bookingCurrencies"); }
            set { BackingStore?.Set("bookingCurrencies", value); }
        }
        /// <summary>
        /// Instantiates a new SolutionsRoot and sets the default values.
        /// </summary>
        public SolutionsRoot() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SolutionsRoot CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SolutionsRoot();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"bookingBusinesses", n => { BookingBusinesses = n.GetCollectionOfObjectValues<BookingBusiness>(BookingBusiness.CreateFromDiscriminatorValue).ToList(); } },
                {"bookingCurrencies", n => { BookingCurrencies = n.GetCollectionOfObjectValues<BookingCurrency>(BookingCurrency.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<BookingBusiness>("bookingBusinesses", BookingBusinesses);
            writer.WriteCollectionOfObjectValues<BookingCurrency>("bookingCurrencies", BookingCurrencies);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
