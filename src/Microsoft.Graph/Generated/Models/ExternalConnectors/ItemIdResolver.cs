// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models.ExternalConnectors
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class ItemIdResolver : global::Microsoft.Graph.Models.ExternalConnectors.UrlToItemResolverBase, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Pattern that specifies how to form the ID of the external item that the URL represents. The named groups from the regular expression in urlPattern within the urlMatchInfo can be referenced by inserting the group name inside curly brackets.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ItemId
        {
            get { return BackingStore?.Get<string?>("itemId"); }
            set { BackingStore?.Set("itemId", value); }
        }
#nullable restore
#else
        public string ItemId
        {
            get { return BackingStore?.Get<string>("itemId"); }
            set { BackingStore?.Set("itemId", value); }
        }
#endif
        /// <summary>Configurations to match and resolve URL.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.ExternalConnectors.UrlMatchInfo? UrlMatchInfo
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ExternalConnectors.UrlMatchInfo?>("urlMatchInfo"); }
            set { BackingStore?.Set("urlMatchInfo", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.ExternalConnectors.UrlMatchInfo UrlMatchInfo
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ExternalConnectors.UrlMatchInfo>("urlMatchInfo"); }
            set { BackingStore?.Set("urlMatchInfo", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Models.ExternalConnectors.ItemIdResolver"/> and sets the default values.
        /// </summary>
        public ItemIdResolver() : base()
        {
            OdataType = "#microsoft.graph.externalConnectors.itemIdResolver";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.ExternalConnectors.ItemIdResolver"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.ExternalConnectors.ItemIdResolver CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Microsoft.Graph.Models.ExternalConnectors.ItemIdResolver();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "itemId", n => { ItemId = n.GetStringValue(); } },
                { "urlMatchInfo", n => { UrlMatchInfo = n.GetObjectValue<global::Microsoft.Graph.Models.ExternalConnectors.UrlMatchInfo>(global::Microsoft.Graph.Models.ExternalConnectors.UrlMatchInfo.CreateFromDiscriminatorValue); } },
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
            writer.WriteStringValue("itemId", ItemId);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.ExternalConnectors.UrlMatchInfo>("urlMatchInfo", UrlMatchInfo);
        }
    }
}
#pragma warning restore CS0618
