using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class List : BaseItem, IParsable {
        /// <summary>The collection of field definitions for this list.</summary>
        public List<ColumnDefinition> Columns {
            get { return BackingStore?.Get<List<ColumnDefinition>>("columns"); }
            set { BackingStore?.Set("columns", value); }
        }
        /// <summary>The collection of content types present in this list.</summary>
        public List<ContentType> ContentTypes {
            get { return BackingStore?.Get<List<ContentType>>("contentTypes"); }
            set { BackingStore?.Set("contentTypes", value); }
        }
        /// <summary>The displayable title of the list.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Only present on document libraries. Allows access to the list as a [drive][] resource with [driveItems][driveItem].</summary>
        public Microsoft.Graph.Models.Drive Drive {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Drive>("drive"); }
            set { BackingStore?.Set("drive", value); }
        }
        /// <summary>All items contained in the list.</summary>
        public List<ListItem> Items {
            get { return BackingStore?.Get<List<ListItem>>("items"); }
            set { BackingStore?.Set("items", value); }
        }
        /// <summary>Provides additional details about the list.</summary>
        public ListInfo List_prop {
            get { return BackingStore?.Get<ListInfo>("list"); }
            set { BackingStore?.Set("list", value); }
        }
        /// <summary>The collection of long-running operations on the list.</summary>
        public List<RichLongRunningOperation> Operations {
            get { return BackingStore?.Get<List<RichLongRunningOperation>>("operations"); }
            set { BackingStore?.Set("operations", value); }
        }
        /// <summary>Returns identifiers useful for SharePoint REST compatibility. Read-only.</summary>
        public Microsoft.Graph.Models.SharepointIds SharepointIds {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SharepointIds>("sharepointIds"); }
            set { BackingStore?.Set("sharepointIds", value); }
        }
        /// <summary>The set of subscriptions on the list.</summary>
        public List<Subscription> Subscriptions {
            get { return BackingStore?.Get<List<Subscription>>("subscriptions"); }
            set { BackingStore?.Set("subscriptions", value); }
        }
        /// <summary>If present, indicates that this is a system-managed list. Read-only.</summary>
        public SystemFacet System {
            get { return BackingStore?.Get<SystemFacet>("system"); }
            set { BackingStore?.Set("system", value); }
        }
        /// <summary>
        /// Instantiates a new list and sets the default values.
        /// </summary>
        public List() : base() {
            OdataType = "#microsoft.graph.list";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new List CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new List();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"columns", n => { Columns = n.GetCollectionOfObjectValues<ColumnDefinition>(ColumnDefinition.CreateFromDiscriminatorValue)?.ToList(); } },
                {"contentTypes", n => { ContentTypes = n.GetCollectionOfObjectValues<ContentType>(ContentType.CreateFromDiscriminatorValue)?.ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"drive", n => { Drive = n.GetObjectValue<Microsoft.Graph.Models.Drive>(Microsoft.Graph.Models.Drive.CreateFromDiscriminatorValue); } },
                {"items", n => { Items = n.GetCollectionOfObjectValues<ListItem>(ListItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"list", n => { List_prop = n.GetObjectValue<ListInfo>(ListInfo.CreateFromDiscriminatorValue); } },
                {"operations", n => { Operations = n.GetCollectionOfObjectValues<RichLongRunningOperation>(RichLongRunningOperation.CreateFromDiscriminatorValue)?.ToList(); } },
                {"sharepointIds", n => { SharepointIds = n.GetObjectValue<Microsoft.Graph.Models.SharepointIds>(Microsoft.Graph.Models.SharepointIds.CreateFromDiscriminatorValue); } },
                {"subscriptions", n => { Subscriptions = n.GetCollectionOfObjectValues<Subscription>(Subscription.CreateFromDiscriminatorValue)?.ToList(); } },
                {"system", n => { System = n.GetObjectValue<SystemFacet>(SystemFacet.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ColumnDefinition>("columns", Columns);
            writer.WriteCollectionOfObjectValues<ContentType>("contentTypes", ContentTypes);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<Microsoft.Graph.Models.Drive>("drive", Drive);
            writer.WriteCollectionOfObjectValues<ListItem>("items", Items);
            writer.WriteObjectValue<ListInfo>("list", List_prop);
            writer.WriteCollectionOfObjectValues<RichLongRunningOperation>("operations", Operations);
            writer.WriteObjectValue<Microsoft.Graph.Models.SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteCollectionOfObjectValues<Subscription>("subscriptions", Subscriptions);
            writer.WriteObjectValue<SystemFacet>("system", System);
        }
    }
}
