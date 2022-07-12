using Microsoft.Graph.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>An abstract class containing the base properties for Managed eBook.</summary>
    public class ManagedEBook : Entity, IParsable {
        /// <summary>The list of assignments for this eBook.</summary>
        public List<ManagedEBookAssignment> Assignments {
            get { return BackingStore?.Get<List<ManagedEBookAssignment>>("assignments"); }
            set { BackingStore?.Set("assignments", value); }
        }
        /// <summary>The date and time when the eBook file was created.</summary>
        public DateTimeOffset? CreatedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("createdDateTime"); }
            set { BackingStore?.Set("createdDateTime", value); }
        }
        /// <summary>Description.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The list of installation states for this eBook.</summary>
        public List<DeviceInstallState> DeviceStates {
            get { return BackingStore?.Get<List<DeviceInstallState>>("deviceStates"); }
            set { BackingStore?.Set("deviceStates", value); }
        }
        /// <summary>Name of the eBook.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The more information Url.</summary>
        public string InformationUrl {
            get { return BackingStore?.Get<string>("informationUrl"); }
            set { BackingStore?.Set("informationUrl", value); }
        }
        /// <summary>Mobile App Install Summary.</summary>
        public EBookInstallSummary InstallSummary {
            get { return BackingStore?.Get<EBookInstallSummary>("installSummary"); }
            set { BackingStore?.Set("installSummary", value); }
        }
        /// <summary>Book cover.</summary>
        public MimeContent LargeCover {
            get { return BackingStore?.Get<MimeContent>("largeCover"); }
            set { BackingStore?.Set("largeCover", value); }
        }
        /// <summary>The date and time when the eBook was last modified.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>The privacy statement Url.</summary>
        public string PrivacyInformationUrl {
            get { return BackingStore?.Get<string>("privacyInformationUrl"); }
            set { BackingStore?.Set("privacyInformationUrl", value); }
        }
        /// <summary>The date and time when the eBook was published.</summary>
        public DateTimeOffset? PublishedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("publishedDateTime"); }
            set { BackingStore?.Set("publishedDateTime", value); }
        }
        /// <summary>Publisher.</summary>
        public string Publisher {
            get { return BackingStore?.Get<string>("publisher"); }
            set { BackingStore?.Set("publisher", value); }
        }
        /// <summary>The list of installation states for this eBook.</summary>
        public List<UserInstallStateSummary> UserStateSummary {
            get { return BackingStore?.Get<List<UserInstallStateSummary>>("userStateSummary"); }
            set { BackingStore?.Set("userStateSummary", value); }
        }
        /// <summary>
        /// Instantiates a new managedEBook and sets the default values.
        /// </summary>
        public ManagedEBook() : base() {
            Type = "#microsoft.graph.managedEBook";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new ManagedEBook CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.iosVppEBook" => new IosVppEBook(),
                _ => new ManagedEBook(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignments", n => { Assignments = n.GetCollectionOfObjectValues<ManagedEBookAssignment>(ManagedEBookAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"deviceStates", n => { DeviceStates = n.GetCollectionOfObjectValues<DeviceInstallState>(DeviceInstallState.CreateFromDiscriminatorValue).ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"informationUrl", n => { InformationUrl = n.GetStringValue(); } },
                {"installSummary", n => { InstallSummary = n.GetObjectValue<EBookInstallSummary>(EBookInstallSummary.CreateFromDiscriminatorValue); } },
                {"largeCover", n => { LargeCover = n.GetObjectValue<MimeContent>(MimeContent.CreateFromDiscriminatorValue); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"privacyInformationUrl", n => { PrivacyInformationUrl = n.GetStringValue(); } },
                {"publishedDateTime", n => { PublishedDateTime = n.GetDateTimeOffsetValue(); } },
                {"publisher", n => { Publisher = n.GetStringValue(); } },
                {"userStateSummary", n => { UserStateSummary = n.GetCollectionOfObjectValues<UserInstallStateSummary>(UserInstallStateSummary.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<ManagedEBookAssignment>("assignments", Assignments);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteCollectionOfObjectValues<DeviceInstallState>("deviceStates", DeviceStates);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteStringValue("informationUrl", InformationUrl);
            writer.WriteObjectValue<EBookInstallSummary>("installSummary", InstallSummary);
            writer.WriteObjectValue<MimeContent>("largeCover", LargeCover);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("privacyInformationUrl", PrivacyInformationUrl);
            writer.WriteDateTimeOffsetValue("publishedDateTime", PublishedDateTime);
            writer.WriteStringValue("publisher", Publisher);
            writer.WriteCollectionOfObjectValues<UserInstallStateSummary>("userStateSummary", UserStateSummary);
        }
    }
}
