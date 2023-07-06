using System.Runtime.Serialization;
using System;
namespace Microsoft.Graph.Models.CallRecords {
    public enum ServiceRole {
        [EnumMember(Value = "audioTeleconferencerController")]
        AudioTeleconferencerController,
        [EnumMember(Value = "conferencingAnnouncementService")]
        ConferencingAnnouncementService,
        [EnumMember(Value = "conferencingAttendant")]
        ConferencingAttendant,
        [EnumMember(Value = "customBot")]
        CustomBot,
        [EnumMember(Value = "exchangeUnifiedMessagingService")]
        ExchangeUnifiedMessagingService,
        [EnumMember(Value = "gateway")]
        Gateway,
        [EnumMember(Value = "mediaController")]
        MediaController,
        [EnumMember(Value = "mediationServer")]
        MediationServer,
        [EnumMember(Value = "mediationServerCloudConnectorEdition")]
        MediationServerCloudConnectorEdition,
        [EnumMember(Value = "responseGroupService")]
        ResponseGroupService,
        [EnumMember(Value = "responseGroupServiceAnnouncementService")]
        ResponseGroupServiceAnnouncementService,
        [EnumMember(Value = "skypeForBusinessApplicationSharingMcu")]
        SkypeForBusinessApplicationSharingMcu,
        [EnumMember(Value = "skypeForBusinessAttendant")]
        SkypeForBusinessAttendant,
        [EnumMember(Value = "skypeForBusinessAudioVideoMcu")]
        SkypeForBusinessAudioVideoMcu,
        [EnumMember(Value = "skypeForBusinessAutoAttendant")]
        SkypeForBusinessAutoAttendant,
        [EnumMember(Value = "skypeForBusinessCallQueues")]
        SkypeForBusinessCallQueues,
        [EnumMember(Value = "skypeForBusinessMicrosoftTeamsGateway")]
        SkypeForBusinessMicrosoftTeamsGateway,
        [EnumMember(Value = "skypeForBusinessUnifiedCommunicationApplicationPlatform")]
        SkypeForBusinessUnifiedCommunicationApplicationPlatform,
        [EnumMember(Value = "skypeTranslator")]
        SkypeTranslator,
        [EnumMember(Value = "unknown")]
        Unknown,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
        [EnumMember(Value = "voicemail")]
        Voicemail,
    }
}
