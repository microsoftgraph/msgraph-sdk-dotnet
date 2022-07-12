using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class AssignedPlan : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The date and time at which the plan was assigned; for example: 2013-01-02T19:32:30Z. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? AssignedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("assignedDateTime"); }
            set { BackingStore?.Set("assignedDateTime", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Condition of the capability assignment. The possible values are Enabled, Warning, Suspended, Deleted, LockedOut.</summary>
        public string CapabilityStatus {
            get { return BackingStore?.Get<string>("capabilityStatus"); }
            set { BackingStore?.Set("capabilityStatus", value); }
        }
        /// <summary>The name of the service; for example, exchange.</summary>
        public string Service {
            get { return BackingStore?.Get<string>("service"); }
            set { BackingStore?.Set("service", value); }
        }
        /// <summary>A GUID that identifies the service plan. For a complete list of GUIDs and their equivalent friendly service names, see Product names and service plan identifiers for licensing.</summary>
        public string ServicePlanId {
            get { return BackingStore?.Get<string>("servicePlanId"); }
            set { BackingStore?.Set("servicePlanId", value); }
        }
        /// <summary>
        /// Instantiates a new assignedPlan and sets the default values.
        /// </summary>
        public AssignedPlan() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AssignedPlan CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AssignedPlan();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"assignedDateTime", n => { AssignedDateTime = n.GetDateTimeOffsetValue(); } },
                {"capabilityStatus", n => { CapabilityStatus = n.GetStringValue(); } },
                {"service", n => { Service = n.GetStringValue(); } },
                {"servicePlanId", n => { ServicePlanId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("assignedDateTime", AssignedDateTime);
            writer.WriteStringValue("capabilityStatus", CapabilityStatus);
            writer.WriteStringValue("service", Service);
            writer.WriteStringValue("servicePlanId", ServicePlanId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
