using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class PrinterBase : Entity, IParsable {
        /// <summary>The capabilities of the printer/printerShare.</summary>
        public PrinterCapabilities Capabilities {
            get { return BackingStore?.Get<PrinterCapabilities>("capabilities"); }
            set { BackingStore?.Set("capabilities", value); }
        }
        /// <summary>The default print settings of printer/printerShare.</summary>
        public PrinterDefaults Defaults {
            get { return BackingStore?.Get<PrinterDefaults>("defaults"); }
            set { BackingStore?.Set("defaults", value); }
        }
        /// <summary>The name of the printer/printerShare.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Whether the printer/printerShare is currently accepting new print jobs.</summary>
        public bool? IsAcceptingJobs {
            get { return BackingStore?.Get<bool?>("isAcceptingJobs"); }
            set { BackingStore?.Set("isAcceptingJobs", value); }
        }
        /// <summary>The list of jobs that are queued for printing by the printer/printerShare.</summary>
        public List<PrintJob> Jobs {
            get { return BackingStore?.Get<List<PrintJob>>("jobs"); }
            set { BackingStore?.Set("jobs", value); }
        }
        /// <summary>The physical and/or organizational location of the printer/printerShare.</summary>
        public PrinterLocation Location {
            get { return BackingStore?.Get<PrinterLocation>("location"); }
            set { BackingStore?.Set("location", value); }
        }
        /// <summary>The manufacturer of the printer/printerShare.</summary>
        public string Manufacturer {
            get { return BackingStore?.Get<string>("manufacturer"); }
            set { BackingStore?.Set("manufacturer", value); }
        }
        /// <summary>The model name of the printer/printerShare.</summary>
        public string Model {
            get { return BackingStore?.Get<string>("model"); }
            set { BackingStore?.Set("model", value); }
        }
        /// <summary>The status property</summary>
        public PrinterStatus Status {
            get { return BackingStore?.Get<PrinterStatus>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>
        /// Instantiates a new printerBase and sets the default values.
        /// </summary>
        public PrinterBase() : base() {
            Type = "#microsoft.graph.printerBase";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new PrinterBase CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.printer" => new Printer(),
                "#microsoft.graph.printerShare" => new PrinterShare(),
                _ => new PrinterBase(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"capabilities", n => { Capabilities = n.GetObjectValue<PrinterCapabilities>(PrinterCapabilities.CreateFromDiscriminatorValue); } },
                {"defaults", n => { Defaults = n.GetObjectValue<PrinterDefaults>(PrinterDefaults.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"isAcceptingJobs", n => { IsAcceptingJobs = n.GetBoolValue(); } },
                {"jobs", n => { Jobs = n.GetCollectionOfObjectValues<PrintJob>(PrintJob.CreateFromDiscriminatorValue).ToList(); } },
                {"location", n => { Location = n.GetObjectValue<PrinterLocation>(PrinterLocation.CreateFromDiscriminatorValue); } },
                {"manufacturer", n => { Manufacturer = n.GetStringValue(); } },
                {"model", n => { Model = n.GetStringValue(); } },
                {"status", n => { Status = n.GetObjectValue<PrinterStatus>(PrinterStatus.CreateFromDiscriminatorValue); } },
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
