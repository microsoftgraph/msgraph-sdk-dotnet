using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CalendarSharingMessageAction : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>The action property</summary>
        public CalendarSharingAction? Action {
            get { return BackingStore?.Get<CalendarSharingAction?>("action"); }
            set { BackingStore?.Set("action", value); }
        }
        /// <summary>The actionType property</summary>
        public CalendarSharingActionType? ActionType {
            get { return BackingStore?.Get<CalendarSharingActionType?>("actionType"); }
            set { BackingStore?.Set("actionType", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The importance property</summary>
        public CalendarSharingActionImportance? Importance {
            get { return BackingStore?.Get<CalendarSharingActionImportance?>("importance"); }
            set { BackingStore?.Set("importance", value); }
        }
        /// <summary>
        /// Instantiates a new calendarSharingMessageAction and sets the default values.
        /// </summary>
        public CalendarSharingMessageAction() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static CalendarSharingMessageAction CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CalendarSharingMessageAction();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"action", n => { Action = n.GetEnumValue<CalendarSharingAction>(); } },
                {"actionType", n => { ActionType = n.GetEnumValue<CalendarSharingActionType>(); } },
                {"importance", n => { Importance = n.GetEnumValue<CalendarSharingActionImportance>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<CalendarSharingAction>("action", Action);
            writer.WriteEnumValue<CalendarSharingActionType>("actionType", ActionType);
            writer.WriteEnumValue<CalendarSharingActionImportance>("importance", Importance);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
