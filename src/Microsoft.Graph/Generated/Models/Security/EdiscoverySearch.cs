using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class EdiscoverySearch : Search, IParsable {
        /// <summary>Adds an additional source to the eDiscovery search.</summary>
        public List<DataSource> AdditionalSources {
            get { return BackingStore?.Get<List<DataSource>>("additionalSources"); }
            set { BackingStore?.Set("additionalSources", value); }
        }
        /// <summary>Adds the results of the eDiscovery search to the specified reviewSet.</summary>
        public EdiscoveryAddToReviewSetOperation AddToReviewSetOperation {
            get { return BackingStore?.Get<EdiscoveryAddToReviewSetOperation>("addToReviewSetOperation"); }
            set { BackingStore?.Set("addToReviewSetOperation", value); }
        }
        /// <summary>Custodian sources that are included in the eDiscovery search.</summary>
        public List<DataSource> CustodianSources {
            get { return BackingStore?.Get<List<DataSource>>("custodianSources"); }
            set { BackingStore?.Set("custodianSources", value); }
        }
        /// <summary>When specified, the collection will span across a service for an entire workload. Possible values are: none, allTenantMailboxes, allTenantSites, allCaseCustodians, allCaseNoncustodialDataSources.</summary>
        public Microsoft.Graph.Models.Security.DataSourceScopes? DataSourceScopes {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Security.DataSourceScopes?>("dataSourceScopes"); }
            set { BackingStore?.Set("dataSourceScopes", value); }
        }
        /// <summary>The last estimate operation associated with the eDiscovery search.</summary>
        public EdiscoveryEstimateOperation LastEstimateStatisticsOperation {
            get { return BackingStore?.Get<EdiscoveryEstimateOperation>("lastEstimateStatisticsOperation"); }
            set { BackingStore?.Set("lastEstimateStatisticsOperation", value); }
        }
        /// <summary>noncustodialDataSource sources that are included in the eDiscovery search</summary>
        public List<EdiscoveryNoncustodialDataSource> NoncustodialSources {
            get { return BackingStore?.Get<List<EdiscoveryNoncustodialDataSource>>("noncustodialSources"); }
            set { BackingStore?.Set("noncustodialSources", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EdiscoverySearch CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EdiscoverySearch();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"additionalSources", n => { AdditionalSources = n.GetCollectionOfObjectValues<DataSource>(DataSource.CreateFromDiscriminatorValue).ToList(); } },
                {"addToReviewSetOperation", n => { AddToReviewSetOperation = n.GetObjectValue<EdiscoveryAddToReviewSetOperation>(EdiscoveryAddToReviewSetOperation.CreateFromDiscriminatorValue); } },
                {"custodianSources", n => { CustodianSources = n.GetCollectionOfObjectValues<DataSource>(DataSource.CreateFromDiscriminatorValue).ToList(); } },
                {"dataSourceScopes", n => { DataSourceScopes = n.GetEnumValue<DataSourceScopes>(); } },
                {"lastEstimateStatisticsOperation", n => { LastEstimateStatisticsOperation = n.GetObjectValue<EdiscoveryEstimateOperation>(EdiscoveryEstimateOperation.CreateFromDiscriminatorValue); } },
                {"noncustodialSources", n => { NoncustodialSources = n.GetCollectionOfObjectValues<EdiscoveryNoncustodialDataSource>(EdiscoveryNoncustodialDataSource.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<DataSource>("additionalSources", AdditionalSources);
            writer.WriteObjectValue<EdiscoveryAddToReviewSetOperation>("addToReviewSetOperation", AddToReviewSetOperation);
            writer.WriteCollectionOfObjectValues<DataSource>("custodianSources", CustodianSources);
            writer.WriteEnumValue<DataSourceScopes>("dataSourceScopes", DataSourceScopes);
            writer.WriteObjectValue<EdiscoveryEstimateOperation>("lastEstimateStatisticsOperation", LastEstimateStatisticsOperation);
            writer.WriteCollectionOfObjectValues<EdiscoveryNoncustodialDataSource>("noncustodialSources", NoncustodialSources);
        }
    }
}
