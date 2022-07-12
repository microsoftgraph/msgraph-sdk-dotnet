using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class Subscription : Entity, IParsable {
        /// <summary>Optional. Identifier of the application used to create the subscription. Read-only.</summary>
        public string ApplicationId {
            get { return BackingStore?.Get<string>("applicationId"); }
            set { BackingStore?.Set("applicationId", value); }
        }
        /// <summary>Required. Indicates the type of change in the subscribed resource that will raise a change notification. The supported values are: created, updated, deleted. Multiple values can be combined using a comma-separated list. Note:  Drive root item and list change notifications support only the updated changeType. User and group change notifications support updated and deleted changeType.</summary>
        public string ChangeType {
            get { return BackingStore?.Get<string>("changeType"); }
            set { BackingStore?.Set("changeType", value); }
        }
        /// <summary>Optional. Specifies the value of the clientState property sent by the service in each change notification. The maximum length is 255 characters. The client can check that the change notification came from the service by comparing the value of the clientState property sent with the subscription with the value of the clientState property received with each change notification.</summary>
        public string ClientState {
            get { return BackingStore?.Get<string>("clientState"); }
            set { BackingStore?.Set("clientState", value); }
        }
        /// <summary>Optional. Identifier of the user or service principal that created the subscription. If the app used delegated permissions to create the subscription, this field contains the ID of the signed-in user the app called on behalf of. If the app used application permissions, this field contains the ID of the service principal corresponding to the app. Read-only.</summary>
        public string CreatorId {
            get { return BackingStore?.Get<string>("creatorId"); }
            set { BackingStore?.Set("creatorId", value); }
        }
        /// <summary>Optional. A base64-encoded representation of a certificate with a public key used to encrypt resource data in change notifications. Optional but required when includeResourceData is true.</summary>
        public string EncryptionCertificate {
            get { return BackingStore?.Get<string>("encryptionCertificate"); }
            set { BackingStore?.Set("encryptionCertificate", value); }
        }
        /// <summary>Optional. A custom app-provided identifier to help identify the certificate needed to decrypt resource data. Required when includeResourceData is true.</summary>
        public string EncryptionCertificateId {
            get { return BackingStore?.Get<string>("encryptionCertificateId"); }
            set { BackingStore?.Set("encryptionCertificateId", value); }
        }
        /// <summary>Required. Specifies the date and time when the webhook subscription expires. The time is in UTC, and can be an amount of time from subscription creation that varies for the resource subscribed to. For the maximum supported subscription length of time, see the table below.</summary>
        public DateTimeOffset? ExpirationDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("expirationDateTime"); }
            set { BackingStore?.Set("expirationDateTime", value); }
        }
        /// <summary>Optional. When set to true, change notifications include resource data (such as content of a chat message).</summary>
        public bool? IncludeResourceData {
            get { return BackingStore?.Get<bool?>("includeResourceData"); }
            set { BackingStore?.Set("includeResourceData", value); }
        }
        /// <summary>Optional. Specifies the latest version of Transport Layer Security (TLS) that the notification endpoint, specified by notificationUrl, supports. The possible values are: v1_0, v1_1, v1_2, v1_3. For subscribers whose notification endpoint supports a version lower than the currently recommended version (TLS 1.2), specifying this property by a set timeline allows them to temporarily use their deprecated version of TLS before completing their upgrade to TLS 1.2. For these subscribers, not setting this property per the timeline would result in subscription operations failing. For subscribers whose notification endpoint already supports TLS 1.2, setting this property is optional. In such cases, Microsoft Graph defaults the property to v1_2.</summary>
        public string LatestSupportedTlsVersion {
            get { return BackingStore?.Get<string>("latestSupportedTlsVersion"); }
            set { BackingStore?.Set("latestSupportedTlsVersion", value); }
        }
        /// <summary>Optional. The URL of the endpoint that receives lifecycle notifications, including subscriptionRemoved and missed notifications. This URL must make use of the HTTPS protocol.</summary>
        public string LifecycleNotificationUrl {
            get { return BackingStore?.Get<string>("lifecycleNotificationUrl"); }
            set { BackingStore?.Set("lifecycleNotificationUrl", value); }
        }
        /// <summary>Optional.  OData query options for specifying the value for the targeting resource. Clients receive notifications when the resource reaches the state matching the query options provided here. With this new property in the subscription creation payload along with all existing properties, Webhooks will deliver notifications whenever a resource reaches the desired state mentioned in the notificationQueryOptions property. For example, when the print job is completed or when a print job resource isFetchable property value becomes true etc.</summary>
        public string NotificationQueryOptions {
            get { return BackingStore?.Get<string>("notificationQueryOptions"); }
            set { BackingStore?.Set("notificationQueryOptions", value); }
        }
        /// <summary>Required. The URL of the endpoint that receives the change notifications. This URL must make use of the HTTPS protocol.</summary>
        public string NotificationUrl {
            get { return BackingStore?.Get<string>("notificationUrl"); }
            set { BackingStore?.Set("notificationUrl", value); }
        }
        /// <summary>Optional. The app ID that the subscription service can use to generate the validation token. This allows the client to validate the authenticity of the notification received.</summary>
        public string NotificationUrlAppId {
            get { return BackingStore?.Get<string>("notificationUrlAppId"); }
            set { BackingStore?.Set("notificationUrlAppId", value); }
        }
        /// <summary>Required. Specifies the resource that will be monitored for changes. Do not include the base URL (https://graph.microsoft.com/beta/). See the possible resource path values for each supported resource.</summary>
        public string Resource {
            get { return BackingStore?.Get<string>("resource"); }
            set { BackingStore?.Set("resource", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Subscription CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Subscription();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"applicationId", n => { ApplicationId = n.GetStringValue(); } },
                {"changeType", n => { ChangeType = n.GetStringValue(); } },
                {"clientState", n => { ClientState = n.GetStringValue(); } },
                {"creatorId", n => { CreatorId = n.GetStringValue(); } },
                {"encryptionCertificate", n => { EncryptionCertificate = n.GetStringValue(); } },
                {"encryptionCertificateId", n => { EncryptionCertificateId = n.GetStringValue(); } },
                {"expirationDateTime", n => { ExpirationDateTime = n.GetDateTimeOffsetValue(); } },
                {"includeResourceData", n => { IncludeResourceData = n.GetBoolValue(); } },
                {"latestSupportedTlsVersion", n => { LatestSupportedTlsVersion = n.GetStringValue(); } },
                {"lifecycleNotificationUrl", n => { LifecycleNotificationUrl = n.GetStringValue(); } },
                {"notificationQueryOptions", n => { NotificationQueryOptions = n.GetStringValue(); } },
                {"notificationUrl", n => { NotificationUrl = n.GetStringValue(); } },
                {"notificationUrlAppId", n => { NotificationUrlAppId = n.GetStringValue(); } },
                {"resource", n => { Resource = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("applicationId", ApplicationId);
            writer.WriteStringValue("changeType", ChangeType);
            writer.WriteStringValue("clientState", ClientState);
            writer.WriteStringValue("creatorId", CreatorId);
            writer.WriteStringValue("encryptionCertificate", EncryptionCertificate);
            writer.WriteStringValue("encryptionCertificateId", EncryptionCertificateId);
            writer.WriteDateTimeOffsetValue("expirationDateTime", ExpirationDateTime);
            writer.WriteBoolValue("includeResourceData", IncludeResourceData);
            writer.WriteStringValue("latestSupportedTlsVersion", LatestSupportedTlsVersion);
            writer.WriteStringValue("lifecycleNotificationUrl", LifecycleNotificationUrl);
            writer.WriteStringValue("notificationQueryOptions", NotificationQueryOptions);
            writer.WriteStringValue("notificationUrl", NotificationUrl);
            writer.WriteStringValue("notificationUrlAppId", NotificationUrlAppId);
            writer.WriteStringValue("resource", Resource);
        }
    }
}
