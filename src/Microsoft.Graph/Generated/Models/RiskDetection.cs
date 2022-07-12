using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class RiskDetection : Entity, IParsable {
        /// <summary>Indicates the activity type the detected risk is linked to. The possible values are signin, user, unknownFutureValue.</summary>
        public ActivityType? Activity {
            get { return BackingStore?.Get<ActivityType?>("activity"); }
            set { BackingStore?.Set("activity", value); }
        }
        /// <summary>Date and time that the risky activity occurred. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? ActivityDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("activityDateTime"); }
            set { BackingStore?.Set("activityDateTime", value); }
        }
        /// <summary>Additional information associated with the risk detection in JSON format.</summary>
        public string AdditionalInfo {
            get { return BackingStore?.Get<string>("additionalInfo"); }
            set { BackingStore?.Set("additionalInfo", value); }
        }
        /// <summary>Correlation ID of the sign-in associated with the risk detection. This property is null if the risk detection is not associated with a sign-in.</summary>
        public string CorrelationId {
            get { return BackingStore?.Get<string>("correlationId"); }
            set { BackingStore?.Set("correlationId", value); }
        }
        /// <summary>Date and time that the risk was detected. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? DetectedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("detectedDateTime"); }
            set { BackingStore?.Set("detectedDateTime", value); }
        }
        /// <summary>Timing of the detected risk (real-time/offline). The possible values are notDefined, realtime, nearRealtime, offline, unknownFutureValue.</summary>
        public RiskDetectionTimingType? DetectionTimingType {
            get { return BackingStore?.Get<RiskDetectionTimingType?>("detectionTimingType"); }
            set { BackingStore?.Set("detectionTimingType", value); }
        }
        /// <summary>Provides the IP address of the client from where the risk occurred.</summary>
        public string IpAddress {
            get { return BackingStore?.Get<string>("ipAddress"); }
            set { BackingStore?.Set("ipAddress", value); }
        }
        /// <summary>Date and time that the risk detection was last updated.</summary>
        public DateTimeOffset? LastUpdatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastUpdatedDateTime"); }
            set { BackingStore?.Set("lastUpdatedDateTime", value); }
        }
        /// <summary>Location of the sign-in.</summary>
        public SignInLocation Location {
            get { return BackingStore?.Get<SignInLocation>("location"); }
            set { BackingStore?.Set("location", value); }
        }
        /// <summary>Request ID of the sign-in associated with the risk detection. This property is null if the risk detection is not associated with a sign-in.</summary>
        public string RequestId {
            get { return BackingStore?.Get<string>("requestId"); }
            set { BackingStore?.Set("requestId", value); }
        }
        /// <summary>Details of the detected risk. The possible values are none, adminGeneratedTemporaryPassword, userPerformedSecuredPasswordChange, userPerformedSecuredPasswordReset, adminConfirmedSigninSafe, aiConfirmedSigninSafe, userPassedMFADrivenByRiskBasedPolicy, adminDismissedAllRiskForUser, adminConfirmedSigninCompromised, hidden, adminConfirmedUserCompromised, unknownFutureValue. Note: Details for this property are only available for Azure AD Premium P2 customers. P1 customers will be returned hidden.</summary>
        public Microsoft.Graph.Models.RiskDetail? RiskDetail {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskDetail?>("riskDetail"); }
            set { BackingStore?.Set("riskDetail", value); }
        }
        /// <summary>The type of risk event detected. The possible values are unlikelyTravel, anonymizedIPAddress, maliciousIPAddress, unfamiliarFeatures, malwareInfectedIPAddress, suspiciousIPAddress, leakedCredentials, investigationsThreatIntelligence, generic,adminConfirmedUserCompromised, mcasImpossibleTravel, mcasSuspiciousInboxManipulationRules, investigationsThreatIntelligenceSigninLinked, maliciousIPAddressValidCredentialsBlockedIP, and unknownFutureValue.  For more information about each value, see riskEventType values.</summary>
        public string RiskEventType {
            get { return BackingStore?.Get<string>("riskEventType"); }
            set { BackingStore?.Set("riskEventType", value); }
        }
        /// <summary>Level of the detected risk. The possible values are low, medium, high, hidden, none, unknownFutureValue. Note: Details for this property are only available for Azure AD Premium P2 customers. P1 customers will be returned hidden.</summary>
        public Microsoft.Graph.Models.RiskLevel? RiskLevel {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskLevel?>("riskLevel"); }
            set { BackingStore?.Set("riskLevel", value); }
        }
        /// <summary>The state of a detected risky user or sign-in. The possible values are none, confirmedSafe, remediated, dismissed, atRisk, confirmedCompromised, and unknownFutureValue.</summary>
        public Microsoft.Graph.Models.RiskState? RiskState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskState?>("riskState"); }
            set { BackingStore?.Set("riskState", value); }
        }
        /// <summary>Source of the risk detection. For example, activeDirectory.</summary>
        public string Source {
            get { return BackingStore?.Get<string>("source"); }
            set { BackingStore?.Set("source", value); }
        }
        /// <summary>Indicates the type of token issuer for the detected sign-in risk. The possible values are AzureAD, ADFederationServices, and unknownFutureValue.</summary>
        public Microsoft.Graph.Models.TokenIssuerType? TokenIssuerType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.TokenIssuerType?>("tokenIssuerType"); }
            set { BackingStore?.Set("tokenIssuerType", value); }
        }
        /// <summary>Name of the user.</summary>
        public string UserDisplayName {
            get { return BackingStore?.Get<string>("userDisplayName"); }
            set { BackingStore?.Set("userDisplayName", value); }
        }
        /// <summary>Unique ID of the user.  The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public string UserId {
            get { return BackingStore?.Get<string>("userId"); }
            set { BackingStore?.Set("userId", value); }
        }
        /// <summary>The user principal name (UPN) of the user.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new RiskDetection CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RiskDetection();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"activity", n => { Activity = n.GetEnumValue<ActivityType>(); } },
                {"activityDateTime", n => { ActivityDateTime = n.GetDateTimeOffsetValue(); } },
                {"additionalInfo", n => { AdditionalInfo = n.GetStringValue(); } },
                {"correlationId", n => { CorrelationId = n.GetStringValue(); } },
                {"detectedDateTime", n => { DetectedDateTime = n.GetDateTimeOffsetValue(); } },
                {"detectionTimingType", n => { DetectionTimingType = n.GetEnumValue<RiskDetectionTimingType>(); } },
                {"ipAddress", n => { IpAddress = n.GetStringValue(); } },
                {"lastUpdatedDateTime", n => { LastUpdatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"location", n => { Location = n.GetObjectValue<SignInLocation>(SignInLocation.CreateFromDiscriminatorValue); } },
                {"requestId", n => { RequestId = n.GetStringValue(); } },
                {"riskDetail", n => { RiskDetail = n.GetEnumValue<RiskDetail>(); } },
                {"riskEventType", n => { RiskEventType = n.GetStringValue(); } },
                {"riskLevel", n => { RiskLevel = n.GetEnumValue<RiskLevel>(); } },
                {"riskState", n => { RiskState = n.GetEnumValue<RiskState>(); } },
                {"source", n => { Source = n.GetStringValue(); } },
                {"tokenIssuerType", n => { TokenIssuerType = n.GetEnumValue<TokenIssuerType>(); } },
                {"userDisplayName", n => { UserDisplayName = n.GetStringValue(); } },
                {"userId", n => { UserId = n.GetStringValue(); } },
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
            writer.WriteEnumValue<ActivityType>("activity", Activity);
            writer.WriteDateTimeOffsetValue("activityDateTime", ActivityDateTime);
            writer.WriteStringValue("additionalInfo", AdditionalInfo);
            writer.WriteStringValue("correlationId", CorrelationId);
            writer.WriteDateTimeOffsetValue("detectedDateTime", DetectedDateTime);
            writer.WriteEnumValue<RiskDetectionTimingType>("detectionTimingType", DetectionTimingType);
            writer.WriteStringValue("ipAddress", IpAddress);
            writer.WriteDateTimeOffsetValue("lastUpdatedDateTime", LastUpdatedDateTime);
            writer.WriteObjectValue<SignInLocation>("location", Location);
            writer.WriteStringValue("requestId", RequestId);
            writer.WriteEnumValue<RiskDetail>("riskDetail", RiskDetail);
            writer.WriteStringValue("riskEventType", RiskEventType);
            writer.WriteEnumValue<RiskLevel>("riskLevel", RiskLevel);
            writer.WriteEnumValue<RiskState>("riskState", RiskState);
            writer.WriteStringValue("source", Source);
            writer.WriteEnumValue<TokenIssuerType>("tokenIssuerType", TokenIssuerType);
            writer.WriteStringValue("userDisplayName", UserDisplayName);
            writer.WriteStringValue("userId", UserId);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
        }
    }
}
