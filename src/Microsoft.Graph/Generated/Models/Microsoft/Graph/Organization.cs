using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class Organization : DirectoryObject, IParsable {
        /// <summary>The collection of service plans associated with the tenant. Not nullable.</summary>
        public List<AssignedPlan> AssignedPlans { get; set; }
        public OrganizationalBranding Branding { get; set; }
        /// <summary>Telephone number for the organization. Although this is a string collection, only one number can be set for this property.</summary>
        public List<string> BusinessPhones { get; set; }
        /// <summary>Navigation property to manage certificate-based authentication configuration. Only a single instance of certificateBasedAuthConfiguration can be created in the collection.</summary>
        public List<CertificateBasedAuthConfiguration> CertificateBasedAuthConfiguration { get; set; }
        /// <summary>City name of the address for the organization.</summary>
        public string City { get; set; }
        /// <summary>Country/region name of the address for the organization.</summary>
        public string Country { get; set; }
        /// <summary>Country or region abbreviation for the organization in ISO 3166-2 format.</summary>
        public string CountryLetterCode { get; set; }
        /// <summary>Timestamp of when the organization was created. The value cannot be modified and is automatically populated when the organization is created. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The display name for the tenant.</summary>
        public string DisplayName { get; set; }
        /// <summary>The collection of open extensions defined for the organization. Read-only. Nullable.</summary>
        public List<Extension> Extensions { get; set; }
        /// <summary>Not nullable.</summary>
        public List<string> MarketingNotificationEmails { get; set; }
        /// <summary>Mobile device management authority. Possible values are: unknown, intune, sccm, office365.</summary>
        public MdmAuthority? MobileDeviceManagementAuthority { get; set; }
        /// <summary>The time and date at which the tenant was last synced with the on-premises directory. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z. Read-only.</summary>
        public DateTimeOffset? OnPremisesLastSyncDateTime { get; set; }
        /// <summary>true if this object is synced from an on-premises directory; false if this object was originally synced from an on-premises directory but is no longer synced. Nullable. null if this object has never been synced from an on-premises directory (default).</summary>
        public bool? OnPremisesSyncEnabled { get; set; }
        /// <summary>Postal code of the address for the organization.</summary>
        public string PostalCode { get; set; }
        /// <summary>The preferred language for the organization. Should follow ISO 639-1 Code; for example, en.</summary>
        public string PreferredLanguage { get; set; }
        /// <summary>The privacy profile of an organization.</summary>
        public PrivacyProfile PrivacyProfile { get; set; }
        /// <summary>Not nullable.</summary>
        public List<ProvisionedPlan> ProvisionedPlans { get; set; }
        public List<string> SecurityComplianceNotificationMails { get; set; }
        public List<string> SecurityComplianceNotificationPhones { get; set; }
        /// <summary>State name of the address for the organization.</summary>
        public string State { get; set; }
        /// <summary>Street name of the address for organization.</summary>
        public string Street { get; set; }
        /// <summary>Not nullable.</summary>
        public List<string> TechnicalNotificationMails { get; set; }
        public string TenantType { get; set; }
        /// <summary>The collection of domains associated with this tenant. Not nullable.</summary>
        public List<VerifiedDomain> VerifiedDomains { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"assignedPlans", (o,n) => { (o as Organization).AssignedPlans = n.GetCollectionOfObjectValues<AssignedPlan>().ToList(); } },
                {"branding", (o,n) => { (o as Organization).Branding = n.GetObjectValue<OrganizationalBranding>(); } },
                {"businessPhones", (o,n) => { (o as Organization).BusinessPhones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"certificateBasedAuthConfiguration", (o,n) => { (o as Organization).CertificateBasedAuthConfiguration = n.GetCollectionOfObjectValues<CertificateBasedAuthConfiguration>().ToList(); } },
                {"city", (o,n) => { (o as Organization).City = n.GetStringValue(); } },
                {"country", (o,n) => { (o as Organization).Country = n.GetStringValue(); } },
                {"countryLetterCode", (o,n) => { (o as Organization).CountryLetterCode = n.GetStringValue(); } },
                {"createdDateTime", (o,n) => { (o as Organization).CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"displayName", (o,n) => { (o as Organization).DisplayName = n.GetStringValue(); } },
                {"extensions", (o,n) => { (o as Organization).Extensions = n.GetCollectionOfObjectValues<Extension>().ToList(); } },
                {"marketingNotificationEmails", (o,n) => { (o as Organization).MarketingNotificationEmails = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"mobileDeviceManagementAuthority", (o,n) => { (o as Organization).MobileDeviceManagementAuthority = n.GetEnumValue<MdmAuthority>(); } },
                {"onPremisesLastSyncDateTime", (o,n) => { (o as Organization).OnPremisesLastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"onPremisesSyncEnabled", (o,n) => { (o as Organization).OnPremisesSyncEnabled = n.GetBoolValue(); } },
                {"postalCode", (o,n) => { (o as Organization).PostalCode = n.GetStringValue(); } },
                {"preferredLanguage", (o,n) => { (o as Organization).PreferredLanguage = n.GetStringValue(); } },
                {"privacyProfile", (o,n) => { (o as Organization).PrivacyProfile = n.GetObjectValue<PrivacyProfile>(); } },
                {"provisionedPlans", (o,n) => { (o as Organization).ProvisionedPlans = n.GetCollectionOfObjectValues<ProvisionedPlan>().ToList(); } },
                {"securityComplianceNotificationMails", (o,n) => { (o as Organization).SecurityComplianceNotificationMails = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"securityComplianceNotificationPhones", (o,n) => { (o as Organization).SecurityComplianceNotificationPhones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"state", (o,n) => { (o as Organization).State = n.GetStringValue(); } },
                {"street", (o,n) => { (o as Organization).Street = n.GetStringValue(); } },
                {"technicalNotificationMails", (o,n) => { (o as Organization).TechnicalNotificationMails = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"tenantType", (o,n) => { (o as Organization).TenantType = n.GetStringValue(); } },
                {"verifiedDomains", (o,n) => { (o as Organization).VerifiedDomains = n.GetCollectionOfObjectValues<VerifiedDomain>().ToList(); } },
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
            writer.WriteCollectionOfObjectValues<CertificateBasedAuthConfiguration>("certificateBasedAuthConfiguration", CertificateBasedAuthConfiguration);
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
            writer.WriteObjectValue<PrivacyProfile>("privacyProfile", PrivacyProfile);
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
