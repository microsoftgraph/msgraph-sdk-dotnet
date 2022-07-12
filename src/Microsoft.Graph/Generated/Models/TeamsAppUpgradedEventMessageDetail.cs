using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TeamsAppUpgradedEventMessageDetail : EventMessageDetail, IParsable {
        /// <summary>Initiator of the event.</summary>
        public IdentitySet Initiator {
            get { return BackingStore?.Get<IdentitySet>("initiator"); }
            set { BackingStore?.Set("initiator", value); }
        }
        /// <summary>Display name of the teamsApp.</summary>
        public string TeamsAppDisplayName {
            get { return BackingStore?.Get<string>("teamsAppDisplayName"); }
            set { BackingStore?.Set("teamsAppDisplayName", value); }
        }
        /// <summary>Unique identifier of the teamsApp.</summary>
        public string TeamsAppId {
            get { return BackingStore?.Get<string>("teamsAppId"); }
            set { BackingStore?.Set("teamsAppId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new TeamsAppUpgradedEventMessageDetail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TeamsAppUpgradedEventMessageDetail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"initiator", n => { Initiator = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"teamsAppDisplayName", n => { TeamsAppDisplayName = n.GetStringValue(); } },
                {"teamsAppId", n => { TeamsAppId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<IdentitySet>("initiator", Initiator);
            writer.WriteStringValue("teamsAppDisplayName", TeamsAppDisplayName);
            writer.WriteStringValue("teamsAppId", TeamsAppId);
        }
    }
}
