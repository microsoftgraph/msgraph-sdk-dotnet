using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class Security : Entity, IParsable {
        /// <summary>Notifications for suspicious or potential security issues in a customer’s tenant.</summary>
        public List<Microsoft.Graph.Models.Alert> Alerts {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.Alert>>("alerts"); }
            set { BackingStore?.Set("alerts", value); }
        }
        /// <summary>The cases property</summary>
        public CasesRoot Cases {
            get { return BackingStore?.Get<CasesRoot>("cases"); }
            set { BackingStore?.Set("cases", value); }
        }
        /// <summary>The secureScoreControlProfiles property</summary>
        public List<Microsoft.Graph.Models.SecureScoreControlProfile> SecureScoreControlProfiles {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.SecureScoreControlProfile>>("secureScoreControlProfiles"); }
            set { BackingStore?.Set("secureScoreControlProfiles", value); }
        }
        /// <summary>The secureScores property</summary>
        public List<Microsoft.Graph.Models.SecureScore> SecureScores {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.SecureScore>>("secureScores"); }
            set { BackingStore?.Set("secureScores", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Security CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Security();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"alerts", n => { Alerts = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.Alert>(Microsoft.Graph.Models.Alert.CreateFromDiscriminatorValue).ToList(); } },
                {"cases", n => { Cases = n.GetObjectValue<CasesRoot>(CasesRoot.CreateFromDiscriminatorValue); } },
                {"secureScoreControlProfiles", n => { SecureScoreControlProfiles = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.SecureScoreControlProfile>(Microsoft.Graph.Models.SecureScoreControlProfile.CreateFromDiscriminatorValue).ToList(); } },
                {"secureScores", n => { SecureScores = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.SecureScore>(Microsoft.Graph.Models.SecureScore.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.Alert>("alerts", Alerts);
            writer.WriteObjectValue<CasesRoot>("cases", Cases);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.SecureScoreControlProfile>("secureScoreControlProfiles", SecureScoreControlProfiles);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.SecureScore>("secureScores", SecureScores);
        }
    }
}
