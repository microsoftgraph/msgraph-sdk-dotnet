using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models.ODataErrors {
    public class InnerError : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Client request Id as sent by the client application.</summary>
        public string ClientRequestId {
            get { return BackingStore?.Get<string>("client-request-id"); }
            set { BackingStore?.Set("client-request-id", value); }
        }
        /// <summary>Date when the error occured.</summary>
        public DateTimeOffset? Date {
            get { return BackingStore?.Get<DateTimeOffset?>("date"); }
            set { BackingStore?.Set("date", value); }
        }
        /// <summary>Request Id as tracked internally by the service</summary>
        public string RequestId {
            get { return BackingStore?.Get<string>("request-id"); }
            set { BackingStore?.Set("request-id", value); }
        }
        /// <summary>
        /// Instantiates a new InnerError and sets the default values.
        /// </summary>
        public InnerError() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static InnerError CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new InnerError();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"client-request-id", n => { ClientRequestId = n.GetStringValue(); } },
                {"date", n => { Date = n.GetDateTimeOffsetValue(); } },
                {"request-id", n => { RequestId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("client-request-id", ClientRequestId);
            writer.WriteDateTimeOffsetValue("date", Date);
            writer.WriteStringValue("request-id", RequestId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
