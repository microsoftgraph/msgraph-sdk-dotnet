using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class CustomTimeZone : TimeZoneBase, IParsable {
        /// <summary>The time offset of the time zone from Coordinated Universal Time (UTC). This value is in minutes. Time zones that are ahead of UTC have a positive offset; time zones that are behind UTC have a negative offset.</summary>
        public int? Bias {
            get { return BackingStore?.Get<int?>("bias"); }
            set { BackingStore?.Set("bias", value); }
        }
        /// <summary>Specifies when the time zone switches from standard time to daylight saving time.</summary>
        public DaylightTimeZoneOffset DaylightOffset {
            get { return BackingStore?.Get<DaylightTimeZoneOffset>("daylightOffset"); }
            set { BackingStore?.Set("daylightOffset", value); }
        }
        /// <summary>Specifies when the time zone switches from daylight saving time to standard time.</summary>
        public StandardTimeZoneOffset StandardOffset {
            get { return BackingStore?.Get<StandardTimeZoneOffset>("standardOffset"); }
            set { BackingStore?.Set("standardOffset", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new CustomTimeZone CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CustomTimeZone();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"bias", n => { Bias = n.GetIntValue(); } },
                {"daylightOffset", n => { DaylightOffset = n.GetObjectValue<DaylightTimeZoneOffset>(DaylightTimeZoneOffset.CreateFromDiscriminatorValue); } },
                {"standardOffset", n => { StandardOffset = n.GetObjectValue<StandardTimeZoneOffset>(StandardTimeZoneOffset.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteIntValue("bias", Bias);
            writer.WriteObjectValue<DaylightTimeZoneOffset>("daylightOffset", DaylightOffset);
            writer.WriteObjectValue<StandardTimeZoneOffset>("standardOffset", StandardOffset);
        }
    }
}
