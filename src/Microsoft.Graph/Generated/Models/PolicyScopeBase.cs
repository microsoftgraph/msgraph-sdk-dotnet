// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Collections.Generic;
using System.IO;
using System;
namespace Microsoft.Graph.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class PolicyScopeBase : IAdditionalDataHolder, IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The activities property</summary>
        public global::Microsoft.Graph.Models.UserActivityTypes? Activities
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.UserActivityTypes?>("activities"); }
            set { BackingStore?.Set("activities", value); }
        }
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData
        {
            get { return BackingStore.Get<IDictionary<string, object>>("AdditionalData") ?? new Dictionary<string, object>(); }
            set { BackingStore.Set("AdditionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The executionMode property</summary>
        public global::Microsoft.Graph.Models.ExecutionMode? ExecutionMode
        {
            get { return BackingStore?.Get<global::Microsoft.Graph.Models.ExecutionMode?>("executionMode"); }
            set { BackingStore?.Set("executionMode", value); }
        }
        /// <summary>The locations (like domains or URLs) to be protected. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.PolicyLocation>? Locations
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.PolicyLocation>?>("locations"); }
            set { BackingStore?.Set("locations", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.PolicyLocation> Locations
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.PolicyLocation>>("locations"); }
            set { BackingStore?.Set("locations", value); }
        }
#endif
        /// <summary>The OdataType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OdataType
        {
            get { return BackingStore?.Get<string?>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#nullable restore
#else
        public string OdataType
        {
            get { return BackingStore?.Get<string>("@odata.type"); }
            set { BackingStore?.Set("@odata.type", value); }
        }
#endif
        /// <summary>The enforcement actions to take if the policy conditions are met within this scope. Required.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.DlpActionInfo>? PolicyActions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DlpActionInfo>?>("policyActions"); }
            set { BackingStore?.Set("policyActions", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.DlpActionInfo> PolicyActions
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.DlpActionInfo>>("policyActions"); }
            set { BackingStore?.Set("policyActions", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Models.PolicyScopeBase"/> and sets the default values.
        /// </summary>
        public PolicyScopeBase()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.PolicyScopeBase"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::Microsoft.Graph.Models.PolicyScopeBase CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValue = parseNode.GetChildNode("@odata.type")?.GetStringValue();
            return mappingValue switch
            {
                "#microsoft.graph.policyTenantScope" => new global::Microsoft.Graph.Models.PolicyTenantScope(),
                "#microsoft.graph.policyUserScope" => new global::Microsoft.Graph.Models.PolicyUserScope(),
                _ => new global::Microsoft.Graph.Models.PolicyScopeBase(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "activities", n => { Activities = n.GetEnumValue<global::Microsoft.Graph.Models.UserActivityTypes>(); } },
                { "executionMode", n => { ExecutionMode = n.GetEnumValue<global::Microsoft.Graph.Models.ExecutionMode>(); } },
                { "locations", n => { Locations = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.PolicyLocation>(global::Microsoft.Graph.Models.PolicyLocation.CreateFromDiscriminatorValue)?.AsList(); } },
                { "@odata.type", n => { OdataType = n.GetStringValue(); } },
                { "policyActions", n => { PolicyActions = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.DlpActionInfo>(global::Microsoft.Graph.Models.DlpActionInfo.CreateFromDiscriminatorValue)?.AsList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<global::Microsoft.Graph.Models.UserActivityTypes>("activities", Activities);
            writer.WriteEnumValue<global::Microsoft.Graph.Models.ExecutionMode>("executionMode", ExecutionMode);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.PolicyLocation>("locations", Locations);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.DlpActionInfo>("policyActions", PolicyActions);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
