using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class OnenoteSection : OnenoteEntityHierarchyModel, IParsable {
        /// <summary>Indicates whether this is the user&apos;s default section. Read-only.</summary>
        public bool? IsDefault {
            get { return BackingStore?.Get<bool?>("isDefault"); }
            set { BackingStore?.Set("isDefault", value); }
        }
        /// <summary>Links for opening the section. The oneNoteClientURL link opens the section in the OneNote native client if it&apos;s installed. The oneNoteWebURL link opens the section in OneNote on the web.</summary>
        public SectionLinks Links {
            get { return BackingStore?.Get<SectionLinks>("links"); }
            set { BackingStore?.Set("links", value); }
        }
        /// <summary>The collection of pages in the section.  Read-only. Nullable.</summary>
        public List<OnenotePage> Pages {
            get { return BackingStore?.Get<List<OnenotePage>>("pages"); }
            set { BackingStore?.Set("pages", value); }
        }
        /// <summary>The pages endpoint where you can get details for all the pages in the section. Read-only.</summary>
        public string PagesUrl {
            get { return BackingStore?.Get<string>("pagesUrl"); }
            set { BackingStore?.Set("pagesUrl", value); }
        }
        /// <summary>The notebook that contains the section.  Read-only.</summary>
        public Notebook ParentNotebook {
            get { return BackingStore?.Get<Notebook>("parentNotebook"); }
            set { BackingStore?.Set("parentNotebook", value); }
        }
        /// <summary>The section group that contains the section.  Read-only.</summary>
        public SectionGroup ParentSectionGroup {
            get { return BackingStore?.Get<SectionGroup>("parentSectionGroup"); }
            set { BackingStore?.Set("parentSectionGroup", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new OnenoteSection CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnenoteSection();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"isDefault", n => { IsDefault = n.GetBoolValue(); } },
                {"links", n => { Links = n.GetObjectValue<SectionLinks>(SectionLinks.CreateFromDiscriminatorValue); } },
                {"pages", n => { Pages = n.GetCollectionOfObjectValues<OnenotePage>(OnenotePage.CreateFromDiscriminatorValue).ToList(); } },
                {"pagesUrl", n => { PagesUrl = n.GetStringValue(); } },
                {"parentNotebook", n => { ParentNotebook = n.GetObjectValue<Notebook>(Notebook.CreateFromDiscriminatorValue); } },
                {"parentSectionGroup", n => { ParentSectionGroup = n.GetObjectValue<SectionGroup>(SectionGroup.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("isDefault", IsDefault);
            writer.WriteObjectValue<SectionLinks>("links", Links);
            writer.WriteCollectionOfObjectValues<OnenotePage>("pages", Pages);
            writer.WriteStringValue("pagesUrl", PagesUrl);
            writer.WriteObjectValue<Notebook>("parentNotebook", ParentNotebook);
            writer.WriteObjectValue<SectionGroup>("parentSectionGroup", ParentSectionGroup);
        }
    }
}
