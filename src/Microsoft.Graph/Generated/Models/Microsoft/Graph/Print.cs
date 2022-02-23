using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class Print : IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The list of available print connectors.</summary>
        public List<PrintConnector> Connectors { get; set; }
        /// <summary>The list of print long running operations.</summary>
        public List<PrintOperation> Operations { get; set; }
        /// <summary>The list of printers registered in the tenant.</summary>
        public List<Printer> Printers { get; set; }
        /// <summary>The list of available Universal Print service endpoints.</summary>
        public List<PrintService> Services { get; set; }
        /// <summary>Tenant-wide settings for the Universal Print service.</summary>
        public PrintSettings Settings { get; set; }
        /// <summary>The list of printer shares registered in the tenant.</summary>
        public List<PrinterShare> Shares { get; set; }
        /// <summary>List of abstract definition for a task that can be triggered when various events occur within Universal Print.</summary>
        public List<PrintTaskDefinition> TaskDefinitions { get; set; }
        /// <summary>
        /// Instantiates a new Print and sets the default values.
        /// </summary>
        public Print() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"connectors", (o,n) => { (o as Print).Connectors = n.GetCollectionOfObjectValues<PrintConnector>().ToList(); } },
                {"operations", (o,n) => { (o as Print).Operations = n.GetCollectionOfObjectValues<PrintOperation>().ToList(); } },
                {"printers", (o,n) => { (o as Print).Printers = n.GetCollectionOfObjectValues<Printer>().ToList(); } },
                {"services", (o,n) => { (o as Print).Services = n.GetCollectionOfObjectValues<PrintService>().ToList(); } },
                {"settings", (o,n) => { (o as Print).Settings = n.GetObjectValue<PrintSettings>(); } },
                {"shares", (o,n) => { (o as Print).Shares = n.GetCollectionOfObjectValues<PrinterShare>().ToList(); } },
                {"taskDefinitions", (o,n) => { (o as Print).TaskDefinitions = n.GetCollectionOfObjectValues<PrintTaskDefinition>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<PrintConnector>("connectors", Connectors);
            writer.WriteCollectionOfObjectValues<PrintOperation>("operations", Operations);
            writer.WriteCollectionOfObjectValues<Printer>("printers", Printers);
            writer.WriteCollectionOfObjectValues<PrintService>("services", Services);
            writer.WriteObjectValue<PrintSettings>("settings", Settings);
            writer.WriteCollectionOfObjectValues<PrinterShare>("shares", Shares);
            writer.WriteCollectionOfObjectValues<PrintTaskDefinition>("taskDefinitions", TaskDefinitions);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
