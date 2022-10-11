using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class CalendarGroup : Entity, IParsable {
        /// <summary>The calendars in the calendar group. Navigation property. Read-only. Nullable.</summary>
        public List<Calendar> Calendars {
            get { return BackingStore?.Get<List<Calendar>>("calendars"); }
            set { BackingStore?.Set("calendars", value); }
        }
        /// <summary>Identifies the version of the calendar group. Every time the calendar group is changed, ChangeKey changes as well. This allows Exchange to apply changes to the correct version of the object. Read-only.</summary>
        public string ChangeKey {
            get { return BackingStore?.Get<string>("changeKey"); }
            set { BackingStore?.Set("changeKey", value); }
        }
        /// <summary>The class identifier. Read-only.</summary>
        public string ClassId {
            get { return BackingStore?.Get<string>("classId"); }
            set { BackingStore?.Set("classId", value); }
        }
        /// <summary>The group name.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>
        /// Instantiates a new calendarGroup and sets the default values.
        /// </summary>
        public CalendarGroup() : base() {
            OdataType = "#microsoft.graph.calendarGroup";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CalendarGroup CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CalendarGroup();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"calendars", n => { Calendars = n.GetCollectionOfObjectValues<Calendar>(Calendar.CreateFromDiscriminatorValue)?.ToList(); } },
                {"changeKey", n => { ChangeKey = n.GetStringValue(); } },
                {"classId", n => { ClassId = n.GetStringValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
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
