// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    /// <summary>
    /// An abstract base class containing properties for all mobile line of business apps.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    public partial class MobileLobApp : global::Microsoft.Graph.Models.MobileApp, IParsable
    {
        /// <summary>The internal committed content version.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CommittedContentVersion
        {
            get { return BackingStore?.Get<string?>("committedContentVersion"); }
            set { BackingStore?.Set("committedContentVersion", value); }
        }
#nullable restore
#else
        public string CommittedContentVersion
        {
            get { return BackingStore?.Get<string>("committedContentVersion"); }
            set { BackingStore?.Set("committedContentVersion", value); }
        }
#endif
        /// <summary>The list of content versions for this app.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.MobileAppContent>? ContentVersions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.MobileAppContent>?>("contentVersions"); }
            set { BackingStore?.Set("contentVersions", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.MobileAppContent> ContentVersions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.MobileAppContent>>("contentVersions"); }
            set { BackingStore?.Set("contentVersions", value); }
        }
#endif
        /// <summary>The name of the main Lob application file.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FileName
        {
            get { return BackingStore?.Get<string?>("fileName"); }
            set { BackingStore?.Set("fileName", value); }
        }
#nullable restore
#else
        public string FileName
        {
            get { return BackingStore?.Get<string>("fileName"); }
            set { BackingStore?.Set("fileName", value); }
        }
#endif
        /// <summary>The total size, including all uploaded files.</summary>
        public long? Size
        {
            get { return BackingStore?.Get<long?>("size"); }
            set { BackingStore?.Set("size", value); }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Models.MobileLobApp"/> and sets the default values.
        /// </summary>
        public MobileLobApp() : base()
        {
            OdataType = "#microsoft.graph.mobileLobApp";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.MobileLobApp"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.MobileLobApp CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.androidLobApp" => new global::Microsoft.Graph.Models.AndroidLobApp(),
                "#microsoft.graph.iosLobApp" => new global::Microsoft.Graph.Models.IosLobApp(),
                "#microsoft.graph.macOSDmgApp" => new global::Microsoft.Graph.Models.MacOSDmgApp(),
                "#microsoft.graph.macOSLobApp" => new global::Microsoft.Graph.Models.MacOSLobApp(),
                "#microsoft.graph.win32LobApp" => new global::Microsoft.Graph.Models.Win32LobApp(),
                "#microsoft.graph.windowsAppX" => new global::Microsoft.Graph.Models.WindowsAppX(),
                "#microsoft.graph.windowsMobileMSI" => new global::Microsoft.Graph.Models.WindowsMobileMSI(),
                "#microsoft.graph.windowsUniversalAppX" => new global::Microsoft.Graph.Models.WindowsUniversalAppX(),
                _ => new global::Microsoft.Graph.Models.MobileLobApp(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "committedContentVersion", n => { CommittedContentVersion = n.GetStringValue(); } },
                { "contentVersions", n => { ContentVersions = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.MobileAppContent>(global::Microsoft.Graph.Models.MobileAppContent.CreateFromDiscriminatorValue)?.AsList(); } },
                { "fileName", n => { FileName = n.GetStringValue(); } },
                { "size", n => { Size = n.GetLongValue(); } },
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
            writer.WriteStringValue("committedContentVersion", CommittedContentVersion);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.MobileAppContent>("contentVersions", ContentVersions);
            writer.WriteStringValue("fileName", FileName);
        }
    }
}
#pragma warning restore CS0618
