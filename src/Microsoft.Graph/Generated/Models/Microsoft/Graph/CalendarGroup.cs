using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class CalendarGroup : Entity, IParsable {
        /// <summary>The calendars in the calendar group. Navigation property. Read-only. Nullable.</summary>
        public List<Calendar> Calendars { get; set; }
        /// <summary>Identifies the version of the calendar group. Every time the calendar group is changed, ChangeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.</summary>
        public string ChangeKey { get; set; }
        /// <summary>The class identifier. Read-only.</summary>
        public string ClassId { get; set; }
        /// <summary>The group name.</summary>
        public string Name { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"calendars", (o,n) => { (o as CalendarGroup).Calendars = n.GetCollectionOfObjectValues<Calendar>().ToList(); } },
                {"changeKey", (o,n) => { (o as CalendarGroup).ChangeKey = n.GetStringValue(); } },
                {"classId", (o,n) => { (o as CalendarGroup).ClassId = n.GetStringValue(); } },
                {"name", (o,n) => { (o as CalendarGroup).Name = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Calendar>("calendars", Calendars);
            writer.WriteStringValue("changeKey", ChangeKey);
            writer.WriteStringValue("classId", ClassId);
            writer.WriteStringValue("name", Name);
        }
    }
}
