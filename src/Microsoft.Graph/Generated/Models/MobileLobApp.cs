using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    /// <summary>
    /// An abstract base class containing properties for all mobile line of business apps.
    /// </summary>
    public class MobileLobApp : MobileApp, IParsable {
        /// <summary>The internal committed content version.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CommittedContentVersion {
            get { return BackingStore?.Get<string?>("committedContentVersion"); }
            set { BackingStore?.Set("committedContentVersion", value); }
        }
#nullable restore
#else
        public string CommittedContentVersion {
            get { return BackingStore?.Get<string>("committedContentVersion"); }
            set { BackingStore?.Set("committedContentVersion", value); }
        }
#endif
        /// <summary>The list of content versions for this app.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<MobileAppContent>? ContentVersions {
            get { return BackingStore?.Get<List<MobileAppContent>?>("contentVersions"); }
            set { BackingStore?.Set("contentVersions", value); }
        }
#nullable restore
#else
        public List<MobileAppContent> ContentVersions {
            get { return BackingStore?.Get<List<MobileAppContent>>("contentVersions"); }
            set { BackingStore?.Set("contentVersions", value); }
        }
#endif
        /// <summary>The name of the main Lob application file.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FileName {
            get { return BackingStore?.Get<string?>("fileName"); }
            set { BackingStore?.Set("fileName", value); }
        }
#nullable restore
#else
        public string FileName {
            get { return BackingStore?.Get<string>("fileName"); }
            set { BackingStore?.Set("fileName", value); }
        }
#endif
        /// <summary>The total size, including all uploaded files.</summary>
        public long? Size {
            get { return BackingStore?.Get<long?>("size"); }
            set { BackingStore?.Set("size", value); }
        }
        /// <summary>
        /// Instantiates a new mobileLobApp and sets the default values.
        /// </summary>
        public MobileLobApp() : base() {
            OdataType = "#microsoft.graph.mobileLobApp";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new MobileLobApp CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.androidLobApp" => new AndroidLobApp(),
                "#microsoft.graph.iosLobApp" => new IosLobApp(),
                "#microsoft.graph.macOSLobApp" => new MacOSLobApp(),
                "#microsoft.graph.win32LobApp" => new Win32LobApp(),
                "#microsoft.graph.windowsAppX" => new WindowsAppX(),
                "#microsoft.graph.windowsMobileMSI" => new WindowsMobileMSI(),
                "#microsoft.graph.windowsUniversalAppX" => new WindowsUniversalAppX(),
                _ => new MobileLobApp(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"committedContentVersion", n => { CommittedContentVersion = n.GetStringValue(); } },
                {"contentVersions", n => { ContentVersions = n.GetCollectionOfObjectValues<MobileAppContent>(MobileAppContent.CreateFromDiscriminatorValue)?.ToList(); } },
                {"fileName", n => { FileName = n.GetStringValue(); } },
                {"size", n => { Size = n.GetLongValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("committedContentVersion", CommittedContentVersion);
            writer.WriteCollectionOfObjectValues<MobileAppContent>("contentVersions", ContentVersions);
            writer.WriteStringValue("fileName", FileName);
            writer.WriteLongValue("size", Size);
        }
    }
}
