using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class DeviceDetail : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Indicates the browser information of the used for signing-in.</summary>
        public string Browser {
            get { return BackingStore?.Get<string>("browser"); }
            set { BackingStore?.Set("browser", value); }
        }
        /// <summary>Refers to the UniqueID of the device used for signing-in.</summary>
        public string DeviceId {
            get { return BackingStore?.Get<string>("deviceId"); }
            set { BackingStore?.Set("deviceId", value); }
        }
        /// <summary>Refers to the name of the device used for signing-in.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Indicates whether the device is compliant or not.</summary>
        public bool? IsCompliant {
            get { return BackingStore?.Get<bool?>("isCompliant"); }
            set { BackingStore?.Set("isCompliant", value); }
        }
        /// <summary>Indicates if the device is managed or not.</summary>
        public bool? IsManaged {
            get { return BackingStore?.Get<bool?>("isManaged"); }
            set { BackingStore?.Set("isManaged", value); }
        }
        /// <summary>Indicates the OS name and version used for signing-in.</summary>
        public string OperatingSystem {
            get { return BackingStore?.Get<string>("operatingSystem"); }
            set { BackingStore?.Set("operatingSystem", value); }
        }
        /// <summary>Indicates information on whether the signed-in device is Workplace Joined, AzureAD Joined, Domain Joined.</summary>
        public string TrustType {
            get { return BackingStore?.Get<string>("trustType"); }
            set { BackingStore?.Set("trustType", value); }
        }
        /// <summary>
        /// Instantiates a new deviceDetail and sets the default values.
        /// </summary>
        public DeviceDetail() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static DeviceDetail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceDetail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"browser", n => { Browser = n.GetStringValue(); } },
                {"deviceId", n => { DeviceId = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"isCompliant", n => { IsCompliant = n.GetBoolValue(); } },
                {"isManaged", n => { IsManaged = n.GetBoolValue(); } },
                {"operatingSystem", n => { OperatingSystem = n.GetStringValue(); } },
                {"trustType", n => { TrustType = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("browser", Browser);
            writer.WriteStringValue("deviceId", DeviceId);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("isCompliant", IsCompliant);
            writer.WriteBoolValue("isManaged", IsManaged);
            writer.WriteStringValue("operatingSystem", OperatingSystem);
            writer.WriteStringValue("trustType", TrustType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
