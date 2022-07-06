using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Microsoft.Graph.Models {
    public class IdentityContainer : Entity, IParsable {
        /// <summary>Represents entry point for API connectors.</summary>
        public List<IdentityApiConnector> ApiConnectors {
            get { return BackingStore?.Get<List<IdentityApiConnector>>("apiConnectors"); }
            set { BackingStore?.Set("apiConnectors", value); }
        }
        /// <summary>Represents entry point for B2X and self-service sign-up identity userflows.</summary>
        public List<B2xIdentityUserFlow> B2xUserFlows {
            get { return BackingStore?.Get<List<B2xIdentityUserFlow>>("b2xUserFlows"); }
            set { BackingStore?.Set("b2xUserFlows", value); }
        }
        /// <summary>the entry point for the Conditional Access (CA) object model.</summary>
        public ConditionalAccessRoot ConditionalAccess {
            get { return BackingStore?.Get<ConditionalAccessRoot>("conditionalAccess"); }
            set { BackingStore?.Set("conditionalAccess", value); }
        }
        /// <summary>Represents entry point for identity provider base.</summary>
        public List<IdentityProviderBase> IdentityProviders {
            get { return BackingStore?.Get<List<IdentityProviderBase>>("identityProviders"); }
            set { BackingStore?.Set("identityProviders", value); }
        }
        /// <summary>Represents entry point for identity userflow attributes.</summary>
        public List<IdentityUserFlowAttribute> UserFlowAttributes {
            get { return BackingStore?.Get<List<IdentityUserFlowAttribute>>("userFlowAttributes"); }
            set { BackingStore?.Set("userFlowAttributes", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IdentityContainer CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IdentityContainer();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"apiConnectors", n => { ApiConnectors = n.GetCollectionOfObjectValues<IdentityApiConnector>(IdentityApiConnector.CreateFromDiscriminatorValue).ToList(); } },
                {"b2xUserFlows", n => { B2xUserFlows = n.GetCollectionOfObjectValues<B2xIdentityUserFlow>(B2xIdentityUserFlow.CreateFromDiscriminatorValue).ToList(); } },
                {"conditionalAccess", n => { ConditionalAccess = n.GetObjectValue<ConditionalAccessRoot>(ConditionalAccessRoot.CreateFromDiscriminatorValue); } },
                {"identityProviders", n => { IdentityProviders = n.GetCollectionOfObjectValues<IdentityProviderBase>(IdentityProviderBase.CreateFromDiscriminatorValue).ToList(); } },
                {"userFlowAttributes", n => { UserFlowAttributes = n.GetCollectionOfObjectValues<IdentityUserFlowAttribute>(IdentityUserFlowAttribute.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<IdentityApiConnector>("apiConnectors", ApiConnectors);
            writer.WriteCollectionOfObjectValues<B2xIdentityUserFlow>("b2xUserFlows", B2xUserFlows);
            writer.WriteObjectValue<ConditionalAccessRoot>("conditionalAccess", ConditionalAccess);
            writer.WriteCollectionOfObjectValues<IdentityProviderBase>("identityProviders", IdentityProviders);
            writer.WriteCollectionOfObjectValues<IdentityUserFlowAttribute>("userFlowAttributes", UserFlowAttributes);
        }
    }
}
