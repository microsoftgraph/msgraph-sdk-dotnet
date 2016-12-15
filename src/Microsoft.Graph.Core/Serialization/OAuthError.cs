using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Graph.Serialization
{
    public class OAuthError
    {
        [DataMember(Name = "error", IsRequired = true, EmitDefaultValue = false)]
        public string Error { get; set; }

        [DataMember(Name = "error_description", IsRequired = false, EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }
    }
}
