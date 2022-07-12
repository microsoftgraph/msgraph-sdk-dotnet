using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Network Usage Rules allow enterprises to specify how managed apps use networks, such as cellular data networks.</summary>
    public class IosNetworkUsageRule : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>If set to true, corresponding managed apps will not be allowed to use cellular data at any time.</summary>
        public bool? CellularDataBlocked {
            get { return BackingStore?.Get<bool?>("cellularDataBlocked"); }
            set { BackingStore?.Set("cellularDataBlocked", value); }
        }
        /// <summary>If set to true, corresponding managed apps will not be allowed to use cellular data when roaming.</summary>
        public bool? CellularDataBlockWhenRoaming {
            get { return BackingStore?.Get<bool?>("cellularDataBlockWhenRoaming"); }
            set { BackingStore?.Set("cellularDataBlockWhenRoaming", value); }
        }
        /// <summary>Information about the managed apps that this rule is going to apply to. This collection can contain a maximum of 500 elements.</summary>
        public List<AppListItem> ManagedApps {
            get { return BackingStore?.Get<List<AppListItem>>("managedApps"); }
            set { BackingStore?.Set("managedApps", value); }
        }
        /// <summary>
        /// Instantiates a new iosNetworkUsageRule and sets the default values.
        /// </summary>
        public IosNetworkUsageRule() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static IosNetworkUsageRule CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosNetworkUsageRule();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"cellularDataBlocked", n => { CellularDataBlocked = n.GetBoolValue(); } },
                {"cellularDataBlockWhenRoaming", n => { CellularDataBlockWhenRoaming = n.GetBoolValue(); } },
                {"managedApps", n => { ManagedApps = n.GetCollectionOfObjectValues<AppListItem>(AppListItem.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteBoolValue("cellularDataBlocked", CellularDataBlocked);
            writer.WriteBoolValue("cellularDataBlockWhenRoaming", CellularDataBlockWhenRoaming);
            writer.WriteCollectionOfObjectValues<AppListItem>("managedApps", ManagedApps);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
