using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class Authentication : Entity, IParsable {
        /// <summary>Represents the FIDO2 security keys registered to a user for authentication.</summary>
        public List<Fido2AuthenticationMethod> Fido2Methods {
            get { return BackingStore?.Get<List<Fido2AuthenticationMethod>>("fido2Methods"); }
            set { BackingStore?.Set("fido2Methods", value); }
        }
        /// <summary>Represents all authentication methods registered to a user.</summary>
        public List<AuthenticationMethod> Methods {
            get { return BackingStore?.Get<List<AuthenticationMethod>>("methods"); }
            set { BackingStore?.Set("methods", value); }
        }
        /// <summary>The details of the Microsoft Authenticator app registered to a user for authentication.</summary>
        public List<MicrosoftAuthenticatorAuthenticationMethod> MicrosoftAuthenticatorMethods {
            get { return BackingStore?.Get<List<MicrosoftAuthenticatorAuthenticationMethod>>("microsoftAuthenticatorMethods"); }
            set { BackingStore?.Set("microsoftAuthenticatorMethods", value); }
        }
        /// <summary>The operations property</summary>
        public List<LongRunningOperation> Operations {
            get { return BackingStore?.Get<List<LongRunningOperation>>("operations"); }
            set { BackingStore?.Set("operations", value); }
        }
        /// <summary>Represents the details of the password authentication method registered to a user for authentication.</summary>
        public List<PasswordAuthenticationMethod> PasswordMethods {
            get { return BackingStore?.Get<List<PasswordAuthenticationMethod>>("passwordMethods"); }
            set { BackingStore?.Set("passwordMethods", value); }
        }
        /// <summary>Represents a Temporary Access Pass registered to a user for authentication through time-limited passcodes.</summary>
        public List<TemporaryAccessPassAuthenticationMethod> TemporaryAccessPassMethods {
            get { return BackingStore?.Get<List<TemporaryAccessPassAuthenticationMethod>>("temporaryAccessPassMethods"); }
            set { BackingStore?.Set("temporaryAccessPassMethods", value); }
        }
        /// <summary>Represents the Windows Hello for Business authentication method registered to a user for authentication.</summary>
        public List<WindowsHelloForBusinessAuthenticationMethod> WindowsHelloForBusinessMethods {
            get { return BackingStore?.Get<List<WindowsHelloForBusinessAuthenticationMethod>>("windowsHelloForBusinessMethods"); }
            set { BackingStore?.Set("windowsHelloForBusinessMethods", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Authentication CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Authentication();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"fido2Methods", n => { Fido2Methods = n.GetCollectionOfObjectValues<Fido2AuthenticationMethod>(Fido2AuthenticationMethod.CreateFromDiscriminatorValue).ToList(); } },
                {"methods", n => { Methods = n.GetCollectionOfObjectValues<AuthenticationMethod>(AuthenticationMethod.CreateFromDiscriminatorValue).ToList(); } },
                {"microsoftAuthenticatorMethods", n => { MicrosoftAuthenticatorMethods = n.GetCollectionOfObjectValues<MicrosoftAuthenticatorAuthenticationMethod>(MicrosoftAuthenticatorAuthenticationMethod.CreateFromDiscriminatorValue).ToList(); } },
                {"operations", n => { Operations = n.GetCollectionOfObjectValues<LongRunningOperation>(LongRunningOperation.CreateFromDiscriminatorValue).ToList(); } },
                {"passwordMethods", n => { PasswordMethods = n.GetCollectionOfObjectValues<PasswordAuthenticationMethod>(PasswordAuthenticationMethod.CreateFromDiscriminatorValue).ToList(); } },
                {"temporaryAccessPassMethods", n => { TemporaryAccessPassMethods = n.GetCollectionOfObjectValues<TemporaryAccessPassAuthenticationMethod>(TemporaryAccessPassAuthenticationMethod.CreateFromDiscriminatorValue).ToList(); } },
                {"windowsHelloForBusinessMethods", n => { WindowsHelloForBusinessMethods = n.GetCollectionOfObjectValues<WindowsHelloForBusinessAuthenticationMethod>(WindowsHelloForBusinessAuthenticationMethod.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Fido2AuthenticationMethod>("fido2Methods", Fido2Methods);
            writer.WriteCollectionOfObjectValues<AuthenticationMethod>("methods", Methods);
            writer.WriteCollectionOfObjectValues<MicrosoftAuthenticatorAuthenticationMethod>("microsoftAuthenticatorMethods", MicrosoftAuthenticatorMethods);
            writer.WriteCollectionOfObjectValues<LongRunningOperation>("operations", Operations);
            writer.WriteCollectionOfObjectValues<PasswordAuthenticationMethod>("passwordMethods", PasswordMethods);
            writer.WriteCollectionOfObjectValues<TemporaryAccessPassAuthenticationMethod>("temporaryAccessPassMethods", TemporaryAccessPassMethods);
            writer.WriteCollectionOfObjectValues<WindowsHelloForBusinessAuthenticationMethod>("windowsHelloForBusinessMethods", WindowsHelloForBusinessMethods);
        }
    }
}
