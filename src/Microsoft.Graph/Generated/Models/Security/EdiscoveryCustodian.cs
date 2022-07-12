using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.Security {
    public class EdiscoveryCustodian : DataSourceContainer, IParsable {
        /// <summary>Date and time the custodian acknowledged a hold notification.</summary>
        public DateTimeOffset? AcknowledgedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("acknowledgedDateTime"); }
            set { BackingStore?.Set("acknowledgedDateTime", value); }
        }
        /// <summary>Email address of the custodian.</summary>
        public string Email {
            get { return BackingStore?.Get<string>("email"); }
            set { BackingStore?.Set("email", value); }
        }
        /// <summary>Operation entity that represents the latest indexing for the custodian.</summary>
        public EdiscoveryIndexOperation LastIndexOperation {
            get { return BackingStore?.Get<EdiscoveryIndexOperation>("lastIndexOperation"); }
            set { BackingStore?.Set("lastIndexOperation", value); }
        }
        /// <summary>Data source entity for SharePoint sites associated with the custodian.</summary>
        public List<SiteSource> SiteSources {
            get { return BackingStore?.Get<List<SiteSource>>("siteSources"); }
            set { BackingStore?.Set("siteSources", value); }
        }
        /// <summary>Data source entity for groups associated with the custodian.</summary>
        public List<UnifiedGroupSource> UnifiedGroupSources {
            get { return BackingStore?.Get<List<UnifiedGroupSource>>("unifiedGroupSources"); }
            set { BackingStore?.Set("unifiedGroupSources", value); }
        }
        /// <summary>Data source entity for a the custodian. This is the container for a custodian&apos;s mailbox and OneDrive for Business site.</summary>
        public List<UserSource> UserSources {
            get { return BackingStore?.Get<List<UserSource>>("userSources"); }
            set { BackingStore?.Set("userSources", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EdiscoveryCustodian CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EdiscoveryCustodian();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"acknowledgedDateTime", n => { AcknowledgedDateTime = n.GetDateTimeOffsetValue(); } },
                {"email", n => { Email = n.GetStringValue(); } },
                {"lastIndexOperation", n => { LastIndexOperation = n.GetObjectValue<EdiscoveryIndexOperation>(EdiscoveryIndexOperation.CreateFromDiscriminatorValue); } },
                {"siteSources", n => { SiteSources = n.GetCollectionOfObjectValues<SiteSource>(SiteSource.CreateFromDiscriminatorValue).ToList(); } },
                {"unifiedGroupSources", n => { UnifiedGroupSources = n.GetCollectionOfObjectValues<UnifiedGroupSource>(UnifiedGroupSource.CreateFromDiscriminatorValue).ToList(); } },
                {"userSources", n => { UserSources = n.GetCollectionOfObjectValues<UserSource>(UserSource.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("acknowledgedDateTime", AcknowledgedDateTime);
            writer.WriteStringValue("email", Email);
            writer.WriteObjectValue<EdiscoveryIndexOperation>("lastIndexOperation", LastIndexOperation);
            writer.WriteCollectionOfObjectValues<SiteSource>("siteSources", SiteSources);
            writer.WriteCollectionOfObjectValues<UnifiedGroupSource>("unifiedGroupSources", UnifiedGroupSources);
            writer.WriteCollectionOfObjectValues<UserSource>("userSources", UserSources);
        }
    }
}
