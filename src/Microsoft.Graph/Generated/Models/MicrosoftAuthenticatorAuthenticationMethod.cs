using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class MicrosoftAuthenticatorAuthenticationMethod : AuthenticationMethod, IParsable {
        /// <summary>The date and time that this app was registered. This property is null if the device is not registered for passwordless Phone Sign-In.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.</summary>
        public Microsoft.Graph.Models.Device Device {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Device>("device"); }
            set { BackingStore?.Set("device", value); }
        }
        /// <summary>Tags containing app metadata.</summary>
        public string DeviceTag {
            get { return BackingStore?.Get<string>("deviceTag"); }
            set { BackingStore?.Set("deviceTag", value); }
        }
        /// <summary>The name of the device on which this app is registered.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Numerical version of this instance of the Authenticator app.</summary>
        public string PhoneAppVersion {
            get { return BackingStore?.Get<string>("phoneAppVersion"); }
            set { BackingStore?.Set("phoneAppVersion", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MicrosoftAuthenticatorAuthenticationMethod CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MicrosoftAuthenticatorAuthenticationMethod();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"device", n => { Device = n.GetObjectValue<Microsoft.Graph.Models.Device>(Microsoft.Graph.Models.Device.CreateFromDiscriminatorValue); } },
                {"deviceTag", n => { DeviceTag = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"phoneAppVersion", n => { PhoneAppVersion = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.Device>("device", Device);
            writer.WriteStringValue("deviceTag", DeviceTag);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("phoneAppVersion", PhoneAppVersion);
        }
    }
}
