// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class PrintJob : global::Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The dateTimeOffset when the job was acknowledged. Read-only.</summary>
        public DateTimeOffset? AcknowledgedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("acknowledgedDateTime"); }
            set { BackingStore?.Set("acknowledgedDateTime", value); }
        }
        /// <summary>The configuration property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.PrintJobConfiguration? Configuration
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PrintJobConfiguration?>("configuration"); }
            set { BackingStore?.Set("configuration", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.PrintJobConfiguration Configuration
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PrintJobConfiguration>("configuration"); }
            set { BackingStore?.Set("configuration", value); }
        }
#endif
        /// <summary>The createdBy property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.UserIdentity? CreatedBy
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.UserIdentity?>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.UserIdentity CreatedBy
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.UserIdentity>("createdBy"); }
            set { BackingStore?.Set("createdBy", value); }
        }
#endif
        /// <summary>The DateTimeOffset when the job was created. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime
        {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The documents property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.PrintDocument>? Documents
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.PrintDocument>?>("documents"); }
            set { BackingStore?.Set("documents", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.PrintDocument> Documents
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.PrintDocument>>("documents"); }
            set { BackingStore?.Set("documents", value); }
        }
#endif
        /// <summary>The error code of the print job. Read-only.</summary>
        public int? ErrorCode
        {
            get { return BackingStore?.Get<int?>("errorCode"); }
            set { BackingStore?.Set("errorCode", value); }
        }
        /// <summary>If true, document can be fetched by printer.</summary>
        public bool? IsFetchable
        {
            get { return BackingStore?.Get<bool?>("isFetchable"); }
            set { BackingStore?.Set("isFetchable", value); }
        }
        /// <summary>Contains the source job URL, if the job has been redirected from another printer.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RedirectedFrom
        {
            get { return BackingStore?.Get<string?>("redirectedFrom"); }
            set { BackingStore?.Set("redirectedFrom", value); }
        }
#nullable restore
#else
        public string RedirectedFrom
        {
            get { return BackingStore?.Get<string>("redirectedFrom"); }
            set { BackingStore?.Set("redirectedFrom", value); }
        }
#endif
        /// <summary>Contains the destination job URL, if the job has been redirected to another printer.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RedirectedTo
        {
            get { return BackingStore?.Get<string?>("redirectedTo"); }
            set { BackingStore?.Set("redirectedTo", value); }
        }
#nullable restore
#else
        public string RedirectedTo
        {
            get { return BackingStore?.Get<string>("redirectedTo"); }
            set { BackingStore?.Set("redirectedTo", value); }
        }
#endif
        /// <summary>The status property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.PrintJobStatus? Status
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PrintJobStatus?>("status"); }
            set { BackingStore?.Set("status", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.PrintJobStatus Status
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PrintJobStatus>("status"); }
            set { BackingStore?.Set("status", value); }
        }
#endif
        /// <summary>A list of printTasks that were triggered by this print job.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.PrintTask>? Tasks
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.PrintTask>?>("tasks"); }
            set { BackingStore?.Set("tasks", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.PrintTask> Tasks
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.PrintTask>>("tasks"); }
            set { BackingStore?.Set("tasks", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.PrintJob"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.PrintJob CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Microsoft.Graph.Models.PrintJob();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "acknowledgedDateTime", n => { AcknowledgedDateTime = n.GetDateTimeOffsetValue(); } },
                { "configuration", n => { Configuration = n.GetObjectValue<global::Microsoft.Graph.Models.PrintJobConfiguration>(global::Microsoft.Graph.Models.PrintJobConfiguration.CreateFromDiscriminatorValue); } },
                { "createdBy", n => { CreatedBy = n.GetObjectValue<global::Microsoft.Graph.Models.UserIdentity>(global::Microsoft.Graph.Models.UserIdentity.CreateFromDiscriminatorValue); } },
                { "createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                { "documents", n => { Documents = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.PrintDocument>(global::Microsoft.Graph.Models.PrintDocument.CreateFromDiscriminatorValue)?.AsList(); } },
                { "errorCode", n => { ErrorCode = n.GetIntValue(); } },
                { "isFetchable", n => { IsFetchable = n.GetBoolValue(); } },
                { "redirectedFrom", n => { RedirectedFrom = n.GetStringValue(); } },
                { "redirectedTo", n => { RedirectedTo = n.GetStringValue(); } },
                { "status", n => { Status = n.GetObjectValue<global::Microsoft.Graph.Models.PrintJobStatus>(global::Microsoft.Graph.Models.PrintJobStatus.CreateFromDiscriminatorValue); } },
                { "tasks", n => { Tasks = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.PrintTask>(global::Microsoft.Graph.Models.PrintTask.CreateFromDiscriminatorValue)?.AsList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("acknowledgedDateTime", AcknowledgedDateTime);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.PrintJobConfiguration>("configuration", Configuration);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.UserIdentity>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.PrintDocument>("documents", Documents);
            writer.WriteIntValue("errorCode", ErrorCode);
            writer.WriteBoolValue("isFetchable", IsFetchable);
            writer.WriteStringValue("redirectedFrom", RedirectedFrom);
            writer.WriteStringValue("redirectedTo", RedirectedTo);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.PrintJobStatus>("status", Status);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.PrintTask>("tasks", Tasks);
        }
    }
}
#pragma warning restore CS0618
