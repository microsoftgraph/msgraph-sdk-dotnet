using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class SearchRequest : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The aggregationFilters property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? AggregationFilters {
            get { return BackingStore?.Get<List<string>?>("aggregationFilters"); }
            set { BackingStore?.Set("aggregationFilters", value); }
        }
#nullable restore
#else
        public List<string> AggregationFilters {
            get { return BackingStore?.Get<List<string>>("aggregationFilters"); }
            set { BackingStore?.Set("aggregationFilters", value); }
        }
#endif
        /// <summary>The aggregations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<AggregationOption>? Aggregations {
            get { return BackingStore?.Get<List<AggregationOption>?>("aggregations"); }
            set { BackingStore?.Set("aggregations", value); }
        }
#nullable restore
#else
        public List<AggregationOption> Aggregations {
            get { return BackingStore?.Get<List<AggregationOption>>("aggregations"); }
            set { BackingStore?.Set("aggregations", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The collapseProperties property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CollapseProperty>? CollapseProperties {
            get { return BackingStore?.Get<List<CollapseProperty>?>("collapseProperties"); }
            set { BackingStore?.Set("collapseProperties", value); }
        }
#nullable restore
#else
        public List<CollapseProperty> CollapseProperties {
            get { return BackingStore?.Get<List<CollapseProperty>>("collapseProperties"); }
            set { BackingStore?.Set("collapseProperties", value); }
        }
#endif
        /// <summary>The contentSources property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? ContentSources {
            get { return BackingStore?.Get<List<string>?>("contentSources"); }
            set { BackingStore?.Set("contentSources", value); }
        }
#nullable restore
#else
        public List<string> ContentSources {
            get { return BackingStore?.Get<List<string>>("contentSources"); }
            set { BackingStore?.Set("contentSources", value); }
        }
#endif
        /// <summary>The enableTopResults property</summary>
        public bool? EnableTopResults {
            get { return BackingStore?.Get<bool?>("enableTopResults"); }
            set { BackingStore?.Set("enableTopResults", value); }
        }
        /// <summary>The entityTypes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<EntityType?>? EntityTypes {
            get { return BackingStore?.Get<List<EntityType?>?>("entityTypes"); }
            set { BackingStore?.Set("entityTypes", value); }
        }
#nullable restore
#else
        public List<EntityType?> EntityTypes {
            get { return BackingStore?.Get<List<EntityType?>>("entityTypes"); }
            set { BackingStore?.Set("entityTypes", value); }
        }
#endif
        /// <summary>The fields property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? Fields {
            get { return BackingStore?.Get<List<string>?>("fields"); }
            set { BackingStore?.Set("fields", value); }
        }
#nullable restore
#else
        public List<string> Fields {
            get { return BackingStore?.Get<List<string>>("fields"); }
            set { BackingStore?.Set("fields", value); }
        }
#endif
        /// <summary>The from property</summary>
        public int? From {
            get { return BackingStore?.Get<int?>("from"); }
            set { BackingStore?.Set("from", value); }
        }
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>The query property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SearchQuery? Query {
            get { return BackingStore?.Get<SearchQuery?>("query"); }
            set { BackingStore?.Set("query", value); }
        }
#nullable restore
#else
        public SearchQuery Query {
            get { return BackingStore?.Get<SearchQuery>("query"); }
            set { BackingStore?.Set("query", value); }
        }
#endif
        /// <summary>The queryAlterationOptions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public SearchAlterationOptions? QueryAlterationOptions {
            get { return BackingStore?.Get<SearchAlterationOptions?>("queryAlterationOptions"); }
            set { BackingStore?.Set("queryAlterationOptions", value); }
        }
#nullable restore
#else
        public SearchAlterationOptions QueryAlterationOptions {
            get { return BackingStore?.Get<SearchAlterationOptions>("queryAlterationOptions"); }
            set { BackingStore?.Set("queryAlterationOptions", value); }
        }
#endif
        /// <summary>The region property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Region {
            get { return BackingStore?.Get<string?>("region"); }
            set { BackingStore?.Set("region", value); }
        }
#nullable restore
#else
        public string Region {
            get { return BackingStore?.Get<string>("region"); }
            set { BackingStore?.Set("region", value); }
        }
#endif
        /// <summary>The resultTemplateOptions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ResultTemplateOption? ResultTemplateOptions {
            get { return BackingStore?.Get<ResultTemplateOption?>("resultTemplateOptions"); }
            set { BackingStore?.Set("resultTemplateOptions", value); }
        }
