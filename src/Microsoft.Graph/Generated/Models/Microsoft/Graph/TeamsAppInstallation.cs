using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class TeamsAppInstallation : Entity, IParsable {
        /// <summary>The app that is installed.</summary>
        public TeamsApp TeamsApp { get; set; }
        /// <summary>The details of this version of the app.</summary>
        public TeamsAppDefinition TeamsAppDefinition { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"teamsApp", (o,n) => { (o as TeamsAppInstallation).TeamsApp = n.GetObjectValue<TeamsApp>(); } },
                {"teamsAppDefinition", (o,n) => { (o as TeamsAppInstallation).TeamsAppDefinition = n.GetObjectValue<TeamsAppDefinition>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<TeamsApp>("teamsApp", TeamsApp);
            writer.WriteObjectValue<TeamsAppDefinition>("teamsAppDefinition", TeamsAppDefinition);
        }
    }
}
