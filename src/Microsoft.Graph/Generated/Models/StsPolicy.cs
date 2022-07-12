using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class StsPolicy : PolicyBase, IParsable {
        /// <summary>The appliesTo property</summary>
        public List<DirectoryObject> AppliesTo {
            get { return BackingStore?.Get<List<DirectoryObject>>("appliesTo"); }
            set { BackingStore?.Set("appliesTo", value); }
        }
        /// <summary>A string collection containing a JSON string that defines the rules and settings for a policy. The syntax for the definition differs for each derived policy type. Required.</summary>
        public List<string> Definition {
            get { return BackingStore?.Get<List<string>>("definition"); }
            set { BackingStore?.Set("definition", value); }
        }
        /// <summary>If set to true, activates this policy. There can be many policies for the same policy type, but only one can be activated as the organization default. Optional, default value is false.</summary>
        public bool? IsOrganizationDefault {
            get { return BackingStore?.Get<bool?>("isOrganizationDefault"); }
            set { BackingStore?.Set("isOrganizationDefault", value); }
        }
        /// <summary>
        /// Instantiates a new StsPolicy and sets the default values.
        /// </summary>
        public StsPolicy() : base() {
            Type = "#microsoft.graph.stsPolicy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new StsPolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.activityBasedTimeoutPolicy" => new ActivityBasedTimeoutPolicy(),
                "#microsoft.graph.claimsMappingPolicy" => new ClaimsMappingPolicy(),
                "#microsoft.graph.homeRealmDiscoveryPolicy" => new HomeRealmDiscoveryPolicy(),
                "#microsoft.graph.tokenIssuancePolicy" => new TokenIssuancePolicy(),
                "#microsoft.graph.tokenLifetimePolicy" => new TokenLifetimePolicy(),
                _ => new StsPolicy(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appliesTo", n => { AppliesTo = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue).ToList(); } },
                {"definition", n => { Definition = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"isOrganizationDefault", n => { IsOrganizationDefault = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("appliesTo", AppliesTo);
            writer.WriteCollectionOfPrimitiveValues<string>("definition", Definition);
            writer.WriteBoolValue("isOrganizationDefault", IsOrganizationDefault);
        }
    }
}