#nullable restore
#else
        public ResultTemplateOption ResultTemplateOptions {
            get { return BackingStore?.Get<ResultTemplateOption>("resultTemplateOptions"); }
            set { BackingStore?.Set("resultTemplateOptions", value); }
        }
#endif
        /// <summary>The sharePointOneDriveOptions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.SharePointOneDriveOptions? SharePointOneDriveOptions {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SharePointOneDriveOptions?>("sharePointOneDriveOptions"); }
            set { BackingStore?.Set("sharePointOneDriveOptions", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.SharePointOneDriveOptions SharePointOneDriveOptions {
            get { return BackingStore?.Get<Microsoft.Graph.Models.SharePointOneDriveOptions>("sharePointOneDriveOptions"); }
            set { BackingStore?.Set("sharePointOneDriveOptions", value); }
        }
#endif
        /// <summary>The size property</summary>
        public int? Size {
            get { return BackingStore?.Get<int?>("size"); }
            set { BackingStore?.Set("size", value); }
        }
        /// <summary>The sortProperties property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SortProperty>? SortProperties {
            get { return BackingStore?.Get<List<SortProperty>?>("sortProperties"); }
            set { BackingStore?.Set("sortProperties", value); }
        }
#nullable restore
#else
        public List<SortProperty> SortProperties {
            get { return BackingStore?.Get<List<SortProperty>>("sortProperties"); }
            set { BackingStore?.Set("sortProperties", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new SearchRequest and sets the default values.
        /// </summary>
        public SearchRequest() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static SearchRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SearchRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"aggregationFilters", n => { AggregationFilters = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"aggregations", n => { Aggregations = n.GetCollectionOfObjectValues<AggregationOption>(AggregationOption.CreateFromDiscriminatorValue)?.ToList(); } },
                {"collapseProperties", n => { CollapseProperties = n.GetCollectionOfObjectValues<CollapseProperty>(CollapseProperty.CreateFromDiscriminatorValue)?.ToList(); } },
                {"contentSources", n => { ContentSources = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"enableTopResults", n => { EnableTopResults = n.GetBoolValue(); } },
                {"entityTypes", n => { EntityTypes = n.GetCollectionOfEnumValues<EntityType>()?.ToList(); } },
                {"fields", n => { Fields = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"from", n => { From = n.GetIntValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"query", n => { Query = n.GetObjectValue<SearchQuery>(SearchQuery.CreateFromDiscriminatorValue); } },
                {"queryAlterationOptions", n => { QueryAlterationOptions = n.GetObjectValue<SearchAlterationOptions>(SearchAlterationOptions.CreateFromDiscriminatorValue); } },
                {"region", n => { Region = n.GetStringValue(); } },
                {"resultTemplateOptions", n => { ResultTemplateOptions = n.GetObjectValue<ResultTemplateOption>(ResultTemplateOption.CreateFromDiscriminatorValue); } },
                {"sharePointOneDriveOptions", n => { SharePointOneDriveOptions = n.GetObjectValue<Microsoft.Graph.Models.SharePointOneDriveOptions>(Microsoft.Graph.Models.SharePointOneDriveOptions.CreateFromDiscriminatorValue); } },
                {"size", n => { Size = n.GetIntValue(); } },
                {"sortProperties", n => { SortProperties = n.GetCollectionOfObjectValues<SortProperty>(SortProperty.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("aggregationFilters", AggregationFilters);
            writer.WriteCollectionOfObjectValues<AggregationOption>("aggregations", Aggregations);
            writer.WriteCollectionOfObjectValues<CollapseProperty>("collapseProperties", CollapseProperties);
            writer.WriteCollectionOfPrimitiveValues<string>("contentSources", ContentSources);
            writer.WriteBoolValue("enableTopResults", EnableTopResults);
            writer.WriteCollectionOfEnumValues<EntityType>("entityTypes", EntityTypes);
            writer.WriteCollectionOfPrimitiveValues<string>("fields", Fields);
            writer.WriteIntValue("from", From);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteObjectValue<SearchQuery>("query", Query);
            writer.WriteObjectValue<SearchAlterationOptions>("queryAlterationOptions", QueryAlterationOptions);
            writer.WriteStringValue("region", Region);
            writer.WriteObjectValue<ResultTemplateOption>("resultTemplateOptions", ResultTemplateOptions);
            writer.WriteObjectValue<Microsoft.Graph.Models.SharePointOneDriveOptions>("sharePointOneDriveOptions", SharePointOneDriveOptions);
            writer.WriteIntValue("size", Size);
            writer.WriteCollectionOfObjectValues<SortProperty>("sortProperties", SortProperties);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
