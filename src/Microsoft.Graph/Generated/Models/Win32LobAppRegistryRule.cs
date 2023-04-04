using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class Win32LobAppRegistryRule : Win32LobAppRule, IParsable {
        /// <summary>A value indicating whether to search the 32-bit registry on 64-bit systems.</summary>
        public bool? Check32BitOn64System {
            get { return BackingStore?.Get<bool?>("check32BitOn64System"); }
            set { BackingStore?.Set("check32BitOn64System", value); }
        }
        /// <summary>The registry comparison value.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ComparisonValue {
            get { return BackingStore?.Get<string?>("comparisonValue"); }
            set { BackingStore?.Set("comparisonValue", value); }
        }
#nullable restore
#else
        public string ComparisonValue {
            get { return BackingStore?.Get<string>("comparisonValue"); }
            set { BackingStore?.Set("comparisonValue", value); }
        }
#endif
        /// <summary>The full path of the registry entry containing the value to detect.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? KeyPath {
            get { return BackingStore?.Get<string?>("keyPath"); }
            set { BackingStore?.Set("keyPath", value); }
        }
#nullable restore
#else
        public string KeyPath {
            get { return BackingStore?.Get<string>("keyPath"); }
            set { BackingStore?.Set("keyPath", value); }
        }
#endif
        /// <summary>Contains all supported registry data detection type.</summary>
        public Win32LobAppRegistryRuleOperationType? OperationType {
            get { return BackingStore?.Get<Win32LobAppRegistryRuleOperationType?>("operationType"); }
            set { BackingStore?.Set("operationType", value); }
        }
        /// <summary>Contains properties for detection operator.</summary>
        public Win32LobAppRuleOperator? Operator {
            get { return BackingStore?.Get<Win32LobAppRuleOperator?>("operator"); }
            set { BackingStore?.Set("operator", value); }
        }
        /// <summary>The name of the registry value to detect.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ValueName {
            get { return BackingStore?.Get<string?>("valueName"); }
            set { BackingStore?.Set("valueName", value); }
        }
#nullable restore
#else
        public string ValueName {
            get { return BackingStore?.Get<string>("valueName"); }
            set { BackingStore?.Set("valueName", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new Win32LobAppRegistryRule and sets the default values.
        /// </summary>
        public Win32LobAppRegistryRule() : base() {
            OdataType = "#microsoft.graph.win32LobAppRegistryRule";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Win32LobAppRegistryRule CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Win32LobAppRegistryRule();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"check32BitOn64System", n => { Check32BitOn64System = n.GetBoolValue(); } },
                {"comparisonValue", n => { ComparisonValue = n.GetStringValue(); } },
                {"keyPath", n => { KeyPath = n.GetStringValue(); } },
                {"operationType", n => { OperationType = n.GetEnumValue<Win32LobAppRegistryRuleOperationType>(); } },
                {"operator", n => { Operator = n.GetEnumValue<Win32LobAppRuleOperator>(); } },
                {"valueName", n => { ValueName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("check32BitOn64System", Check32BitOn64System);
            writer.WriteStringValue("comparisonValue", ComparisonValue);
            writer.WriteStringValue("keyPath", KeyPath);
            writer.WriteEnumValue<Win32LobAppRegistryRuleOperationType>("operationType", OperationType);
            writer.WriteEnumValue<Win32LobAppRuleOperator>("operator", Operator);
            writer.WriteStringValue("valueName", ValueName);
        }
    }
}
