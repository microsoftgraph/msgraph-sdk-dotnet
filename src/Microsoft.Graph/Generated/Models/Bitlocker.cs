using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Bitlocker : Entity, IParsable {
        /// <summary>The recovery keys associated with the bitlocker entity.</summary>
        public List<BitlockerRecoveryKey> RecoveryKeys {
            get { return BackingStore?.Get<List<BitlockerRecoveryKey>>("recoveryKeys"); }
            set { BackingStore?.Set("recoveryKeys", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Bitlocker CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Bitlocker();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"recoveryKeys", n => { RecoveryKeys = n.GetCollectionOfObjectValues<BitlockerRecoveryKey>(BitlockerRecoveryKey.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<BitlockerRecoveryKey>("recoveryKeys", RecoveryKeys);
        }
    }
}
