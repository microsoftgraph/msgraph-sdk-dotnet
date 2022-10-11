using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    /// <summary>Provides operations to manage the authenticationMethodsPolicy singleton.</summary>
    public class AuthenticationMethodsPolicy : Entity, IParsable {
        /// <summary>Represents the settings for each authentication method. Automatically expanded on GET /policies/authenticationMethodsPolicy.</summary>
        public List<AuthenticationMethodConfiguration> AuthenticationMethodConfigurations {
            get { return BackingStore?.Get<List<AuthenticationMethodConfiguration>>("authenticationMethodConfigurations"); }
            set { BackingStore?.Set("authenticationMethodConfigurations", value); }
        }
        /// <summary>A description of the policy. Read-only.</summary>
        public string Description {
            get { return BackingStore?.Get<string>("description"); }
            set { BackingStore?.Set("description", value); }
        }
        /// <summary>The name of the policy. Read-only.</summary>
        public string DisplayName {
            get { return BackingStore?.Get<string>("displayName"); }
            set { BackingStore?.Set("displayName", value); }
        }
        /// <summary>The date and time of the last update to the policy. Read-only.</summary>
        public DateTimeOffset? LastModifiedDateTime {
            get { return BackingStore?.Get<DateTimeOffset?>("lastModifiedDateTime"); }
            set { BackingStore?.Set("lastModifiedDateTime", value); }
        }
        /// <summary>The version of the policy in use. Read-only.</summary>
        public string PolicyVersion {
            get { return BackingStore?.Get<string>("policyVersion"); }
            set { BackingStore?.Set("policyVersion", value); }
        }
        /// <summary>The reconfirmationInDays property</summary>
        public int? ReconfirmationInDays {
            get { return BackingStore?.Get<int?>("reconfirmationInDays"); }
            set { BackingStore?.Set("reconfirmationInDays", value); }
        }
        /// <summary>Enforce registration at sign-in time. This property can be used to remind users to set up targeted authentication methods.</summary>
        public Microsoft.Graph.Models.RegistrationEnforcement RegistrationEnforcement {
            get { return BackingStore?.Get<Microsoft.Graph.Models.RegistrationEnforcement>("registrationEnforcement"); }
            set { BackingStore?.Set("registrationEnforcement", value); }
        }
        /// <summary>
        /// Instantiates a new authenticationMethodsPolicy and sets the default values.
        /// </summary>
        public AuthenticationMethodsPolicy() : base() {
            OdataType = "#microsoft.graph.authenticationMethodsPolicy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AuthenticationMethodsPolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AuthenticationMethodsPolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"authenticationMethodConfigurations", n => { AuthenticationMethodConfigurations = n.GetCollectionOfObjectValues<AuthenticationMethodConfiguration>(AuthenticationMethodConfiguration.CreateFromDiscriminatorValue)?.ToList(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"policyVersion", n => { PolicyVersion = n.GetStringValue(); } },
                {"reconfirmationInDays", n => { ReconfirmationInDays = n.GetIntValue(); } },
                {"registrationEnforcement", n => { RegistrationEnforcement = n.GetObjectValue<Microsoft.Graph.Models.RegistrationEnforcement>(Microsoft.Graph.Models.RegistrationEnforcement.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<AuthenticationMethodConfiguration>("authenticationMethodConfigurations", AuthenticationMethodConfigurations);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("policyVersion", PolicyVersion);
            writer.WriteIntValue("reconfirmationInDays", ReconfirmationInDays);
            writer.WriteObjectValue<Microsoft.Graph.Models.RegistrationEnforcement>("registrationEnforcement", RegistrationEnforcement);
        }
    }
}
