using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IosDeviceFeaturesConfiguration : AppleDeviceFeaturesConfigurationBase, IParsable {
        /// <summary>Asset tag information for the device, displayed on the login window and lock screen.</summary>
        public string AssetTagTemplate {
            get { return BackingStore?.Get<string>("assetTagTemplate"); }
            set { BackingStore?.Set("assetTagTemplate", value); }
        }
        /// <summary>A list of app and folders to appear on the Home Screen Dock. This collection can contain a maximum of 500 elements.</summary>
        public List<IosHomeScreenItem> HomeScreenDockIcons {
            get { return BackingStore?.Get<List<IosHomeScreenItem>>("homeScreenDockIcons"); }
            set { BackingStore?.Set("homeScreenDockIcons", value); }
        }
        /// <summary>A list of pages on the Home Screen. This collection can contain a maximum of 500 elements.</summary>
        public List<IosHomeScreenPage> HomeScreenPages {
            get { return BackingStore?.Get<List<IosHomeScreenPage>>("homeScreenPages"); }
            set { BackingStore?.Set("homeScreenPages", value); }
        }
        /// <summary>A footnote displayed on the login window and lock screen. Available in iOS 9.3.1 and later.</summary>
        public string LockScreenFootnote {
            get { return BackingStore?.Get<string>("lockScreenFootnote"); }
            set { BackingStore?.Set("lockScreenFootnote", value); }
        }
        /// <summary>Notification settings for each bundle id. Applicable to devices in supervised mode only (iOS 9.3 and later). This collection can contain a maximum of 500 elements.</summary>
        public List<IosNotificationSettings> NotificationSettings {
            get { return BackingStore?.Get<List<IosNotificationSettings>>("notificationSettings"); }
            set { BackingStore?.Set("notificationSettings", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IosDeviceFeaturesConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosDeviceFeaturesConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assetTagTemplate", n => { AssetTagTemplate = n.GetStringValue(); } },
                {"homeScreenDockIcons", n => { HomeScreenDockIcons = n.GetCollectionOfObjectValues<IosHomeScreenItem>(IosHomeScreenItem.CreateFromDiscriminatorValue).ToList(); } },
                {"homeScreenPages", n => { HomeScreenPages = n.GetCollectionOfObjectValues<IosHomeScreenPage>(IosHomeScreenPage.CreateFromDiscriminatorValue).ToList(); } },
                {"lockScreenFootnote", n => { LockScreenFootnote = n.GetStringValue(); } },
                {"notificationSettings", n => { NotificationSettings = n.GetCollectionOfObjectValues<IosNotificationSettings>(IosNotificationSettings.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("assetTagTemplate", AssetTagTemplate);
            writer.WriteCollectionOfObjectValues<IosHomeScreenItem>("homeScreenDockIcons", HomeScreenDockIcons);
            writer.WriteCollectionOfObjectValues<IosHomeScreenPage>("homeScreenPages", HomeScreenPages);
            writer.WriteStringValue("lockScreenFootnote", LockScreenFootnote);
            writer.WriteCollectionOfObjectValues<IosNotificationSettings>("notificationSettings", NotificationSettings);
        }
    }
}
