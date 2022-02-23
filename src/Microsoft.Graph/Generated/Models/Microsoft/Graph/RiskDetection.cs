using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class RiskDetection : Entity, IParsable {
        /// <summary>Indicates the activity type the detected risk is linked to. . Possible values are: signin, user, unknownFutureValue.</summary>
        public ActivityType? Activity { get; set; }
        /// <summary>Date and time that the risky activity occurred. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is look like this: 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? ActivityDateTime { get; set; }
        /// <summary>Additional information associated with the risk detection in JSON format.</summary>
        public string AdditionalInfo { get; set; }
        /// <summary>Correlation ID of the sign-in associated with the risk detection. This property is null if the risk detection is not associated with a sign-in.</summary>
        public string CorrelationId { get; set; }
        /// <summary>Date and time that the risk was detected. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is look like this: 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? DetectedDateTime { get; set; }
        /// <summary>Timing of the detected risk (real-time/offline). Possible values are: notDefined, realtime, nearRealtime, offline, unknownFutureValue.</summary>
        public RiskDetectionTimingType? DetectionTimingType { get; set; }
        /// <summary>Provides the IP address of the client from where the risk occurred.</summary>
        public string IpAddress { get; set; }
        /// <summary>Date and time that the risk detection was last updated. The DateTimeOffset type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is look like this: 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? LastUpdatedDateTime { get; set; }
        /// <summary>Location of the sign-in.</summary>
        public SignInLocation Location { get; set; }
        /// <summary>Request ID of the sign-in associated with the risk detection. This property is null if the risk detection is not associated with a sign-in.</summary>
        public string RequestId { get; set; }
        /// <summary>Details of the detected risk. Possible values are: none, adminGeneratedTemporaryPassword, userPerformedSecuredPasswordChange, userPerformedSecuredPasswordReset, adminConfirmedSigninSafe, aiConfirmedSigninSafe, userPassedMFADrivenByRiskBasedPolicy, adminDismissedAllRiskForUser, adminConfirmedSigninCompromised, hidden, adminConfirmedUserCompromised, unknownFutureValue.</summary>
        public RiskDetail? RiskDetail { get; set; }
        /// <summary>The type of risk event detected. The possible values are unlikelyTravel, anonymizedIPAddress, maliciousIPAddress, unfamiliarFeatures, malwareInfectedIPAddress, suspiciousIPAddress, leakedCredentials, investigationsThreatIntelligence, generic,adminConfirmedUserCompromised, mcasImpossibleTravel, mcasSuspiciousInboxManipulationRules, investigationsThreatIntelligenceSigninLinked, maliciousIPAddressValidCredentialsBlockedIP, and unknownFutureValue. If the risk detection is a premium detection, will show generic. For more information about each value, see riskEventType values.</summary>
        public string RiskEventType { get; set; }
        /// <summary>Level of the detected risk. Possible values are: low, medium, high, hidden, none, unknownFutureValue.</summary>
        public RiskLevel? RiskLevel { get; set; }
        /// <summary>The state of a detected risky user or sign-in. Possible values are: none, confirmedSafe, remediated, dismissed, atRisk, confirmedCompromised, unknownFutureValue.</summary>
        public RiskState? RiskState { get; set; }
        /// <summary>Source of the risk detection. For example, activeDirectory.</summary>
        public string Source { get; set; }
        /// <summary>Indicates the type of token issuer for the detected sign-in risk. Possible values are: AzureAD, ADFederationServices, UnknownFutureValue.</summary>
        public TokenIssuerType? TokenIssuerType { get; set; }
        /// <summary>The user principal name (UPN) of the user.</summary>
        public string UserDisplayName { get; set; }
        /// <summary>Unique ID of the user.</summary>
        public string UserId { get; set; }
        /// <summary>The user principal name (UPN) of the user.</summary>
        public string UserPrincipalName { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"activity", (o,n) => { (o as RiskDetection).Activity = n.GetEnumValue<ActivityType>(); } },
                {"activityDateTime", (o,n) => { (o as RiskDetection).ActivityDateTime = n.GetDateTimeOffsetValue(); } },
                {"additionalInfo", (o,n) => { (o as RiskDetection).AdditionalInfo = n.GetStringValue(); } },
                {"correlationId", (o,n) => { (o as RiskDetection).CorrelationId = n.GetStringValue(); } },
                {"detectedDateTime", (o,n) => { (o as RiskDetection).DetectedDateTime = n.GetDateTimeOffsetValue(); } },
                {"detectionTimingType", (o,n) => { (o as RiskDetection).DetectionTimingType = n.GetEnumValue<RiskDetectionTimingType>(); } },
                {"ipAddress", (o,n) => { (o as RiskDetection).IpAddress = n.GetStringValue(); } },
                {"lastUpdatedDateTime", (o,n) => { (o as RiskDetection).LastUpdatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"location", (o,n) => { (o as RiskDetection).Location = n.GetObjectValue<SignInLocation>(); } },
                {"requestId", (o,n) => { (o as RiskDetection).RequestId = n.GetStringValue(); } },
                {"riskDetail", (o,n) => { (o as RiskDetection).RiskDetail = n.GetEnumValue<RiskDetail>(); } },
                {"riskEventType", (o,n) => { (o as RiskDetection).RiskEventType = n.GetStringValue(); } },
                {"riskLevel", (o,n) => { (o as RiskDetection).RiskLevel = n.GetEnumValue<RiskLevel>(); } },
                {"riskState", (o,n) => { (o as RiskDetection).RiskState = n.GetEnumValue<RiskState>(); } },
                {"source", (o,n) => { (o as RiskDetection).Source = n.GetStringValue(); } },
                {"tokenIssuerType", (o,n) => { (o as RiskDetection).TokenIssuerType = n.GetEnumValue<TokenIssuerType>(); } },
                {"userDisplayName", (o,n) => { (o as RiskDetection).UserDisplayName = n.GetStringValue(); } },
                {"userId", (o,n) => { (o as RiskDetection).UserId = n.GetStringValue(); } },
                {"userPrincipalName", (o,n) => { (o as RiskDetection).UserPrincipalName = n.GetStringValue(); } },
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
