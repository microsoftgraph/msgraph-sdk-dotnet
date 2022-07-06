using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EmailFileAssessmentRequest : ThreatAssessmentRequest, IParsable {
        /// <summary>Base64 encoded .eml email file content. The file content cannot fetch back because it isn&apos;t stored.</summary>
        public string ContentData {
            get { return BackingStore?.Get<string>("contentData"); }
            set { BackingStore?.Set("contentData", value); }
        }
        /// <summary>The reason for mail routed to its destination. Possible values are: none, mailFlowRule, safeSender, blockedSender, advancedSpamFiltering, domainAllowList, domainBlockList, notInAddressBook, firstTimeSender, autoPurgeToInbox, autoPurgeToJunk, autoPurgeToDeleted, outbound, notJunk, junk.</summary>
        public MailDestinationRoutingReason? DestinationRoutingReason {
            get { return BackingStore?.Get<MailDestinationRoutingReason?>("destinationRoutingReason"); }
            set { BackingStore?.Set("destinationRoutingReason", value); }
        }
        /// <summary>The mail recipient whose policies are used to assess the mail.</summary>
        public string RecipientEmail {
            get { return BackingStore?.Get<string>("recipientEmail"); }
            set { BackingStore?.Set("recipientEmail", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EmailFileAssessmentRequest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EmailFileAssessmentRequest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"contentData", n => { ContentData = n.GetStringValue(); } },
                {"destinationRoutingReason", n => { DestinationRoutingReason = n.GetEnumValue<MailDestinationRoutingReason>(); } },
                {"recipientEmail", n => { RecipientEmail = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("contentData", ContentData);
            writer.WriteEnumValue<MailDestinationRoutingReason>("destinationRoutingReason", DestinationRoutingReason);
            writer.WriteStringValue("recipientEmail", RecipientEmail);
        }
    }
}
