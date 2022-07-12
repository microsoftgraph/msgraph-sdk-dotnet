using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>The identifier for the deployment an app.</summary>
    public class ManagedMobileApp : Entity, IParsable {
        /// <summary>The identifier for an app with it&apos;s operating system type.</summary>
        public Microsoft.Graph.Models.MobileAppIdentifier MobileAppIdentifier {
            get { return BackingStore?.Get<Microsoft.Graph.Models.MobileAppIdentifier>("mobileAppIdentifier"); }
            set { BackingStore?.Set("mobileAppIdentifier", value); }
        }
        /// <summary>Version of the entity.</summary>
        public string Version {
            get { return BackingStore?.Get<string>("version"); }
            set { BackingStore?.Set("version", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedMobileApp CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ManagedMobileApp();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"mobileAppIdentifier", n => { MobileAppIdentifier = n.GetObjectValue<Microsoft.Graph.Models.MobileAppIdentifier>(Microsoft.Graph.Models.MobileAppIdentifier.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<Microsoft.Graph.Models.MobileAppIdentifier>("mobileAppIdentifier", MobileAppIdentifier);
            writer.WriteStringValue("version", Version);
        }
    }
}
