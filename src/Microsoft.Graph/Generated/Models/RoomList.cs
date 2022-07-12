using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RoomList : Place, IParsable {
        /// <summary>The email address of the room list.</summary>
        public string EmailAddress {
            get { return BackingStore?.Get<string>("emailAddress"); }
            set { BackingStore?.Set("emailAddress", value); }
        }
        /// <summary>The rooms property</summary>
        public List<Room> Rooms {
            get { return BackingStore?.Get<List<Room>>("rooms"); }
            set { BackingStore?.Set("rooms", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new RoomList CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RoomList();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"emailAddress", n => { EmailAddress = n.GetStringValue(); } },
                {"rooms", n => { Rooms = n.GetCollectionOfObjectValues<Room>(Room.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("emailAddress", EmailAddress);
            writer.WriteCollectionOfObjectValues<Room>("rooms", Rooms);
        }
    }
}
