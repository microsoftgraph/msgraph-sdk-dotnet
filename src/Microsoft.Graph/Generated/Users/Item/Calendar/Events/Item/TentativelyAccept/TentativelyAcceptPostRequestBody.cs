using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Users.Item.Calendar.Events.Item.TentativelyAccept {
    /// <summary>Provides operations to call the tentativelyAccept method.</summary>
    public class TentativelyAcceptPostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The Comment property</summary>
        public string Comment {
            get { return BackingStore?.Get<string>("comment"); }
            set { BackingStore?.Set("comment", value); }
        }
        /// <summary>The ProposedNewTime property</summary>
        public TimeSlot ProposedNewTime {
            get { return BackingStore?.Get<TimeSlot>("proposedNewTime"); }
            set { BackingStore?.Set("proposedNewTime", value); }
        }
        /// <summary>The SendResponse property</summary>
        public bool? SendResponse {
            get { return BackingStore?.Get<bool?>("sendResponse"); }
            set { BackingStore?.Set("sendResponse", value); }
        }
        /// <summary>
        /// Instantiates a new tentativelyAcceptPostRequestBody and sets the default values.
        /// </summary>
        public TentativelyAcceptPostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TentativelyAcceptPostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TentativelyAcceptPostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"comment", n => { Comment = n.GetStringValue(); } },
                {"proposedNewTime", n => { ProposedNewTime = n.GetObjectValue<TimeSlot>(TimeSlot.CreateFromDiscriminatorValue); } },
                {"sendResponse", n => { SendResponse = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("comment", Comment);
            writer.WriteObjectValue<TimeSlot>("proposedNewTime", ProposedNewTime);
            writer.WriteBoolValue("sendResponse", SendResponse);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
