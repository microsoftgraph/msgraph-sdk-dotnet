using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SubscribedSku : Entity, IParsable {
        /// <summary>For example, &apos;User&apos; or &apos;Company&apos;.</summary>
        public string AppliesTo {
            get { return BackingStore?.Get<string>("appliesTo"); }
            set { BackingStore?.Set("appliesTo", value); }
        }
        /// <summary>Possible values are: Enabled, Warning, Suspended, Deleted, LockedOut. The capabilityStatus is Enabled if the prepaidUnits property has at least 1 unit that is enabled, and LockedOut if the customer cancelled their subscription.</summary>
        public string CapabilityStatus {
            get { return BackingStore?.Get<string>("capabilityStatus"); }
            set { BackingStore?.Set("capabilityStatus", value); }
        }
        /// <summary>The number of licenses that have been assigned.</summary>
        public int? ConsumedUnits {
            get { return BackingStore?.Get<int?>("consumedUnits"); }
            set { BackingStore?.Set("consumedUnits", value); }
        }
        /// <summary>Information about the number and status of prepaid licenses.</summary>
        public LicenseUnitsDetail PrepaidUnits {
            get { return BackingStore?.Get<LicenseUnitsDetail>("prepaidUnits"); }
            set { BackingStore?.Set("prepaidUnits", value); }
        }
        /// <summary>Information about the service plans that are available with the SKU. Not nullable</summary>
        public List<ServicePlanInfo> ServicePlans {
            get { return BackingStore?.Get<List<ServicePlanInfo>>("servicePlans"); }
            set { BackingStore?.Set("servicePlans", value); }
        }
        /// <summary>The unique identifier (GUID) for the service SKU.</summary>
        public string SkuId {
            get { return BackingStore?.Get<string>("skuId"); }
            set { BackingStore?.Set("skuId", value); }
        }
        /// <summary>The SKU part number; for example: &apos;AAD_PREMIUM&apos; or &apos;RMSBASIC&apos;. To get a list of commercial subscriptions that an organization has acquired, see List subscribedSkus.</summary>
        public string SkuPartNumber {
            get { return BackingStore?.Get<string>("skuPartNumber"); }
            set { BackingStore?.Set("skuPartNumber", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SubscribedSku CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SubscribedSku();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appliesTo", n => { AppliesTo = n.GetStringValue(); } },
                {"capabilityStatus", n => { CapabilityStatus = n.GetStringValue(); } },
                {"consumedUnits", n => { ConsumedUnits = n.GetIntValue(); } },
                {"prepaidUnits", n => { PrepaidUnits = n.GetObjectValue<LicenseUnitsDetail>(LicenseUnitsDetail.CreateFromDiscriminatorValue); } },
                {"servicePlans", n => { ServicePlans = n.GetCollectionOfObjectValues<ServicePlanInfo>(ServicePlanInfo.CreateFromDiscriminatorValue).ToList(); } },
                {"skuId", n => { SkuId = n.GetStringValue(); } },
                {"skuPartNumber", n => { SkuPartNumber = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("appliesTo", AppliesTo);
            writer.WriteStringValue("capabilityStatus", CapabilityStatus);
            writer.WriteIntValue("consumedUnits", ConsumedUnits);
            writer.WriteObjectValue<LicenseUnitsDetail>("prepaidUnits", PrepaidUnits);
            writer.WriteCollectionOfObjectValues<ServicePlanInfo>("servicePlans", ServicePlans);
            writer.WriteStringValue("skuId", SkuId);
            writer.WriteStringValue("skuPartNumber", SkuPartNumber);
        }
    }
}
