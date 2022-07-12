using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Communications.Calls.Item.RecordResponse {
    /// <summary>Provides operations to call the recordResponse method.</summary>
    public class RecordResponsePostRequestBody : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The bargeInAllowed property</summary>
        public bool? BargeInAllowed {
            get { return BackingStore?.Get<bool?>("bargeInAllowed"); }
            set { BackingStore?.Set("bargeInAllowed", value); }
        }
        /// <summary>The clientContext property</summary>
        public string ClientContext {
            get { return BackingStore?.Get<string>("clientContext"); }
            set { BackingStore?.Set("clientContext", value); }
        }
        /// <summary>The initialSilenceTimeoutInSeconds property</summary>
        public int? InitialSilenceTimeoutInSeconds {
            get { return BackingStore?.Get<int?>("initialSilenceTimeoutInSeconds"); }
            set { BackingStore?.Set("initialSilenceTimeoutInSeconds", value); }
        }
        /// <summary>The maxRecordDurationInSeconds property</summary>
        public int? MaxRecordDurationInSeconds {
            get { return BackingStore?.Get<int?>("maxRecordDurationInSeconds"); }
            set { BackingStore?.Set("maxRecordDurationInSeconds", value); }
        }
        /// <summary>The maxSilenceTimeoutInSeconds property</summary>
        public int? MaxSilenceTimeoutInSeconds {
            get { return BackingStore?.Get<int?>("maxSilenceTimeoutInSeconds"); }
            set { BackingStore?.Set("maxSilenceTimeoutInSeconds", value); }
        }
        /// <summary>The playBeep property</summary>
        public bool? PlayBeep {
            get { return BackingStore?.Get<bool?>("playBeep"); }
            set { BackingStore?.Set("playBeep", value); }
        }
        /// <summary>The prompts property</summary>
        public List<Prompt> Prompts {
            get { return BackingStore?.Get<List<Prompt>>("prompts"); }
            set { BackingStore?.Set("prompts", value); }
        }
        /// <summary>The stopTones property</summary>
        public List<string> StopTones {
            get { return BackingStore?.Get<List<string>>("stopTones"); }
            set { BackingStore?.Set("stopTones", value); }
        }
        /// <summary>
        /// Instantiates a new recordResponsePostRequestBody and sets the default values.
        /// </summary>
        public RecordResponsePostRequestBody() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static RecordResponsePostRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RecordResponsePostRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"bargeInAllowed", n => { BargeInAllowed = n.GetBoolValue(); } },
                {"clientContext", n => { ClientContext = n.GetStringValue(); } },
                {"initialSilenceTimeoutInSeconds", n => { InitialSilenceTimeoutInSeconds = n.GetIntValue(); } },
                {"maxRecordDurationInSeconds", n => { MaxRecordDurationInSeconds = n.GetIntValue(); } },
                {"maxSilenceTimeoutInSeconds", n => { MaxSilenceTimeoutInSeconds = n.GetIntValue(); } },
                {"playBeep", n => { PlayBeep = n.GetBoolValue(); } },
                {"prompts", n => { Prompts = n.GetCollectionOfObjectValues<Prompt>(Prompt.CreateFromDiscriminatorValue).ToList(); } },
                {"stopTones", n => { StopTones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("bargeInAllowed", BargeInAllowed);
            writer.WriteStringValue("clientContext", ClientContext);
            writer.WriteIntValue("initialSilenceTimeoutInSeconds", InitialSilenceTimeoutInSeconds);
            writer.WriteIntValue("maxRecordDurationInSeconds", MaxRecordDurationInSeconds);
            writer.WriteIntValue("maxSilenceTimeoutInSeconds", MaxSilenceTimeoutInSeconds);
            writer.WriteBoolValue("playBeep", PlayBeep);
            writer.WriteCollectionOfObjectValues<Prompt>("prompts", Prompts);
            writer.WriteCollectionOfPrimitiveValues<string>("stopTones", StopTones);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
