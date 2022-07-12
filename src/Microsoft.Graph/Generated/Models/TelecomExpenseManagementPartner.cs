using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>telecomExpenseManagementPartner resources represent the metadata and status of a given TEM service. Once your organization has onboarded with a partner, the partner can be enabled or disabled to switch TEM functionality on or off.</summary>
    public class TelecomExpenseManagementPartner : Entity, IParsable {
        /// <summary>Whether the partner&apos;s AAD app has been authorized to access Intune.</summary>
        public bool? AppAuthorized {
            get { return BackingStore?.Get<bool?>("appAuthorized"); }
            set { BackingStore?.Set("appAuthorized", value); }
        }
        /// <summary>Display name of the TEM partner.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Whether Intune&apos;s connection to the TEM service is currently enabled or disabled.</summary>
        public bool? Enabled {
            get { return BackingStore?.Get<bool?>("enabled"); }
            set { BackingStore?.Set("enabled", value); }
        }
        /// <summary>Timestamp of the last request sent to Intune by the TEM partner.</summary>
        public DateTimeOffset? LastConnectionDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastConnectionDateTime"); }
            set { BackingStore?.Set("lastConnectionDateTime", value); }
        }
        /// <summary>URL of the TEM partner&apos;s administrative control panel, where an administrator can configure their TEM service.</summary>
        public string Url {
            get { return BackingStore?.Get<string>("url"); }
            set { BackingStore?.Set("url", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new TelecomExpenseManagementPartner CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TelecomExpenseManagementPartner();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appAuthorized", n => { AppAuthorized = n.GetBoolValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"enabled", n => { Enabled = n.GetBoolValue(); } },
                {"lastConnectionDateTime", n => { LastConnectionDateTime = n.GetDateTimeOffsetValue(); } },
                {"url", n => { Url = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("appAuthorized", AppAuthorized);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("enabled", Enabled);
            writer.WriteDateTimeOffsetValue("lastConnectionDateTime", LastConnectionDateTime);
            writer.WriteStringValue("url", Url);
        }
    }
}
