using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RichLongRunningOperation : LongRunningOperation, IParsable {
        /// <summary>Error due to which the operation failed.</summary>
        public PublicError Error {
            get { return BackingStore?.Get<PublicError>("error"); }
            set { BackingStore?.Set("error", value); }
        }
        /// <summary>A value between 0 and 100 that indicates the progress of the operation.</summary>
        public int? PercentageComplete {
            get { return BackingStore?.Get<int?>("percentageComplete"); }
            set { BackingStore?.Set("percentageComplete", value); }
        }
        /// <summary>A unique identifier for the result.</summary>
        public string ResourceId {
            get { return BackingStore?.Get<string>("resourceId"); }
            set { BackingStore?.Set("resourceId", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new RichLongRunningOperation CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RichLongRunningOperation();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"error", n => { Error = n.GetObjectValue<PublicError>(PublicError.CreateFromDiscriminatorValue); } },
                {"percentageComplete", n => { PercentageComplete = n.GetIntValue(); } },
                {"resourceId", n => { ResourceId = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<PublicError>("error", Error);
            writer.WriteIntValue("percentageComplete", PercentageComplete);
            writer.WriteStringValue("resourceId", ResourceId);
        }
    }
}
