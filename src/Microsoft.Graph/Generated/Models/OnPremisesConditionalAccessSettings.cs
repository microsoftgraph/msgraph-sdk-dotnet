using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Singleton entity which represents the Exchange OnPremises Conditional Access Settings for a tenant.</summary>
    public class OnPremisesConditionalAccessSettings : Entity, IParsable {
        /// <summary>Indicates if on premises conditional access is enabled for this organization</summary>
        public bool? Enabled {
            get { return BackingStore?.Get<bool?>("enabled"); }
            set { BackingStore?.Set("enabled", value); }
        }
        /// <summary>User groups that will be exempt by on premises conditional access. All users in these groups will be exempt from the conditional access policy.</summary>
        public List<string> ExcludedGroups {
            get { return BackingStore?.Get<List<string>>("excludedGroups"); }
            set { BackingStore?.Set("excludedGroups", value); }
        }
        /// <summary>User groups that will be targeted by on premises conditional access. All users in these groups will be required to have mobile device managed and compliant for mail access.</summary>
        public List<string> IncludedGroups {
            get { return BackingStore?.Get<List<string>>("includedGroups"); }
            set { BackingStore?.Set("includedGroups", value); }
        }
        /// <summary>Override the default access rule when allowing a device to ensure access is granted.</summary>
        public bool? OverrideDefaultRule {
            get { return BackingStore?.Get<bool?>("overrideDefaultRule"); }
            set { BackingStore?.Set("overrideDefaultRule", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new OnPremisesConditionalAccessSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnPremisesConditionalAccessSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"enabled", n => { Enabled = n.GetBoolValue(); } },
                {"excludedGroups", n => { ExcludedGroups = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"includedGroups", n => { IncludedGroups = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"overrideDefaultRule", n => { OverrideDefaultRule = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("enabled", Enabled);
            writer.WriteCollectionOfPrimitiveValues<string>("excludedGroups", ExcludedGroups);
            writer.WriteCollectionOfPrimitiveValues<string>("includedGroups", IncludedGroups);
            writer.WriteBoolValue("overrideDefaultRule", OverrideDefaultRule);
        }
    }
}
