using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class UserSignInInsight : GovernanceInsight, IParsable {
        /// <summary>Indicates when the user last signed in.</summary>
        public DateTimeOffset? LastSignInDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastSignInDateTime"); }
            set { BackingStore?.Set("lastSignInDateTime", value); }
        }
        /// <summary>
        /// Instantiates a new userSignInInsight and sets the default values.
        /// </summary>
        public UserSignInInsight() : base() {
            OdataType = "#microsoft.graph.userSignInInsight";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new UserSignInInsight CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UserSignInInsight();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"lastSignInDateTime", n => { LastSignInDateTime = n.GetDateTimeOffsetValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("lastSignInDateTime", LastSignInDateTime);
        }
    }
}
