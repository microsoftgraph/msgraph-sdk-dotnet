using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.DeviceManagement.DeviceCompliancePolicies.Item.ScheduleActionsForRules {
    public class ScheduleActionsForRulesPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The deviceComplianceScheduledActionForRules property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DeviceComplianceScheduledActionForRule>? DeviceComplianceScheduledActionForRules {
            get { return BackingStore?.Get<List<DeviceComplianceScheduledActionForRule>?>("deviceComplianceScheduledActionForRules"); }
            set { BackingStore?.Set("deviceComplianceScheduledActionForRules", value); }
        }
#nullable restore
#else
        public List<DeviceComplianceScheduledActionForRule> DeviceComplianceScheduledActionForRules {
            get { return BackingStore?.Get<List<DeviceComplianceScheduledActionForRule>>("deviceComplianceScheduledActionForRules"); }
            set { BackingStore?.Set("deviceComplianceScheduledActionForRules", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new scheduleActionsForRulesPostRequestBody and sets the default values.
        /// </summary>
        public ScheduleActionsForRulesPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ScheduleActionsForRulesPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ScheduleActionsForRulesPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"deviceComplianceScheduledActionForRules", n => { DeviceComplianceScheduledActionForRules = n.GetCollectionOfObjectValues<DeviceComplianceScheduledActionForRule>(DeviceComplianceScheduledActionForRule.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<DeviceComplianceScheduledActionForRule>("deviceComplianceScheduledActionForRules", DeviceComplianceScheduledActionForRules);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
