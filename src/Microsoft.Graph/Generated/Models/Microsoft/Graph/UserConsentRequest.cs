using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class UserConsentRequest : Request, IParsable {
        /// <summary>Approval decisions associated with a request.</summary>
        public Approval Approval { get; set; }
        /// <summary>The user's justification for requiring access to the app. Supports $filter (eq only) and $orderby.</summary>
        public string Reason { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"approval", (o,n) => { (o as UserConsentRequest).Approval = n.GetObjectValue<Approval>(); } },
                {"reason", (o,n) => { (o as UserConsentRequest).Reason = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Approval>("approval", Approval);
            writer.WriteStringValue("reason", Reason);
        }
    }
}
