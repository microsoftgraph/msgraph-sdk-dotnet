using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class SecureScoreControlStateUpdate : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Assigns the control to the user who will take the action.</summary>
        public string AssignedTo {
            get { return BackingStore?.Get<string>("assignedTo"); }
            set { BackingStore?.Set("assignedTo", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Provides optional comment about the control.</summary>
        public string Comment {
            get { return BackingStore?.Get<string>("comment"); }
            set { BackingStore?.Set("comment", value); }
        }
        /// <summary>State of the control, which can be modified via a PATCH command (for example, ignored, thirdParty).</summary>
        public string State {
            get { return BackingStore?.Get<string>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>ID of the user who updated tenant state.</summary>
        public string UpdatedBy {
            get { return BackingStore?.Get<string>("updatedBy"); }
            set { BackingStore?.Set("updatedBy", value); }
        }
        /// <summary>Time at which the control state was updated.</summary>
        public DateTimeOffset? UpdatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("updatedDateTime"); }
            set { BackingStore?.Set("updatedDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new secureScoreControlStateUpdate and sets the default values.
        /// </summary>
        public SecureScoreControlStateUpdate() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SecureScoreControlStateUpdate CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SecureScoreControlStateUpdate();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"assignedTo", n => { AssignedTo = n.GetStringValue(); } },
                {"comment", n => { Comment = n.GetStringValue(); } },
                {"state", n => { State = n.GetStringValue(); } },
                {"updatedBy", n => { UpdatedBy = n.GetStringValue(); } },
                {"updatedDateTime", n => { UpdatedDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("assignedTo", AssignedTo);
            writer.WriteStringValue("comment", Comment);
            writer.WriteStringValue("state", State);
            writer.WriteStringValue("updatedBy", UpdatedBy);
            writer.WriteDateTimeOffsetValue("updatedDateTime", UpdatedDateTime);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
