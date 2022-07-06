using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Represents diagnostics status.</summary>
    public class ManagedAppDiagnosticStatus : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Instruction on how to mitigate a failed validation</summary>
        public string MitigationInstruction {
            get { return BackingStore?.Get<string>("mitigationInstruction"); }
            set { BackingStore?.Set("mitigationInstruction", value); }
        }
        /// <summary>The state of the operation</summary>
        public string State {
            get { return BackingStore?.Get<string>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>The validation friendly name</summary>
        public string ValidationName {
            get { return BackingStore?.Get<string>("validationName"); }
            set { BackingStore?.Set("validationName", value); }
        }
        /// <summary>
        /// Instantiates a new managedAppDiagnosticStatus and sets the default values.
        /// </summary>
        public ManagedAppDiagnosticStatus() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ManagedAppDiagnosticStatus CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ManagedAppDiagnosticStatus();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"mitigationInstruction", n => { MitigationInstruction = n.GetStringValue(); } },
                {"state", n => { State = n.GetStringValue(); } },
                {"validationName", n => { ValidationName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("mitigationInstruction", MitigationInstruction);
            writer.WriteStringValue("state", State);
            writer.WriteStringValue("validationName", ValidationName);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
