using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UriClickSecurityState : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The clickAction property</summary>
        public string ClickAction {
            get { return BackingStore?.Get<string>("clickAction"); }
            set { BackingStore?.Set("clickAction", value); }
        }
        /// <summary>The clickDateTime property</summary>
        public DateTimeOffset? ClickDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("clickDateTime"); }
            set { BackingStore?.Set("clickDateTime", value); }
        }
        /// <summary>The id property</summary>
        public string Id {
            get { return BackingStore?.Get<string>("id"); }
            set { BackingStore?.Set("id", value); }
        }
        /// <summary>The sourceId property</summary>
        public string SourceId {
            get { return BackingStore?.Get<string>("sourceId"); }
            set { BackingStore?.Set("sourceId", value); }
        }
        /// <summary>The uriDomain property</summary>
        public string UriDomain {
            get { return BackingStore?.Get<string>("uriDomain"); }
            set { BackingStore?.Set("uriDomain", value); }
        }
        /// <summary>The verdict property</summary>
        public string Verdict {
            get { return BackingStore?.Get<string>("verdict"); }
            set { BackingStore?.Set("verdict", value); }
        }
        /// <summary>
        /// Instantiates a new uriClickSecurityState and sets the default values.
        /// </summary>
        public UriClickSecurityState() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static UriClickSecurityState CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UriClickSecurityState();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"clickAction", n => { ClickAction = n.GetStringValue(); } },
                {"clickDateTime", n => { ClickDateTime = n.GetDateTimeOffsetValue(); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"sourceId", n => { SourceId = n.GetStringValue(); } },
                {"uriDomain", n => { UriDomain = n.GetStringValue(); } },
                {"verdict", n => { Verdict = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("clickAction", ClickAction);
            writer.WriteDateTimeOffsetValue("clickDateTime", ClickDateTime);
            writer.WriteStringValue("id", Id);
            writer.WriteStringValue("sourceId", SourceId);
            writer.WriteStringValue("uriDomain", UriDomain);
            writer.WriteStringValue("verdict", Verdict);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
