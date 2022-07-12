using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>A base complex type to store the detection or requirement rule data for a Win32 LOB app.</summary>
    public class Win32LobAppRule : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Contains rule types for Win32 LOB apps.</summary>
        public Win32LobAppRuleType? RuleType {
            get { return BackingStore?.Get<Win32LobAppRuleType?>("ruleType"); }
            set { BackingStore?.Set("ruleType", value); }
        }
        /// <summary>The type property</summary>
        public string Type {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>
        /// Instantiates a new win32LobAppRule and sets the default values.
        /// </summary>
        public Win32LobAppRule() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            Type = "#microsoft.graph.win32LobAppRule";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Win32LobAppRule CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.win32LobAppFileSystemRule" => new Win32LobAppFileSystemRule(),
                "#microsoft.graph.win32LobAppPowerShellScriptRule" => new Win32LobAppPowerShellScriptRule(),
                "#microsoft.graph.win32LobAppProductCodeRule" => new Win32LobAppProductCodeRule(),
                "#microsoft.graph.win32LobAppRegistryRule" => new Win32LobAppRegistryRule(),
                _ => new Win32LobAppRule(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"ruleType", n => { RuleType = n.GetEnumValue<Win32LobAppRuleType>(); } },
                {"@odata.type", n => { Type = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<Win32LobAppRuleType>("ruleType", RuleType);
            writer.WriteStringValue("@odata.type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
