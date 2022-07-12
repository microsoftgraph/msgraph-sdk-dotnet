using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class EdiscoveryCase : Case, IParsable {
        /// <summary>The user who closed the case.</summary>
        public Microsoft.Graph.Models.IdentitySet ClosedBy {
            get { return BackingStore?.Get<Microsoft.Graph.Models.IdentitySet>("closedBy"); }
            set { BackingStore?.Set("closedBy", value); }
        }
        /// <summary>The date and time when the case was closed. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? ClosedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("closedDateTime"); }
            set { BackingStore?.Set("closedDateTime", value); }
        }
        /// <summary>Returns a list of case ediscoveryCustodian objects for this case.</summary>
        public List<EdiscoveryCustodian> Custodians {
            get { return BackingStore?.Get<List<EdiscoveryCustodian>>("custodians"); }
            set { BackingStore?.Set("custodians", value); }
        }
        /// <summary>The external case number for customer reference.</summary>
        public string ExternalId {
            get { return BackingStore?.Get<string>("externalId"); }
            set { BackingStore?.Set("externalId", value); }
        }
        /// <summary>Returns a list of case ediscoveryNoncustodialDataSource objects for this case.</summary>
        public List<EdiscoveryNoncustodialDataSource> NoncustodialDataSources {
            get { return BackingStore?.Get<List<EdiscoveryNoncustodialDataSource>>("noncustodialDataSources"); }
            set { BackingStore?.Set("noncustodialDataSources", value); }
        }
        /// <summary>Returns a list of case caseOperation objects for this case.</summary>
        public List<CaseOperation> Operations {
            get { return BackingStore?.Get<List<CaseOperation>>("operations"); }
            set { BackingStore?.Set("operations", value); }
        }
        /// <summary>Returns a list of eDiscoveryReviewSet objects in the case.</summary>
        public List<EdiscoveryReviewSet> ReviewSets {
            get { return BackingStore?.Get<List<EdiscoveryReviewSet>>("reviewSets"); }
            set { BackingStore?.Set("reviewSets", value); }
        }
        /// <summary>Returns a list of eDiscoverySearch objects associated with this case.</summary>
        public List<EdiscoverySearch> Searches {
            get { return BackingStore?.Get<List<EdiscoverySearch>>("searches"); }
            set { BackingStore?.Set("searches", value); }
        }
        /// <summary>Returns a list of eDIscoverySettings objects in the case.</summary>
        public EdiscoveryCaseSettings Settings {
            get { return BackingStore?.Get<EdiscoveryCaseSettings>("settings"); }
            set { BackingStore?.Set("settings", value); }
        }
        /// <summary>Returns a list of ediscoveryReviewTag objects associated to this case.</summary>
        public List<EdiscoveryReviewTag> Tags {
            get { return BackingStore?.Get<List<EdiscoveryReviewTag>>("tags"); }
            set { BackingStore?.Set("tags", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EdiscoveryCase CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EdiscoveryCase();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"closedBy", n => { ClosedBy = n.GetObjectValue<Microsoft.Graph.Models.IdentitySet>(Microsoft.Graph.Models.IdentitySet.CreateFromDiscriminatorValue); } },
                {"closedDateTime", n => { ClosedDateTime = n.GetDateTimeOffsetValue(); } },
                {"custodians", n => { Custodians = n.GetCollectionOfObjectValues<EdiscoveryCustodian>(EdiscoveryCustodian.CreateFromDiscriminatorValue).ToList(); } },
                {"externalId", n => { ExternalId = n.GetStringValue(); } },
                {"noncustodialDataSources", n => { NoncustodialDataSources = n.GetCollectionOfObjectValues<EdiscoveryNoncustodialDataSource>(EdiscoveryNoncustodialDataSource.CreateFromDiscriminatorValue).ToList(); } },
                {"operations", n => { Operations = n.GetCollectionOfObjectValues<CaseOperation>(CaseOperation.CreateFromDiscriminatorValue).ToList(); } },
                {"reviewSets", n => { ReviewSets = n.GetCollectionOfObjectValues<EdiscoveryReviewSet>(EdiscoveryReviewSet.CreateFromDiscriminatorValue).ToList(); } },
                {"searches", n => { Searches = n.GetCollectionOfObjectValues<EdiscoverySearch>(EdiscoverySearch.CreateFromDiscriminatorValue).ToList(); } },
                {"settings", n => { Settings = n.GetObjectValue<EdiscoveryCaseSettings>(EdiscoveryCaseSettings.CreateFromDiscriminatorValue); } },
                {"tags", n => { Tags = n.GetCollectionOfObjectValues<EdiscoveryReviewTag>(EdiscoveryReviewTag.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.IdentitySet>("closedBy", ClosedBy);
            writer.WriteDateTimeOffsetValue("closedDateTime", ClosedDateTime);
            writer.WriteCollectionOfObjectValues<EdiscoveryCustodian>("custodians", Custodians);
            writer.WriteStringValue("externalId", ExternalId);
            writer.WriteCollectionOfObjectValues<EdiscoveryNoncustodialDataSource>("noncustodialDataSources", NoncustodialDataSources);
            writer.WriteCollectionOfObjectValues<CaseOperation>("operations", Operations);
            writer.WriteCollectionOfObjectValues<EdiscoveryReviewSet>("reviewSets", ReviewSets);
            writer.WriteCollectionOfObjectValues<EdiscoverySearch>("searches", Searches);
            writer.WriteObjectValue<EdiscoveryCaseSettings>("settings", Settings);
            writer.WriteCollectionOfObjectValues<EdiscoveryReviewTag>("tags", Tags);
        }
    }
}
