using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class ConditionalAccessPolicy : Entity, IParsable {
        /// <summary>The conditions property</summary>
        public ConditionalAccessConditionSet Conditions {
            get { return BackingStore?.Get<ConditionalAccessConditionSet>("conditions"); }
            set { BackingStore?.Set("conditions", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Readonly.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>The description property</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>Specifies a display name for the conditionalAccessPolicy object.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Specifies the grant controls that must be fulfilled to pass the policy.</summary>
        public ConditionalAccessGrantControls GrantControls {
            get { return BackingStore?.Get<ConditionalAccessGrantControls>("grantControls"); }
            set { BackingStore?.Set("grantControls", value); }
        }
        /// <summary>The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Readonly.</summary>
        public DateTimeOffset? ModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("modifiedDateTime"); }
            set { BackingStore?.Set("modifiedDateTime", value); }
        }
        /// <summary>Specifies the session controls that are enforced after sign-in.</summary>
        public ConditionalAccessSessionControls SessionControls {
            get { return BackingStore?.Get<ConditionalAccessSessionControls>("sessionControls"); }
            set { BackingStore?.Set("sessionControls", value); }
        }
        /// <summary>The state property</summary>
        public ConditionalAccessPolicyState? State {
            get { return BackingStore?.Get<ConditionalAccessPolicyState?>("state"); }
            set { BackingStore?.Set("state", value); }
        }
        /// <summary>
        /// Instantiates a new conditionalAccessPolicy and sets the default values.
        /// </summary>
        public ConditionalAccessPolicy() : base() {
            OdataType = "#microsoft.graph.conditionalAccessPolicy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ConditionalAccessPolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConditionalAccessPolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"conditions", n => { Conditions = n.GetObjectValue<ConditionalAccessConditionSet>(ConditionalAccessConditionSet.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"grantControls", n => { GrantControls = n.GetObjectValue<ConditionalAccessGrantControls>(ConditionalAccessGrantControls.CreateFromDiscriminatorValue); } },
                {"modifiedDateTime", n => { ModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"sessionControls", n => { SessionControls = n.GetObjectValue<ConditionalAccessSessionControls>(ConditionalAccessSessionControls.CreateFromDiscriminatorValue); } },
                {"state", n => { State = n.GetEnumValue<ConditionalAccessPolicyState>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ConditionalAccessConditionSet>("conditions", Conditions);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<ConditionalAccessGrantControls>("grantControls", GrantControls);
            writer.WriteDateTimeOffsetValue("modifiedDateTime", ModifiedDateTime);
            writer.WriteObjectValue<ConditionalAccessSessionControls>("sessionControls", SessionControls);
            writer.WriteEnumValue<ConditionalAccessPolicyState>("state", State);
        }
    }
}
