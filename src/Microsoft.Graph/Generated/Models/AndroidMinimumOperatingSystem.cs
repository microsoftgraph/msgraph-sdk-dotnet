using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Contains properties for the minimum operating system required for an Android mobile app.</summary>
    public class AndroidMinimumOperatingSystem : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Version 10.0 or later.</summary>
        public bool? V10_0 {
            get { return BackingStore?.Get<bool?>("v10_0"); }
            set { BackingStore?.Set("v10_0", value); }
        }
        /// <summary>Version 11.0 or later.</summary>
        public bool? V11_0 {
            get { return BackingStore?.Get<bool?>("v11_0"); }
            set { BackingStore?.Set("v11_0", value); }
        }
        /// <summary>Version 4.0 or later.</summary>
        public bool? V4_0 {
            get { return BackingStore?.Get<bool?>("v4_0"); }
            set { BackingStore?.Set("v4_0", value); }
        }
        /// <summary>Version 4.0.3 or later.</summary>
        public bool? V4_0_3 {
            get { return BackingStore?.Get<bool?>("v4_0_3"); }
            set { BackingStore?.Set("v4_0_3", value); }
        }
        /// <summary>Version 4.1 or later.</summary>
        public bool? V4_1 {
            get { return BackingStore?.Get<bool?>("v4_1"); }
            set { BackingStore?.Set("v4_1", value); }
        }
        /// <summary>Version 4.2 or later.</summary>
        public bool? V4_2 {
            get { return BackingStore?.Get<bool?>("v4_2"); }
            set { BackingStore?.Set("v4_2", value); }
        }
        /// <summary>Version 4.3 or later.</summary>
        public bool? V4_3 {
            get { return BackingStore?.Get<bool?>("v4_3"); }
            set { BackingStore?.Set("v4_3", value); }
        }
        /// <summary>Version 4.4 or later.</summary>
        public bool? V4_4 {
            get { return BackingStore?.Get<bool?>("v4_4"); }
            set { BackingStore?.Set("v4_4", value); }
        }
        /// <summary>Version 5.0 or later.</summary>
        public bool? V5_0 {
            get { return BackingStore?.Get<bool?>("v5_0"); }
            set { BackingStore?.Set("v5_0", value); }
        }
        /// <summary>Version 5.1 or later.</summary>
        public bool? V5_1 {
            get { return BackingStore?.Get<bool?>("v5_1"); }
            set { BackingStore?.Set("v5_1", value); }
        }
        /// <summary>
        /// Instantiates a new androidMinimumOperatingSystem and sets the default values.
        /// </summary>
        public AndroidMinimumOperatingSystem() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static AndroidMinimumOperatingSystem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AndroidMinimumOperatingSystem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"v10_0", n => { V10_0 = n.GetBoolValue(); } },
                {"v11_0", n => { V11_0 = n.GetBoolValue(); } },
                {"v4_0", n => { V4_0 = n.GetBoolValue(); } },
                {"v4_0_3", n => { V4_0_3 = n.GetBoolValue(); } },
                {"v4_1", n => { V4_1 = n.GetBoolValue(); } },
                {"v4_2", n => { V4_2 = n.GetBoolValue(); } },
                {"v4_3", n => { V4_3 = n.GetBoolValue(); } },
                {"v4_4", n => { V4_4 = n.GetBoolValue(); } },
                {"v5_0", n => { V5_0 = n.GetBoolValue(); } },
                {"v5_1", n => { V5_1 = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("v10_0", V10_0);
            writer.WriteBoolValue("v11_0", V11_0);
            writer.WriteBoolValue("v4_0", V4_0);
            writer.WriteBoolValue("v4_0_3", V4_0_3);
            writer.WriteBoolValue("v4_1", V4_1);
            writer.WriteBoolValue("v4_2", V4_2);
            writer.WriteBoolValue("v4_3", V4_3);
            writer.WriteBoolValue("v4_4", V4_4);
            writer.WriteBoolValue("v5_0", V5_0);
            writer.WriteBoolValue("v5_1", V5_1);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
