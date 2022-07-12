using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ArchivedPrintJob : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>True if the job was acquired by a printer; false otherwise. Read-only.</summary>
        public bool? AcquiredByPrinter {
            get { return BackingStore?.Get<bool?>("acquiredByPrinter"); }
            set { BackingStore?.Set("acquiredByPrinter", value); }
        }
        /// <summary>The dateTimeOffset when the job was acquired by the printer, if any. Read-only.</summary>
        public DateTimeOffset? AcquiredDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("acquiredDateTime"); }
            set { BackingStore?.Set("acquiredDateTime", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The dateTimeOffset when the job was completed, canceled or aborted. Read-only.</summary>
        public DateTimeOffset? CompletionDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("completionDateTime"); }
            set { BackingStore?.Set("completionDateTime", value); }
        }
        /// <summary>The number of copies that were printed. Read-only.</summary>
        public int? CopiesPrinted {
            get { return BackingStore?.Get<int?>("copiesPrinted"); }
            set { BackingStore?.Set("copiesPrinted", value); }
        }
        /// <summary>The user who created the print job. Read-only.</summary>
        public UserIdentity CreatedBy {
            get { return BackingStore?.Get<UserIdentity>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
        /// <summary>The dateTimeOffset when the job was created. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The archived print job&apos;s GUID. Read-only.</summary>
        public string Id {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>The printer ID that the job was queued for. Read-only.</summary>
        public string PrinterId {
            get { return BackingStore?.Get<string>("printerId"); }
            set { BackingStore?.Set("printerId", value); }
        }
        /// <summary>The processingState property</summary>
        public PrintJobProcessingState? ProcessingState {
            get { return BackingStore?.Get<PrintJobProcessingState?>("processingState"); }
            set { BackingStore?.Set("processingState", value); }
        }
        /// <summary>
        /// Instantiates a new archivedPrintJob and sets the default values.
        /// </summary>
        public ArchivedPrintJob() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ArchivedPrintJob CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ArchivedPrintJob();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"acquiredByPrinter", n => { AcquiredByPrinter = n.GetBoolValue(); } },
                {"acquiredDateTime", n => { AcquiredDateTime = n.GetDateTimeOffsetValue(); } },
                {"completionDateTime", n => { CompletionDateTime = n.GetDateTimeOffsetValue(); } },
                {"copiesPrinted", n => { CopiesPrinted = n.GetIntValue(); } },
                {"createdBy", n => { CreatedBy = n.GetObjectValue<UserIdentity>(UserIdentity.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"printerId", n => { PrinterId = n.GetStringValue(); } },
                {"processingState", n => { ProcessingState = n.GetEnumValue<PrintJobProcessingState>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("acquiredByPrinter", AcquiredByPrinter);
            writer.WriteDateTimeOffsetValue("acquiredDateTime", AcquiredDateTime);
            writer.WriteDateTimeOffsetValue("completionDateTime", CompletionDateTime);
            writer.WriteIntValue("copiesPrinted", CopiesPrinted);
            writer.WriteObjectValue<UserIdentity>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("printerId", PrinterId);
            writer.WriteEnumValue<PrintJobProcessingState>("processingState", ProcessingState);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
