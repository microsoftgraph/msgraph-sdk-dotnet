using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RecurrencePattern : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.</summary>
        public int? DayOfMonth {
            get { return BackingStore?.Get<int?>("dayOfMonth"); }
            set { BackingStore?.Set("dayOfMonth", value); }
        }
        /// <summary>A collection of the days of the week on which the event occurs. The possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. If type is relativeMonthly or relativeYearly, and daysOfWeek specifies more than one day, the event falls on the first day that satisfies the pattern.  Required if type is weekly, relativeMonthly, or relativeYearly.</summary>
        public List<string> DaysOfWeek {
            get { return BackingStore?.Get<List<string>>("daysOfWeek"); }
            set { BackingStore?.Set("daysOfWeek", value); }
        }
        /// <summary>The first day of the week. The possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. Default is sunday. Required if type is weekly.</summary>
        public DayOfWeek? FirstDayOfWeek {
            get { return BackingStore?.Get<DayOfWeek?>("firstDayOfWeek"); }
            set { BackingStore?.Set("firstDayOfWeek", value); }
        }
        /// <summary>Specifies on which instance of the allowed days specified in daysOfWeek the event occurs, counted from the first instance in the month. The possible values are: first, second, third, fourth, last. Default is first. Optional and used if type is relativeMonthly or relativeYearly.</summary>
        public WeekIndex? Index {
            get { return BackingStore?.Get<WeekIndex?>("index"); }
            set { BackingStore?.Set("index", value); }
        }
        /// <summary>The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.</summary>
        public int? Interval {
            get { return BackingStore?.Get<int?>("interval"); }
            set { BackingStore?.Set("interval", value); }
        }
        /// <summary>The month in which the event occurs.  This is a number from 1 to 12.</summary>
        public int? Month {
            get { return BackingStore?.Get<int?>("month"); }
            set { BackingStore?.Set("month", value); }
        }
        /// <summary>The recurrence pattern type: daily, weekly, absoluteMonthly, relativeMonthly, absoluteYearly, relativeYearly. Required. For more information, see values of type property.</summary>
        public RecurrencePatternType? Type {
            get { return BackingStore?.Get<RecurrencePatternType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new recurrencePattern and sets the default values.
        /// </summary>
        public RecurrencePattern() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static RecurrencePattern CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RecurrencePattern();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"dayOfMonth", n => { DayOfMonth = n.GetIntValue(); } },
                {"daysOfWeek", n => { DaysOfWeek = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"firstDayOfWeek", n => { FirstDayOfWeek = n.GetEnumValue<DayOfWeek>(); } },
                {"index", n => { Index = n.GetEnumValue<WeekIndex>(); } },
                {"interval", n => { Interval = n.GetIntValue(); } },
                {"month", n => { Month = n.GetIntValue(); } },
                {"type", n => { Type = n.GetEnumValue<RecurrencePatternType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("dayOfMonth", DayOfMonth);
            writer.WriteCollectionOfPrimitiveValues<string>("daysOfWeek", DaysOfWeek);
            writer.WriteEnumValue<DayOfWeek>("firstDayOfWeek", FirstDayOfWeek);
            writer.WriteEnumValue<WeekIndex>("index", Index);
            writer.WriteIntValue("interval", Interval);
            writer.WriteIntValue("month", Month);
            writer.WriteEnumValue<RecurrencePatternType>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
