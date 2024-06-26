// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    #pragma warning disable CS1591
    public class OnenoteEntityBaseModel : Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The endpoint where you can get details about the page. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Self
        {
            get { return BackingStore?.Get<string?>("self"); }
            set { BackingStore?.Set("self", value); }
        }
#nullable restore
#else
        public string Self
        {
            get { return BackingStore?.Get<string>("self"); }
            set { BackingStore?.Set("self", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.OnenoteEntityBaseModel"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.OnenoteEntityBaseModel CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.notebook" => new Microsoft.Graph.Models.Notebook(),
                "#microsoft.graph.onenoteEntityHierarchyModel" => new Microsoft.Graph.Models.OnenoteEntityHierarchyModel(),
                "#microsoft.graph.onenoteEntitySchemaObjectModel" => new Microsoft.Graph.Models.OnenoteEntitySchemaObjectModel(),
                "#microsoft.graph.onenotePage" => new Microsoft.Graph.Models.OnenotePage(),
                "#microsoft.graph.onenoteResource" => new Microsoft.Graph.Models.OnenoteResource(),
                "#microsoft.graph.onenoteSection" => new Microsoft.Graph.Models.OnenoteSection(),
                "#microsoft.graph.sectionGroup" => new Microsoft.Graph.Models.SectionGroup(),
                _ => new Microsoft.Graph.Models.OnenoteEntityBaseModel(),
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
                { "self", n => { Self = n.GetStringValue(); } },
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
            writer.WriteStringValue("self", Self);
        }
    }
}
