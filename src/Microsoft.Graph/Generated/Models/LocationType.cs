using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models {
    public enum LocationType {
        [EnumMember(Value = "default")]
        @Default,
        [EnumMember(Value = "businessAddress")]
        BusinessAddress,
        [EnumMember(Value = "conferenceRoom")]
        ConferenceRoom,
        [EnumMember(Value = "geoCoordinates")]
        GeoCoordinates,
        [EnumMember(Value = "homeAddress")]
        HomeAddress,
        [EnumMember(Value = "hotel")]
        Hotel,
        [EnumMember(Value = "localBusiness")]
        LocalBusiness,
        [EnumMember(Value = "postalAddress")]
        PostalAddress,
        [EnumMember(Value = "restaurant")]
        Restaurant,
        [EnumMember(Value = "streetAddress")]
        StreetAddress,
    }
}
