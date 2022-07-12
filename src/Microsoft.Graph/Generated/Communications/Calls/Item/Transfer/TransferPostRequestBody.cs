using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Communications.Calls.Item.Transfer {
    /// <summary>Provides operations to call the transfer method.</summary>
    public class TransferPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The transferee property</summary>
        public ParticipantInfo Transferee {
            get { return BackingStore?.Get<ParticipantInfo>("transferee"); }
            set { BackingStore?.Set("transferee", value); }
        }
        /// <summary>The transferTarget property</summary>
        public InvitationParticipantInfo TransferTarget {
            get { return BackingStore?.Get<InvitationParticipantInfo>("transferTarget"); }
            set { BackingStore?.Set("transferTarget", value); }
        }
        /// <summary>
        /// Instantiates a new transferPostRequestBody and sets the default values.
        /// </summary>
        public TransferPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TransferPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TransferPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"transferee", n => { Transferee = n.GetObjectValue<ParticipantInfo>(ParticipantInfo.CreateFromDiscriminatorValue); } },
                {"transferTarget", n => { TransferTarget = n.GetObjectValue<InvitationParticipantInfo>(InvitationParticipantInfo.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ParticipantInfo>("transferee", Transferee);
            writer.WriteObjectValue<InvitationParticipantInfo>("transferTarget", TransferTarget);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
