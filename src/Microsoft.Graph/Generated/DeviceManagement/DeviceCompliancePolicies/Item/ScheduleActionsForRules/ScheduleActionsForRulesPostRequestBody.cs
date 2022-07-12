using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.DeviceManagement.DeviceCompliancePolicies.Item.ScheduleActionsForRules {
    /// <summary>Provides operations to call the scheduleActionsForRules method.</summary>
    public class ScheduleActionsForRulesPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The deviceComplianceScheduledActionForRules property</summary>
        public List<DeviceComplianceScheduledActionForRule> DeviceComplianceScheduledActionForRules {
            get { return BackingStore?.Get<List<DeviceComplianceScheduledActionForRule>>("deviceComplianceScheduledActionForRules"); }
            set { BackingStore?.Set("deviceComplianceScheduledActionForRules", value); }
        }
        /// <summary>
        /// Instantiates a new scheduleActionsForRulesPostRequestBody and sets the default values.
        /// </summary>
        public ScheduleActionsForRulesPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ScheduleActionsForRulesPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ScheduleActionsForRulesPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"deviceComplianceScheduledActionForRules", n => { DeviceComplianceScheduledActionForRules = n.GetCollectionOfObjectValues<DeviceComplianceScheduledActionForRule>(DeviceComplianceScheduledActionForRule.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<DeviceComplianceScheduledActionForRule>("deviceComplianceScheduledActionForRules", DeviceComplianceScheduledActionForRules);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
