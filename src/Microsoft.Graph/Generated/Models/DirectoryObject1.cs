// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class DirectoryObject1 : global::Microsoft.Graph.Models.Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Conceptual container for user and group directory objects.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.AdministrativeUnit>? AdministrativeUnits
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.AdministrativeUnit>?>("administrativeUnits"); }
            set { BackingStore?.Set("administrativeUnits", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.AdministrativeUnit> AdministrativeUnits
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.AdministrativeUnit>>("administrativeUnits"); }
            set { BackingStore?.Set("administrativeUnits", value); }
        }
#endif
        /// <summary>Group of related custom security attribute definitions.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.AttributeSet>? AttributeSets
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.AttributeSet>?>("attributeSets"); }
            set { BackingStore?.Set("attributeSets", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.AttributeSet> AttributeSets
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.AttributeSet>>("attributeSets"); }
            set { BackingStore?.Set("attributeSets", value); }
        }
#endif
        /// <summary>Schema of a custom security attributes (key-value pairs).</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.CustomSecurityAttributeDefinition>? CustomSecurityAttributeDefinitions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.CustomSecurityAttributeDefinition>?>("customSecurityAttributeDefinitions"); }
            set { BackingStore?.Set("customSecurityAttributeDefinitions", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.CustomSecurityAttributeDefinition> CustomSecurityAttributeDefinitions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.CustomSecurityAttributeDefinition>>("customSecurityAttributeDefinitions"); }
            set { BackingStore?.Set("customSecurityAttributeDefinitions", value); }
        }
#endif
        /// <summary>Recently deleted items. Read-only. Nullable.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.DirectoryObject>? DeletedItems
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DirectoryObject>?>("deletedItems"); }
            set { BackingStore?.Set("deletedItems", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.DirectoryObject> DeletedItems
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DirectoryObject>>("deletedItems"); }
            set { BackingStore?.Set("deletedItems", value); }
        }
#endif
        /// <summary>The credentials of the device&apos;s local administrator account backed up to Microsoft Entra ID.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.DeviceLocalCredentialInfo>? DeviceLocalCredentials
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceLocalCredentialInfo>?>("deviceLocalCredentials"); }
            set { BackingStore?.Set("deviceLocalCredentials", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.DeviceLocalCredentialInfo> DeviceLocalCredentials
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DeviceLocalCredentialInfo>>("deviceLocalCredentials"); }
            set { BackingStore?.Set("deviceLocalCredentials", value); }
        }
#endif
        /// <summary>Configure domain federation with organizations whose identity provider (IdP) supports either the SAML or WS-Fed protocol.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.IdentityProviderBase>? FederationConfigurations
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.IdentityProviderBase>?>("federationConfigurations"); }
            set { BackingStore?.Set("federationConfigurations", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.IdentityProviderBase> FederationConfigurations
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.IdentityProviderBase>>("federationConfigurations"); }
            set { BackingStore?.Set("federationConfigurations", value); }
        }
#endif
        /// <summary>A container for on-premises directory synchronization functionalities that are available for the organization.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.OnPremisesDirectorySynchronization>? OnPremisesSynchronization
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OnPremisesDirectorySynchronization>?>("onPremisesSynchronization"); }
            set { BackingStore?.Set("onPremisesSynchronization", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.OnPremisesDirectorySynchronization> OnPremisesSynchronization
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OnPremisesDirectorySynchronization>>("onPremisesSynchronization"); }
            set { BackingStore?.Set("onPremisesSynchronization", value); }
        }
#endif
        /// <summary>The collection of public key infrastructure instances for the certificate-based authentication feature for users in a Microsoft Entra tenant.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::Microsoft.Graph.Models.PublicKeyInfrastructureRoot? PublicKeyInfrastructure
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PublicKeyInfrastructureRoot?>("publicKeyInfrastructure"); }
            set { BackingStore?.Set("publicKeyInfrastructure", value); }
        }
