using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WindowsUniversalAppX : MobileLobApp, IParsable {
        /// <summary>Contains properties for Windows architecture.</summary>
        public WindowsArchitecture? ApplicableArchitectures {
            get { return BackingStore?.Get<WindowsArchitecture?>("applicableArchitectures"); }
            set { BackingStore?.Set("applicableArchitectures", value); }
        }
        /// <summary>Contains properties for Windows device type.</summary>
        public WindowsDeviceType? ApplicableDeviceTypes {
            get { return BackingStore?.Get<WindowsDeviceType?>("applicableDeviceTypes"); }
            set { BackingStore?.Set("applicableDeviceTypes", value); }
        }
        /// <summary>The Identity Name.</summary>
        public string IdentityName {
            get { return BackingStore?.Get<string>("identityName"); }
            set { BackingStore?.Set("identityName", value); }
        }
        /// <summary>The Identity Publisher Hash.</summary>
        public string IdentityPublisherHash {
            get { return BackingStore?.Get<string>("identityPublisherHash"); }
            set { BackingStore?.Set("identityPublisherHash", value); }
        }
        /// <summary>The Identity Resource Identifier.</summary>
        public string IdentityResourceIdentifier {
            get { return BackingStore?.Get<string>("identityResourceIdentifier"); }
            set { BackingStore?.Set("identityResourceIdentifier", value); }
        }
        /// <summary>The identity version.</summary>
        public string IdentityVersion {
            get { return BackingStore?.Get<string>("identityVersion"); }
            set { BackingStore?.Set("identityVersion", value); }
        }
        /// <summary>Whether or not the app is a bundle.</summary>
        public bool? IsBundle {
            get { return BackingStore?.Get<bool?>("isBundle"); }
            set { BackingStore?.Set("isBundle", value); }
        }
        /// <summary>The minimum operating system required for a Windows mobile app.</summary>
        public WindowsMinimumOperatingSystem MinimumSupportedOperatingSystem {
            get { return BackingStore?.Get<WindowsMinimumOperatingSystem>("minimumSupportedOperatingSystem"); }
            set { BackingStore?.Set("minimumSupportedOperatingSystem", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WindowsUniversalAppX CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WindowsUniversalAppX();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"applicableArchitectures", n => { ApplicableArchitectures = n.GetEnumValue<WindowsArchitecture>(); } },
                {"applicableDeviceTypes", n => { ApplicableDeviceTypes = n.GetEnumValue<WindowsDeviceType>(); } },
                {"identityName", n => { IdentityName = n.GetStringValue(); } },
                {"identityPublisherHash", n => { IdentityPublisherHash = n.GetStringValue(); } },
                {"identityResourceIdentifier", n => { IdentityResourceIdentifier = n.GetStringValue(); } },
                {"identityVersion", n => { IdentityVersion = n.GetStringValue(); } },
                {"isBundle", n => { IsBundle = n.GetBoolValue(); } },
                {"minimumSupportedOperatingSystem", n => { MinimumSupportedOperatingSystem = n.GetObjectValue<WindowsMinimumOperatingSystem>(WindowsMinimumOperatingSystem.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<WindowsArchitecture>("applicableArchitectures", ApplicableArchitectures);
            writer.WriteEnumValue<WindowsDeviceType>("applicableDeviceTypes", ApplicableDeviceTypes);
            writer.WriteStringValue("identityName", IdentityName);
            writer.WriteStringValue("identityPublisherHash", IdentityPublisherHash);
            writer.WriteStringValue("identityResourceIdentifier", IdentityResourceIdentifier);
            writer.WriteStringValue("identityVersion", IdentityVersion);
            writer.WriteBoolValue("isBundle", IsBundle);
            writer.WriteObjectValue<WindowsMinimumOperatingSystem>("minimumSupportedOperatingSystem", MinimumSupportedOperatingSystem);
        }
    }
}
