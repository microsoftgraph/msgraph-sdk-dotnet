using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class SectionGroup : OnenoteEntityHierarchyModel, IParsable {
        /// <summary>The notebook that contains the section group. Read-only.</summary>
        public Notebook ParentNotebook {
            get { return BackingStore?.Get<Notebook>("parentNotebook"); }
            set { BackingStore?.Set("parentNotebook", value); }
        }
        /// <summary>The section group that contains the section group. Read-only.</summary>
        public SectionGroup ParentSectionGroup {
            get { return BackingStore?.Get<SectionGroup>("parentSectionGroup"); }
            set { BackingStore?.Set("parentSectionGroup", value); }
        }
        /// <summary>The section groups in the section. Read-only. Nullable.</summary>
        public List<SectionGroup> SectionGroups {
            get { return BackingStore?.Get<List<SectionGroup>>("sectionGroups"); }
            set { BackingStore?.Set("sectionGroups", value); }
        }
        /// <summary>The URL for the sectionGroups navigation property, which returns all the section groups in the section group. Read-only.</summary>
        public string SectionGroupsUrl {
            get { return BackingStore?.Get<string>("sectionGroupsUrl"); }
            set { BackingStore?.Set("sectionGroupsUrl", value); }
        }
        /// <summary>The sections in the section group. Read-only. Nullable.</summary>
        public List<OnenoteSection> Sections {
            get { return BackingStore?.Get<List<OnenoteSection>>("sections"); }
            set { BackingStore?.Set("sections", value); }
        }
        /// <summary>The URL for the sections navigation property, which returns all the sections in the section group. Read-only.</summary>
        public string SectionsUrl {
            get { return BackingStore?.Get<string>("sectionsUrl"); }
            set { BackingStore?.Set("sectionsUrl", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SectionGroup CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SectionGroup();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"parentNotebook", n => { ParentNotebook = n.GetObjectValue<Notebook>(Notebook.CreateFromDiscriminatorValue); } },
                {"parentSectionGroup", n => { ParentSectionGroup = n.GetObjectValue<SectionGroup>(SectionGroup.CreateFromDiscriminatorValue); } },
                {"sectionGroups", n => { SectionGroups = n.GetCollectionOfObjectValues<SectionGroup>(SectionGroup.CreateFromDiscriminatorValue).ToList(); } },
                {"sectionGroupsUrl", n => { SectionGroupsUrl = n.GetStringValue(); } },
                {"sections", n => { Sections = n.GetCollectionOfObjectValues<OnenoteSection>(OnenoteSection.CreateFromDiscriminatorValue).ToList(); } },
                {"sectionsUrl", n => { SectionsUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Notebook>("parentNotebook", ParentNotebook);
            writer.WriteObjectValue<SectionGroup>("parentSectionGroup", ParentSectionGroup);
            writer.WriteCollectionOfObjectValues<SectionGroup>("sectionGroups", SectionGroups);
            writer.WriteStringValue("sectionGroupsUrl", SectionGroupsUrl);
            writer.WriteCollectionOfObjectValues<OnenoteSection>("sections", Sections);
            writer.WriteStringValue("sectionsUrl", SectionsUrl);
        }
    }
}
