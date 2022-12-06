using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class ConditionalAccessConditionSet : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>Applications and user actions included in and excluded from the policy. Required.</summary>
        public ConditionalAccessApplications Applications {
            get { return BackingStore?.Get<ConditionalAccessApplications>("applications"); }
            set { BackingStore?.Set("applications", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>Client applications (service principals and workload identities) included in and excluded from the policy. Either users or clientApplications is required.</summary>
        public ConditionalAccessClientApplications ClientApplications {
            get { return BackingStore?.Get<ConditionalAccessClientApplications>("clientApplications"); }
            set { BackingStore?.Set("clientApplications", value); }
        }
        /// <summary>Client application types included in the policy. Possible values are: all, browser, mobileAppsAndDesktopClients, exchangeActiveSync, easSupported, other. Required.</summary>
        public List<ConditionalAccessClientApp?> ClientAppTypes {
            get { return BackingStore?.Get<List<ConditionalAccessClientApp?>>("clientAppTypes"); }
            set { BackingStore?.Set("clientAppTypes", value); }
        }
        /// <summary>Devices in the policy.</summary>
        public ConditionalAccessDevices Devices {
            get { return BackingStore?.Get<ConditionalAccessDevices>("devices"); }
            set { BackingStore?.Set("devices", value); }
        }
        /// <summary>Locations included in and excluded from the policy.</summary>
        public ConditionalAccessLocations Locations {
            get { return BackingStore?.Get<ConditionalAccessLocations>("locations"); }
            set { BackingStore?.Set("locations", value); }
        }
        /// <summary>The OdataType property</summary>
        public string OdataType {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
        /// <summary>Platforms included in and excluded from the policy.</summary>
        public ConditionalAccessPlatforms Platforms {
            get { return BackingStore?.Get<ConditionalAccessPlatforms>("platforms"); }
            set { BackingStore?.Set("platforms", value); }
        }
        /// <summary>Service principal risk levels included in the policy. Possible values are: low, medium, high, none, unknownFutureValue.</summary>
        public List<RiskLevel?> ServicePrincipalRiskLevels {
            get { return BackingStore?.Get<List<RiskLevel?>>("servicePrincipalRiskLevels"); }
            set { BackingStore?.Set("servicePrincipalRiskLevels", value); }
        }
        /// <summary>Sign-in risk levels included in the policy. Possible values are: low, medium, high, hidden, none, unknownFutureValue. Required.</summary>
        public List<RiskLevel?> SignInRiskLevels {
            get { return BackingStore?.Get<List<RiskLevel?>>("signInRiskLevels"); }
            set { BackingStore?.Set("signInRiskLevels", value); }
        }
        /// <summary>User risk levels included in the policy. Possible values are: low, medium, high, hidden, none, unknownFutureValue. Required.</summary>
        public List<RiskLevel?> UserRiskLevels {
            get { return BackingStore?.Get<List<RiskLevel?>>("userRiskLevels"); }
            set { BackingStore?.Set("userRiskLevels", value); }
        }
        /// <summary>Users, groups, and roles included in and excluded from the policy. Either users or clientApplications is required.</summary>
        public ConditionalAccessUsers Users {
            get { return BackingStore?.Get<ConditionalAccessUsers>("users"); }
            set { BackingStore?.Set("users", value); }
        }
        /// <summary>
        /// Instantiates a new conditionalAccessConditionSet and sets the default values.
        /// </summary>
        public ConditionalAccessConditionSet() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ConditionalAccessConditionSet CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ConditionalAccessConditionSet();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"applications", n => { Applications = n.GetObjectValue<ConditionalAccessApplications>(ConditionalAccessApplications.CreateFromDiscriminatorValue); } },
                {"clientApplications", n => { ClientApplications = n.GetObjectValue<ConditionalAccessClientApplications>(ConditionalAccessClientApplications.CreateFromDiscriminatorValue); } },
                {"clientAppTypes", n => { ClientAppTypes = n.GetCollectionOfEnumValues<ConditionalAccessClientApp>()?.ToList(); } },
                {"devices", n => { Devices = n.GetObjectValue<ConditionalAccessDevices>(ConditionalAccessDevices.CreateFromDiscriminatorValue); } },
                {"locations", n => { Locations = n.GetObjectValue<ConditionalAccessLocations>(ConditionalAccessLocations.CreateFromDiscriminatorValue); } },
                {"@odata.type", n => { OdataType = n.GetStringValue(); } },
                {"platforms", n => { Platforms = n.GetObjectValue<ConditionalAccessPlatforms>(ConditionalAccessPlatforms.CreateFromDiscriminatorValue); } },
                {"servicePrincipalRiskLevels", n => { ServicePrincipalRiskLevels = n.GetCollectionOfEnumValues<RiskLevel>()?.ToList(); } },
                {"signInRiskLevels", n => { SignInRiskLevels = n.GetCollectionOfEnumValues<RiskLevel>()?.ToList(); } },
                {"userRiskLevels", n => { UserRiskLevels = n.GetCollectionOfEnumValues<RiskLevel>()?.ToList(); } },
                {"users", n => { Users = n.GetObjectValue<ConditionalAccessUsers>(ConditionalAccessUsers.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ConditionalAccessApplications>("applications", Applications);
            writer.WriteObjectValue<ConditionalAccessClientApplications>("clientApplications", ClientApplications);
            writer.WriteCollectionOfEnumValues<ConditionalAccessClientApp>("clientAppTypes", ClientAppTypes);
            writer.WriteObjectValue<ConditionalAccessDevices>("devices", Devices);
            writer.WriteObjectValue<ConditionalAccessLocations>("locations", Locations);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteObjectValue<ConditionalAccessPlatforms>("platforms", Platforms);
            writer.WriteCollectionOfEnumValues<RiskLevel>("servicePrincipalRiskLevels", ServicePrincipalRiskLevels);
            writer.WriteCollectionOfEnumValues<RiskLevel>("signInRiskLevels", SignInRiskLevels);
            writer.WriteCollectionOfEnumValues<RiskLevel>("userRiskLevels", UserRiskLevels);
            writer.WriteObjectValue<ConditionalAccessUsers>("users", Users);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
