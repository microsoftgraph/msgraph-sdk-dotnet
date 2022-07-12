using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.ODataErrors {
    public class MainError : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The code property</summary>
        public string Code {
            get { return BackingStore?.Get<string>("code"); }
            set { BackingStore?.Set("code", value); }
        }
        /// <summary>The details property</summary>
        public List<ErrorDetails> Details {
            get { return BackingStore?.Get<List<ErrorDetails>>("details"); }
            set { BackingStore?.Set("details", value); }
        }
        /// <summary>The innererror property</summary>
        public Microsoft.Graph.Models.ODataErrors.InnerError Innererror {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ODataErrors.InnerError>("innererror"); }
            set { BackingStore?.Set("innererror", value); }
        }
        /// <summary>The message property</summary>
        public string Message {
            get { return BackingStore?.Get<string>("message"); }
            set { BackingStore?.Set("message", value); }
        }
        /// <summary>The target property</summary>
        public string Target {
            get { return BackingStore?.Get<string>("target"); }
            set { BackingStore?.Set("target", value); }
        }
        /// <summary>
        /// Instantiates a new MainError and sets the default values.
        /// </summary>
        public MainError() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static MainError CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MainError();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"code", n => { Code = n.GetStringValue(); } },
                {"details", n => { Details = n.GetCollectionOfObjectValues<ErrorDetails>(ErrorDetails.CreateFromDiscriminatorValue).ToList(); } },
                {"innererror", n => { Innererror = n.GetObjectValue<Microsoft.Graph.Models.ODataErrors.InnerError>(Microsoft.Graph.Models.ODataErrors.InnerError.CreateFromDiscriminatorValue); } },
                {"message", n => { Message = n.GetStringValue(); } },
                {"target", n => { Target = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("code", Code);
            writer.WriteCollectionOfObjectValues<ErrorDetails>("details", Details);
            writer.WriteObjectValue<Microsoft.Graph.Models.ODataErrors.InnerError>("innererror", Innererror);
            writer.WriteStringValue("message", Message);
            writer.WriteStringValue("target", Target);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
