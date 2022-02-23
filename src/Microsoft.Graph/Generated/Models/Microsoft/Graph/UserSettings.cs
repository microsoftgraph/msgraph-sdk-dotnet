using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class UserSettings : Entity, IParsable {
        /// <summary>Reflects the Office Delve organization level setting. When set to true, the organization doesn't have access to Office Delve. This setting is read-only and can only be changed by administrators in the SharePoint admin center.</summary>
        public bool? ContributionToContentDiscoveryAsOrganizationDisabled { get; set; }
        /// <summary>When set to true, documents in the user's Office Delve are disabled. Users can control this setting in Office Delve.</summary>
        public bool? ContributionToContentDiscoveryDisabled { get; set; }
        /// <summary>The shift preferences for the user.</summary>
        public ShiftPreferences ShiftPreferences { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"contributionToContentDiscoveryAsOrganizationDisabled", (o,n) => { (o as UserSettings).ContributionToContentDiscoveryAsOrganizationDisabled = n.GetBoolValue(); } },
                {"contributionToContentDiscoveryDisabled", (o,n) => { (o as UserSettings).ContributionToContentDiscoveryDisabled = n.GetBoolValue(); } },
                {"shiftPreferences", (o,n) => { (o as UserSettings).ShiftPreferences = n.GetObjectValue<ShiftPreferences>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("contributionToContentDiscoveryAsOrganizationDisabled", ContributionToContentDiscoveryAsOrganizationDisabled);
            writer.WriteBoolValue("contributionToContentDiscoveryDisabled", ContributionToContentDiscoveryDisabled);
            writer.WriteObjectValue<ShiftPreferences>("shiftPreferences", ShiftPreferences);
        }
    }
}
