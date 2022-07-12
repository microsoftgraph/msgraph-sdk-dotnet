using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Place : Entity, IParsable {
        /// <summary>The street address of the place.</summary>
        public PhysicalAddress Address {
            get { return BackingStore?.Get<PhysicalAddress>("address"); }
            set { BackingStore?.Set("address", value); }
        }
        /// <summary>The name associated with the place.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Specifies the place location in latitude, longitude and (optionally) altitude coordinates.</summary>
        public OutlookGeoCoordinates GeoCoordinates {
            get { return BackingStore?.Get<OutlookGeoCoordinates>("geoCoordinates"); }
            set { BackingStore?.Set("geoCoordinates", value); }
        }
        /// <summary>The phone number of the place.</summary>
        public string Phone {
            get { return BackingStore?.Get<string>("phone"); }
            set { BackingStore?.Set("phone", value); }
        }
        /// <summary>
        /// Instantiates a new Place and sets the default values.
        /// </summary>
        public Place() : base() {
            Type = "#microsoft.graph.place";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Place CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.room" => new Room(),
                "#microsoft.graph.roomList" => new RoomList(),
                _ => new Place(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"address", n => { Address = n.GetObjectValue<PhysicalAddress>(PhysicalAddress.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"geoCoordinates", n => { GeoCoordinates = n.GetObjectValue<OutlookGeoCoordinates>(OutlookGeoCoordinates.CreateFromDiscriminatorValue); } },
                {"phone", n => { Phone = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PhysicalAddress>("address", Address);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<OutlookGeoCoordinates>("geoCoordinates", GeoCoordinates);
            writer.WriteStringValue("phone", Phone);
        }
    }
}
