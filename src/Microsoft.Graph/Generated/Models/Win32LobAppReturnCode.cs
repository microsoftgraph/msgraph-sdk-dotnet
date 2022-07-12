using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Contains return code properties for a Win32 App</summary>
    public class Win32LobAppReturnCode : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Return code.</summary>
        public int? ReturnCode {
            get { return BackingStore?.Get<int?>("returnCode"); }
            set { BackingStore?.Set("returnCode", value); }
        }
        /// <summary>Indicates the type of return code.</summary>
        public Win32LobAppReturnCodeType? Type {
            get { return BackingStore?.Get<Win32LobAppReturnCodeType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>
        /// Instantiates a new win32LobAppReturnCode and sets the default values.
        /// </summary>
        public Win32LobAppReturnCode() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static Win32LobAppReturnCode CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Win32LobAppReturnCode();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"returnCode", n => { ReturnCode = n.GetIntValue(); } },
                {"type", n => { Type = n.GetEnumValue<Win32LobAppReturnCodeType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("returnCode", ReturnCode);
            writer.WriteEnumValue<Win32LobAppReturnCodeType>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
