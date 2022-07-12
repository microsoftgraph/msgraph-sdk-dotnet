using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AttendeeAvailability : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The email address and type of attendee - whether it&apos;s a person or a resource, and whether required or optional if it&apos;s a person.</summary>
        public AttendeeBase Attendee {
            get { return BackingStore?.Get<AttendeeBase>("attendee"); }
            set { BackingStore?.Set("attendee", value); }
        }
        /// <summary>The availability status of the attendee. Possible values are: free, tentative, busy, oof, workingElsewhere, unknown.</summary>
        public FreeBusyStatus? Availability {
            get { return BackingStore?.Get<FreeBusyStatus?>("availability"); }
            set { BackingStore?.Set("availability", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>
        /// Instantiates a new attendeeAvailability and sets the default values.
        /// </summary>
        public AttendeeAvailability() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AttendeeAvailability CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AttendeeAvailability();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attendee", n => { Attendee = n.GetObjectValue<AttendeeBase>(AttendeeBase.CreateFromDiscriminatorValue); } },
                {"availability", n => { Availability = n.GetEnumValue<FreeBusyStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AttendeeBase>("attendee", Attendee);
            writer.WriteEnumValue<FreeBusyStatus>("availability", Availability);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
