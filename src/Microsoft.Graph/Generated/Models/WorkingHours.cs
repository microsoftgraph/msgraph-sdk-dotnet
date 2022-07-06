using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WorkingHours : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The days of the week on which the user works.</summary>
        public List<string> DaysOfWeek {
            get { return BackingStore?.Get<List<string>>("daysOfWeek"); }
            set { BackingStore?.Set("daysOfWeek", value); }
        }
        /// <summary>The time of the day that the user stops working.</summary>
        public Time? EndTime {
            get { return BackingStore?.Get<Time?>("endTime"); }
            set { BackingStore?.Set("endTime", value); }
        }
        /// <summary>The time of the day that the user starts working.</summary>
        public Time? StartTime {
            get { return BackingStore?.Get<Time?>("startTime"); }
            set { BackingStore?.Set("startTime", value); }
        }
        /// <summary>The time zone to which the working hours apply.</summary>
        public TimeZoneBase TimeZone {
            get { return BackingStore?.Get<TimeZoneBase>("timeZone"); }
            set { BackingStore?.Set("timeZone", value); }
        }
        /// <summary>
        /// Instantiates a new workingHours and sets the default values.
        /// </summary>
        public WorkingHours() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static WorkingHours CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkingHours();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"daysOfWeek", n => { DaysOfWeek = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"endTime", n => { EndTime = n.GetTimeValue(); } },
                {"startTime", n => { StartTime = n.GetTimeValue(); } },
                {"timeZone", n => { TimeZone = n.GetObjectValue<TimeZoneBase>(TimeZoneBase.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("daysOfWeek", DaysOfWeek);
            writer.WriteTimeValue("endTime", EndTime);
            writer.WriteTimeValue("startTime", StartTime);
            writer.WriteObjectValue<TimeZoneBase>("timeZone", TimeZone);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
