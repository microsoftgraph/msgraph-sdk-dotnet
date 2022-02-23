using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class PrinterBase : Entity, IParsable {
        /// <summary>The capabilities of the printer/printerShare.</summary>
        public PrinterCapabilities Capabilities { get; set; }
        /// <summary>The default print settings of printer/printerShare.</summary>
        public PrinterDefaults Defaults { get; set; }
        /// <summary>The name of the printer/printerShare.</summary>
        public string DisplayName { get; set; }
        /// <summary>Whether the printer/printerShare is currently accepting new print jobs.</summary>
        public bool? IsAcceptingJobs { get; set; }
        /// <summary>The list of jobs that are queued for printing by the printer/printerShare.</summary>
        public List<PrintJob> Jobs { get; set; }
        /// <summary>The physical and/or organizational location of the printer/printerShare.</summary>
        public PrinterLocation Location { get; set; }
        /// <summary>The manufacturer of the printer/printerShare.</summary>
        public string Manufacturer { get; set; }
        /// <summary>The model name of the printer/printerShare.</summary>
        public string Model { get; set; }
        public PrinterStatus Status { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"capabilities", (o,n) => { (o as PrinterBase).Capabilities = n.GetObjectValue<PrinterCapabilities>(); } },
                {"defaults", (o,n) => { (o as PrinterBase).Defaults = n.GetObjectValue<PrinterDefaults>(); } },
                {"displayName", (o,n) => { (o as PrinterBase).DisplayName = n.GetStringValue(); } },
                {"isAcceptingJobs", (o,n) => { (o as PrinterBase).IsAcceptingJobs = n.GetBoolValue(); } },
                {"jobs", (o,n) => { (o as PrinterBase).Jobs = n.GetCollectionOfObjectValues<PrintJob>().ToList(); } },
                {"location", (o,n) => { (o as PrinterBase).Location = n.GetObjectValue<PrinterLocation>(); } },
                {"manufacturer", (o,n) => { (o as PrinterBase).Manufacturer = n.GetStringValue(); } },
                {"model", (o,n) => { (o as PrinterBase).Model = n.GetStringValue(); } },
                {"status", (o,n) => { (o as PrinterBase).Status = n.GetObjectValue<PrinterStatus>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PrinterCapabilities>("capabilities", Capabilities);
            writer.WriteObjectValue<PrinterDefaults>("defaults", Defaults);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("isAcceptingJobs", IsAcceptingJobs);
            writer.WriteCollectionOfObjectValues<PrintJob>("jobs", Jobs);
            writer.WriteObjectValue<PrinterLocation>("location", Location);
            writer.WriteStringValue("manufacturer", Manufacturer);
            writer.WriteStringValue("model", Model);
            writer.WriteObjectValue<PrinterStatus>("status", Status);
        }
    }
}
