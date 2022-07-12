using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class LocationConstraint : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The client requests the service to include in the response a meeting location for the meeting. If this is true and all the resources are busy, findMeetingTimes will not return any meeting time suggestions. If this is false and all the resources are busy, findMeetingTimes would still look for meeting times without locations.</summary>
        public bool? IsRequired {
            get { return BackingStore?.Get<bool?>("isRequired"); }
            set { BackingStore?.Set("isRequired", value); }
        }
        /// <summary>Constraint information for one or more locations that the client requests for the meeting.</summary>
        public List<LocationConstraintItem> Locations {
            get { return BackingStore?.Get<List<LocationConstraintItem>>("locations"); }
            set { BackingStore?.Set("locations", value); }
        }
        /// <summary>The client requests the service to suggest one or more meeting locations.</summary>
        public bool? SuggestLocation {
            get { return BackingStore?.Get<bool?>("suggestLocation"); }
            set { BackingStore?.Set("suggestLocation", value); }
        }
        /// <summary>
        /// Instantiates a new locationConstraint and sets the default values.
        /// </summary>
        public LocationConstraint() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static LocationConstraint CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LocationConstraint();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"isRequired", n => { IsRequired = n.GetBoolValue(); } },
                {"locations", n => { Locations = n.GetCollectionOfObjectValues<LocationConstraintItem>(LocationConstraintItem.CreateFromDiscriminatorValue).ToList(); } },
                {"suggestLocation", n => { SuggestLocation = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("isRequired", IsRequired);
            writer.WriteCollectionOfObjectValues<LocationConstraintItem>("locations", Locations);
            writer.WriteBoolValue("suggestLocation", SuggestLocation);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
