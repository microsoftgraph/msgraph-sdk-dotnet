using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class TeamsTab : Entity, IParsable {
        /// <summary>Container for custom settings applied to a tab. The tab is considered configured only once this property is set.</summary>
        public TeamsTabConfiguration Configuration { get; set; }
        /// <summary>Name of the tab.</summary>
        public string DisplayName { get; set; }
        /// <summary>The application that is linked to the tab. This cannot be changed after tab creation.</summary>
        public TeamsApp TeamsApp { get; set; }
        /// <summary>Deep link URL of the tab instance. Read only.</summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"configuration", (o,n) => { (o as TeamsTab).Configuration = n.GetObjectValue<TeamsTabConfiguration>(); } },
                {"displayName", (o,n) => { (o as TeamsTab).DisplayName = n.GetStringValue(); } },
                {"teamsApp", (o,n) => { (o as TeamsTab).TeamsApp = n.GetObjectValue<TeamsApp>(); } },
                {"webUrl", (o,n) => { (o as TeamsTab).WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<TeamsTabConfiguration>("configuration", Configuration);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<TeamsApp>("teamsApp", TeamsApp);
            writer.WriteStringValue("webUrl", WebUrl);
        }
    }
}
