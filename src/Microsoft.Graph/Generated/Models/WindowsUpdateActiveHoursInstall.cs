using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class WindowsUpdateActiveHoursInstall : WindowsUpdateInstallScheduleType, IParsable {
        /// <summary>Active Hours End</summary>
        public Time? ActiveHoursEnd {
            get { return BackingStore?.Get<Time?>("activeHoursEnd"); }
            set { BackingStore?.Set("activeHoursEnd", value); }
        }
        /// <summary>Active Hours Start</summary>
        public Time? ActiveHoursStart {
            get { return BackingStore?.Get<Time?>("activeHoursStart"); }
            set { BackingStore?.Set("activeHoursStart", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new WindowsUpdateActiveHoursInstall CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WindowsUpdateActiveHoursInstall();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"activeHoursEnd", n => { ActiveHoursEnd = n.GetTimeValue(); } },
                {"activeHoursStart", n => { ActiveHoursStart = n.GetTimeValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteTimeValue("activeHoursEnd", ActiveHoursEnd);
            writer.WriteTimeValue("activeHoursStart", ActiveHoursStart);
        }
    }
}
