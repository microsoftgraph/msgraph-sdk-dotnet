using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the admin singleton.</summary>
    public class MessageRule : Entity, IParsable {
        /// <summary>Actions to be taken on a message when the corresponding conditions are fulfilled.</summary>
        public MessageRuleActions Actions {
            get { return BackingStore?.Get<MessageRuleActions>("actions"); }
            set { BackingStore?.Set("actions", value); }
        }
        /// <summary>Conditions that when fulfilled, will trigger the corresponding actions for that rule.</summary>
        public MessageRulePredicates Conditions {
            get { return BackingStore?.Get<MessageRulePredicates>("conditions"); }
            set { BackingStore?.Set("conditions", value); }
        }
        /// <summary>The display name of the rule.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Exception conditions for the rule.</summary>
        public MessageRulePredicates Exceptions {
            get { return BackingStore?.Get<MessageRulePredicates>("exceptions"); }
            set { BackingStore?.Set("exceptions", value); }
        }
        /// <summary>Indicates whether the rule is in an error condition. Read-only.</summary>
        public bool? HasError {
            get { return BackingStore?.Get<bool?>("hasError"); }
            set { BackingStore?.Set("hasError", value); }
        }
        /// <summary>Indicates whether the rule is enabled to be applied to messages.</summary>
        public bool? IsEnabled {
            get { return BackingStore?.Get<bool?>("isEnabled"); }
            set { BackingStore?.Set("isEnabled", value); }
        }
        /// <summary>Indicates if the rule is read-only and cannot be modified or deleted by the rules REST API.</summary>
        public bool? IsReadOnly {
            get { return BackingStore?.Get<bool?>("isReadOnly"); }
            set { BackingStore?.Set("isReadOnly", value); }
        }
        /// <summary>Indicates the order in which the rule is executed, among other rules.</summary>
        public int? Sequence {
            get { return BackingStore?.Get<int?>("sequence"); }
            set { BackingStore?.Set("sequence", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MessageRule CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MessageRule();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"actions", n => { Actions = n.GetObjectValue<MessageRuleActions>(MessageRuleActions.CreateFromDiscriminatorValue); } },
                {"conditions", n => { Conditions = n.GetObjectValue<MessageRulePredicates>(MessageRulePredicates.CreateFromDiscriminatorValue); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"exceptions", n => { Exceptions = n.GetObjectValue<MessageRulePredicates>(MessageRulePredicates.CreateFromDiscriminatorValue); } },
                {"hasError", n => { HasError = n.GetBoolValue(); } },
                {"isEnabled", n => { IsEnabled = n.GetBoolValue(); } },
                {"isReadOnly", n => { IsReadOnly = n.GetBoolValue(); } },
                {"sequence", n => { Sequence = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<MessageRuleActions>("actions", Actions);
            writer.WriteObjectValue<MessageRulePredicates>("conditions", Conditions);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<MessageRulePredicates>("exceptions", Exceptions);
            writer.WriteBoolValue("hasError", HasError);
            writer.WriteBoolValue("isEnabled", IsEnabled);
            writer.WriteBoolValue("isReadOnly", IsReadOnly);
            writer.WriteIntValue("sequence", Sequence);
        }
    }
}
