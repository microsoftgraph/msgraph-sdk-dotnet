using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ManagedApp : MobileApp, IParsable {
        /// <summary>A managed (MAM) application&apos;s availability.</summary>
        public ManagedAppAvailability? AppAvailability {
            get { return BackingStore?.Get<ManagedAppAvailability?>("appAvailability"); }
            set { BackingStore?.Set("appAvailability", value); }
        }
        /// <summary>The Application&apos;s version.</summary>
        public string Version {
            get { return BackingStore?.Get<string>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Instantiates a new ManagedApp and sets the default values.
        /// </summary>
        public ManagedApp() : base() {
            Type = "#microsoft.graph.managedApp";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedApp CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.managedAndroidStoreApp" => new ManagedAndroidStoreApp(),
                "#microsoft.graph.managedIOSStoreApp" => new ManagedIOSStoreApp(),
                "#microsoft.graph.managedMobileLobApp" => new ManagedMobileLobApp(),
                _ => new ManagedApp(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appAvailability", n => { AppAvailability = n.GetEnumValue<ManagedAppAvailability>(); } },
                {"version", n => { Version = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ManagedAppAvailability>("appAvailability", AppAvailability);
            writer.WriteStringValue("version", Version);
        }
    }
}
