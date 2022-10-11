using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreementAcceptance entities.</summary>
    public class Person : Entity, IParsable {
        /// <summary>The person&apos;s birthday.</summary>
        public string Birthday {
            get { return BackingStore?.Get<string>("birthday"); }
            set { BackingStore?.Set("birthday", value); }
        }
        /// <summary>The name of the person&apos;s company.</summary>
        public string CompanyName {
            get { return BackingStore?.Get<string>("companyName"); }
            set { BackingStore?.Set("companyName", value); }
        }
        /// <summary>The person&apos;s department.</summary>
        public string Department {
            get { return BackingStore?.Get<string>("department"); }
            set { BackingStore?.Set("department", value); }
        }
        /// <summary>The person&apos;s display name.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The person&apos;s given name.</summary>
        public string GivenName {
            get { return BackingStore?.Get<string>("givenName"); }
            set { BackingStore?.Set("givenName", value); }
        }
        /// <summary>The instant message voice over IP (VOIP) session initiation protocol (SIP) address for the user. Read-only.</summary>
        public string ImAddress {
            get { return BackingStore?.Get<string>("imAddress"); }
            set { BackingStore?.Set("imAddress", value); }
        }
        /// <summary>true if the user has flagged this person as a favorite.</summary>
        public bool? IsFavorite {
            get { return BackingStore?.Get<bool?>("isFavorite"); }
            set { BackingStore?.Set("isFavorite", value); }
        }
        /// <summary>The person&apos;s job title.</summary>
        public string JobTitle {
            get { return BackingStore?.Get<string>("jobTitle"); }
            set { BackingStore?.Set("jobTitle", value); }
        }
        /// <summary>The location of the person&apos;s office.</summary>
        public string OfficeLocation {
            get { return BackingStore?.Get<string>("officeLocation"); }
            set { BackingStore?.Set("officeLocation", value); }
        }
        /// <summary>Free-form notes that the user has taken about this person.</summary>
        public string PersonNotes {
            get { return BackingStore?.Get<string>("personNotes"); }
            set { BackingStore?.Set("personNotes", value); }
        }
        /// <summary>The type of person.</summary>
        public Microsoft.Graph.Models.PersonType PersonType {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PersonType>("personType"); }
            set { BackingStore?.Set("personType", value); }
        }
        /// <summary>The person&apos;s phone numbers.</summary>
        public List<Phone> Phones {
            get { return BackingStore?.Get<List<Phone>>("phones"); }
            set { BackingStore?.Set("phones", value); }
        }
        /// <summary>The person&apos;s addresses.</summary>
        public List<Location> PostalAddresses {
            get { return BackingStore?.Get<List<Location>>("postalAddresses"); }
            set { BackingStore?.Set("postalAddresses", value); }
        }
        /// <summary>The person&apos;s profession.</summary>
        public string Profession {
            get { return BackingStore?.Get<string>("profession"); }
            set { BackingStore?.Set("profession", value); }
        }
        /// <summary>The person&apos;s email addresses.</summary>
        public List<ScoredEmailAddress> ScoredEmailAddresses {
            get { return BackingStore?.Get<List<ScoredEmailAddress>>("scoredEmailAddresses"); }
            set { BackingStore?.Set("scoredEmailAddresses", value); }
        }
        /// <summary>The person&apos;s surname.</summary>
        public string Surname {
            get { return BackingStore?.Get<string>("surname"); }
            set { BackingStore?.Set("surname", value); }
        }
        /// <summary>The user principal name (UPN) of the person. The UPN is an Internet-style login name for the person based on the Internet standard RFC 822. By convention, this should map to the person&apos;s email name. The general format is alias@domain.</summary>
        public string UserPrincipalName {
            get { return BackingStore?.Get<string>("userPrincipalName"); }
            set { BackingStore?.Set("userPrincipalName", value); }
        }
        /// <summary>The person&apos;s websites.</summary>
        public List<Website> Websites {
            get { return BackingStore?.Get<List<Website>>("websites"); }
            set { BackingStore?.Set("websites", value); }
        }
        /// <summary>The phonetic Japanese name of the person&apos;s company.</summary>
        public string YomiCompany {
            get { return BackingStore?.Get<string>("yomiCompany"); }
            set { BackingStore?.Set("yomiCompany", value); }
        }
        /// <summary>
        /// Instantiates a new person and sets the default values.
        /// </summary>
        public Person() : base() {
            OdataType = "#microsoft.graph.person";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Person CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Person();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"birthday", n => { Birthday = n.GetStringValue(); } },
                {"companyName", n => { CompanyName = n.GetStringValue(); } },
                {"department", n => { Department = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"givenName", n => { GivenName = n.GetStringValue(); } },
                {"imAddress", n => { ImAddress = n.GetStringValue(); } },
                {"isFavorite", n => { IsFavorite = n.GetBoolValue(); } },
                {"jobTitle", n => { JobTitle = n.GetStringValue(); } },
                {"officeLocation", n => { OfficeLocation = n.GetStringValue(); } },
                {"personNotes", n => { PersonNotes = n.GetStringValue(); } },
                {"personType", n => { PersonType = n.GetObjectValue<Microsoft.Graph.Models.PersonType>(Microsoft.Graph.Models.PersonType.CreateFromDiscriminatorValue); } },
                {"phones", n => { Phones = n.GetCollectionOfObjectValues<Phone>(Phone.CreateFromDiscriminatorValue)?.ToList(); } },
                {"postalAddresses", n => { PostalAddresses = n.GetCollectionOfObjectValues<Location>(Location.CreateFromDiscriminatorValue)?.ToList(); } },
                {"profession", n => { Profession = n.GetStringValue(); } },
                {"scoredEmailAddresses", n => { ScoredEmailAddresses = n.GetCollectionOfObjectValues<ScoredEmailAddress>(ScoredEmailAddress.CreateFromDiscriminatorValue)?.ToList(); } },
                {"surname", n => { Surname = n.GetStringValue(); } },
                {"userPrincipalName", n => { UserPrincipalName = n.GetStringValue(); } },
                {"websites", n => { Websites = n.GetCollectionOfObjectValues<Website>(Website.CreateFromDiscriminatorValue)?.ToList(); } },
                {"yomiCompany", n => { YomiCompany = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("birthday", Birthday);
            writer.WriteStringValue("companyName", CompanyName);
            writer.WriteStringValue("department", Department);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("givenName", GivenName);
            writer.WriteStringValue("imAddress", ImAddress);
            writer.WriteBoolValue("isFavorite", IsFavorite);
            writer.WriteStringValue("jobTitle", JobTitle);
            writer.WriteStringValue("officeLocation", OfficeLocation);
            writer.WriteStringValue("personNotes", PersonNotes);
            writer.WriteObjectValue<Microsoft.Graph.Models.PersonType>("personType", PersonType);
            writer.WriteCollectionOfObjectValues<Phone>("phones", Phones);
            writer.WriteCollectionOfObjectValues<Location>("postalAddresses", PostalAddresses);
            writer.WriteStringValue("profession", Profession);
            writer.WriteCollectionOfObjectValues<ScoredEmailAddress>("scoredEmailAddresses", ScoredEmailAddresses);
            writer.WriteStringValue("surname", Surname);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
            writer.WriteCollectionOfObjectValues<Website>("websites", Websites);
            writer.WriteStringValue("yomiCompany", YomiCompany);
        }
    }
}
