using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RiskyUser : Entity, IParsable {
        /// <summary>The activity related to user risk level change</summary>
        public List<RiskyUserHistoryItem> History {
            get { return BackingStore?.Get<List<RiskyUserHistoryItem>>("history"); }
            set { BackingStore?.Set("history", value); }
        }
        /// <summary>Indicates whether the user is deleted. Possible values are: true, false.</summary>
        public bool? IsDeleted {
            get { return BackingStore?.Get<bool?>("isDeleted"); }
            set { BackingStore?.Set("isDeleted", value); }
        }
        /// <summary>Indicates whether a user&apos;s risky state is being processed by the backend.</summary>
        public bool? IsProcessing {
            get { return BackingStore?.Get<bool?>("isProcessing"); }
            set { BackingStore?.Set("isProcessing", value); }
        }
        /// <summary>The possible values are none, adminGeneratedTemporaryPassword, userPerformedSecuredPasswordChange, userPerformedSecuredPasswordReset, adminConfirmedSigninSafe, aiConfirmedSigninSafe, userPassedMFADrivenByRiskBasedPolicy, adminDismissedAllRiskForUser, adminConfirmedSigninCompromised, hidden, adminConfirmedUserCompromised, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.RiskDetail? RiskDetail {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskDetail?>("riskDetail"); }
            set { BackingStore?.Set("riskDetail", value); }
        }
        /// <summary>The date and time that the risky user was last updated.  The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? RiskLastUpdatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("riskLastUpdatedDateTime"); }
            set { BackingStore?.Set("riskLastUpdatedDateTime", value); }
        }
        /// <summary>Level of the detected risky user. The possible values are low, medium, high, hidden, none, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.RiskLevel? RiskLevel {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskLevel?>("riskLevel"); }
            set { BackingStore?.Set("riskLevel", value); }
        }
        /// <summary>State of the user&apos;s risk. Possible values are: none, confirmedSafe, remediated, dismissed, atRisk, confirmedCompromised, unknownFutureValue.</summary>
        public Microsoft.Graph.Models.RiskState? RiskState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskState?>("riskState"); }
            set { BackingStore?.Set("riskState", value); }
        }
        /// <summary>Risky user display name.</summary>
        public string UserDisplayName {
            get { return BackingStore?.Get<string>("userDisplayName"); }
            set { BackingStore?.Set("userDisplayName", value); }
        }
        /// <summary>Risky user principal name.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>
        /// Instantiates a new RiskyUser and sets the default values.
        /// </summary>
        public RiskyUser() : base() {
            Type = "#microsoft.graph.riskyUser";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new RiskyUser CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.riskyUserHistoryItem" => new RiskyUserHistoryItem(),
                _ => new RiskyUser(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"history", n => { History = n.GetCollectionOfObjectValues<RiskyUserHistoryItem>(RiskyUserHistoryItem.CreateFromDiscriminatorValue).ToList(); } },
                {"isDeleted", n => { IsDeleted = n.GetBoolValue(); } },
                {"isProcessing", n => { IsProcessing = n.GetBoolValue(); } },
                {"riskDetail", n => { RiskDetail = n.GetEnumValue<RiskDetail>(); } },
                {"riskLastUpdatedDateTime", n => { RiskLastUpdatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"riskLevel", n => { RiskLevel = n.GetEnumValue<RiskLevel>(); } },
                {"riskState", n => { RiskState = n.GetEnumValue<RiskState>(); } },
                {"userDisplayName", n => { UserDisplayName = n.GetStringValue(); } },
                {"userPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<RiskyUserHistoryItem>("history", History);
            writer.WriteBoolValue("isDeleted", IsDeleted);
            writer.WriteBoolValue("isProcessing", IsProcessing);
            writer.WriteEnumValue<RiskDetail>("riskDetail", RiskDetail);
            writer.WriteDateTimeOffsetValue("riskLastUpdatedDateTime", RiskLastUpdatedDateTime);
            writer.WriteEnumValue<RiskLevel>("riskLevel", RiskLevel);
            writer.WriteEnumValue<RiskState>("riskState", RiskState);
            writer.WriteStringValue("userDisplayName", UserDisplayName);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
        }
    }
}
