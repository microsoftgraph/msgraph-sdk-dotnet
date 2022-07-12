using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UserTeamwork : Entity, IParsable {
        /// <summary>The list of associatedTeamInfo objects that a user is associated with.</summary>
        public List<AssociatedTeamInfo> AssociatedTeams {
            get { return BackingStore?.Get<List<AssociatedTeamInfo>>("associatedTeams"); }
            set { BackingStore?.Set("associatedTeams", value); }
        }
        /// <summary>The apps installed in the personal scope of this user.</summary>
        public List<UserScopeTeamsAppInstallation> InstalledApps {
            get { return BackingStore?.Get<List<UserScopeTeamsAppInstallation>>("installedApps"); }
            set { BackingStore?.Set("installedApps", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UserTeamwork CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UserTeamwork();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"associatedTeams", n => { AssociatedTeams = n.GetCollectionOfObjectValues<AssociatedTeamInfo>(AssociatedTeamInfo.CreateFromDiscriminatorValue).ToList(); } },
                {"installedApps", n => { InstalledApps = n.GetCollectionOfObjectValues<UserScopeTeamsAppInstallation>(UserScopeTeamsAppInstallation.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<AssociatedTeamInfo>("associatedTeams", AssociatedTeams);
            writer.WriteCollectionOfObjectValues<UserScopeTeamsAppInstallation>("installedApps", InstalledApps);
        }
    }
}
