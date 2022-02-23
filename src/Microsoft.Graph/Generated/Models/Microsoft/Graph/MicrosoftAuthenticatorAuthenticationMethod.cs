using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class MicrosoftAuthenticatorAuthenticationMethod : AuthenticationMethod, IParsable {
        /// <summary>The date and time that this app was registered. This property is null if the device is not registered for passwordless Phone Sign-In.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The registered device on which Microsoft Authenticator resides. This property is null if the device is not registered for passwordless Phone Sign-In.</summary>
        public Device Device { get; set; }
        /// <summary>Tags containing app metadata.</summary>
        public string DeviceTag { get; set; }
        /// <summary>The name of the device on which this app is registered.</summary>
        public string DisplayName { get; set; }
        /// <summary>Numerical version of this instance of the Authenticator app.</summary>
        public string PhoneAppVersion { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"createdDateTime", (o,n) => { (o as MicrosoftAuthenticatorAuthenticationMethod).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"device", (o,n) => { (o as MicrosoftAuthenticatorAuthenticationMethod).Device = n.GetObjectValue<Device>(); } },
                {"deviceTag", (o,n) => { (o as MicrosoftAuthenticatorAuthenticationMethod).DeviceTag = n.GetStringValue(); } },
                {"displayName", (o,n) => { (o as MicrosoftAuthenticatorAuthenticationMethod).DisplayName = n.GetStringValue(); } },
                {"phoneAppVersion", (o,n) => { (o as MicrosoftAuthenticatorAuthenticationMethod).PhoneAppVersion = n.GetStringValue(); } },
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
            writer.WriteObjectValue<Device>("device", Device);
            writer.WriteStringValue("deviceTag", DeviceTag);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("phoneAppVersion", PhoneAppVersion);
        }
    }
}
