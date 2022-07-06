using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ManagedAndroidLobApp : ManagedMobileLobApp, IParsable {
        /// <summary>The value for the minimum applicable operating system.</summary>
        public AndroidMinimumOperatingSystem MinimumSupportedOperatingSystem {
            get { return BackingStore?.Get<AndroidMinimumOperatingSystem>("minimumSupportedOperatingSystem"); }
            set { BackingStore?.Set("minimumSupportedOperatingSystem", value); }
        }
        /// <summary>The package identifier.</summary>
        public string PackageId {
            get { return BackingStore?.Get<string>("packageId"); }
            set { BackingStore?.Set("packageId", value); }
        }
        /// <summary>The version code of managed Android Line of Business (LoB) app.</summary>
        public string VersionCode {
            get { return BackingStore?.Get<string>("versionCode"); }
            set { BackingStore?.Set("versionCode", value); }
        }
        /// <summary>The version name of managed Android Line of Business (LoB) app.</summary>
        public string VersionName {
            get { return BackingStore?.Get<string>("versionName"); }
            set { BackingStore?.Set("versionName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedAndroidLobApp CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ManagedAndroidLobApp();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"minimumSupportedOperatingSystem", n => { MinimumSupportedOperatingSystem = n.GetObjectValue<AndroidMinimumOperatingSystem>(AndroidMinimumOperatingSystem.CreateFromDiscriminatorValue); } },
                {"packageId", n => { PackageId = n.GetStringValue(); } },
                {"versionCode", n => { VersionCode = n.GetStringValue(); } },
                {"versionName", n => { VersionName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<AndroidMinimumOperatingSystem>("minimumSupportedOperatingSystem", MinimumSupportedOperatingSystem);
            writer.WriteStringValue("packageId", PackageId);
            writer.WriteStringValue("versionCode", VersionCode);
            writer.WriteStringValue("versionName", VersionName);
        }
    }
}
