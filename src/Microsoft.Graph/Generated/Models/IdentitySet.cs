using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IdentitySet : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Optional. The application associated with this action.</summary>
        public Identity Application {
            get { return BackingStore?.Get<Identity>("application"); }
            set { BackingStore?.Set("application", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Optional. The device associated with this action.</summary>
        public Identity Device {
            get { return BackingStore?.Get<Identity>("device"); }
            set { BackingStore?.Set("device", value); }
        }
        /// <summary>The type property</summary>
        public string Type {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>Optional. The user associated with this action.</summary>
        public Identity User {
            get { return BackingStore?.Get<Identity>("user"); }
            set { BackingStore?.Set("user", value); }
        }
        /// <summary>
        /// Instantiates a new identitySet and sets the default values.
        /// </summary>
        public IdentitySet() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            Type = "#microsoft.graph.identitySet";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static IdentitySet CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.chatMessageFromIdentitySet" => new ChatMessageFromIdentitySet(),
                "#microsoft.graph.chatMessageMentionedIdentitySet" => new ChatMessageMentionedIdentitySet(),
                "#microsoft.graph.chatMessageReactionIdentitySet" => new ChatMessageReactionIdentitySet(),
                "#microsoft.graph.sharePointIdentitySet" => new SharePointIdentitySet(),
                _ => new IdentitySet(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"application", n => { Application = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
                {"device", n => { Device = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
                {"@odata.type", n => { Type = n.GetStringValue(); } },
                {"user", n => { User = n.GetObjectValue<Identity>(Identity.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Identity>("application", Application);
            writer.WriteObjectValue<Identity>("device", Device);
            writer.WriteStringValue("@odata.type", Type);
            writer.WriteObjectValue<Identity>("user", User);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
