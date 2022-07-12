using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class OnlineMeetingInfo : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The ID of the conference.</summary>
        public string ConferenceId {
            get { return BackingStore?.Get<string>("conferenceId"); }
            set { BackingStore?.Set("conferenceId", value); }
        }
        /// <summary>The external link that launches the online meeting. This is a URL that clients will launch into a browser and will redirect the user to join the meeting.</summary>
        public string JoinUrl {
            get { return BackingStore?.Get<string>("joinUrl"); }
            set { BackingStore?.Set("joinUrl", value); }
        }
        /// <summary>All of the phone numbers associated with this conference.</summary>
        public List<Phone> Phones {
            get { return BackingStore?.Get<List<Phone>>("phones"); }
            set { BackingStore?.Set("phones", value); }
        }
        /// <summary>The pre-formatted quickdial for this call.</summary>
        public string QuickDial {
            get { return BackingStore?.Get<string>("quickDial"); }
            set { BackingStore?.Set("quickDial", value); }
        }
        /// <summary>The toll free numbers that can be used to join the conference.</summary>
        public List<string> TollFreeNumbers {
            get { return BackingStore?.Get<List<string>>("tollFreeNumbers"); }
            set { BackingStore?.Set("tollFreeNumbers", value); }
        }
        /// <summary>The toll number that can be used to join the conference.</summary>
        public string TollNumber {
            get { return BackingStore?.Get<string>("tollNumber"); }
            set { BackingStore?.Set("tollNumber", value); }
        }
        /// <summary>
        /// Instantiates a new onlineMeetingInfo and sets the default values.
        /// </summary>
        public OnlineMeetingInfo() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static OnlineMeetingInfo CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnlineMeetingInfo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"conferenceId", n => { ConferenceId = n.GetStringValue(); } },
                {"joinUrl", n => { JoinUrl = n.GetStringValue(); } },
                {"phones", n => { Phones = n.GetCollectionOfObjectValues<Phone>(Phone.CreateFromDiscriminatorValue).ToList(); } },
                {"quickDial", n => { QuickDial = n.GetStringValue(); } },
                {"tollFreeNumbers", n => { TollFreeNumbers = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"tollNumber", n => { TollNumber = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("conferenceId", ConferenceId);
            writer.WriteStringValue("joinUrl", JoinUrl);
            writer.WriteCollectionOfObjectValues<Phone>("phones", Phones);
            writer.WriteStringValue("quickDial", QuickDial);
            writer.WriteCollectionOfPrimitiveValues<string>("tollFreeNumbers", TollFreeNumbers);
            writer.WriteStringValue("tollNumber", TollNumber);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
