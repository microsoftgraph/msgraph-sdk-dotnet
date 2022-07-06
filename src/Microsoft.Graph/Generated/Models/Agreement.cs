using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the collection of agreement entities.</summary>
    public class Agreement : Entity, IParsable {
        /// <summary>Read-only. Information about acceptances of this agreement.</summary>
        public List<AgreementAcceptance> Acceptances {
            get { return BackingStore?.Get<List<AgreementAcceptance>>("acceptances"); }
            set { BackingStore?.Set("acceptances", value); }
        }
        /// <summary>Display name of the agreement. The display name is used for internal tracking of the agreement but is not shown to end users who view the agreement. Supports $filter (eq).</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>Default PDF linked to this agreement.</summary>
        public AgreementFile FileObject {
            get { return BackingStore?.Get<AgreementFile>("file"); }
            set { BackingStore?.Set("file", value); }
        }
        /// <summary>PDFs linked to this agreement. Note: This property is in the process of being deprecated. Use the  file property instead.</summary>
        public List<AgreementFileLocalization> Files {
            get { return BackingStore?.Get<List<AgreementFileLocalization>>("files"); }
            set { BackingStore?.Set("files", value); }
        }
        /// <summary>This setting enables you to require end users to accept this agreement on every device that they are accessing it from. The end user will be required to register their device in Azure AD, if they haven&apos;t already done so. Supports $filter (eq).</summary>
        public bool? IsPerDeviceAcceptanceRequired {
            get { return BackingStore?.Get<bool?>("isPerDeviceAcceptanceRequired"); }
            set { BackingStore?.Set("isPerDeviceAcceptanceRequired", value); }
        }
        /// <summary>Indicates whether the user has to expand the agreement before accepting. Supports $filter (eq).</summary>
        public bool? IsViewingBeforeAcceptanceRequired {
            get { return BackingStore?.Get<bool?>("isViewingBeforeAcceptanceRequired"); }
            set { BackingStore?.Set("isViewingBeforeAcceptanceRequired", value); }
        }
        /// <summary>Expiration schedule and frequency of agreement for all users.  Supports $filter (eq).</summary>
        public Microsoft.Graph.Models.TermsExpiration TermsExpiration {
            get { return BackingStore?.Get<Microsoft.Graph.Models.TermsExpiration>("termsExpiration"); }
            set { BackingStore?.Set("termsExpiration", value); }
        }
        /// <summary>The duration after which the user must re-accept the terms of use. The value is represented in ISO 8601 format for durations.</summary>
        public TimeSpan? UserReacceptRequiredFrequency {
            get { return BackingStore?.Get<TimeSpan?>("userReacceptRequiredFrequency"); }
            set { BackingStore?.Set("userReacceptRequiredFrequency", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Agreement CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Agreement();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"acceptances", n => { Acceptances = n.GetCollectionOfObjectValues<AgreementAcceptance>(AgreementAcceptance.CreateFromDiscriminatorValue).ToList(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"file", n => { FileObject = n.GetObjectValue<AgreementFile>(AgreementFile.CreateFromDiscriminatorValue); } },
                {"files", n => { Files = n.GetCollectionOfObjectValues<AgreementFileLocalization>(AgreementFileLocalization.CreateFromDiscriminatorValue).ToList(); } },
                {"isPerDeviceAcceptanceRequired", n => { IsPerDeviceAcceptanceRequired = n.GetBoolValue(); } },
                {"isViewingBeforeAcceptanceRequired", n => { IsViewingBeforeAcceptanceRequired = n.GetBoolValue(); } },
                {"termsExpiration", n => { TermsExpiration = n.GetObjectValue<Microsoft.Graph.Models.TermsExpiration>(Microsoft.Graph.Models.TermsExpiration.CreateFromDiscriminatorValue); } },
                {"userReacceptRequiredFrequency", n => { UserReacceptRequiredFrequency = n.GetTimeSpanValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<AgreementAcceptance>("acceptances", Acceptances);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<AgreementFile>("file", FileObject);
            writer.WriteCollectionOfObjectValues<AgreementFileLocalization>("files", Files);
            writer.WriteBoolValue("isPerDeviceAcceptanceRequired", IsPerDeviceAcceptanceRequired);
            writer.WriteBoolValue("isViewingBeforeAcceptanceRequired", IsViewingBeforeAcceptanceRequired);
            writer.WriteObjectValue<Microsoft.Graph.Models.TermsExpiration>("termsExpiration", TermsExpiration);
            writer.WriteTimeSpanValue("userReacceptRequiredFrequency", UserReacceptRequiredFrequency);
        }
    }
}
