using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MicrosoftGraphSdk.Models.Microsoft.Graph {
    public class TermsAndConditionsAcceptanceStatus : Entity, IParsable {
        /// <summary>DateTime when the terms were last accepted by the user.</summary>
        public DateTimeOffset? AcceptedDateTime { get; set; }
        /// <summary>Most recent version number of the T&C accepted by the user.</summary>
        public int? AcceptedVersion { get; set; }
        /// <summary>Navigation link to the terms and conditions that are assigned.</summary>
        public TermsAndConditions TermsAndConditions { get; set; }
        /// <summary>Display name of the user whose acceptance the entity represents.</summary>
        public string UserDisplayName { get; set; }
        /// <summary>The userPrincipalName of the User that accepted the term.</summary>
        public string UserPrincipalName { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"acceptedDateTime", (o,n) => { (o as TermsAndConditionsAcceptanceStatus).AcceptedDateTime = n.GetDateTimeOffsetValue(); } },
                {"acceptedVersion", (o,n) => { (o as TermsAndConditionsAcceptanceStatus).AcceptedVersion = n.GetIntValue(); } },
                {"termsAndConditions", (o,n) => { (o as TermsAndConditionsAcceptanceStatus).TermsAndConditions = n.GetObjectValue<TermsAndConditions>(); } },
                {"userDisplayName", (o,n) => { (o as TermsAndConditionsAcceptanceStatus).UserDisplayName = n.GetStringValue(); } },
                {"userPrincipalName", (o,n) => { (o as TermsAndConditionsAcceptanceStatus).UserPrincipalName = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteDateTimeOffsetValue("acceptedDateTime", AcceptedDateTime);
            writer.WriteIntValue("acceptedVersion", AcceptedVersion);
            writer.WriteObjectValue<TermsAndConditions>("termsAndConditions", TermsAndConditions);
            writer.WriteStringValue("userDisplayName", UserDisplayName);
            writer.WriteStringValue("userPrincipalName", UserPrincipalName);
        }
    }
}
