using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TeleconferenceDeviceQuality : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>A unique identifier for all  the participant calls in a conference or a unique identifier for two participant calls in P2P call. This needs to be copied over from Microsoft.Graph.Call.CallChainId.</summary>
        public string CallChainId {
            get { return BackingStore?.Get<string>("callChainId"); }
            set { BackingStore?.Set("callChainId", value); }
        }
        /// <summary>A geo-region where the service is deployed, such as ProdNoam.</summary>
        public string CloudServiceDeploymentEnvironment {
            get { return BackingStore?.Get<string>("cloudServiceDeploymentEnvironment"); }
            set { BackingStore?.Set("cloudServiceDeploymentEnvironment", value); }
        }
        /// <summary>A unique deployment identifier assigned by Azure.</summary>
        public string CloudServiceDeploymentId {
            get { return BackingStore?.Get<string>("cloudServiceDeploymentId"); }
            set { BackingStore?.Set("cloudServiceDeploymentId", value); }
        }
        /// <summary>The Azure deployed cloud service instance name, such as FrontEnd_IN_3.</summary>
        public string CloudServiceInstanceName {
            get { return BackingStore?.Get<string>("cloudServiceInstanceName"); }
            set { BackingStore?.Set("cloudServiceInstanceName", value); }
        }
        /// <summary>The Azure deployed cloud service name, such as contoso.cloudapp.net.</summary>
        public string CloudServiceName {
            get { return BackingStore?.Get<string>("cloudServiceName"); }
            set { BackingStore?.Set("cloudServiceName", value); }
        }
        /// <summary>Any additional description, such as VTC Bldg 30/21.</summary>
        public string DeviceDescription {
            get { return BackingStore?.Get<string>("deviceDescription"); }
            set { BackingStore?.Set("deviceDescription", value); }
        }
        /// <summary>The user media agent name, such as Cisco SX80.</summary>
        public string DeviceName {
            get { return BackingStore?.Get<string>("deviceName"); }
            set { BackingStore?.Set("deviceName", value); }
        }
        /// <summary>A unique identifier for a specific media leg of a participant in a conference.  One participant can have multiple media leg identifiers if retargeting happens. CVI partner assigns this value.</summary>
        public string MediaLegId {
            get { return BackingStore?.Get<string>("mediaLegId"); }
            set { BackingStore?.Set("mediaLegId", value); }
        }
        /// <summary>The list of media qualities in a media session (call), such as audio quality, video quality, and/or screen sharing quality.</summary>
        public List<TeleconferenceDeviceMediaQuality> MediaQualityList {
            get { return BackingStore?.Get<List<TeleconferenceDeviceMediaQuality>>("mediaQualityList"); }
            set { BackingStore?.Set("mediaQualityList", value); }
        }
        /// <summary>A unique identifier for a specific participant in a conference. The CVI partner needs to copy over Call.MyParticipantId to this property.</summary>
        public string ParticipantId {
            get { return BackingStore?.Get<string>("participantId"); }
            set { BackingStore?.Set("participantId", value); }
        }
        /// <summary>
        /// Instantiates a new teleconferenceDeviceQuality and sets the default values.
        /// </summary>
        public TeleconferenceDeviceQuality() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TeleconferenceDeviceQuality CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TeleconferenceDeviceQuality();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"callChainId", n => { CallChainId = n.GetStringValue(); } },
                {"cloudServiceDeploymentEnvironment", n => { CloudServiceDeploymentEnvironment = n.GetStringValue(); } },
                {"cloudServiceDeploymentId", n => { CloudServiceDeploymentId = n.GetStringValue(); } },
                {"cloudServiceInstanceName", n => { CloudServiceInstanceName = n.GetStringValue(); } },
                {"cloudServiceName", n => { CloudServiceName = n.GetStringValue(); } },
                {"deviceDescription", n => { DeviceDescription = n.GetStringValue(); } },
                {"deviceName", n => { DeviceName = n.GetStringValue(); } },
                {"mediaLegId", n => { MediaLegId = n.GetStringValue(); } },
                {"mediaQualityList", n => { MediaQualityList = n.GetCollectionOfObjectValues<TeleconferenceDeviceMediaQuality>(TeleconferenceDeviceMediaQuality.CreateFromDiscriminatorValue).ToList(); } },
                {"participantId", n => { ParticipantId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("callChainId", CallChainId);
            writer.WriteStringValue("cloudServiceDeploymentEnvironment", CloudServiceDeploymentEnvironment);
            writer.WriteStringValue("cloudServiceDeploymentId", CloudServiceDeploymentId);
            writer.WriteStringValue("cloudServiceInstanceName", CloudServiceInstanceName);
            writer.WriteStringValue("cloudServiceName", CloudServiceName);
            writer.WriteStringValue("deviceDescription", DeviceDescription);
            writer.WriteStringValue("deviceName", DeviceName);
            writer.WriteStringValue("mediaLegId", MediaLegId);
            writer.WriteCollectionOfObjectValues<TeleconferenceDeviceMediaQuality>("mediaQualityList", MediaQualityList);
            writer.WriteStringValue("participantId", ParticipantId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
