using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Printer : PrinterBase, IParsable {
        /// <summary>The connectors that are associated with the printer.</summary>
        public List<PrintConnector> Connectors {
            get { return BackingStore?.Get<List<PrintConnector>>("connectors"); }
            set { BackingStore?.Set("connectors", value); }
        }
        /// <summary>True if the printer has a physical device for printing. Read-only.</summary>
        public bool? HasPhysicalDevice {
            get { return BackingStore?.Get<bool?>("hasPhysicalDevice"); }
            set { BackingStore?.Set("hasPhysicalDevice", value); }
        }
        /// <summary>True if the printer is shared; false otherwise. Read-only.</summary>
        public bool? IsShared {
            get { return BackingStore?.Get<bool?>("isShared"); }
            set { BackingStore?.Set("isShared", value); }
        }
        /// <summary>The most recent dateTimeOffset when a printer interacted with Universal Print. Read-only.</summary>
        public DateTimeOffset? LastSeenDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastSeenDateTime"); }
            set { BackingStore?.Set("lastSeenDateTime", value); }
        }
        /// <summary>The DateTimeOffset when the printer was registered. Read-only.</summary>
        public DateTimeOffset? RegisteredDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("registeredDateTime"); }
            set { BackingStore?.Set("registeredDateTime", value); }
        }
        /// <summary>The list of printerShares that are associated with the printer. Currently, only one printerShare can be associated with the printer. Read-only. Nullable.</summary>
        public List<PrinterShare> Shares {
            get { return BackingStore?.Get<List<PrinterShare>>("shares"); }
            set { BackingStore?.Set("shares", value); }
        }
        /// <summary>A list of task triggers that are associated with the printer.</summary>
        public List<PrintTaskTrigger> TaskTriggers {
            get { return BackingStore?.Get<List<PrintTaskTrigger>>("taskTriggers"); }
            set { BackingStore?.Set("taskTriggers", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Printer CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Printer();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"connectors", n => { Connectors = n.GetCollectionOfObjectValues<PrintConnector>(PrintConnector.CreateFromDiscriminatorValue).ToList(); } },
                {"hasPhysicalDevice", n => { HasPhysicalDevice = n.GetBoolValue(); } },
                {"isShared", n => { IsShared = n.GetBoolValue(); } },
                {"lastSeenDateTime", n => { LastSeenDateTime = n.GetDateTimeOffsetValue(); } },
                {"registeredDateTime", n => { RegisteredDateTime = n.GetDateTimeOffsetValue(); } },
                {"shares", n => { Shares = n.GetCollectionOfObjectValues<PrinterShare>(PrinterShare.CreateFromDiscriminatorValue).ToList(); } },
                {"taskTriggers", n => { TaskTriggers = n.GetCollectionOfObjectValues<PrintTaskTrigger>(PrintTaskTrigger.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<PrintConnector>("connectors", Connectors);
            writer.WriteBoolValue("hasPhysicalDevice", HasPhysicalDevice);
            writer.WriteBoolValue("isShared", IsShared);
            writer.WriteDateTimeOffsetValue("lastSeenDateTime", LastSeenDateTime);
            writer.WriteDateTimeOffsetValue("registeredDateTime", RegisteredDateTime);
            writer.WriteCollectionOfObjectValues<PrinterShare>("shares", Shares);
            writer.WriteCollectionOfObjectValues<PrintTaskTrigger>("taskTriggers", TaskTriggers);
        }
    }
}
