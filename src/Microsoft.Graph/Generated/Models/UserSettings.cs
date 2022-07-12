using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UserSettings : Entity, IParsable {
        /// <summary>Reflects the Office Delve organization level setting. When set to true, the organization doesn&apos;t have access to Office Delve. This setting is read-only and can only be changed by administrators in the SharePoint admin center.</summary>
        public bool? ContributionToContentDiscoveryAsOrganizationDisabled {
            get { return BackingStore?.Get<bool?>("contributionToContentDiscoveryAsOrganizationDisabled"); }
            set { BackingStore?.Set("contributionToContentDiscoveryAsOrganizationDisabled", value); }
        }
        /// <summary>When set to true, documents in the user&apos;s Office Delve are disabled. Users can control this setting in Office Delve.</summary>
        public bool? ContributionToContentDiscoveryDisabled {
            get { return BackingStore?.Get<bool?>("contributionToContentDiscoveryDisabled"); }
            set { BackingStore?.Set("contributionToContentDiscoveryDisabled", value); }
        }
        /// <summary>The shift preferences for the user.</summary>
        public Microsoft.Graph.Models.ShiftPreferences ShiftPreferences {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ShiftPreferences>("shiftPreferences"); }
            set { BackingStore?.Set("shiftPreferences", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UserSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UserSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"contributionToContentDiscoveryAsOrganizationDisabled", n => { ContributionToContentDiscoveryAsOrganizationDisabled = n.GetBoolValue(); } },
                {"contributionToContentDiscoveryDisabled", n => { ContributionToContentDiscoveryDisabled = n.GetBoolValue(); } },
                {"shiftPreferences", n => { ShiftPreferences = n.GetObjectValue<Microsoft.Graph.Models.ShiftPreferences>(Microsoft.Graph.Models.ShiftPreferences.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<Microsoft.Graph.Models.ShiftPreferences>("shiftPreferences", ShiftPreferences);
        }
    }
}
