using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IdentityGovernance : IAdditionalDataHolder, IBackedModel, IParsable {
        /// <summary>The accessReviews property</summary>
        public AccessReviewSet AccessReviews {
            get { return BackingStore?.Get<AccessReviewSet>("accessReviews"); }
            set { BackingStore?.Set("accessReviews", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData {
            get { return BackingStore?.Get<IDictionary<string, object>>("additionalData"); }
            set { BackingStore?.Set("additionalData", value); }
        }
        /// <summary>The appConsent property</summary>
        public AppConsentApprovalRoute AppConsent {
            get { return BackingStore?.Get<AppConsentApprovalRoute>("appConsent"); }
            set { BackingStore?.Set("appConsent", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The entitlementManagement property</summary>
        public Microsoft.Graph.Models.EntitlementManagement EntitlementManagement {
            get { return BackingStore?.Get<Microsoft.Graph.Models.EntitlementManagement>("entitlementManagement"); }
            set { BackingStore?.Set("entitlementManagement", value); }
        }
        /// <summary>The termsOfUse property</summary>
        public TermsOfUseContainer TermsOfUse {
            get { return BackingStore?.Get<TermsOfUseContainer>("termsOfUse"); }
            set { BackingStore?.Set("termsOfUse", value); }
        }
        /// <summary>
        /// Instantiates a new IdentityGovernance and sets the default values.
        /// </summary>
        public IdentityGovernance() {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static IdentityGovernance CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IdentityGovernance();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"accessReviews", n => { AccessReviews = n.GetObjectValue<AccessReviewSet>(AccessReviewSet.CreateFromDiscriminatorValue); } },
                {"appConsent", n => { AppConsent = n.GetObjectValue<AppConsentApprovalRoute>(AppConsentApprovalRoute.CreateFromDiscriminatorValue); } },
                {"entitlementManagement", n => { EntitlementManagement = n.GetObjectValue<Microsoft.Graph.Models.EntitlementManagement>(Microsoft.Graph.Models.EntitlementManagement.CreateFromDiscriminatorValue); } },
                {"termsOfUse", n => { TermsOfUse = n.GetObjectValue<TermsOfUseContainer>(TermsOfUseContainer.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<AccessReviewSet>("accessReviews", AccessReviews);
            writer.WriteObjectValue<AppConsentApprovalRoute>("appConsent", AppConsent);
            writer.WriteObjectValue<Microsoft.Graph.Models.EntitlementManagement>("entitlementManagement", EntitlementManagement);
            writer.WriteObjectValue<TermsOfUseContainer>("termsOfUse", TermsOfUse);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
