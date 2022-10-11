using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class SignIn : Entity, IParsable {
        /// <summary>App name displayed in the Azure Portal. Supports $filter (eq and startsWith operators only).</summary>
        public string AppDisplayName {
            get { return BackingStore?.Get<string>("appDisplayName"); }
            set { BackingStore?.Set("appDisplayName", value); }
        }
        /// <summary>Unique GUID representing the app ID in the Azure Active Directory. Supports $filter (eq operator only).</summary>
        public string AppId {
            get { return BackingStore?.Get<string>("appId"); }
            set { BackingStore?.Set("appId", value); }
        }
        /// <summary>The appliedConditionalAccessPolicies property</summary>
        public List<AppliedConditionalAccessPolicy> AppliedConditionalAccessPolicies {
            get { return BackingStore?.Get<List<AppliedConditionalAccessPolicy>>("appliedConditionalAccessPolicies"); }
            set { BackingStore?.Set("appliedConditionalAccessPolicies", value); }
        }
        /// <summary>Identifies the client used for the sign-in activity. Modern authentication clients include Browser and modern clients. Legacy authentication clients include Exchange ActiveSync, IMAP, MAPI, SMTP, POP, and other clients. Supports $filter (eq operator only).</summary>
        public string ClientAppUsed {
            get { return BackingStore?.Get<string>("clientAppUsed"); }
            set { BackingStore?.Set("clientAppUsed", value); }
        }
        /// <summary>Reports status of an activated conditional access policy. Possible values are: success, failure, notApplied, and unknownFutureValue. Supports $filter (eq operator only).</summary>
        public Microsoft.Graph.Models.ConditionalAccessStatus? ConditionalAccessStatus {
            get { return BackingStore?.Get<Microsoft.Graph.Models.ConditionalAccessStatus?>("conditionalAccessStatus"); }
            set { BackingStore?.Set("conditionalAccessStatus", value); }
        }
        /// <summary>The request ID sent from the client when the sign-in is initiated; used to troubleshoot sign-in activity. Supports $filter (eq operator only).</summary>
        public string CorrelationId {
            get { return BackingStore?.Get<string>("correlationId"); }
            set { BackingStore?.Set("correlationId", value); }
        }
        /// <summary>Date and time (UTC) the sign-in was initiated. Example: midnight on Jan 1, 2014 is reported as 2014-01-01T00:00:00Z. Supports $orderby and $filter (eq, le, and ge operators only).</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Device information from where the sign-in occurred; includes device ID, operating system, and browser. Supports $filter (eq and startsWith operators only) on browser and operatingSytem properties.</summary>
        public Microsoft.Graph.Models.DeviceDetail DeviceDetail {
            get { return BackingStore?.Get<Microsoft.Graph.Models.DeviceDetail>("deviceDetail"); }
            set { BackingStore?.Set("deviceDetail", value); }
        }
        /// <summary>IP address of the client used to sign in. Supports $filter (eq and startsWith operators only).</summary>
        public string IpAddress {
            get { return BackingStore?.Get<string>("ipAddress"); }
            set { BackingStore?.Set("ipAddress", value); }
        }
        /// <summary>Indicates if a sign-in is interactive or not.</summary>
        public bool? IsInteractive {
            get { return BackingStore?.Get<bool?>("isInteractive"); }
            set { BackingStore?.Set("isInteractive", value); }
        }
        /// <summary>Provides the city, state, and country code where the sign-in originated. Supports $filter (eq and startsWith operators only) on city, state, and countryOrRegion properties.</summary>
        public SignInLocation Location {
            get { return BackingStore?.Get<SignInLocation>("location"); }
            set { BackingStore?.Set("location", value); }
        }
        /// <summary>Name of the resource the user signed into. Supports $filter (eq operator only).</summary>
        public string ResourceDisplayName {
            get { return BackingStore?.Get<string>("resourceDisplayName"); }
            set { BackingStore?.Set("resourceDisplayName", value); }
        }
        /// <summary>ID of the resource that the user signed into. Supports $filter (eq operator only).</summary>
        public string ResourceId {
            get { return BackingStore?.Get<string>("resourceId"); }
            set { BackingStore?.Set("resourceId", value); }
        }
        /// <summary>Provides the &apos;reason&apos; behind a specific state of a risky user, sign-in or a risk event. The possible values are: none, adminGeneratedTemporaryPassword, userPerformedSecuredPasswordChange, userPerformedSecuredPasswordReset, adminConfirmedSigninSafe, aiConfirmedSigninSafe, userPassedMFADrivenByRiskBasedPolicy, adminDismissedAllRiskForUser, adminConfirmedSigninCompromised, unknownFutureValue. The value none means that no action has been performed on the user or sign-in so far.  Supports $filter (eq operator only).Note: Details for this property require an Azure AD Premium P2 license. Other licenses return the value hidden.</summary>
        public Microsoft.Graph.Models.RiskDetail? RiskDetail {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskDetail?>("riskDetail"); }
            set { BackingStore?.Set("riskDetail", value); }
        }
        /// <summary>Risk event types associated with the sign-in. The possible values are: unlikelyTravel, anonymizedIPAddress, maliciousIPAddress, unfamiliarFeatures, malwareInfectedIPAddress, suspiciousIPAddress, leakedCredentials, investigationsThreatIntelligence,  generic, and unknownFutureValue. Supports $filter (eq operator only).</summary>
        public List<RiskEventType?> RiskEventTypes {
            get { return BackingStore?.Get<List<RiskEventType?>>("riskEventTypes"); }
            set { BackingStore?.Set("riskEventTypes", value); }
        }
        /// <summary>The list of risk event types associated with the sign-in. Possible values: unlikelyTravel, anonymizedIPAddress, maliciousIPAddress, unfamiliarFeatures, malwareInfectedIPAddress, suspiciousIPAddress, leakedCredentials, investigationsThreatIntelligence,  generic, or unknownFutureValue. Supports $filter (eq and startsWith operators only).</summary>
        public List<string> RiskEventTypes_v2 {
            get { return BackingStore?.Get<List<string>>("riskEventTypes_v2"); }
            set { BackingStore?.Set("riskEventTypes_v2", value); }
        }
        /// <summary>Aggregated risk level. The possible values are: none, low, medium, high, hidden, and unknownFutureValue. The value hidden means the user or sign-in was not enabled for Azure AD Identity Protection. Supports $filter (eq operator only).  Note: Details for this property are only available for Azure AD Premium P2 customers. All other customers will be returned hidden.</summary>
        public RiskLevel? RiskLevelAggregated {
            get { return BackingStore?.Get<RiskLevel?>("riskLevelAggregated"); }
            set { BackingStore?.Set("riskLevelAggregated", value); }
        }
        /// <summary>Risk level during sign-in. The possible values are: none, low, medium, high, hidden, and unknownFutureValue. The value hidden means the user or sign-in was not enabled for Azure AD Identity Protection.  Supports $filter (eq operator only). Note: Details for this property are only available for Azure AD Premium P2 customers. All other customers will be returned hidden.</summary>
        public RiskLevel? RiskLevelDuringSignIn {
            get { return BackingStore?.Get<RiskLevel?>("riskLevelDuringSignIn"); }
            set { BackingStore?.Set("riskLevelDuringSignIn", value); }
        }
        /// <summary>Reports status of the risky user, sign-in, or a risk event. The possible values are: none, confirmedSafe, remediated, dismissed, atRisk, confirmedCompromised, unknownFutureValue. Supports $filter (eq operator only).</summary>
        public Microsoft.Graph.Models.RiskState? RiskState {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RiskState?>("riskState"); }
            set { BackingStore?.Set("riskState", value); }
        }
        /// <summary>Sign-in status. Includes the error code and description of the error (in case of a sign-in failure). Supports $filter (eq operator only) on errorCode property.</summary>
        public SignInStatus Status {
            get { return BackingStore?.Get<SignInStatus>("status"); }
            set { BackingStore?.Set("status", value); }
        }
        /// <summary>Display name of the user that initiated the sign-in. Supports $filter (eq and startsWith operators only).</summary>
        public string UserDisplayName {
            get { return BackingStore?.Get<string>("userDisplayName"); }
            set { BackingStore?.Set("userDisplayName", value); }
        }
        /// <summary>ID of the user that initiated the sign-in. Supports $filter (eq operator only).</summary>
        public string UserId {
            get { return BackingStore?.Get<string>("userId"); }
            set { BackingStore?.Set("userId", value); }
        }
        /// <summary>User principal name of the user that initiated the sign-in. Supports $filter (eq and startsWith operators only).</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>
        /// Instantiates a new signIn and sets the default values.
        /// </summary>
        public SignIn() : base() {
            OdataType = "#microsoft.graph.signIn";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new SignIn CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SignIn();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appDisplayName", n => { AppDisplayName = n.GetStringValue(); } },
                {"appId", n => { AppId = n.GetStringValue(); } },
                {"appliedConditionalAccessPolicies", n => { AppliedConditionalAccessPolicies = n.GetCollectionOfObjectValues<AppliedConditionalAccessPolicy>(AppliedConditionalAccessPolicy.CreateFromDiscriminatorValue)?.ToList(); } },
                {"clientAppUsed", n => { ClientAppUsed = n.GetStringValue(); } },
                {"conditionalAccessStatus", n => { ConditionalAccessStatus = n.GetEnumValue<ConditionalAccessStatus>(); } },
                {"correlationId", n => { CorrelationId = n.GetStringValue(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"deviceDetail", n => { DeviceDetail = n.GetObjectValue<Microsoft.Graph.Models.DeviceDetail>(Microsoft.Graph.Models.DeviceDetail.CreateFromDiscriminatorValue); } },
                {"ipAddress", n => { IpAddress = n.GetStringValue(); } },
                {"isInteractive", n => { IsInteractive = n.GetBoolValue(); } },
                {"location", n => { Location = n.GetObjectValue<SignInLocation>(SignInLocation.CreateFromDiscriminatorValue); } },
                {"resourceDisplayName", n => { ResourceDisplayName = n.GetStringValue(); } },
                {"resourceId", n => { ResourceId = n.GetStringValue(); } },
                {"riskDetail", n => { RiskDetail = n.GetEnumValue<RiskDetail>(); } },
                {"riskEventTypes", n => { RiskEventTypes = n.GetCollectionOfEnumValues<RiskEventType>()?.ToList(); } },
                {"riskEventTypes_v2", n => { RiskEventTypes_v2 = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"riskLevelAggregated", n => { RiskLevelAggregated = n.GetEnumValue<RiskLevel>(); } },
                {"riskLevelDuringSignIn", n => { RiskLevelDuringSignIn = n.GetEnumValue<RiskLevel>(); } },
                {"riskState", n => { RiskState = n.GetEnumValue<RiskState>(); } },
                {"status", n => { Status = n.GetObjectValue<SignInStatus>(SignInStatus.CreateFromDiscriminatorValue); } },
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
            writer.WriteStringValue("appDisplayName", AppDisplayName);
            writer.WriteStringValue("appId", AppId);
            writer.WriteCollectionOfObjectValues<AppliedConditionalAccessPolicy>("appliedConditionalAccessPolicies", AppliedConditionalAccessPolicies);
            writer.WriteStringValue("clientAppUsed", ClientAppUsed);
            writer.WriteEnumValue<ConditionalAccessStatus>("conditionalAccessStatus", ConditionalAccessStatus);
            writer.WriteStringValue("correlationId", CorrelationId);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<Microsoft.Graph.Models.DeviceDetail>("deviceDetail", DeviceDetail);
            writer.WriteStringValue("ipAddress", IpAddress);
            writer.WriteBoolValue("isInteractive", IsInteractive);
            writer.WriteObjectValue<SignInLocation>("location", Location);
            writer.WriteStringValue("resourceDisplayName", ResourceDisplayName);
            writer.WriteStringValue("resourceId", ResourceId);
            writer.WriteEnumValue<RiskDetail>("riskDetail", RiskDetail);
            writer.WriteCollectionOfEnumValues<RiskEventType>("riskEventTypes", RiskEventTypes);
            writer.WriteCollectionOfPrimitiveValues<string>("riskEventTypes_v2", RiskEventTypes_v2);
            writer.WriteEnumValue<RiskLevel>("riskLevelAggregated", RiskLevelAggregated);
            writer.WriteEnumValue<RiskLevel>("riskLevelDuringSignIn", RiskLevelDuringSignIn);
            writer.WriteEnumValue<RiskState>("riskState", RiskState);
            writer.WriteObjectValue<SignInStatus>("status", Status);
            writer.WriteStringValue("userDisplayName", UserDisplayName);
            writer.WriteStringValue("userId", UserId);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
        }
    }
}
