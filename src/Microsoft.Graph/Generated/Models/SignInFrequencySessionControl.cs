using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class SignInFrequencySessionControl : ConditionalAccessSessionControl, IParsable {
        /// <summary>The possible values are primaryAndSecondaryAuthentication, secondaryAuthentication, unknownFutureValue.</summary>
        public SignInFrequencyAuthenticationType? AuthenticationType {
            get { return BackingStore?.Get<SignInFrequencyAuthenticationType?>("authenticationType"); }
            set { BackingStore?.Set("authenticationType", value); }
        }
        /// <summary>The possible values are timeBased, everyTime, unknownFutureValue.</summary>
        public SignInFrequencyInterval? FrequencyInterval {
            get { return BackingStore?.Get<SignInFrequencyInterval?>("frequencyInterval"); }
            set { BackingStore?.Set("frequencyInterval", value); }
        }
        /// <summary>Possible values are: days, hours.</summary>
        public SigninFrequencyType? Type {
            get { return BackingStore?.Get<SigninFrequencyType?>("type"); }
            set { BackingStore?.Set("type", value); }
        }
        /// <summary>The number of days or hours.</summary>
        public int? Value {
            get { return BackingStore?.Get<int?>("value"); }
            set { BackingStore?.Set("value", value); }
        }
        /// <summary>
        /// Instantiates a new signInFrequencySessionControl and sets the default values.
        /// </summary>
        public SignInFrequencySessionControl() : base() {
            OdataType = "#microsoft.graph.signInFrequencySessionControl";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new SignInFrequencySessionControl CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SignInFrequencySessionControl();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"authenticationType", n => { AuthenticationType = n.GetEnumValue<SignInFrequencyAuthenticationType>(); } },
                {"frequencyInterval", n => { FrequencyInterval = n.GetEnumValue<SignInFrequencyInterval>(); } },
                {"type", n => { Type = n.GetEnumValue<SigninFrequencyType>(); } },
                {"value", n => { Value = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<SignInFrequencyAuthenticationType>("authenticationType", AuthenticationType);
            writer.WriteEnumValue<SignInFrequencyInterval>("frequencyInterval", FrequencyInterval);
            writer.WriteEnumValue<SigninFrequencyType>("type", Type);
            writer.WriteIntValue("value", Value);
        }
    }
}
