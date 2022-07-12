using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IncompleteData : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The service does not have source data before the specified time.</summary>
        public DateTimeOffset? MissingDataBeforeDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("missingDataBeforeDateTime"); }
            set { BackingStore?.Set("missingDataBeforeDateTime", value); }
        }
        /// <summary>Some data was not recorded due to excessive activity.</summary>
        public bool? WasThrottled {
            get { return BackingStore?.Get<bool?>("wasThrottled"); }
            set { BackingStore?.Set("wasThrottled", value); }
        }
        /// <summary>
        /// Instantiates a new incompleteData and sets the default values.
        /// </summary>
        public IncompleteData() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static IncompleteData CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IncompleteData();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"missingDataBeforeDateTime", n => { MissingDataBeforeDateTime = n.GetDateTimeOffsetValue(); } },
                {"wasThrottled", n => { WasThrottled = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("missingDataBeforeDateTime", MissingDataBeforeDateTime);
            writer.WriteBoolValue("wasThrottled", WasThrottled);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
