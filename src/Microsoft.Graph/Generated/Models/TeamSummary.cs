using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TeamSummary : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Count of guests in a team.</summary>
        public int? GuestsCount {
            get { return BackingStore?.Get<int?>("guestsCount"); }
            set { BackingStore?.Set("guestsCount", value); }
        }
        /// <summary>Count of members in a team.</summary>
        public int? MembersCount {
            get { return BackingStore?.Get<int?>("membersCount"); }
            set { BackingStore?.Set("membersCount", value); }
        }
        /// <summary>Count of owners in a team.</summary>
        public int? OwnersCount {
            get { return BackingStore?.Get<int?>("ownersCount"); }
            set { BackingStore?.Set("ownersCount", value); }
        }
        /// <summary>
        /// Instantiates a new teamSummary and sets the default values.
        /// </summary>
        public TeamSummary() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TeamSummary CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TeamSummary();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"guestsCount", n => { GuestsCount = n.GetIntValue(); } },
                {"membersCount", n => { MembersCount = n.GetIntValue(); } },
                {"ownersCount", n => { OwnersCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("guestsCount", GuestsCount);
            writer.WriteIntValue("membersCount", MembersCount);
            writer.WriteIntValue("ownersCount", OwnersCount);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
