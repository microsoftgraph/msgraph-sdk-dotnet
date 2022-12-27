using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>
    /// Provides operations to manage the appCatalogs singleton.
    /// </summary>
    public class ConditionalAccessTemplate : Entity, IParsable {
        /// <summary>The user-friendly name of the template.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The details property</summary>
        public ConditionalAccessPolicyDetail Details {
            get { return BackingStore?.Get<ConditionalAccessPolicyDetail>("details"); }
            set { BackingStore?.Set("details", value); }
        }
        /// <summary>The user-friendly name of the template.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>The scenarios property</summary>
        public TemplateScenarios? Scenarios {
            get { return BackingStore?.Get<TemplateScenarios?>("scenarios"); }
            set { BackingStore?.Set("scenarios", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ConditionalAccessTemplate CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConditionalAccessTemplate();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"description", n => { Description = n.GetStringValue(); } },
                {"details", n => { Details = n.GetObjectValue<ConditionalAccessPolicyDetail>(ConditionalAccessPolicyDetail.CreateFromDiscriminatorValue); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"scenarios", n => { Scenarios = n.GetEnumValue<TemplateScenarios>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("description", Description);
            writer.WriteObjectValue<ConditionalAccessPolicyDetail>("details", Details);
            writer.WriteStringValue("name", Name);
            writer.WriteEnumValue<TemplateScenarios>("scenarios", Scenarios);
        }
    }
}
