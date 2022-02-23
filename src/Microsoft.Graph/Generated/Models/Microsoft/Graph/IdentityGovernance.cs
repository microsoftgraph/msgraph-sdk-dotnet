using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class IdentityGovernance : IParsable {
        public AccessReviewSet AccessReviews { get; set; }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        public AppConsentApprovalRoute AppConsent { get; set; }
        public EntitlementManagement EntitlementManagement { get; set; }
        public TermsOfUseContainer TermsOfUse { get; set; }
        /// <summary>
        /// Instantiates a new IdentityGovernance and sets the default values.
        /// </summary>
        public IdentityGovernance() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"accessReviews", (o,n) => { (o as IdentityGovernance).AccessReviews = n.GetObjectValue<AccessReviewSet>(); } },
                {"appConsent", (o,n) => { (o as IdentityGovernance).AppConsent = n.GetObjectValue<AppConsentApprovalRoute>(); } },
                {"entitlementManagement", (o,n) => { (o as IdentityGovernance).EntitlementManagement = n.GetObjectValue<EntitlementManagement>(); } },
                {"termsOfUse", (o,n) => { (o as IdentityGovernance).TermsOfUse = n.GetObjectValue<TermsOfUseContainer>(); } },
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
            writer.WriteObjectValue<EntitlementManagement>("entitlementManagement", EntitlementManagement);
            writer.WriteObjectValue<TermsOfUseContainer>("termsOfUse", TermsOfUse);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
