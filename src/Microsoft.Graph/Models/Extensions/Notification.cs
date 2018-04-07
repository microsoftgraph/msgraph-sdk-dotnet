using System;
using Newtonsoft.Json;

namespace Microsoft.Graph
{
    /// <summary>
    /// Represents the notifications received from a webhook subscription.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Queued webhook notifications.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "value", Required = Required.Default)]
        public List<NotificationValue> Values { get; set; }
    }

    /// <summary>
    /// Represents a value in a received webhook notification.
    /// </summary>
    public class NotificationValue
    {
        /// <summary>
        /// The ID for the subscription to which this notification belongs.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subscriptionId", Required = Required.Default)]
        public String SubscriptionId { get; set; }

        /// <summary>
        /// The expiration time for the subscription.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subscriptionExpirationDateTime", Required = Required.Default)]
        public String SubscriptionExpirationDateTime { get; set; }

        /// <summary>
        /// The clientState property specified in the subscription request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "clientState", Required = Required.Default)]
        public String ClientState { get; set; }

        /// <summary>
        /// The event type that caused the notification. For example, created on mail receive, or updated on marking a message read.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "changeType", Required = Required.Default)]
        public String ChangeType { get; set; }

        /// <summary>
        /// The URI of the resource relative to https://graph.microsoft.com.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "resource", Required = Required.Default)]
        public String Resource { get; set; }

        /// <summary>
        /// The object dependent on the resource being subscribed to.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "resourceData", Required = Required.Default)]
        public NotificationResourceData ResourceData { get; set; }
    }

    /// <summary>
    /// The object dependent on the resource being subscribed to.
    /// </summary>
    public class NotificationResourceData
    {
        /// <summary>
        /// The OData entity type in Microsoft Graph that describes the represented object.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type", Required = Required.Default)]
        public String ODataType { get; set; }

        /// <summary>
        /// The OData identifier of the object.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.id", Required = Required.Default)]
        public String ODataId { get; set; }

        /// <summary>
        /// The HTTP entity tag that represents a version of the object.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.etag", Required = Required.Default)]
        public String ODataEtag { get; set; }

        /// <summary>
        /// The identifier of the object.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id", Required = Required.Default)]
        public String Id { get; set; }
    }
}
