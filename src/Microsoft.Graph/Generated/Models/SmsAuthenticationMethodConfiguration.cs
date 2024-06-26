// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace Microsoft.Graph.Models
{
    #pragma warning disable CS1591
    public class SmsAuthenticationMethodConfiguration : Microsoft.Graph.Models.AuthenticationMethodConfiguration, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>A collection of groups that are enabled to use the authentication method.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Microsoft.Graph.Models.SmsAuthenticationMethodTarget>? IncludeTargets
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.SmsAuthenticationMethodTarget>?>("includeTargets"); }
            set { BackingStore?.Set("includeTargets", value); }
        }
#nullable restore
#else
        public List<Microsoft.Graph.Models.SmsAuthenticationMethodTarget> IncludeTargets
        {
            get { return BackingStore?.Get<List<Microsoft.Graph.Models.SmsAuthenticationMethodTarget>>("includeTargets"); }
            set { BackingStore?.Set("includeTargets", value); }
        }
#endif
        /// <summary>
        /// Instantiates a new <see cref="Microsoft.Graph.Models.SmsAuthenticationMethodConfiguration"/> and sets the default values.
        /// </summary>
        public SmsAuthenticationMethodConfiguration() : base()
        {
            OdataType = "#microsoft.graph.smsAuthenticationMethodConfiguration";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="Microsoft.Graph.Models.SmsAuthenticationMethodConfiguration"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Microsoft.Graph.Models.SmsAuthenticationMethodConfiguration CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Microsoft.Graph.Models.SmsAuthenticationMethodConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "includeTargets", n => { IncludeTargets = n.GetCollectionOfObjectValues<Microsoft.Graph.Models.SmsAuthenticationMethodTarget>(Microsoft.Graph.Models.SmsAuthenticationMethodTarget.CreateFromDiscriminatorValue)?.ToList(); } },
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
            writer.WriteCollectionOfObjectValues<Microsoft.Graph.Models.SmsAuthenticationMethodTarget>("includeTargets", IncludeTargets);
        }
    }
}
