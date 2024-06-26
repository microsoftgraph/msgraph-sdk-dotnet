// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    #pragma warning disable CS1591
    public class B2xIdentityUserFlow : Microsoft.Graph.Models.IdentityUserFlow, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Configuration for enabling an API connector for use as part of the self-service sign-up user flow. You can only obtain the value of this object using Get userFlowApiConnectorConfiguration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.UserFlowApiConnectorConfiguration? ApiConnectorConfiguration
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.UserFlowApiConnectorConfiguration?>("apiConnectorConfiguration"); }
            set { BackingStore?.Set("apiConnectorConfiguration", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.UserFlowApiConnectorConfiguration ApiConnectorConfiguration
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.UserFlowApiConnectorConfiguration>("apiConnectorConfiguration"); }
            set { BackingStore?.Set("apiConnectorConfiguration", value); }
        }
#endif
        /// <summary>The identity providers included in the user flow.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.IdentityProvider>? IdentityProviders
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.IdentityProvider>?>("identityProviders"); }
            set { BackingStore?.Set("identityProviders", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.IdentityProvider> IdentityProviders
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.IdentityProvider>>("identityProviders"); }
            set { BackingStore?.Set("identityProviders", value); }
        }
#endif
        /// <summary>The languages supported for customization within the user flow. Language customization is enabled by default in self-service sign-up user flow. You can&apos;t create custom languages in self-service sign-up user flows.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.UserFlowLanguageConfiguration>? Languages
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.UserFlowLanguageConfiguration>?>("languages"); }
            set { BackingStore?.Set("languages", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.UserFlowLanguageConfiguration> Languages
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.UserFlowLanguageConfiguration>>("languages"); }
            set { BackingStore?.Set("languages", value); }
        }
#endif
        /// <summary>The user attribute assignments included in the user flow.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.IdentityUserFlowAttributeAssignment>? UserAttributeAssignments
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.IdentityUserFlowAttributeAssignment>?>("userAttributeAssignments"); }
            set { BackingStore?.Set("userAttributeAssignments", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.IdentityUserFlowAttributeAssignment> UserAttributeAssignments
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.IdentityUserFlowAttributeAssignment>>("userAttributeAssignments"); }
            set { BackingStore?.Set("userAttributeAssignments", value); }
        }
#endif
        /// <summary>The userFlowIdentityProviders property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.IdentityProviderBase>? UserFlowIdentityProviders
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.IdentityProviderBase>?>("userFlowIdentityProviders"); }
            set { BackingStore?.Set("userFlowIdentityProviders", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.IdentityProviderBase> UserFlowIdentityProviders
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.IdentityProviderBase>>("userFlowIdentityProviders"); }
            set { BackingStore?.Set("userFlowIdentityProviders", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.B2xIdentityUserFlow"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.B2xIdentityUserFlow CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Microsoft.Graph.Models.B2xIdentityUserFlow();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "apiConnectorConfiguration", n => { ApiConnectorConfiguration = n.GetObjectValue<Microsoft.Graph.Models.UserFlowApiConnectorConfiguration>(Microsoft.Graph.Models.UserFlowApiConnectorConfiguration.CreateFromDiscriminatorValue); } },
                { "identityProviders", n => { IdentityProviders = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.IdentityProvider>(Microsoft.Graph.Models.IdentityProvider.CreateFromDiscriminatorValue)?.ToList(); } },
                { "languages", n => { Languages = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.UserFlowLanguageConfiguration>(Microsoft.Graph.Models.UserFlowLanguageConfiguration.CreateFromDiscriminatorValue)?.ToList(); } },
                { "userAttributeAssignments", n => { UserAttributeAssignments = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.IdentityUserFlowAttributeAssignment>(Microsoft.Graph.Models.IdentityUserFlowAttributeAssignment.CreateFromDiscriminatorValue)?.ToList(); } },
                { "userFlowIdentityProviders", n => { UserFlowIdentityProviders = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.IdentityProviderBase>(Microsoft.Graph.Models.IdentityProviderBase.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<Microsoft.Graph.Models.UserFlowApiConnectorConfiguration>("apiConnectorConfiguration", ApiConnectorConfiguration);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.IdentityProvider>("identityProviders", IdentityProviders);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.UserFlowLanguageConfiguration>("languages", Languages);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.IdentityUserFlowAttributeAssignment>("userAttributeAssignments", UserAttributeAssignments);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.IdentityProviderBase>("userFlowIdentityProviders", UserFlowIdentityProviders);
        }
    }
}
