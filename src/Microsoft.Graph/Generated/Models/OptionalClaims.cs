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
    public partial class OptionalClaims : IAdditionalDataHolder, IBackedModel, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The optional claims returned in the JWT access token.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.OptionalClaim>? AccessToken
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OptionalClaim>?>("accessToken"); }
            set { BackingStore?.Set("accessToken", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.OptionalClaim> AccessToken
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OptionalClaim>>("accessToken"); }
            set { BackingStore?.Set("accessToken", value); }
        }
#endif
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData
        {
            get { return BackingStore.Get<IDictionary<string, object>>("AdditionalData") ?? new Dictionary<string, object>(); }
            set { BackingStore.Set("AdditionalData", value); }
        }
        /// <summary>Stores model information.</summary>
        public IBackingStore BackingStore { get; private set; }
        /// <summary>The optional claims returned in the JWT ID token.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.OptionalClaim>? IdToken
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OptionalClaim>?>("idToken"); }
            set { BackingStore?.Set("idToken", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.OptionalClaim> IdToken
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OptionalClaim>>("idToken"); }
            set { BackingStore?.Set("idToken", value); }
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
        /// <summary>The optional claims returned in the SAML token.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::Microsoft.Graph.Models.OptionalClaim>? Saml2Token
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OptionalClaim>?>("saml2Token"); }
            set { BackingStore?.Set("saml2Token", value); }
        }
#nullable restore
#else
        public List<global::Microsoft.Graph.Models.OptionalClaim> Saml2Token
        {
            get { return BackingStore?.Get<List<global::Microsoft.Graph.Models.OptionalClaim>>("saml2Token"); }
            set { BackingStore?.Set("saml2Token", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::Microsoft.Graph.Models.OptionalClaims"/> and sets the default values.
        /// </summary>
        public OptionalClaims()
        {
            BackingStore = BackingStoreFactorySingleton.Instance.CreateBackingStore();
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::Microsoft.Graph.Models.OptionalClaims"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::Microsoft.Graph.Models.OptionalClaims CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::Microsoft.Graph.Models.OptionalClaims();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "accessToken", n => { AccessToken = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.OptionalClaim>(global::Microsoft.Graph.Models.OptionalClaim.CreateFromDiscriminatorValue)?.AsList(); } },
                { "idToken", n => { IdToken = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.OptionalClaim>(global::Microsoft.Graph.Models.OptionalClaim.CreateFromDiscriminatorValue)?.AsList(); } },
                { "@odata.type", n => { OdataType = n.GetStringValue(); } },
                { "saml2Token", n => { Saml2Token = n.GetCollectionOfObjectValues<global::Microsoft.Graph.Models.OptionalClaim>(global::Microsoft.Graph.Models.OptionalClaim.CreateFromDiscriminatorValue)?.AsList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.OptionalClaim>("accessToken", AccessToken);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.OptionalClaim>("idToken", IdToken);
            writer.WriteStringValue("@odata.type", OdataType);
            writer.WriteCollectionOfObjectValues<global::Microsoft.Graph.Models.OptionalClaim>("saml2Token", Saml2Token);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
