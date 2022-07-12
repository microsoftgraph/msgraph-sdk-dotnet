using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class UserConsentRequest : Request, IParsable {
        /// <summary>Approval decisions associated with a request.</summary>
        public Microsoft.Graph.Models.Approval Approval {
            get { return BackingStore?.Get<Microsoft.Graph.Models.Approval>("approval"); }
            set { BackingStore?.Set("approval", value); }
        }
        /// <summary>The user&apos;s justification for requiring access to the app. Supports $filter (eq only) and $orderby.</summary>
        public string Reason {
            get { return BackingStore?.Get<string>("reason"); }
            set { BackingStore?.Set("reason", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new UserConsentRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UserConsentRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"approval", n => { Approval = n.GetObjectValue<Microsoft.Graph.Models.Approval>(Microsoft.Graph.Models.Approval.CreateFromDiscriminatorValue); } },
                {"reason", n => { Reason = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.Approval>("approval", Approval);
            writer.WriteStringValue("reason", Reason);
        }
    }
}
