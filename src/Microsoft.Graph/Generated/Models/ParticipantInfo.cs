using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ParticipantInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The ISO 3166-1 Alpha-2 country code of the participant&apos;s best estimated physical location at the start of the call. Read-only.</summary>
        public string CountryCode {
            get { return BackingStore?.Get<string>("countryCode"); }
            set { BackingStore?.Set("countryCode", value); }
        }
        /// <summary>The type of endpoint the participant is using. Possible values are: default, voicemail, skypeForBusiness, skypeForBusinessVoipPhone and unknownFutureValue. Read-only.</summary>
        public Microsoft.Graph.Models.EndpointType? EndpointType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.EndpointType?>("endpointType"); }
            set { BackingStore?.Set("endpointType", value); }
        }
        /// <summary>The identity property</summary>
        public IdentitySet Identity {
            get { return BackingStore?.Get<IdentitySet>("identity"); }
            set { BackingStore?.Set("identity", value); }
        }
        /// <summary>The language culture string. Read-only.</summary>
        public string LanguageId {
            get { return BackingStore?.Get<string>("languageId"); }
            set { BackingStore?.Set("languageId", value); }
        }
        /// <summary>The OdataType property</summary>
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>The participant ID of the participant. Read-only.</summary>
        public string ParticipantId {
            get { return BackingStore?.Get<string>("participantId"); }
            set { BackingStore?.Set("participantId", value); }
        }
        /// <summary>The home region of the participant. This can be a country, a continent, or a larger geographic region. This does not change based on the participant&apos;s current physical location, unlike countryCode. Read-only.</summary>
        public string Region {
            get { return BackingStore?.Get<string>("region"); }
            set { BackingStore?.Set("region", value); }
        }
        /// <summary>
        /// Instantiates a new participantInfo and sets the default values.
        /// </summary>
        public ParticipantInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
            OdataType = "#microsoft.graph.participantInfo";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ParticipantInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ParticipantInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"countryCode", n => { CountryCode = n.GetStringValue(); } },
                {"endpointType", n => { EndpointType = n.GetEnumValue<EndpointType>(); } },
                {"identity", n => { Identity = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"languageId", n => { LanguageId = n.GetStringValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"participantId", n => { ParticipantId = n.GetStringValue(); } },
                {"region", n => { Region = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("countryCode", CountryCode);
            writer.WriteEnumValue<EndpointType>("endpointType", EndpointType);
            writer.WriteObjectValue<IdentitySet>("identity", Identity);
            writer.WriteStringValue("languageId", LanguageId);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteStringValue("participantId", ParticipantId);
            writer.WriteStringValue("region", Region);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
