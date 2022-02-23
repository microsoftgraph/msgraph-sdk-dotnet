using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph.TermStore {
    public class Group : Entity, IParsable {
        /// <summary>Date and time of the group creation. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Description that gives details on the term usage.</summary>
        public string Description { get; set; }
        /// <summary>Name of the group.</summary>
        public string DisplayName { get; set; }
        /// <summary>ID of the parent site of this group.</summary>
        public string ParentSiteId { get; set; }
        /// <summary>Returns the type of the group. Possible values are global, system, and siteCollection.</summary>
        public TermGroupScope? Scope { get; set; }
        /// <summary>All sets under the group in a term [store].</summary>
        public List<Set> Sets { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"createdDateTime", (o,n) => { (o as Group).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", (o,n) => { (o as Group).Description = n.GetStringValue(); } },
                {"displayName", (o,n) => { (o as Group).DisplayName = n.GetStringValue(); } },
                {"parentSiteId", (o,n) => { (o as Group).ParentSiteId = n.GetStringValue(); } },
                {"scope", (o,n) => { (o as Group).Scope = n.GetEnumValue<TermGroupScope>(); } },
                {"sets", (o,n) => { (o as Group).Sets = n.GetCollectionOfObjectValues<Set>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("parentSiteId", ParentSiteId);
            writer.WriteEnumValue<TermGroupScope>("scope", Scope);
            writer.WriteCollectionOfObjectValues<Set>("sets", Sets);
        }
    }
}
