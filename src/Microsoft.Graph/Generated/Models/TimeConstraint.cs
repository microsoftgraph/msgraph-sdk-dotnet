using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TimeConstraint : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>The nature of the activity, optional. Possible values are: work, personal, unrestricted, or unknown.</summary>
        public Microsoft.Graph.Models.ActivityDomain? ActivityDomain {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ActivityDomain?>("activityDomain"); }
            set { BackingStore?.Set("activityDomain", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The timeSlots property</summary>
        public List<TimeSlot> TimeSlots {
            get { return BackingStore?.Get<List<TimeSlot>>("timeSlots"); }
            set { BackingStore?.Set("timeSlots", value); }
        }
        /// <summary>
        /// Instantiates a new timeConstraint and sets the default values.
        /// </summary>
        public TimeConstraint() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TimeConstraint CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TimeConstraint();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"activityDomain", n => { ActivityDomain = n.GetEnumValue<ActivityDomain>(); } },
                {"timeSlots", n => { TimeSlots = n.GetCollectionOfObjectValues<TimeSlot>(TimeSlot.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<ActivityDomain>("activityDomain", ActivityDomain);
            writer.WriteCollectionOfObjectValues<TimeSlot>("timeSlots", TimeSlots);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
