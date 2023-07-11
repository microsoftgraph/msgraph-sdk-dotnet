using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models.IdentityGovernance {
    public class CustomTaskExtensionCallbackConfiguration : CustomExtensionCallbackConfiguration, IParsable {
        /// <summary>The authorizedApps property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.Application>? AuthorizedApps {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.Application>?>("authorizedApps"); }
            set { BackingStore?.Set("authorizedApps", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.Application> AuthorizedApps {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.Application>>("authorizedApps"); }
            set { BackingStore?.Set("authorizedApps", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new customTaskExtensionCallbackConfiguration and sets the default values.
        /// </summary>
        public CustomTaskExtensionCallbackConfiguration() : base() {
            OdataType = "#microsoft.graph.identityGovernance.customTaskExtensionCallbackConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new CustomTaskExtensionCallbackConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CustomTaskExtensionCallbackConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"authorizedApps", n => { AuthorizedApps = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.Application>(Microsoft.Graph.Models.Application.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.Application>("authorizedApps", AuthorizedApps);
        }
    }
}
