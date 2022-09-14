using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of orgContact entities.</summary>
    public class OrgContact : DirectoryObject, IParsable {
        /// <summary>The addresses property</summary>
        public List<PhysicalOfficeAddress> Addresses {
            get { return BackingStore?.Get<List<PhysicalOfficeAddress>>("addresses"); }
            set { BackingStore?.Set("addresses", value); }
        }
        /// <summary>The companyName property</summary>
        public string CompanyName {
            get { return BackingStore?.Get<string>("companyName"); }
            set { BackingStore?.Set("companyName", value); }
        }
        /// <summary>The department property</summary>
        public string Department {
            get { return BackingStore?.Get<string>("department"); }
            set { BackingStore?.Set("department", value); }
        }
        /// <summary>The directReports property</summary>
        public List<DirectoryObject> DirectReports {
            get { return BackingStore?.Get<List<DirectoryObject>>("directReports"); }
            set { BackingStore?.Set("directReports", value); }
        }
        /// <summary>The displayName property</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The givenName property</summary>
        public string GivenName {
            get { return BackingStore?.Get<string>("givenName"); }
            set { BackingStore?.Set("givenName", value); }
        }
        /// <summary>The jobTitle property</summary>
        public string JobTitle {
            get { return BackingStore?.Get<string>("jobTitle"); }
            set { BackingStore?.Set("jobTitle", value); }
        }
        /// <summary>The mail property</summary>
        public string Mail {
            get { return BackingStore?.Get<string>("mail"); }
            set { BackingStore?.Set("mail", value); }
        }
        /// <summary>The mailNickname property</summary>
        public string MailNickname {
            get { return BackingStore?.Get<string>("mailNickname"); }
            set { BackingStore?.Set("mailNickname", value); }
        }
        /// <summary>The manager property</summary>
        public DirectoryObject Manager {
            get { return BackingStore?.Get<DirectoryObject>("manager"); }
            set { BackingStore?.Set("manager", value); }
        }
        /// <summary>The memberOf property</summary>
        public List<DirectoryObject> MemberOf {
            get { return BackingStore?.Get<List<DirectoryObject>>("memberOf"); }
            set { BackingStore?.Set("memberOf", value); }
        }
        /// <summary>The onPremisesLastSyncDateTime property</summary>
        public DateTimeOffset? OnPremisesLastSyncDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("onPremisesLastSyncDateTime"); }
            set { BackingStore?.Set("onPremisesLastSyncDateTime", value); }
        }
        /// <summary>The onPremisesProvisioningErrors property</summary>
        public List<OnPremisesProvisioningError> OnPremisesProvisioningErrors {
            get { return BackingStore?.Get<List<OnPremisesProvisioningError>>("onPremisesProvisioningErrors"); }
            set { BackingStore?.Set("onPremisesProvisioningErrors", value); }
        }
        /// <summary>The onPremisesSyncEnabled property</summary>
        public bool? OnPremisesSyncEnabled {
            get { return BackingStore?.Get<bool?>("onPremisesSyncEnabled"); }
            set { BackingStore?.Set("onPremisesSyncEnabled", value); }
        }
        /// <summary>The phones property</summary>
        public List<Phone> Phones {
            get { return BackingStore?.Get<List<Phone>>("phones"); }
            set { BackingStore?.Set("phones", value); }
        }
        /// <summary>The proxyAddresses property</summary>
        public List<string> ProxyAddresses {
            get { return BackingStore?.Get<List<string>>("proxyAddresses"); }
            set { BackingStore?.Set("proxyAddresses", value); }
        }
        /// <summary>The surname property</summary>
        public string Surname {
            get { return BackingStore?.Get<string>("surname"); }
            set { BackingStore?.Set("surname", value); }
        }
        /// <summary>The transitiveMemberOf property</summary>
        public List<DirectoryObject> TransitiveMemberOf {
            get { return BackingStore?.Get<List<DirectoryObject>>("transitiveMemberOf"); }
            set { BackingStore?.Set("transitiveMemberOf", value); }
        }
        /// <summary>
        /// Instantiates a new orgContact and sets the default values.
        /// </summary>
        public OrgContact() : base() {
            OdataType = "#microsoft.graph.orgContact";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new OrgContact CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OrgContact();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"addresses", n => { Addresses = n.GetCollectionOfObjectValues<PhysicalOfficeAddress>(PhysicalOfficeAddress.CreateFromDiscriminatorValue)?.ToList(); } },
                {"companyName", n => { CompanyName = n.GetStringValue(); } },
                {"department", n => { Department = n.GetStringValue(); } },
                {"directReports", n => { DirectReports = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"givenName", n => { GivenName = n.GetStringValue(); } },
                {"jobTitle", n => { JobTitle = n.GetStringValue(); } },
                {"mail", n => { Mail = n.GetStringValue(); } },
                {"mailNickname", n => { MailNickname = n.GetStringValue(); } },
                {"manager", n => { Manager = n.GetObjectValue<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue); } },
                {"memberOf", n => { MemberOf = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"onPremisesLastSyncDateTime", n => { OnPremisesLastSyncDateTime = n.GetDateTimeOffsetValue(); } },
                {"onPremisesProvisioningErrors", n => { OnPremisesProvisioningErrors = n.GetCollectionOfObjectValues<OnPremisesProvisioningError>(OnPremisesProvisioningError.CreateFromDiscriminatorValue)?.ToList(); } },
                {"onPremisesSyncEnabled", n => { OnPremisesSyncEnabled = n.GetBoolValue(); } },
                {"phones", n => { Phones = n.GetCollectionOfObjectValues<Phone>(Phone.CreateFromDiscriminatorValue)?.ToList(); } },
                {"proxyAddresses", n => { ProxyAddresses = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                {"surname", n => { Surname = n.GetStringValue(); } },
                {"transitiveMemberOf", n => { TransitiveMemberOf = n.GetCollectionOfObjectValues<DirectoryObject>(DirectoryObject.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<PhysicalOfficeAddress>("addresses", Addresses);
            writer.WriteStringValue("companyName", CompanyName);
            writer.WriteStringValue("department", Department);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("directReports", DirectReports);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("givenName", GivenName);
            writer.WriteStringValue("jobTitle", JobTitle);
            writer.WriteStringValue("mail", Mail);
            writer.WriteStringValue("mailNickname", MailNickname);
            writer.WriteObjectValue<DirectoryObject>("manager", Manager);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("memberOf", MemberOf);
            writer.WriteDateTimeOffsetValue("onPremisesLastSyncDateTime", OnPremisesLastSyncDateTime);
            writer.WriteCollectionOfObjectValues<OnPremisesProvisioningError>("onPremisesProvisioningErrors", OnPremisesProvisioningErrors);
            writer.WriteBoolValue("onPremisesSyncEnabled", OnPremisesSyncEnabled);
            writer.WriteCollectionOfObjectValues<Phone>("phones", Phones);
            writer.WriteCollectionOfPrimitiveValues<string>("proxyAddresses", ProxyAddresses);
            writer.WriteStringValue("surname", Surname);
            writer.WriteCollectionOfObjectValues<DirectoryObject>("transitiveMemberOf", TransitiveMemberOf);
        }
    }
}
