using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class AccessPackageAutomaticRequestSettings : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The gracePeriodBeforeAccessRemoval property</summary>
        public TimeSpan? GracePeriodBeforeAccessRemoval {
            get { return BackingStore?.Get<TimeSpan?>("gracePeriodBeforeAccessRemoval"); }
            set { BackingStore?.Set("gracePeriodBeforeAccessRemoval", value); }
        }
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>The removeAccessWhenTargetLeavesAllowedTargets property</summary>
        public bool? RemoveAccessWhenTargetLeavesAllowedTargets {
            get { return BackingStore?.Get<bool?>("removeAccessWhenTargetLeavesAllowedTargets"); }
            set { BackingStore?.Set("removeAccessWhenTargetLeavesAllowedTargets", value); }
        }
        /// <summary>If set to true, automatic assignments will be created for targets in the allowed target scope.</summary>
        public bool? RequestAccessForAllowedTargets {
            get { return BackingStore?.Get<bool?>("requestAccessForAllowedTargets"); }
            set { BackingStore?.Set("requestAccessForAllowedTargets", value); }
        }
        /// <summary>
        /// Instantiates a new accessPackageAutomaticRequestSettings and sets the default values.
        /// </summary>
        public AccessPackageAutomaticRequestSettings() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static AccessPackageAutomaticRequestSettings CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AccessPackageAutomaticRequestSettings();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"gracePeriodBeforeAccessRemoval", n => { GracePeriodBeforeAccessRemoval = n.GetTimeSpanValue(); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"removeAccessWhenTargetLeavesAllowedTargets", n => { RemoveAccessWhenTargetLeavesAllowedTargets = n.GetBoolValue(); } },
                {"requestAccessForAllowedTargets", n => { RequestAccessForAllowedTargets = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteTimeSpanValue("gracePeriodBeforeAccessRemoval", GracePeriodBeforeAccessRemoval);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteBoolValue("removeAccessWhenTargetLeavesAllowedTargets", RemoveAccessWhenTargetLeavesAllowedTargets);
            writer.WriteBoolValue("requestAccessForAllowedTargets", RequestAccessForAllowedTargets);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
