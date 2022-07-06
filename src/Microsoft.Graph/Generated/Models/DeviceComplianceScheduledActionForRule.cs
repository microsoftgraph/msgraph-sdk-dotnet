using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Scheduled Action for Rule</summary>
    public class DeviceComplianceScheduledActionForRule : Entity, IParsable {
        /// <summary>Name of the rule which this scheduled action applies to. Currently scheduled actions are created per policy instead of per rule, thus RuleName is always set to default value PasswordRequired.</summary>
        public string RuleName {
            get { return BackingStore?.Get<string>("ruleName"); }
            set { BackingStore?.Set("ruleName", value); }
        }
        /// <summary>The list of scheduled action configurations for this compliance policy. Compliance policy must have one and only one block scheduled action.</summary>
        public List<DeviceComplianceActionItem> ScheduledActionConfigurations {
            get { return BackingStore?.Get<List<DeviceComplianceActionItem>>("scheduledActionConfigurations"); }
            set { BackingStore?.Set("scheduledActionConfigurations", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceComplianceScheduledActionForRule CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceComplianceScheduledActionForRule();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"ruleName", n => { RuleName = n.GetStringValue(); } },
                {"scheduledActionConfigurations", n => { ScheduledActionConfigurations = n.GetCollectionOfObjectValues<DeviceComplianceActionItem>(DeviceComplianceActionItem.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("ruleName", RuleName);
            writer.WriteCollectionOfObjectValues<DeviceComplianceActionItem>("scheduledActionConfigurations", ScheduledActionConfigurations);
        }
    }
}
