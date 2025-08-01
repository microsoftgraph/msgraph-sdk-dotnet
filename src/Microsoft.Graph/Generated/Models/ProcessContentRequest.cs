// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class ProcessContentRequest : IAdditionalDataHolder, IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The activityMetadata property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ActivityMetadata? ActivityMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ActivityMetadata?>("activityMetadata"); }
            set { BackingStore?.Set("activityMetadata", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ActivityMetadata ActivityMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ActivityMetadata>("activityMetadata"); }
            set { BackingStore?.Set("activityMetadata", value); }
        }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData
        {
            get { return BackingStore.Get<IDictionary<string, object>>("AdditionalData") ?? new Dictionary<string, object>(); }
            set { BackingStore.Set("AdditionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>A collection of content entries to be processed. Each entry contains the content itself and its metadata. Use conversation metadata for content like prompts and responses and file metadata for files. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.ProcessContentMetadataBase>? ContentEntries
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ProcessContentMetadataBase>?>("contentEntries"); }
            set { BackingStore?.Set("contentEntries", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.ProcessContentMetadataBase> ContentEntries
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.ProcessContentMetadataBase>>("contentEntries"); }
            set { BackingStore?.Set("contentEntries", value); }
        }
#endif
        /// <summary>The deviceMetadata property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.DeviceMetadata? DeviceMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DeviceMetadata?>("deviceMetadata"); }
            set { BackingStore?.Set("deviceMetadata", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.DeviceMetadata DeviceMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.DeviceMetadata>("deviceMetadata"); }
            set { BackingStore?.Set("deviceMetadata", value); }
        }
#endif
        /// <summary>The integratedAppMetadata property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.IntegratedApplicationMetadata? IntegratedAppMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.IntegratedApplicationMetadata?>("integratedAppMetadata"); }
            set { BackingStore?.Set("integratedAppMetadata", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.IntegratedApplicationMetadata IntegratedAppMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.IntegratedApplicationMetadata>("integratedAppMetadata"); }
            set { BackingStore?.Set("integratedAppMetadata", value); }
        }
#endif
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType
        {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType
        {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>Metadata about the protected application making the request. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ProtectedApplicationMetadata? ProtectedAppMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ProtectedApplicationMetadata?>("protectedAppMetadata"); }
            set { BackingStore?.Set("protectedAppMetadata", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ProtectedApplicationMetadata ProtectedAppMetadata
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ProtectedApplicationMetadata>("protectedAppMetadata"); }
            set { BackingStore?.Set("protectedAppMetadata", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Models.ProcessContentRequest"/> and sets the default values.
        /// </summary>
        public ProcessContentRequest()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.ProcessContentRequest"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::Microsoft.Graph.Models.ProcessContentRequest CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Microsoft.Graph.Models.ProcessContentRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "activityMetadata", n => { ActivityMetadata = n.GetObjectValue<global::Microsoft.Graph.Models.ActivityMetadata>(global::Microsoft.Graph.Models.ActivityMetadata.CreateFromDiscriminatorValue); } },
                { "contentEntries", n => { ContentEntries = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.ProcessContentMetadataBase>(global::Microsoft.Graph.Models.ProcessContentMetadataBase.CreateFromDiscriminatorValue)?.AsList(); } },
                { "deviceMetadata", n => { DeviceMetadata = n.GetObjectValue<global::Microsoft.Graph.Models.DeviceMetadata>(global::Microsoft.Graph.Models.DeviceMetadata.CreateFromDiscriminatorValue); } },
                { "integratedAppMetadata", n => { IntegratedAppMetadata = n.GetObjectValue<global::Microsoft.Graph.Models.IntegratedApplicationMetadata>(global::Microsoft.Graph.Models.IntegratedApplicationMetadata.CreateFromDiscriminatorValue); } },
                { "@odata.type", n => { OdataType = n.GetStringValue(); } },
                { "protectedAppMetadata", n => { ProtectedAppMetadata = n.GetObjectValue<global::Microsoft.Graph.Models.ProtectedApplicationMetadata>(global::Microsoft.Graph.Models.ProtectedApplicationMetadata.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ActivityMetadata>("activityMetadata", ActivityMetadata);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.ProcessContentMetadataBase>("contentEntries", ContentEntries);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.DeviceMetadata>("deviceMetadata", DeviceMetadata);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.IntegratedApplicationMetadata>("integratedAppMetadata", IntegratedAppMetadata);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ProtectedApplicationMetadata>("protectedAppMetadata", ProtectedAppMetadata);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
