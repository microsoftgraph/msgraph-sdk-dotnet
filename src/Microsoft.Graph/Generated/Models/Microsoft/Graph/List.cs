using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class List : BaseItem, IParsable {
        /// <summary>The collection of field definitions for this list.</summary>
        public List<ColumnDefinition> Columns { get; set; }
        /// <summary>The collection of content types present in this list.</summary>
        public List<ContentType> ContentTypes { get; set; }
        /// <summary>The displayable title of the list.</summary>
        public string DisplayName { get; set; }
        /// <summary>Only present on document libraries. Allows access to the list as a [drive][] resource with [driveItems][driveItem].</summary>
        public Drive Drive { get; set; }
        /// <summary>All items contained in the list.</summary>
        public List<ListItem> Items { get; set; }
        /// <summary>Provides additional details about the list.</summary>
        public ListInfo List_prop { get; set; }
        /// <summary>Returns identifiers useful for SharePoint REST compatibility. Read-only.</summary>
        public SharepointIds SharepointIds { get; set; }
        /// <summary>The set of subscriptions on the list.</summary>
        public List<Subscription> Subscriptions { get; set; }
        /// <summary>If present, indicates that this is a system-managed list. Read-only.</summary>
        public SystemFacet System { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"columns", (o,n) => { (o as List).Columns = n.GetCollectionOfObjectValues<ColumnDefinition>().ToList(); } },
                {"contentTypes", (o,n) => { (o as List).ContentTypes = n.GetCollectionOfObjectValues<ContentType>().ToList(); } },
                {"displayName", (o,n) => { (o as List).DisplayName = n.GetStringValue(); } },
                {"drive", (o,n) => { (o as List).Drive = n.GetObjectValue<Drive>(); } },
                {"items", (o,n) => { (o as List).Items = n.GetCollectionOfObjectValues<ListItem>().ToList(); } },
                {"list", (o,n) => { (o as List).List_prop = n.GetObjectValue<ListInfo>(); } },
                {"sharepointIds", (o,n) => { (o as List).SharepointIds = n.GetObjectValue<SharepointIds>(); } },
                {"subscriptions", (o,n) => { (o as List).Subscriptions = n.GetCollectionOfObjectValues<Subscription>().ToList(); } },
                {"system", (o,n) => { (o as List).System = n.GetObjectValue<SystemFacet>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ColumnDefinition>("columns", Columns);
            writer.WriteCollectionOfObjectValues<ContentType>("contentTypes", ContentTypes);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<Drive>("drive", Drive);
            writer.WriteCollectionOfObjectValues<ListItem>("items", Items);
            writer.WriteObjectValue<ListInfo>("list", List_prop);
            writer.WriteObjectValue<SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteCollectionOfObjectValues<Subscription>("subscriptions", Subscriptions);
            writer.WriteObjectValue<SystemFacet>("system", System);
        }
    }
}
