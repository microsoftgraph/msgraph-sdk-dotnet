using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class TeamGuestSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>If set to true, guests can add and update channels.</summary>
        public bool? AllowCreateUpdateChannels {
            get { return BackingStore?.Get<bool?>("allowCreateUpdateChannels"); }
            set { BackingStore?.Set("allowCreateUpdateChannels", value); }
        }
        /// <summary>If set to true, guests can delete channels.</summary>
        public bool? AllowDeleteChannels {
            get { return BackingStore?.Get<bool?>("allowDeleteChannels"); }
            set { BackingStore?.Set("allowDeleteChannels", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>
        /// Instantiates a new teamGuestSettings and sets the default values.
        /// </summary>
        public TeamGuestSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static TeamGuestSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TeamGuestSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowCreateUpdateChannels", n => { AllowCreateUpdateChannels = n.GetBoolValue(); } },
                {"allowDeleteChannels", n => { AllowDeleteChannels = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("allowCreateUpdateChannels", AllowCreateUpdateChannels);
            writer.WriteBoolValue("allowDeleteChannels", AllowDeleteChannels);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
