using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class ColumnDefinition : Entity, IParsable {
        /// <summary>This column stores boolean values.</summary>
        public BooleanColumn Boolean {
            get { return BackingStore?.Get<BooleanColumn>("boolean"); }
            set { BackingStore?.Set("boolean", value); }
        }
        /// <summary>This column&apos;s data is calculated based on other columns.</summary>
        public CalculatedColumn Calculated {
            get { return BackingStore?.Get<CalculatedColumn>("calculated"); }
            set { BackingStore?.Set("calculated", value); }
        }
        /// <summary>This column stores data from a list of choices.</summary>
        public ChoiceColumn Choice {
            get { return BackingStore?.Get<ChoiceColumn>("choice"); }
            set { BackingStore?.Set("choice", value); }
        }
        /// <summary>For site columns, the name of the group this column belongs to. Helps organize related columns.</summary>
        public string ColumnGroup {
            get { return BackingStore?.Get<string>("columnGroup"); }
            set { BackingStore?.Set("columnGroup", value); }
        }
        /// <summary>This column stores content approval status.</summary>
        public ContentApprovalStatusColumn ContentApprovalStatus {
            get { return BackingStore?.Get<ContentApprovalStatusColumn>("contentApprovalStatus"); }
            set { BackingStore?.Set("contentApprovalStatus", value); }
        }
        /// <summary>This column stores currency values.</summary>
        public CurrencyColumn Currency {
            get { return BackingStore?.Get<CurrencyColumn>("currency"); }
            set { BackingStore?.Set("currency", value); }
        }
        /// <summary>This column stores DateTime values.</summary>
        public DateTimeColumn DateTime {
            get { return BackingStore?.Get<DateTimeColumn>("dateTime"); }
            set { BackingStore?.Set("dateTime", value); }
        }
        /// <summary>The default value for this column.</summary>
        public DefaultColumnValue DefaultValue {
            get { return BackingStore?.Get<DefaultColumnValue>("defaultValue"); }
            set { BackingStore?.Set("defaultValue", value); }
        }
        /// <summary>The user-facing description of the column.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The user-facing name of the column.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>If true, no two list items may have the same value for this column.</summary>
        public bool? EnforceUniqueValues {
            get { return BackingStore?.Get<bool?>("enforceUniqueValues"); }
            set { BackingStore?.Set("enforceUniqueValues", value); }
        }
        /// <summary>This column stores a geolocation.</summary>
        public GeolocationColumn Geolocation {
            get { return BackingStore?.Get<GeolocationColumn>("geolocation"); }
            set { BackingStore?.Set("geolocation", value); }
        }
        /// <summary>Specifies whether the column is displayed in the user interface.</summary>
        public bool? Hidden {
            get { return BackingStore?.Get<bool?>("hidden"); }
            set { BackingStore?.Set("hidden", value); }
        }
        /// <summary>This column stores hyperlink or picture values.</summary>
        public HyperlinkOrPictureColumn HyperlinkOrPicture {
            get { return BackingStore?.Get<HyperlinkOrPictureColumn>("hyperlinkOrPicture"); }
            set { BackingStore?.Set("hyperlinkOrPicture", value); }
        }
        /// <summary>Specifies whether the column values can be used for sorting and searching.</summary>
        public bool? Indexed {
            get { return BackingStore?.Get<bool?>("indexed"); }
            set { BackingStore?.Set("indexed", value); }
        }
        /// <summary>Indicates whether this column can be deleted.</summary>
        public bool? IsDeletable {
            get { return BackingStore?.Get<bool?>("isDeletable"); }
            set { BackingStore?.Set("isDeletable", value); }
        }
        /// <summary>Indicates whether values in the column can be reordered. Read-only.</summary>
        public bool? IsReorderable {
            get { return BackingStore?.Get<bool?>("isReorderable"); }
            set { BackingStore?.Set("isReorderable", value); }
        }
        /// <summary>Specifies whether the column can be changed.</summary>
        public bool? IsSealed {
            get { return BackingStore?.Get<bool?>("isSealed"); }
            set { BackingStore?.Set("isSealed", value); }
        }
        /// <summary>This column&apos;s data is looked up from another source in the site.</summary>
        public LookupColumn Lookup {
            get { return BackingStore?.Get<LookupColumn>("lookup"); }
            set { BackingStore?.Set("lookup", value); }
        }
        /// <summary>The API-facing name of the column as it appears in the [fields][] on a [listItem][]. For the user-facing name, see displayName.</summary>
        public string Name {
            get { return BackingStore?.Get<string>("name"); }
            set { BackingStore?.Set("name", value); }
        }
        /// <summary>This column stores number values.</summary>
        public NumberColumn Number {
            get { return BackingStore?.Get<NumberColumn>("number"); }
            set { BackingStore?.Set("number", value); }
        }
        /// <summary>This column stores Person or Group values.</summary>
        public PersonOrGroupColumn PersonOrGroup {
            get { return BackingStore?.Get<PersonOrGroupColumn>("personOrGroup"); }
            set { BackingStore?.Set("personOrGroup", value); }
        }
        /// <summary>If &apos;true&apos;, changes to this column will be propagated to lists that implement the column.</summary>
        public bool? PropagateChanges {
            get { return BackingStore?.Get<bool?>("propagateChanges"); }
            set { BackingStore?.Set("propagateChanges", value); }
        }
        /// <summary>Specifies whether the column values can be modified.</summary>
        public bool? ReadOnly {
            get { return BackingStore?.Get<bool?>("readOnly"); }
            set { BackingStore?.Set("readOnly", value); }
        }
        /// <summary>Specifies whether the column value isn&apos;t optional.</summary>
        public bool? Required {
            get { return BackingStore?.Get<bool?>("required"); }
            set { BackingStore?.Set("required", value); }
        }
        /// <summary>The source column for the content type column.</summary>
        public ColumnDefinition SourceColumn {
            get { return BackingStore?.Get<ColumnDefinition>("sourceColumn"); }
            set { BackingStore?.Set("sourceColumn", value); }
        }
        /// <summary>ContentType from which this column is inherited from. Present only in contentTypes columns response. Read-only.</summary>
        public ContentTypeInfo SourceContentType {
            get { return BackingStore?.Get<ContentTypeInfo>("sourceContentType"); }
            set { BackingStore?.Set("sourceContentType", value); }
        }
        /// <summary>This column stores taxonomy terms.</summary>
        public TermColumn Term {
            get { return BackingStore?.Get<TermColumn>("term"); }
            set { BackingStore?.Set("term", value); }
        }
        /// <summary>This column stores text values.</summary>
        public TextColumn Text {
            get { return BackingStore?.Get<TextColumn>("text"); }
            set { BackingStore?.Set("text", value); }
        }
        /// <summary>This column stores thumbnail values.</summary>
        public ThumbnailColumn Thumbnail {
            get { return BackingStore?.Get<ThumbnailColumn>("thumbnail"); }
            set { BackingStore?.Set("thumbnail", value); }
        }
        /// <summary>For site columns, the type of column. Read-only.</summary>
        public ColumnTypes? Type {
            get { return BackingStore?.Get<ColumnTypes?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>This column stores validation formula and message for the column.</summary>
        public ColumnValidation Validation {
            get { return BackingStore?.Get<ColumnValidation>("validation"); }
            set { BackingStore?.Set("validation", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new ColumnDefinition CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ColumnDefinition();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"boolean", n => { Boolean = n.GetObjectValue<BooleanColumn>(BooleanColumn.CreateFromDiscriminatorValue); } },
                {"calculated", n => { Calculated = n.GetObjectValue<CalculatedColumn>(CalculatedColumn.CreateFromDiscriminatorValue); } },
                {"choice", n => { Choice = n.GetObjectValue<ChoiceColumn>(ChoiceColumn.CreateFromDiscriminatorValue); } },
                {"columnGroup", n => { ColumnGroup = n.GetStringValue(); } },
                {"contentApprovalStatus", n => { ContentApprovalStatus = n.GetObjectValue<ContentApprovalStatusColumn>(ContentApprovalStatusColumn.CreateFromDiscriminatorValue); } },
                {"currency", n => { Currency = n.GetObjectValue<CurrencyColumn>(CurrencyColumn.CreateFromDiscriminatorValue); } },
                {"dateTime", n => { DateTime = n.GetObjectValue<DateTimeColumn>(DateTimeColumn.CreateFromDiscriminatorValue); } },
                {"defaultValue", n => { DefaultValue = n.GetObjectValue<DefaultColumnValue>(DefaultColumnValue.CreateFromDiscriminatorValue); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"enforceUniqueValues", n => { EnforceUniqueValues = n.GetBoolValue(); } },
                {"geolocation", n => { Geolocation = n.GetObjectValue<GeolocationColumn>(GeolocationColumn.CreateFromDiscriminatorValue); } },
                {"hidden", n => { Hidden = n.GetBoolValue(); } },
                {"hyperlinkOrPicture", n => { HyperlinkOrPicture = n.GetObjectValue<HyperlinkOrPictureColumn>(HyperlinkOrPictureColumn.CreateFromDiscriminatorValue); } },
                {"indexed", n => { Indexed = n.GetBoolValue(); } },
                {"isDeletable", n => { IsDeletable = n.GetBoolValue(); } },
                {"isReorderable", n => { IsReorderable = n.GetBoolValue(); } },
                {"isSealed", n => { IsSealed = n.GetBoolValue(); } },
                {"lookup", n => { Lookup = n.GetObjectValue<LookupColumn>(LookupColumn.CreateFromDiscriminatorValue); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"number", n => { Number = n.GetObjectValue<NumberColumn>(NumberColumn.CreateFromDiscriminatorValue); } },
                {"personOrGroup", n => { PersonOrGroup = n.GetObjectValue<PersonOrGroupColumn>(PersonOrGroupColumn.CreateFromDiscriminatorValue); } },
                {"propagateChanges", n => { PropagateChanges = n.GetBoolValue(); } },
                {"readOnly", n => { ReadOnly = n.GetBoolValue(); } },
                {"required", n => { Required = n.GetBoolValue(); } },
                {"sourceColumn", n => { SourceColumn = n.GetObjectValue<ColumnDefinition>(ColumnDefinition.CreateFromDiscriminatorValue); } },
                {"sourceContentType", n => { SourceContentType = n.GetObjectValue<ContentTypeInfo>(ContentTypeInfo.CreateFromDiscriminatorValue); } },
                {"term", n => { Term = n.GetObjectValue<TermColumn>(TermColumn.CreateFromDiscriminatorValue); } },
                {"text", n => { Text = n.GetObjectValue<TextColumn>(TextColumn.CreateFromDiscriminatorValue); } },
                {"thumbnail", n => { Thumbnail = n.GetObjectValue<ThumbnailColumn>(ThumbnailColumn.CreateFromDiscriminatorValue); } },
                {"type", n => { Type = n.GetEnumValue<ColumnTypes>(); } },
                {"validation", n => { Validation = n.GetObjectValue<ColumnValidation>(ColumnValidation.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<BooleanColumn>("boolean", Boolean);
            writer.WriteObjectValue<CalculatedColumn>("calculated", Calculated);
            writer.WriteObjectValue<ChoiceColumn>("choice", Choice);
            writer.WriteStringValue("columnGroup", ColumnGroup);
            writer.WriteObjectValue<ContentApprovalStatusColumn>("contentApprovalStatus", ContentApprovalStatus);
            writer.WriteObjectValue<CurrencyColumn>("currency", Currency);
            writer.WriteObjectValue<DateTimeColumn>("dateTime", DateTime);
            writer.WriteObjectValue<DefaultColumnValue>("defaultValue", DefaultValue);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteBoolValue("enforceUniqueValues", EnforceUniqueValues);
            writer.WriteObjectValue<GeolocationColumn>("geolocation", Geolocation);
            writer.WriteBoolValue("hidden", Hidden);
            writer.WriteObjectValue<HyperlinkOrPictureColumn>("hyperlinkOrPicture", HyperlinkOrPicture);
            writer.WriteBoolValue("indexed", Indexed);
            writer.WriteBoolValue("isDeletable", IsDeletable);
            writer.WriteBoolValue("isReorderable", IsReorderable);
            writer.WriteBoolValue("isSealed", IsSealed);
            writer.WriteObjectValue<LookupColumn>("lookup", Lookup);
            writer.WriteStringValue("name", Name);
            writer.WriteObjectValue<NumberColumn>("number", Number);
            writer.WriteObjectValue<PersonOrGroupColumn>("personOrGroup", PersonOrGroup);
            writer.WriteBoolValue("propagateChanges", PropagateChanges);
            writer.WriteBoolValue("readOnly", ReadOnly);
            writer.WriteBoolValue("required", Required);
            writer.WriteObjectValue<ColumnDefinition>("sourceColumn", SourceColumn);
            writer.WriteObjectValue<ContentTypeInfo>("sourceContentType", SourceContentType);
            writer.WriteObjectValue<TermColumn>("term", Term);
            writer.WriteObjectValue<TextColumn>("text", Text);
            writer.WriteObjectValue<ThumbnailColumn>("thumbnail", Thumbnail);
            writer.WriteEnumValue<ColumnTypes>("type", Type);
            writer.WriteObjectValue<ColumnValidation>("validation", Validation);
        }
    }
}
