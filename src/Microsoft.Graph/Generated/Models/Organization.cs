using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of organization entities.</summary>
    public class Organization : DirectoryObject, IParsable {
        /// <summary>The collection of service plans associated with the tenant. Not nullable.</summary>
        public List<AssignedPlan> AssignedPlans {
            get { return BackingStore?.Get<List<AssignedPlan>>(nameof(AssignedPlans)); }
            set { BackingStore?.Set(nameof(AssignedPlans), value); }
        }
        /// <summary>Resource to manage the default branding for the organization. Nullable.</summary>
        public OrganizationalBranding Branding {
            get { return BackingStore?.Get<OrganizationalBranding>(nameof(Branding)); }
            set { BackingStore?.Set(nameof(Branding), value); }
        }
        /// <summary>Telephone number for the organization. Although this is a string collection, only one number can be set for this property.</summary>
        public List<string> BusinessPhones {
            get { return BackingStore?.Get<List<string>>(nameof(BusinessPhones)); }
            set { BackingStore?.Set(nameof(BusinessPhones), value); }
        }
        /// <summary>Navigation property to manage certificate-based authentication configuration. Only a single instance of certificateBasedAuthConfiguration can be created in the collection.</summary>
        public List<Microsoft.Graph.Models.CertificateBasedAuthConfiguration> CertificateBasedAuthConfiguration {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.CertificateBasedAuthConfiguration>>(nameof(CertificateBasedAuthConfiguration)); }
            set { BackingStore?.Set(nameof(CertificateBasedAuthConfiguration), value); }
        }
        /// <summary>City name of the address for the organization.</summary>
        public string City {
            get { return BackingStore?.Get<string>(nameof(City)); }
            set { BackingStore?.Set(nameof(City), value); }
        }
        /// <summary>Country/region name of the address for the organization.</summary>
        public string Country {
            get { return BackingStore?.Get<string>(nameof(Country)); }
            set { BackingStore?.Set(nameof(Country), value); }
        }
        /// <summary>Country or region abbreviation for the organization in ISO 3166-2 format.</summary>
        public string CountryLetterCode {
            get { return BackingStore?.Get<string>(nameof(CountryLetterCode)); }
            set { BackingStore?.Set(nameof(CountryLetterCode), value); }
        }
        /// <summary>Timestamp of when the organization was created. The value cannot be modified and is automatically populated when the organization is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>(nameof(CreatedDateTime)); }
            set { BackingStore?.Set(nameof(CreatedDateTime), value); }
        }
        /// <summary>The display name for the tenant.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>(nameof(DisplayName)); }
            set { BackingStore?.Set(nameof(DisplayName), value); }
        }
        /// <summary>The collection of open extensions defined for the organization resource. Nullable.</summary>
        public List<Extension> Extensions {
            get { return BackingStore?.Get<List<Extension>>(nameof(Extensions)); }
            set { BackingStore?.Set(nameof(Extensions), value); }
        }
        /// <summary>Not nullable.</summary>
        public List<string> MarketingNotificationEmails {
            get { return BackingStore?.Get<List<string>>(nameof(MarketingNotificationEmails)); }
            set { BackingStore?.Set(nameof(MarketingNotificationEmails), value); }
        }
        /// <summary>Mobile device management authority. Possible values are: unknown, intune, sccm, office365.</summary>
        public MdmAuthority? MobileDeviceManagementAuthority {
            get { return BackingStore?.Get<MdmAuthority?>(nameof(MobileDeviceManagementAuthority)); }
            set { BackingStore?.Set(nameof(MobileDeviceManagementAuthority), value); }
        }
        /// <summary>The time and date at which the tenant was last synced with the on-premises directory. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? OnPremisesLastSyncDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>(nameof(OnPremisesLastSyncDateTime)); }
            set { BackingStore?.Set(nameof(OnPremisesLastSyncDateTime), value); }
        }
        /// <summary>true if this object is synced from an on-premises directory; false if this object was originally synced from an on-premises directory but is no longer synced; Nullable. null if this object has never been synced from an on-premises directory (default).</summary>
        public bool? OnPremisesSyncEnabled {
            get { return BackingStore?.Get<bool?>(nameof(OnPremisesSyncEnabled)); }
            set { BackingStore?.Set(nameof(OnPremisesSyncEnabled), value); }
        }
        /// <summary>Postal code of the address for the organization.</summary>
        public string PostalCode {
            get { return BackingStore?.Get<string>(nameof(PostalCode)); }
            set { BackingStore?.Set(nameof(PostalCode), value); }
        }
        /// <summary>The preferred language for the organization. Should follow ISO 639-1 Code; for example en.</summary>
        public string PreferredLanguage {
            get { return BackingStore?.Get<string>(nameof(PreferredLanguage)); }
            set { BackingStore?.Set(nameof(PreferredLanguage), value); }
        }
        /// <summary>The privacy profile of an organization.</summary>
        public Microsoft.Graph.Models.PrivacyProfile PrivacyProfile {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PrivacyProfile>(nameof(PrivacyProfile)); }
            set { BackingStore?.Set(nameof(PrivacyProfile), value); }
        }
        /// <summary>Not nullable.</summary>
        public List<ProvisionedPlan> ProvisionedPlans {
            get { return BackingStore?.Get<List<ProvisionedPlan>>(nameof(ProvisionedPlans)); }
            set { BackingStore?.Set(nameof(ProvisionedPlans), value); }
        }
        /// <summary>The securityComplianceNotificationMails property</summary>
        public List<string> SecurityComplianceNotificationMails {
            get { return BackingStore?.Get<List<string>>(nameof(SecurityComplianceNotificationMails)); }
            set { BackingStore?.Set(nameof(SecurityComplianceNotificationMails), value); }
        }
        /// <summary>The securityComplianceNotificationPhones property</summary>
        public List<string> SecurityComplianceNotificationPhones {
            get { return BackingStore?.Get<List<string>>(nameof(SecurityComplianceNotificationPhones)); }
            set { BackingStore?.Set(nameof(SecurityComplianceNotificationPhones), value); }
        }
        /// <summary>State name of the address for the organization.</summary>
        public string State {
            get { return BackingStore?.Get<string>(nameof(State)); }
            set { BackingStore?.Set(nameof(State), value); }
        }
        /// <summary>Street name of the address for organization.</summary>
        public string Street {
            get { return BackingStore?.Get<string>(nameof(Street)); }
            set { BackingStore?.Set(nameof(Street), value); }
        }
        /// <summary>Not nullable.</summary>
        public List<string> TechnicalNotificationMails {
            get { return BackingStore?.Get<List<string>>(nameof(TechnicalNotificationMails)); }
            set { BackingStore?.Set(nameof(TechnicalNotificationMails), value); }
        }
        /// <summary>The tenantType property</summary>
        public string TenantType {
            get { return BackingStore?.Get<string>(nameof(TenantType)); }
            set { BackingStore?.Set(nameof(TenantType), value); }
        }
        /// <summary>The collection of domains associated with this tenant. Not nullable.</summary>
        public List<VerifiedDomain> VerifiedDomains {
            get { return BackingStore?.Get<List<VerifiedDomain>>(nameof(VerifiedDomains)); }
            set { BackingStore?.Set(nameof(VerifiedDomains), value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Organization CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Organization();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignedPlans", n => { AssignedPlans = n.GetCollectionOfObjectValues<AssignedPlan>(AssignedPlan.CreateFromDiscriminatorValue).ToList(); } },
                {"branding", n => { Branding = n.GetObjectValue<OrganizationalBranding>(OrganizationalBranding.CreateFromDiscriminatorValue); } },
                {"businessPhones", n => { BusinessPhones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"certificateBasedAuthConfiguration", n => { CertificateBasedAuthConfiguration = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.CertificateBasedAuthConfiguration>(Microsoft.Graph.Models.CertificateBasedAuthConfiguration.CreateFromDiscriminatorValue).ToList(); } },
                {"city", n => { City = n.GetStringValue(); } },
                {"country", n => { Country = n.GetStringValue(); } },
                {"countryLetterCode", n => { CountryLetterCode = n.GetStringValue(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"extensions", n => { Extensions = n.GetCollectionOfObjectValues<Extension>(Extension.CreateFromDiscriminatorValue).ToList(); } },
                {"marketingNotificationEmails", n => { MarketingNotificationEmails = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"mobileDeviceManagementAuthority", n => { MobileDeviceManagementAuthority = n.GetEnumValue<MdmAuthority>(); } },
                {"onPremisesLastSyncDateTime", n => { OnPremisesLastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"onPremisesSyncEnabled", n => { OnPremisesSyncEnabled = n.GetBoolValue(); } },
                {"postalCode", n => { PostalCode = n.GetStringValue(); } },
                {"preferredLanguage", n => { PreferredLanguage = n.GetStringValue(); } },
                {"privacyProfile", n => { PrivacyProfile = n.GetObjectValue<Microsoft.Graph.Models.PrivacyProfile>(Microsoft.Graph.Models.PrivacyProfile.CreateFromDiscriminatorValue); } },
                {"provisionedPlans", n => { ProvisionedPlans = n.GetCollectionOfObjectValues<ProvisionedPlan>(ProvisionedPlan.CreateFromDiscriminatorValue).ToList(); } },
                {"securityComplianceNotificationMails", n => { SecurityComplianceNotificationMails = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"securityComplianceNotificationPhones", n => { SecurityComplianceNotificationPhones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"state", n => { State = n.GetStringValue(); } },
                {"street", n => { Street = n.GetStringValue(); } },
                {"technicalNotificationMails", n => { TechnicalNotificationMails = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"tenantType", n => { TenantType = n.GetStringValue(); } },
                {"verifiedDomains", n => { VerifiedDomains = n.GetCollectionOfObjectValues<VerifiedDomain>(VerifiedDomain.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<AssignedPlan>("assignedPlans", AssignedPlans);
            writer.WriteObjectValue<OrganizationalBranding>("branding", Branding);
            writer.WriteCollectionOfPrimitiveValues<string>("businessPhones", BusinessPhones);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.CertificateBasedAuthConfiguration>("certificateBasedAuthConfiguration", CertificateBasedAuthConfiguration);
            writer.WriteStringValue("city", City);
            writer.WriteStringValue("country", Country);
            writer.WriteStringValue("countryLetterCode", CountryLetterCode);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<Extension>("extensions", Extensions);
            writer.WriteCollectionOfPrimitiveValues<string>("marketingNotificationEmails", MarketingNotificationEmails);
            writer.WriteEnumValue<MdmAuthority>("mobileDeviceManagementAuthority", MobileDeviceManagementAuthority);
            writer.WriteDateTimeOffsetValue("onPremisesLastSyncDateTime", OnPremisesLastSyncDateTime);
            writer.WriteBoolValue("onPremisesSyncEnabled", OnPremisesSyncEnabled);
            writer.WriteStringValue("postalCode", PostalCode);
            writer.WriteStringValue("preferredLanguage", PreferredLanguage);
            writer.WriteObjectValue<Microsoft.Graph.Models.PrivacyProfile>("privacyProfile", PrivacyProfile);
            writer.WriteCollectionOfObjectValues<ProvisionedPlan>("provisionedPlans", ProvisionedPlans);
            writer.WriteCollectionOfPrimitiveValues<string>("securityComplianceNotificationMails", SecurityComplianceNotificationMails);
            writer.WriteCollectionOfPrimitiveValues<string>("securityComplianceNotificationPhones", SecurityComplianceNotificationPhones);
            writer.WriteStringValue("state", State);
            writer.WriteStringValue("street", Street);
            writer.WriteCollectionOfPrimitiveValues<string>("technicalNotificationMails", TechnicalNotificationMails);
            writer.WriteStringValue("tenantType", TenantType);
            writer.WriteCollectionOfObjectValues<VerifiedDomain>("verifiedDomains", VerifiedDomains);
        }
    }
}
