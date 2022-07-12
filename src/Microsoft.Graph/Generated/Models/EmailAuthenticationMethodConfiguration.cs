using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class EmailAuthenticationMethodConfiguration : AuthenticationMethodConfiguration, IParsable {
        /// <summary>Determines whether email OTP is usable by external users for authentication. Possible values are: default, enabled, disabled, unknownFutureValue. Tenants in the default state who did not use public preview will automatically have email OTP enabled beginning in October 2021.</summary>
        public ExternalEmailOtpState? AllowExternalIdToUseEmailOtp {
            get { return BackingStore?.Get<ExternalEmailOtpState?>("allowExternalIdToUseEmailOtp"); }
            set { BackingStore?.Set("allowExternalIdToUseEmailOtp", value); }
        }
        /// <summary>A collection of users or groups who are enabled to use the authentication method.</summary>
        public List<AuthenticationMethodTarget> IncludeTargets {
            get { return BackingStore?.Get<List<AuthenticationMethodTarget>>("includeTargets"); }
            set { BackingStore?.Set("includeTargets", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new EmailAuthenticationMethodConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new EmailAuthenticationMethodConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"allowExternalIdToUseEmailOtp", n => { AllowExternalIdToUseEmailOtp = n.GetEnumValue<ExternalEmailOtpState>(); } },
                {"includeTargets", n => { IncludeTargets = n.GetCollectionOfObjectValues<AuthenticationMethodTarget>(AuthenticationMethodTarget.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ExternalEmailOtpState>("allowExternalIdToUseEmailOtp", AllowExternalIdToUseEmailOtp);
            writer.WriteCollectionOfObjectValues<AuthenticationMethodTarget>("includeTargets", IncludeTargets);
        }
    }
}
