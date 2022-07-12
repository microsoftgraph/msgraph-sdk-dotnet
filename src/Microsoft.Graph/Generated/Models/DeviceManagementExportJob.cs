using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Entity representing a job to export a report</summary>
    public class DeviceManagementExportJob : Entity, IParsable {
        /// <summary>Time that the exported report expires</summary>
        public DateTimeOffset? ExpirationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("expirationDateTime"); }
            set { BackingStore?.Set("expirationDateTime", value); }
        }
        /// <summary>Filters applied on the report</summary>
        public string Filter {
            get { return BackingStore?.Get<string>("filter"); }
            set { BackingStore?.Set("filter", value); }
        }
        /// <summary>Possible values for the file format of a report</summary>
        public DeviceManagementReportFileFormat? Format {
            get { return BackingStore?.Get<DeviceManagementReportFileFormat?>("format"); }
            set { BackingStore?.Set("format", value); }
        }
        /// <summary>Configures how the requested export job is localized</summary>
        public DeviceManagementExportJobLocalizationType? LocalizationType {
            get { return BackingStore?.Get<DeviceManagementExportJobLocalizationType?>("localizationType"); }
            set { BackingStore?.Set("localizationType", value); }
        }
        /// <summary>Name of the report</summary>
        public string ReportName {
            get { return BackingStore?.Get<string>("reportName"); }
            set { BackingStore?.Set("reportName", value); }
        }
        /// <summary>Time that the exported report was requested</summary>
        public DateTimeOffset? RequestDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("requestDateTime"); }
            set { BackingStore?.Set("requestDateTime", value); }
        }
        /// <summary>Columns selected from the report</summary>
        public List<string> Select {
            get { return BackingStore?.Get<List<string>>("select"); }
            set { BackingStore?.Set("select", value); }
        }
        /// <summary>A snapshot is an identifiable subset of the dataset represented by the ReportName. A sessionId or CachedReportConfiguration id can be used here. If a sessionId is specified, Filter, Select, and OrderBy are applied to the data represented by the sessionId. Filter, Select, and OrderBy cannot be specified together with a CachedReportConfiguration id.</summary>
        public string SnapshotId {
            get { return BackingStore?.Get<string>("snapshotId"); }
            set { BackingStore?.Set("snapshotId", value); }
        }
        /// <summary>Possible statuses associated with a generated report</summary>
        public DeviceManagementReportStatus? Status {
            get { return BackingStore?.Get<DeviceManagementReportStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>Temporary location of the exported report</summary>
        public string Url {
            get { return BackingStore?.Get<string>("url"); }
            set { BackingStore?.Set("url", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceManagementExportJob CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceManagementExportJob();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"expirationDateTime", n => { ExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"filter", n => { Filter = n.GetStringValue(); } },
                {"format", n => { Format = n.GetEnumValue<DeviceManagementReportFileFormat>(); } },
                {"localizationType", n => { LocalizationType = n.GetEnumValue<DeviceManagementExportJobLocalizationType>(); } },
                {"reportName", n => { ReportName = n.GetStringValue(); } },
                {"requestDateTime", n => { RequestDateTime = n.GetDateTimeOffsetValue(); } },
                {"select", n => { Select = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"snapshotId", n => { SnapshotId = n.GetStringValue(); } },
                {"status", n => { Status = n.GetEnumValue<DeviceManagementReportStatus>(); } },
                {"url", n => { Url = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("expirationDateTime", ExpirationDateTime);
            writer.WriteStringValue("filter", Filter);
            writer.WriteEnumValue<DeviceManagementReportFileFormat>("format", Format);
            writer.WriteEnumValue<DeviceManagementExportJobLocalizationType>("localizationType", LocalizationType);
            writer.WriteStringValue("reportName", ReportName);
            writer.WriteDateTimeOffsetValue("requestDateTime", RequestDateTime);
            writer.WriteCollectionOfPrimitiveValues<string>("select", Select);
            writer.WriteStringValue("snapshotId", SnapshotId);
            writer.WriteEnumValue<DeviceManagementReportStatus>("status", Status);
            writer.WriteStringValue("url", Url);
        }
    }
}
