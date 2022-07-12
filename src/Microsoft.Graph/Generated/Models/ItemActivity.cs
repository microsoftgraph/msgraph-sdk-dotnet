using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class ItemActivity : Entity, IParsable {
        /// <summary>An item was accessed.</summary>
        public AccessAction Access {
            get { return BackingStore?.Get<AccessAction>("access"); }
            set { BackingStore?.Set("access", value); }
        }
        /// <summary>Details about when the activity took place. Read-only.</summary>
        public DateTimeOffset? ActivityDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("activityDateTime"); }
            set { BackingStore?.Set("activityDateTime", value); }
        }
        /// <summary>Identity of who performed the action. Read-only.</summary>
        public IdentitySet Actor {
            get { return BackingStore?.Get<IdentitySet>("actor"); }
            set { BackingStore?.Set("actor", value); }
        }
        /// <summary>Exposes the driveItem that was the target of this activity.</summary>
        public Microsoft.Graph.Models.DriveItem DriveItem {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DriveItem>("driveItem"); }
            set { BackingStore?.Set("driveItem", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ItemActivity CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ItemActivity();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"access", n => { Access = n.GetObjectValue<AccessAction>(AccessAction.CreateFromDiscriminatorValue); } },
                {"activityDateTime", n => { ActivityDateTime = n.GetDateTimeOffsetValue(); } },
                {"actor", n => { Actor = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"driveItem", n => { DriveItem = n.GetObjectValue<Microsoft.Graph.Models.DriveItem>(Microsoft.Graph.Models.DriveItem.CreateFromDiscriminatorValue); } },
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
            writer.WriteObjectValue<Microsoft.Graph.Models.DriveItem>("driveItem", DriveItem);
        }
    }
}
