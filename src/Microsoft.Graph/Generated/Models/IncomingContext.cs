using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IncomingContext : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The id of the participant that is under observation. Read-only.</summary>
        public string ObservedParticipantId {
            get { return BackingStore?.Get<string>("observedParticipantId"); }
            set { BackingStore?.Set("observedParticipantId", value); }
        }
        /// <summary>The identity that the call is happening on behalf of.</summary>
        public IdentitySet OnBehalfOf {
            get { return BackingStore?.Get<IdentitySet>("onBehalfOf"); }
            set { BackingStore?.Set("onBehalfOf", value); }
        }
        /// <summary>The id of the participant that triggered the incoming call. Read-only.</summary>
        public string SourceParticipantId {
            get { return BackingStore?.Get<string>("sourceParticipantId"); }
            set { BackingStore?.Set("sourceParticipantId", value); }
        }
        /// <summary>The identity that transferred the call.</summary>
        public IdentitySet Transferor {
            get { return BackingStore?.Get<IdentitySet>("transferor"); }
            set { BackingStore?.Set("transferor", value); }
        }
        /// <summary>
        /// Instantiates a new incomingContext and sets the default values.
        /// </summary>
        public IncomingContext() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static IncomingContext CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IncomingContext();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"observedParticipantId", n => { ObservedParticipantId = n.GetStringValue(); } },
                {"onBehalfOf", n => { OnBehalfOf = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"sourceParticipantId", n => { SourceParticipantId = n.GetStringValue(); } },
                {"transferor", n => { Transferor = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("observedParticipantId", ObservedParticipantId);
            writer.WriteObjectValue<IdentitySet>("onBehalfOf", OnBehalfOf);
            writer.WriteStringValue("sourceParticipantId", SourceParticipantId);
            writer.WriteObjectValue<IdentitySet>("transferor", Transferor);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
