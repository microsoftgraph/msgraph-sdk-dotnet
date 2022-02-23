using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class PrintJob : Entity, IParsable {
        public PrintJobConfiguration Configuration { get; set; }
        /// <summary>Read-only. Nullable.</summary>
        public UserIdentity CreatedBy { get; set; }
        /// <summary>The DateTimeOffset when the job was created. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Read-only.</summary>
        public List<PrintDocument> Documents { get; set; }
        /// <summary>If true, document can be fetched by printer.</summary>
        public bool? IsFetchable { get; set; }
        /// <summary>Contains the source job URL, if the job has been redirected from another printer.</summary>
        public string RedirectedFrom { get; set; }
        /// <summary>Contains the destination job URL, if the job has been redirected to another printer.</summary>
        public string RedirectedTo { get; set; }
        public PrintJobStatus Status { get; set; }
        /// <summary>A list of printTasks that were triggered by this print job.</summary>
        public List<PrintTask> Tasks { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"configuration", (o,n) => { (o as PrintJob).Configuration = n.GetObjectValue<PrintJobConfiguration>(); } },
                {"createdBy", (o,n) => { (o as PrintJob).CreatedBy = n.GetObjectValue<UserIdentity>(); } },
                {"createdDateTime", (o,n) => { (o as PrintJob).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"documents", (o,n) => { (o as PrintJob).Documents = n.GetCollectionOfObjectValues<PrintDocument>().ToList(); } },
                {"isFetchable", (o,n) => { (o as PrintJob).IsFetchable = n.GetBoolValue(); } },
                {"redirectedFrom", (o,n) => { (o as PrintJob).RedirectedFrom = n.GetStringValue(); } },
                {"redirectedTo", (o,n) => { (o as PrintJob).RedirectedTo = n.GetStringValue(); } },
                {"status", (o,n) => { (o as PrintJob).Status = n.GetObjectValue<PrintJobStatus>(); } },
                {"tasks", (o,n) => { (o as PrintJob).Tasks = n.GetCollectionOfObjectValues<PrintTask>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PrintJobConfiguration>("configuration", Configuration);
            writer.WriteObjectValue<UserIdentity>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteCollectionOfObjectValues<PrintDocument>("documents", Documents);
            writer.WriteBoolValue("isFetchable", IsFetchable);
            writer.WriteStringValue("redirectedFrom", RedirectedFrom);
            writer.WriteStringValue("redirectedTo", RedirectedTo);
            writer.WriteObjectValue<PrintJobStatus>("status", Status);
            writer.WriteCollectionOfObjectValues<PrintTask>("tasks", Tasks);
        }
    }
}
