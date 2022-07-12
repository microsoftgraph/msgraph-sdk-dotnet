using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Contact : OutlookItem, IParsable {
        /// <summary>The name of the contact&apos;s assistant.</summary>
        public string AssistantName {
            get { return BackingStore?.Get<string>("assistantName"); }
            set { BackingStore?.Set("assistantName", value); }
        }
        /// <summary>The contact&apos;s birthday. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z</summary>
        public DateTimeOffset? Birthday {
            get { return BackingStore?.Get<DateTimeOffset?>("birthday"); }
            set { BackingStore?.Set("birthday", value); }
        }
        /// <summary>The contact&apos;s business address.</summary>
        public PhysicalAddress BusinessAddress {
            get { return BackingStore?.Get<PhysicalAddress>("businessAddress"); }
            set { BackingStore?.Set("businessAddress", value); }
        }
        /// <summary>The business home page of the contact.</summary>
        public string BusinessHomePage {
            get { return BackingStore?.Get<string>("businessHomePage"); }
            set { BackingStore?.Set("businessHomePage", value); }
        }
        /// <summary>The contact&apos;s business phone numbers.</summary>
        public List<string> BusinessPhones {
            get { return BackingStore?.Get<List<string>>("businessPhones"); }
            set { BackingStore?.Set("businessPhones", value); }
        }
        /// <summary>The names of the contact&apos;s children.</summary>
        public List<string> Children {
            get { return BackingStore?.Get<List<string>>("children"); }
            set { BackingStore?.Set("children", value); }
        }
        /// <summary>The name of the contact&apos;s company.</summary>
        public string CompanyName {
            get { return BackingStore?.Get<string>("companyName"); }
            set { BackingStore?.Set("companyName", value); }
        }
        /// <summary>The contact&apos;s department.</summary>
        public string Department {
            get { return BackingStore?.Get<string>("department"); }
            set { BackingStore?.Set("department", value); }
        }
        /// <summary>The contact&apos;s display name. You can specify the display name in a create or update operation. Note that later updates to other properties may cause an automatically generated value to overwrite the displayName value you have specified. To preserve a pre-existing value, always include it as displayName in an update operation.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The contact&apos;s email addresses.</summary>
        public List<EmailAddress> EmailAddresses {
            get { return BackingStore?.Get<List<EmailAddress>>("emailAddresses"); }
            set { BackingStore?.Set("emailAddresses", value); }
        }
        /// <summary>The collection of open extensions defined for the contact. Nullable.</summary>
        public List<Extension> Extensions {
            get { return BackingStore?.Get<List<Extension>>("extensions"); }
            set { BackingStore?.Set("extensions", value); }
        }
        /// <summary>The name the contact is filed under.</summary>
        public string FileAs {
            get { return BackingStore?.Get<string>("fileAs"); }
            set { BackingStore?.Set("fileAs", value); }
        }
        /// <summary>The contact&apos;s generation.</summary>
        public string Generation {
            get { return BackingStore?.Get<string>("generation"); }
            set { BackingStore?.Set("generation", value); }
        }
        /// <summary>The contact&apos;s given name.</summary>
        public string GivenName {
            get { return BackingStore?.Get<string>("givenName"); }
            set { BackingStore?.Set("givenName", value); }
        }
        /// <summary>The contact&apos;s home address.</summary>
        public PhysicalAddress HomeAddress {
            get { return BackingStore?.Get<PhysicalAddress>("homeAddress"); }
            set { BackingStore?.Set("homeAddress", value); }
        }
        /// <summary>The contact&apos;s home phone numbers.</summary>
        public List<string> HomePhones {
            get { return BackingStore?.Get<List<string>>("homePhones"); }
            set { BackingStore?.Set("homePhones", value); }
        }
        /// <summary>The imAddresses property</summary>
        public List<string> ImAddresses {
            get { return BackingStore?.Get<List<string>>("imAddresses"); }
            set { BackingStore?.Set("imAddresses", value); }
        }
        /// <summary>The initials property</summary>
        public string Initials {
            get { return BackingStore?.Get<string>("initials"); }
            set { BackingStore?.Set("initials", value); }
        }
        /// <summary>The jobTitle property</summary>
        public string JobTitle {
            get { return BackingStore?.Get<string>("jobTitle"); }
            set { BackingStore?.Set("jobTitle", value); }
        }
        /// <summary>The manager property</summary>
        public string Manager {
            get { return BackingStore?.Get<string>("manager"); }
            set { BackingStore?.Set("manager", value); }
        }
        /// <summary>The middleName property</summary>
        public string MiddleName {
            get { return BackingStore?.Get<string>("middleName"); }
            set { BackingStore?.Set("middleName", value); }
        }
        /// <summary>The mobilePhone property</summary>
        public string MobilePhone {
            get { return BackingStore?.Get<string>("mobilePhone"); }
            set { BackingStore?.Set("mobilePhone", value); }
        }
        /// <summary>The collection of multi-value extended properties defined for the contact. Read-only. Nullable.</summary>
        public List<MultiValueLegacyExtendedProperty> MultiValueExtendedProperties {
            get { return BackingStore?.Get<List<MultiValueLegacyExtendedProperty>>("multiValueExtendedProperties"); }
            set { BackingStore?.Set("multiValueExtendedProperties", value); }
        }
        /// <summary>The nickName property</summary>
        public string NickName {
            get { return BackingStore?.Get<string>("nickName"); }
            set { BackingStore?.Set("nickName", value); }
        }
        /// <summary>The officeLocation property</summary>
        public string OfficeLocation {
            get { return BackingStore?.Get<string>("officeLocation"); }
            set { BackingStore?.Set("officeLocation", value); }
        }
        /// <summary>The otherAddress property</summary>
        public PhysicalAddress OtherAddress {
            get { return BackingStore?.Get<PhysicalAddress>("otherAddress"); }
            set { BackingStore?.Set("otherAddress", value); }
        }
        /// <summary>The parentFolderId property</summary>
        public string ParentFolderId {
            get { return BackingStore?.Get<string>("parentFolderId"); }
            set { BackingStore?.Set("parentFolderId", value); }
        }
        /// <summary>The personalNotes property</summary>
        public string PersonalNotes {
            get { return BackingStore?.Get<string>("personalNotes"); }
            set { BackingStore?.Set("personalNotes", value); }
        }
        /// <summary>Optional contact picture. You can get or set a photo for a contact.</summary>
        public ProfilePhoto Photo {
            get { return BackingStore?.Get<ProfilePhoto>("photo"); }
            set { BackingStore?.Set("photo", value); }
        }
        /// <summary>The profession property</summary>
        public string Profession {
            get { return BackingStore?.Get<string>("profession"); }
            set { BackingStore?.Set("profession", value); }
        }
        /// <summary>The collection of single-value extended properties defined for the contact. Read-only. Nullable.</summary>
        public List<SingleValueLegacyExtendedProperty> SingleValueExtendedProperties {
            get { return BackingStore?.Get<List<SingleValueLegacyExtendedProperty>>("singleValueExtendedProperties"); }
            set { BackingStore?.Set("singleValueExtendedProperties", value); }
        }
        /// <summary>The spouseName property</summary>
        public string SpouseName {
            get { return BackingStore?.Get<string>("spouseName"); }
            set { BackingStore?.Set("spouseName", value); }
        }
        /// <summary>The surname property</summary>
        public string Surname {
            get { return BackingStore?.Get<string>("surname"); }
            set { BackingStore?.Set("surname", value); }
        }
        /// <summary>The title property</summary>
        public string Title {
            get { return BackingStore?.Get<string>("title"); }
            set { BackingStore?.Set("title", value); }
        }
        /// <summary>The yomiCompanyName property</summary>
        public string YomiCompanyName {
            get { return BackingStore?.Get<string>("yomiCompanyName"); }
            set { BackingStore?.Set("yomiCompanyName", value); }
        }
        /// <summary>The yomiGivenName property</summary>
        public string YomiGivenName {
            get { return BackingStore?.Get<string>("yomiGivenName"); }
            set { BackingStore?.Set("yomiGivenName", value); }
        }
        /// <summary>The yomiSurname property</summary>
        public string YomiSurname {
            get { return BackingStore?.Get<string>("yomiSurname"); }
            set { BackingStore?.Set("yomiSurname", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Contact CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Contact();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assistantName", n => { AssistantName = n.GetStringValue(); } },
                {"birthday", n => { Birthday = n.GetDateTimeOffsetValue(); } },
                {"businessAddress", n => { BusinessAddress = n.GetObjectValue<PhysicalAddress>(PhysicalAddress.CreateFromDiscriminatorValue); } },
                {"businessHomePage", n => { BusinessHomePage = n.GetStringValue(); } },
                {"businessPhones", n => { BusinessPhones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"children", n => { Children = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"companyName", n => { CompanyName = n.GetStringValue(); } },
                {"department", n => { Department = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"emailAddresses", n => { EmailAddresses = n.GetCollectionOfObjectValues<EmailAddress>(EmailAddress.CreateFromDiscriminatorValue).ToList(); } },
                {"extensions", n => { Extensions = n.GetCollectionOfObjectValues<Extension>(Extension.CreateFromDiscriminatorValue).ToList(); } },
                {"fileAs", n => { FileAs = n.GetStringValue(); } },
                {"generation", n => { Generation = n.GetStringValue(); } },
                {"givenName", n => { GivenName = n.GetStringValue(); } },
                {"homeAddress", n => { HomeAddress = n.GetObjectValue<PhysicalAddress>(PhysicalAddress.CreateFromDiscriminatorValue); } },
                {"homePhones", n => { HomePhones = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"imAddresses", n => { ImAddresses = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"initials", n => { Initials = n.GetStringValue(); } },
                {"jobTitle", n => { JobTitle = n.GetStringValue(); } },
                {"manager", n => { Manager = n.GetStringValue(); } },
                {"middleName", n => { MiddleName = n.GetStringValue(); } },
                {"mobilePhone", n => { MobilePhone = n.GetStringValue(); } },
                {"multiValueExtendedProperties", n => { MultiValueExtendedProperties = n.GetCollectionOfObjectValues<MultiValueLegacyExtendedProperty>(MultiValueLegacyExtendedProperty.CreateFromDiscriminatorValue).ToList(); } },
                {"nickName", n => { NickName = n.GetStringValue(); } },
                {"officeLocation", n => { OfficeLocation = n.GetStringValue(); } },
                {"otherAddress", n => { OtherAddress = n.GetObjectValue<PhysicalAddress>(PhysicalAddress.CreateFromDiscriminatorValue); } },
                {"parentFolderId", n => { ParentFolderId = n.GetStringValue(); } },
                {"personalNotes", n => { PersonalNotes = n.GetStringValue(); } },
                {"photo", n => { Photo = n.GetObjectValue<ProfilePhoto>(ProfilePhoto.CreateFromDiscriminatorValue); } },
                {"profession", n => { Profession = n.GetStringValue(); } },
                {"singleValueExtendedProperties", n => { SingleValueExtendedProperties = n.GetCollectionOfObjectValues<SingleValueLegacyExtendedProperty>(SingleValueLegacyExtendedProperty.CreateFromDiscriminatorValue).ToList(); } },
                {"spouseName", n => { SpouseName = n.GetStringValue(); } },
                {"surname", n => { Surname = n.GetStringValue(); } },
                {"title", n => { Title = n.GetStringValue(); } },
                {"yomiCompanyName", n => { YomiCompanyName = n.GetStringValue(); } },
                {"yomiGivenName", n => { YomiGivenName = n.GetStringValue(); } },
                {"yomiSurname", n => { YomiSurname = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("assistantName", AssistantName);
            writer.WriteDateTimeOffsetValue("birthday", Birthday);
            writer.WriteObjectValue<PhysicalAddress>("businessAddress", BusinessAddress);
            writer.WriteStringValue("businessHomePage", BusinessHomePage);
            writer.WriteCollectionOfPrimitiveValues<string>("businessPhones", BusinessPhones);
            writer.WriteCollectionOfPrimitiveValues<string>("children", Children);
            writer.WriteStringValue("companyName", CompanyName);
            writer.WriteStringValue("department", Department);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteCollectionOfObjectValues<EmailAddress>("emailAddresses", EmailAddresses);
            writer.WriteCollectionOfObjectValues<Extension>("extensions", Extensions);
            writer.WriteStringValue("fileAs", FileAs);
            writer.WriteStringValue("generation", Generation);
            writer.WriteStringValue("givenName", GivenName);
            writer.WriteObjectValue<PhysicalAddress>("homeAddress", HomeAddress);
            writer.WriteCollectionOfPrimitiveValues<string>("homePhones", HomePhones);
            writer.WriteCollectionOfPrimitiveValues<string>("imAddresses", ImAddresses);
            writer.WriteStringValue("initials", Initials);
            writer.WriteStringValue("jobTitle", JobTitle);
            writer.WriteStringValue("manager", Manager);
            writer.WriteStringValue("middleName", MiddleName);
            writer.WriteStringValue("mobilePhone", MobilePhone);
            writer.WriteCollectionOfObjectValues<MultiValueLegacyExtendedProperty>("multiValueExtendedProperties", MultiValueExtendedProperties);
            writer.WriteStringValue("nickName", NickName);
            writer.WriteStringValue("officeLocation", OfficeLocation);
            writer.WriteObjectValue<PhysicalAddress>("otherAddress", OtherAddress);
            writer.WriteStringValue("parentFolderId", ParentFolderId);
            writer.WriteStringValue("personalNotes", PersonalNotes);
            writer.WriteObjectValue<ProfilePhoto>("photo", Photo);
            writer.WriteStringValue("profession", Profession);
            writer.WriteCollectionOfObjectValues<SingleValueLegacyExtendedProperty>("singleValueExtendedProperties", SingleValueExtendedProperties);
            writer.WriteStringValue("spouseName", SpouseName);
            writer.WriteStringValue("surname", Surname);
            writer.WriteStringValue("title", Title);
            writer.WriteStringValue("yomiCompanyName", YomiCompanyName);
            writer.WriteStringValue("yomiGivenName", YomiGivenName);
            writer.WriteStringValue("yomiSurname", YomiSurname);
        }
    }
}
