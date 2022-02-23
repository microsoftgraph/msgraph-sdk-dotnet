using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class TeamsApp : Entity, IParsable {
        /// <summary>The details for each version of the app.</summary>
        public List<TeamsAppDefinition> AppDefinitions { get; set; }
        /// <summary>The name of the catalog app provided by the app developer in the Microsoft Teams zip app package.</summary>
        public string DisplayName { get; set; }
        /// <summary>The method of distribution for the app. Read-only.</summary>
        public TeamsAppDistributionMethod? DistributionMethod { get; set; }
        /// <summary>The ID of the catalog provided by the app developer in the Microsoft Teams zip app package.</summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"appDefinitions", (o,n) => { (o as TeamsApp).AppDefinitions = n.GetCollectionOfObjectValues<TeamsAppDefinition>().ToList(); } },
                {"displayName", (o,n) => { (o as TeamsApp).DisplayName = n.GetStringValue(); } },
                {"distributionMethod", (o,n) => { (o as TeamsApp).DistributionMethod = n.GetEnumValue<TeamsAppDistributionMethod>(); } },
                {"externalId", (o,n) => { (o as TeamsApp).ExternalId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<TeamsAppDefinition>("appDefinitions", AppDefinitions);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteEnumValue<TeamsAppDistributionMethod>("distributionMethod", DistributionMethod);
            writer.WriteStringValue("externalId", ExternalId);
        }
    }
}
