using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ServicePlanInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The object the service plan can be assigned to. The possible values are:User - service plan can be assigned to individual users.Company - service plan can be assigned to the entire tenant.</summary>
        public string AppliesTo {
            get { return BackingStore?.Get<string>("appliesTo"); }
            set { BackingStore?.Set("appliesTo", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The provisioning status of the service plan. The possible values are:Success - Service is fully provisioned.Disabled - Service has been disabled.ErrorStatus - The service plan has not been provisioned and is in an error state.PendingInput - Service is not yet provisioned; awaiting service confirmation.PendingActivation - Service is provisioned but requires explicit activation by administrator (for example, Intune_O365 service plan)PendingProvisioning - Microsoft has added a new service to the product SKU and it has not been activated in the tenant, yet.</summary>
        public string ProvisioningStatus {
            get { return BackingStore?.Get<string>("provisioningStatus"); }
            set { BackingStore?.Set("provisioningStatus", value); }
        }
        /// <summary>The unique identifier of the service plan.</summary>
        public string ServicePlanId {
            get { return BackingStore?.Get<string>("servicePlanId"); }
            set { BackingStore?.Set("servicePlanId", value); }
        }
        /// <summary>The name of the service plan.</summary>
        public string ServicePlanName {
            get { return BackingStore?.Get<string>("servicePlanName"); }
            set { BackingStore?.Set("servicePlanName", value); }
        }
        /// <summary>
        /// Instantiates a new servicePlanInfo and sets the default values.
        /// </summary>
        public ServicePlanInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ServicePlanInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ServicePlanInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"appliesTo", n => { AppliesTo = n.GetStringValue(); } },
                {"provisioningStatus", n => { ProvisioningStatus = n.GetStringValue(); } },
                {"servicePlanId", n => { ServicePlanId = n.GetStringValue(); } },
                {"servicePlanName", n => { ServicePlanName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("appliesTo", AppliesTo);
            writer.WriteStringValue("provisioningStatus", ProvisioningStatus);
            writer.WriteStringValue("servicePlanId", ServicePlanId);
            writer.WriteStringValue("servicePlanName", ServicePlanName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
