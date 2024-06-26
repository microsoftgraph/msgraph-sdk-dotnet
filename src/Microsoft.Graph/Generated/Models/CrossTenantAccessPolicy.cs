// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    #pragma warning disable CS1591
    public class CrossTenantAccessPolicy : Microsoft.Graph.Models.PolicyBase, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Used to specify which Microsoft clouds an organization would like to collaborate with. By default, this value is empty. Supported values for this field are: microsoftonline.com, microsoftonline.us, and partner.microsoftonline.cn.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<string>? AllowedCloudEndpoints
        {
            get { return BackingStore?.Get<List<string>?>("allowedCloudEndpoints"); }
            set { BackingStore?.Set("allowedCloudEndpoints", value); }
        }
#nullable restore
#else
        public List<string> AllowedCloudEndpoints
        {
            get { return BackingStore?.Get<List<string>>("allowedCloudEndpoints"); }
            set { BackingStore?.Set("allowedCloudEndpoints", value); }
        }
#endif
        /// <summary>Defines the default configuration for how your organization interacts with external Microsoft Entra organizations.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationDefault? Default
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationDefault?>("default"); }
            set { BackingStore?.Set("default", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationDefault Default
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationDefault>("default"); }
            set { BackingStore?.Set("default", value); }
        }
#endif
        /// <summary>Defines partner-specific configurations for external Microsoft Entra organizations.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationPartner>? Partners
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationPartner>?>("partners"); }
            set { BackingStore?.Set("partners", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationPartner> Partners
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationPartner>>("partners"); }
            set { BackingStore?.Set("partners", value); }
        }
#endif
        /// <summary>Represents the base policy in the directory for multitenant organization settings.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Microsoft.Graph.Models.PolicyTemplate? Templates
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PolicyTemplate?>("templates"); }
            set { BackingStore?.Set("templates", value); }
        }
#nullable restore
#else
        public Microsoft.Graph.Models.PolicyTemplate Templates
        {
            get { return BackingStore?.Get<Microsoft.Graph.Models.PolicyTemplate>("templates"); }
            set { BackingStore?.Set("templates", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="Microsoft.Graph.Models.CrossTenantAccessPolicy"/> and sets the default values.
        /// </summary>
        public CrossTenantAccessPolicy() : base()
        {
            OdataType = "#microsoft.graph.crossTenantAccessPolicy";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.CrossTenantAccessPolicy"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.CrossTenantAccessPolicy CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Microsoft.Graph.Models.CrossTenantAccessPolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "allowedCloudEndpoints", n => { AllowedCloudEndpoints = n.GetCollectionOfPrimitiveValues<string>()?.ToList(); } },
                { "default", n => { Default = n.GetObjectValue<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationDefault>(Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationDefault.CreateFromDiscriminatorValue); } },
                { "partners", n => { Partners = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationPartner>(Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationPartner.CreateFromDiscriminatorValue)?.ToList(); } },
                { "templates", n => { Templates = n.GetObjectValue<Microsoft.Graph.Models.PolicyTemplate>(Microsoft.Graph.Models.PolicyTemplate.CreateFromDiscriminatorValue); } },
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
            writer.WriteCollectionOfPrimitiveValues<string>("allowedCloudEndpoints", AllowedCloudEndpoints);
            writer.WriteObjectValue<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationDefault>("default", Default);
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.CrossTenantAccessPolicyConfigurationPartner>("partners", Partners);
            writer.WriteObjectValue<Microsoft.Graph.Models.PolicyTemplate>("templates", Templates);
        }
    }
}
