using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class ItemActivity : Entity, IParsable {
        /// <summary>An item was accessed.</summary>
        public AccessAction Access { get; set; }
        /// <summary>Details about when the activity took place. Read-only.</summary>
        public DateTimeOffset? ActivityDateTime { get; set; }
        /// <summary>Identity of who performed the action. Read-only.</summary>
        public IdentitySet Actor { get; set; }
        /// <summary>Exposes the driveItem that was the target of this activity.</summary>
        public DriveItem DriveItem { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"access", (o,n) => { (o as ItemActivity).Access = n.GetObjectValue<AccessAction>(); } },
                {"activityDateTime", (o,n) => { (o as ItemActivity).ActivityDateTime = n.GetDateTimeOffsetValue(); } },
                {"actor", (o,n) => { (o as ItemActivity).Actor = n.GetObjectValue<IdentitySet>(); } },
                {"driveItem", (o,n) => { (o as ItemActivity).DriveItem = n.GetObjectValue<DriveItem>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<AccessAction>("access", Access);
            writer.WriteDateTimeOffsetValue("activityDateTime", ActivityDateTime);
            writer.WriteObjectValue<IdentitySet>("actor", Actor);
            writer.WriteObjectValue<DriveItem>("driveItem", DriveItem);
        }
    }
}
