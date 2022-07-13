using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AvailabilityItem : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The endTime property</summary>
        public Time? EndTime {
            get { return BackingStore?.Get<Time?>("endTime"); }
            set { BackingStore?.Set("endTime", value); }
        }
        /// <summary>Indicates the service ID in case of 1:n appointments. If the appointment is of type 1:n, this field will be present, otherwise, null.</summary>
        public string ServiceId {
            get { return BackingStore?.Get<string>("serviceId"); }
            set { BackingStore?.Set("serviceId", value); }
        }
        /// <summary>The startTime property</summary>
        public Time? StartTime {
            get { return BackingStore?.Get<Time?>("startTime"); }
            set { BackingStore?.Set("startTime", value); }
        }
        /// <summary>The status of the staff member. Possible values are: available, busy, slotsAvailable, outOfOffice, unknownFutureValue.</summary>
        public BookingsAvailabilityStatus? Status {
            get { return BackingStore?.Get<BookingsAvailabilityStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new availabilityItem and sets the default values.
        /// </summary>
        public AvailabilityItem() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AvailabilityItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AvailabilityItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"endTime", n => { EndTime = n.GetTimeValue(); } },
                {"serviceId", n => { ServiceId = n.GetStringValue(); } },
                {"startTime", n => { StartTime = n.GetTimeValue(); } },
                {"status", n => { Status = n.GetEnumValue<BookingsAvailabilityStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteTimeValue("endTime", EndTime);
            writer.WriteStringValue("serviceId", ServiceId);
            writer.WriteTimeValue("startTime", StartTime);
            writer.WriteEnumValue<BookingsAvailabilityStatus>("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
