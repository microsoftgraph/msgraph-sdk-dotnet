using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class Location : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The street address of the location.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PhysicalAddress? Address {
            get { return BackingStore?.Get<PhysicalAddress?>("address"); }
            set { BackingStore?.Set("address", value); }
        }
#nullable restore
#else
        public PhysicalAddress Address {
            get { return BackingStore?.Get<PhysicalAddress>("address"); }
            set { BackingStore?.Set("address", value); }
        }
#endif
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The geographic coordinates and elevation of the location.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public OutlookGeoCoordinates? Coordinates {
            get { return BackingStore?.Get<OutlookGeoCoordinates?>("coordinates"); }
            set { BackingStore?.Set("coordinates", value); }
        }
#nullable restore
#else
        public OutlookGeoCoordinates Coordinates {
            get { return BackingStore?.Get<OutlookGeoCoordinates>("coordinates"); }
            set { BackingStore?.Set("coordinates", value); }
        }
#endif
        /// <summary>The name associated with the location.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayName {
            get { return BackingStore?.Get<string?>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#nullable restore
#else
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
#endif
        /// <summary>Optional email address of the location.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LocationEmailAddress {
            get { return BackingStore?.Get<string?>("locationEmailAddress"); }
            set { BackingStore?.Set("locationEmailAddress", value); }
        }
#nullable restore
#else
        public string LocationEmailAddress {
            get { return BackingStore?.Get<string>("locationEmailAddress"); }
            set { BackingStore?.Set("locationEmailAddress", value); }
        }
#endif
        /// <summary>The type of location. The possible values are: default, conferenceRoom, homeAddress, businessAddress,geoCoordinates, streetAddress, hotel, restaurant, localBusiness, postalAddress. Read-only.</summary>
        public Microsoft.Graph.Models.LocationType? LocationType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.LocationType?>("locationType"); }
            set { BackingStore?.Set("locationType", value); }
        }
        /// <summary>Optional URI representing the location.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LocationUri {
            get { return BackingStore?.Get<string?>("locationUri"); }
            set { BackingStore?.Set("locationUri", value); }
        }
#nullable restore
#else
        public string LocationUri {
            get { return BackingStore?.Get<string>("locationUri"); }
            set { BackingStore?.Set("locationUri", value); }
        }
#endif
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>For internal use only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UniqueId {
            get { return BackingStore?.Get<string?>("uniqueId"); }
            set { BackingStore?.Set("uniqueId", value); }
        }
#nullable restore
#else
        public string UniqueId {
            get { return BackingStore?.Get<string>("uniqueId"); }
            set { BackingStore?.Set("uniqueId", value); }
        }
#endif
        /// <summary>For internal use only.</summary>
        public LocationUniqueIdType? UniqueIdType {
            get { return BackingStore?.Get<LocationUniqueIdType?>("uniqueIdType"); }
            set { BackingStore?.Set("uniqueIdType", value); }
        }
        /// <summary>
        /// Instantiates a new location and sets the default values.
        /// </summary>
        public Location() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Location CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.locationConstraintItem" => new LocationConstraintItem(),
                _ => new Location(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"address", n => { Address = n.GetObjectValue<PhysicalAddress>(PhysicalAddress.CreateFromDiscriminatorValue); } },
                {"coordinates", n => { Coordinates = n.GetObjectValue<OutlookGeoCoordinates>(OutlookGeoCoordinates.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"locationEmailAddress", n => { LocationEmailAddress = n.GetStringValue(); } },
                {"locationType", n => { LocationType = n.GetEnumValue<LocationType>(); } },
                {"locationUri", n => { LocationUri = n.GetStringValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"uniqueId", n => { UniqueId = n.GetStringValue(); } },
                {"uniqueIdType", n => { UniqueIdType = n.GetEnumValue<LocationUniqueIdType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<PhysicalAddress>("address", Address);
            writer.WriteObjectValue<OutlookGeoCoordinates>("coordinates", Coordinates);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("locationEmailAddress", LocationEmailAddress);
            writer.WriteEnumValue<LocationType>("locationType", LocationType);
            writer.WriteStringValue("locationUri", LocationUri);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteStringValue("uniqueId", UniqueId);
            writer.WriteEnumValue<LocationUniqueIdType>("uniqueIdType", UniqueIdType);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
