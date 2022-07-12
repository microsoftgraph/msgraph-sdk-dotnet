using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Me.JoinedTeams.Item.Clone {
    /// <summary>Provides operations to call the clone method.</summary>
    public class ClonePostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The classification property</summary>
        public string Classification {
            get { return BackingStore?.Get<string>("classification"); }
            set { BackingStore?.Set("classification", value); }
        }
        /// <summary>The description property</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The displayName property</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The mailNickname property</summary>
        public string MailNickname {
            get { return BackingStore?.Get<string>("mailNickname"); }
            set { BackingStore?.Set("mailNickname", value); }
        }
        /// <summary>The partsToClone property</summary>
        public ClonableTeamParts? PartsToClone {
            get { return BackingStore?.Get<ClonableTeamParts?>("partsToClone"); }
            set { BackingStore?.Set("partsToClone", value); }
        }
        /// <summary>The visibility property</summary>
        public TeamVisibilityType? Visibility {
            get { return BackingStore?.Get<TeamVisibilityType?>("visibility"); }
            set { BackingStore?.Set("visibility", value); }
        }
        /// <summary>
        /// Instantiates a new clonePostRequestBody and sets the default values.
        /// </summary>
        public ClonePostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ClonePostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ClonePostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"classification", n => { Classification = n.GetStringValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"mailNickname", n => { MailNickname = n.GetStringValue(); } },
                {"partsToClone", n => { PartsToClone = n.GetEnumValue<ClonableTeamParts>(); } },
                {"visibility", n => { Visibility = n.GetEnumValue<TeamVisibilityType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("classification", Classification);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("mailNickname", MailNickname);
            writer.WriteEnumValue<ClonableTeamParts>("partsToClone", PartsToClone);
            writer.WriteEnumValue<TeamVisibilityType>("visibility", Visibility);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
