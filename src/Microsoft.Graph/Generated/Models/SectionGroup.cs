// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    #pragma warning disable CS1591
    public class SectionGroup : Microsoft.Graph.Models.OnenoteEntityHierarchyModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The notebook that contains the section group. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.Notebook? ParentNotebook
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Notebook?>("parentNotebook"); }
            set { BackingStore?.Set("parentNotebook", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.Notebook ParentNotebook
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Notebook>("parentNotebook"); }
            set { BackingStore?.Set("parentNotebook", value); }
        }
#endif
        /// <summary>The section group that contains the section group. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.SectionGroup? ParentSectionGroup
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SectionGroup?>("parentSectionGroup"); }
            set { BackingStore?.Set("parentSectionGroup", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.SectionGroup ParentSectionGroup
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SectionGroup>("parentSectionGroup"); }
            set { BackingStore?.Set("parentSectionGroup", value); }
        }
#endif
        /// <summary>The section groups in the section. Read-only. Nullable.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.SectionGroup>? SectionGroups
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.SectionGroup>?>("sectionGroups"); }
            set { BackingStore?.Set("sectionGroups", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.SectionGroup> SectionGroups
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.SectionGroup>>("sectionGroups"); }
            set { BackingStore?.Set("sectionGroups", value); }
        }
#endif
        /// <summary>The URL for the sectionGroups navigation property, which returns all the section groups in the section group. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SectionGroupsUrl
        {
            get { return BackingStore?.Get<string?>("sectionGroupsUrl"); }
            set { BackingStore?.Set("sectionGroupsUrl", value); }
        }
#nullable restore
#else
        public string SectionGroupsUrl
        {
            get { return BackingStore?.Get<string>("sectionGroupsUrl"); }
            set { BackingStore?.Set("sectionGroupsUrl", value); }
        }
#endif
        /// <summary>The sections in the section group. Read-only. Nullable.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.OnenoteSection>? Sections
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.OnenoteSection>?>("sections"); }
            set { BackingStore?.Set("sections", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.OnenoteSection> Sections
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.OnenoteSection>>("sections"); }
            set { BackingStore?.Set("sections", value); }
        }
#endif
        /// <summary>The URL for the sections navigation property, which returns all the sections in the section group. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SectionsUrl
        {
            get { return BackingStore?.Get<string?>("sectionsUrl"); }
            set { BackingStore?.Set("sectionsUrl", value); }
        }
#nullable restore
#else
        public string SectionsUrl
        {
            get { return BackingStore?.Get<string>("sectionsUrl"); }
            set { BackingStore?.Set("sectionsUrl", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="Microsoft.Graph.Models.SectionGroup"/> and sets the default values.
        /// </summary>
        public SectionGroup() : base()
        {
            OdataType = "#microsoft.graph.sectionGroup";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.SectionGroup"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.SectionGroup CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Microsoft.Graph.Models.SectionGroup();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "parentNotebook", n => { ParentNotebook = n.GetObjectValue<Microsoft.Graph.Models.Notebook>(Microsoft.Graph.Models.Notebook.CreateFromDiscriminatorValue); } },
                { "parentSectionGroup", n => { ParentSectionGroup = n.GetObjectValue<Microsoft.Graph.Models.SectionGroup>(Microsoft.Graph.Models.SectionGroup.CreateFromDiscriminatorValue); } },
                { "sectionGroups", n => { SectionGroups = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.SectionGroup>(Microsoft.Graph.Models.SectionGroup.CreateFromDiscriminatorValue)?.ToList(); } },
                { "sectionGroupsUrl", n => { SectionGroupsUrl = n.GetStringValue(); } },
                { "sections", n => { Sections = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.OnenoteSection>(Microsoft.Graph.Models.OnenoteSection.CreateFromDiscriminatorValue)?.ToList(); } },
                { "sectionsUrl", n => { SectionsUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.Notebook>("parentNotebook", ParentNotebook);
            writer.WriteObjectValue<Microsoft.Graph.Models.SectionGroup>("parentSectionGroup", ParentSectionGroup);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.SectionGroup>("sectionGroups", SectionGroups);
            writer.WriteStringValue("sectionGroupsUrl", SectionGroupsUrl);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.OnenoteSection>("sections", Sections);
            writer.WriteStringValue("sectionsUrl", SectionsUrl);
        }
    }
}
