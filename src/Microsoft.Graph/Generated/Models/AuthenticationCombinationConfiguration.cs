using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class AuthenticationCombinationConfiguration : Entity, IParsable {
        /// <summary>The appliesToCombinations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<AuthenticationMethodModes?>? AppliesToCombinations {
            get { return BackingStore?.Get<List<AuthenticationMethodModes?>?>("appliesToCombinations"); }
            set { BackingStore?.Set("appliesToCombinations", value); }
        }
#nullable restore
#else
        public List<AuthenticationMethodModes?> AppliesToCombinations {
            get { return BackingStore?.Get<List<AuthenticationMethodModes?>>("appliesToCombinations"); }
            set { BackingStore?.Set("appliesToCombinations", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new AuthenticationCombinationConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.fido2CombinationConfiguration" => new Fido2CombinationConfiguration(),
                _ => new AuthenticationCombinationConfiguration(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appliesToCombinations", n => { AppliesToCombinations = n.GetCollectionOfEnumValues<AuthenticationMethodModes>()?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfEnumValues<AuthenticationMethodModes>("appliesToCombinations", AppliesToCombinations);
        }
    }
}
