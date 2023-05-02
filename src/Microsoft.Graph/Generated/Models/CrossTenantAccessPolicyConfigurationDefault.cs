using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models {
    public class CrossTenantAccessPolicyConfigurationDefault : Entity, IParsable {
        /// <summary>The automaticUserConsentSettings property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public InboundOutboundPolicyConfiguration? AutomaticUserConsentSettings {
            get { return BackingStore?.Get<InboundOutboundPolicyConfiguration?>("automaticUserConsentSettings"); }
            set { BackingStore?.Set("automaticUserConsentSettings", value); }
        }
#nullable restore
#else
        public InboundOutboundPolicyConfiguration AutomaticUserConsentSettings {
            get { return BackingStore?.Get<InboundOutboundPolicyConfiguration>("automaticUserConsentSettings"); }
            set { BackingStore?.Set("automaticUserConsentSettings", value); }
        }
#endif
        /// <summary>Defines your default configuration for users from other organizations accessing your resources via Azure AD B2B collaboration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting?>("b2bCollaborationInbound"); }
            set { BackingStore?.Set("b2bCollaborationInbound", value); }
        }
#nullable restore
#else
        public CrossTenantAccessPolicyB2BSetting B2bCollaborationInbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting>("b2bCollaborationInbound"); }
            set { BackingStore?.Set("b2bCollaborationInbound", value); }
        }
#endif
        /// <summary>Defines your default configuration for users in your organization going outbound to access resources in another organization via Azure AD B2B collaboration.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting?>("b2bCollaborationOutbound"); }
            set { BackingStore?.Set("b2bCollaborationOutbound", value); }
        }
#nullable restore
#else
        public CrossTenantAccessPolicyB2BSetting B2bCollaborationOutbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting>("b2bCollaborationOutbound"); }
            set { BackingStore?.Set("b2bCollaborationOutbound", value); }
        }
#endif
        /// <summary>Defines your default configuration for users from other organizations accessing your resources via Azure AD B2B direct connect.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting?>("b2bDirectConnectInbound"); }
            set { BackingStore?.Set("b2bDirectConnectInbound", value); }
        }
#nullable restore
#else
        public CrossTenantAccessPolicyB2BSetting B2bDirectConnectInbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting>("b2bDirectConnectInbound"); }
            set { BackingStore?.Set("b2bDirectConnectInbound", value); }
        }
#endif
        /// <summary>Defines your default configuration for users in your organization going outbound to access resources in another organization via Azure AD B2B direct connect.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting?>("b2bDirectConnectOutbound"); }
            set { BackingStore?.Set("b2bDirectConnectOutbound", value); }
        }
#nullable restore
#else
        public CrossTenantAccessPolicyB2BSetting B2bDirectConnectOutbound {
            get { return BackingStore?.Get<CrossTenantAccessPolicyB2BSetting>("b2bDirectConnectOutbound"); }
            set { BackingStore?.Set("b2bDirectConnectOutbound", value); }
        }
#endif
        /// <summary>Determines the default configuration for trusting other Conditional Access claims from external Azure AD organizations.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public CrossTenantAccessPolicyInboundTrust? InboundTrust {
            get { return BackingStore?.Get<CrossTenantAccessPolicyInboundTrust?>("inboundTrust"); }
            set { BackingStore?.Set("inboundTrust", value); }
        }
#nullable restore
#else
        public CrossTenantAccessPolicyInboundTrust InboundTrust {
            get { return BackingStore?.Get<CrossTenantAccessPolicyInboundTrust>("inboundTrust"); }
            set { BackingStore?.Set("inboundTrust", value); }
        }
#endif
        /// <summary>If true, the default configuration is set to the system default configuration. If false, the default settings have been customized.</summary>
        public bool? IsServiceDefault {
            get { return BackingStore?.Get<bool?>("isServiceDefault"); }
            set { BackingStore?.Set("isServiceDefault", value); }
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new CrossTenantAccessPolicyConfigurationDefault CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CrossTenantAccessPolicyConfigurationDefault();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"automaticUserConsentSettings", n => { AutomaticUserConsentSettings = n.GetObjectValue<InboundOutboundPolicyConfiguration>(InboundOutboundPolicyConfiguration.CreateFromDiscriminatorValue); } },
                {"b2bCollaborationInbound", n => { B2bCollaborationInbound = n.GetObjectValue<CrossTenantAccessPolicyB2BSetting>(CrossTenantAccessPolicyB2BSetting.CreateFromDiscriminatorValue); } },
                {"b2bCollaborationOutbound", n => { B2bCollaborationOutbound = n.GetObjectValue<CrossTenantAccessPolicyB2BSetting>(CrossTenantAccessPolicyB2BSetting.CreateFromDiscriminatorValue); } },
                {"b2bDirectConnectInbound", n => { B2bDirectConnectInbound = n.GetObjectValue<CrossTenantAccessPolicyB2BSetting>(CrossTenantAccessPolicyB2BSetting.CreateFromDiscriminatorValue); } },
                {"b2bDirectConnectOutbound", n => { B2bDirectConnectOutbound = n.GetObjectValue<CrossTenantAccessPolicyB2BSetting>(CrossTenantAccessPolicyB2BSetting.CreateFromDiscriminatorValue); } },
                {"inboundTrust", n => { InboundTrust = n.GetObjectValue<CrossTenantAccessPolicyInboundTrust>(CrossTenantAccessPolicyInboundTrust.CreateFromDiscriminatorValue); } },
                {"isServiceDefault", n => { IsServiceDefault = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<InboundOutboundPolicyConfiguration>("automaticUserConsentSettings", AutomaticUserConsentSettings);
            writer.WriteObjectValue<CrossTenantAccessPolicyB2BSetting>("b2bCollaborationInbound", B2bCollaborationInbound);
            writer.WriteObjectValue<CrossTenantAccessPolicyB2BSetting>("b2bCollaborationOutbound", B2bCollaborationOutbound);
            writer.WriteObjectValue<CrossTenantAccessPolicyB2BSetting>("b2bDirectConnectInbound", B2bDirectConnectInbound);
            writer.WriteObjectValue<CrossTenantAccessPolicyB2BSetting>("b2bDirectConnectOutbound", B2bDirectConnectOutbound);
            writer.WriteObjectValue<CrossTenantAccessPolicyInboundTrust>("inboundTrust", InboundTrust);
            writer.WriteBoolValue("isServiceDefault", IsServiceDefault);
        }
    }
}
