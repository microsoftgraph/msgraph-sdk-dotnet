using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UpdateWindowsDeviceAccountActionParameter : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Not yet documented</summary>
        public bool? CalendarSyncEnabled {
            get { return BackingStore?.Get<bool?>("calendarSyncEnabled"); }
            set { BackingStore?.Set("calendarSyncEnabled", value); }
        }
        /// <summary>Not yet documented</summary>
        public WindowsDeviceAccount DeviceAccount {
            get { return BackingStore?.Get<WindowsDeviceAccount>("deviceAccount"); }
            set { BackingStore?.Set("deviceAccount", value); }
        }
        /// <summary>Not yet documented</summary>
        public string DeviceAccountEmail {
            get { return BackingStore?.Get<string>("deviceAccountEmail"); }
            set { BackingStore?.Set("deviceAccountEmail", value); }
        }
        /// <summary>Not yet documented</summary>
        public string ExchangeServer {
            get { return BackingStore?.Get<string>("exchangeServer"); }
            set { BackingStore?.Set("exchangeServer", value); }
        }
        /// <summary>Not yet documented</summary>
        public bool? PasswordRotationEnabled {
            get { return BackingStore?.Get<bool?>("passwordRotationEnabled"); }
            set { BackingStore?.Set("passwordRotationEnabled", value); }
        }
        /// <summary>Not yet documented</summary>
        public string SessionInitiationProtocalAddress {
            get { return BackingStore?.Get<string>("sessionInitiationProtocalAddress"); }
            set { BackingStore?.Set("sessionInitiationProtocalAddress", value); }
        }
        /// <summary>
        /// Instantiates a new updateWindowsDeviceAccountActionParameter and sets the default values.
        /// </summary>
        public UpdateWindowsDeviceAccountActionParameter() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static UpdateWindowsDeviceAccountActionParameter CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UpdateWindowsDeviceAccountActionParameter();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"calendarSyncEnabled", n => { CalendarSyncEnabled = n.GetBoolValue(); } },
                {"deviceAccount", n => { DeviceAccount = n.GetObjectValue<WindowsDeviceAccount>(WindowsDeviceAccount.CreateFromDiscriminatorValue); } },
                {"deviceAccountEmail", n => { DeviceAccountEmail = n.GetStringValue(); } },
                {"exchangeServer", n => { ExchangeServer = n.GetStringValue(); } },
                {"passwordRotationEnabled", n => { PasswordRotationEnabled = n.GetBoolValue(); } },
                {"sessionInitiationProtocalAddress", n => { SessionInitiationProtocalAddress = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("calendarSyncEnabled", CalendarSyncEnabled);
            writer.WriteObjectValue<WindowsDeviceAccount>("deviceAccount", DeviceAccount);
            writer.WriteStringValue("deviceAccountEmail", DeviceAccountEmail);
            writer.WriteStringValue("exchangeServer", ExchangeServer);
            writer.WriteBoolValue("passwordRotationEnabled", PasswordRotationEnabled);
            writer.WriteStringValue("sessionInitiationProtocalAddress", SessionInitiationProtocalAddress);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