#nullable restore
#else
        public global::Microsoft.Graph.Models.PublicKeyInfrastructureRoot PublicKeyInfrastructure
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.PublicKeyInfrastructureRoot>("publicKeyInfrastructure"); }
            set { BackingStore?.Set("publicKeyInfrastructure", value); }
        }
#endif
        /// <summary>List of commercial subscriptions that an organization acquired.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.CompanySubscription>? Subscriptions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.CompanySubscription>?>("subscriptions"); }
            set { BackingStore?.Set("subscriptions", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.CompanySubscription> Subscriptions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.CompanySubscription>>("subscriptions"); }
            set { BackingStore?.Set("subscriptions", value); }
        }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.DirectoryObject1"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::Microsoft.Graph.Models.DirectoryObject1 CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Microsoft.Graph.Models.DirectoryObject1();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "administrativeUnits", n => { AdministrativeUnits = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.AdministrativeUnit>(global::Microsoft.Graph.Models.AdministrativeUnit.CreateFromDiscriminatorValue)?.AsList(); } },
                { "attributeSets", n => { AttributeSets = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.AttributeSet>(global::Microsoft.Graph.Models.AttributeSet.CreateFromDiscriminatorValue)?.AsList(); } },
                { "customSecurityAttributeDefinitions", n => { CustomSecurityAttributeDefinitions = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.CustomSecurityAttributeDefinition>(global::Microsoft.Graph.Models.CustomSecurityAttributeDefinition.CreateFromDiscriminatorValue)?.AsList(); } },
                { "deletedItems", n => { DeletedItems = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.DirectoryObject>(global::Microsoft.Graph.Models.DirectoryObject.CreateFromDiscriminatorValue)?.AsList(); } },
                { "deviceLocalCredentials", n => { DeviceLocalCredentials = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceLocalCredentialInfo>(global::Microsoft.Graph.Models.DeviceLocalCredentialInfo.CreateFromDiscriminatorValue)?.AsList(); } },
                { "federationConfigurations", n => { FederationConfigurations = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.IdentityProviderBase>(global::Microsoft.Graph.Models.IdentityProviderBase.CreateFromDiscriminatorValue)?.AsList(); } },
                { "onPremisesSynchronization", n => { OnPremisesSynchronization = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.OnPremisesDirectorySynchronization>(global::Microsoft.Graph.Models.OnPremisesDirectorySynchronization.CreateFromDiscriminatorValue)?.AsList(); } },
                { "publicKeyInfrastructure", n => { PublicKeyInfrastructure = n.GetObjectValue<global::Microsoft.Graph.Models.PublicKeyInfrastructureRoot>(global::Microsoft.Graph.Models.PublicKeyInfrastructureRoot.CreateFromDiscriminatorValue); } },
                { "subscriptions", n => { Subscriptions = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.CompanySubscription>(global::Microsoft.Graph.Models.CompanySubscription.CreateFromDiscriminatorValue)?.AsList(); } },
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
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.AdministrativeUnit>("administrativeUnits", AdministrativeUnits);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.AttributeSet>("attributeSets", AttributeSets);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.CustomSecurityAttributeDefinition>("customSecurityAttributeDefinitions", CustomSecurityAttributeDefinitions);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.DirectoryObject>("deletedItems", DeletedItems);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.DeviceLocalCredentialInfo>("deviceLocalCredentials", DeviceLocalCredentials);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.IdentityProviderBase>("federationConfigurations", FederationConfigurations);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.OnPremisesDirectorySynchronization>("onPremisesSynchronization", OnPremisesSynchronization);
            writer.WriteObjectValue<global::Microsoft.Graph.Models.PublicKeyInfrastructureRoot>("publicKeyInfrastructure", PublicKeyInfrastructure);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.CompanySubscription>("subscriptions", Subscriptions);
        }
    }
}
#pragma warning restore CS0618
