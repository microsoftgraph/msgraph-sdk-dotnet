using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Graph
{
    public class OpenIdConfiguration
    {
        [JsonProperty("authorization_endpoint")]
        public Uri AuthorizationEndpoint { get; set; }

        [JsonProperty("token_endpoint")]
        public Uri TokenEndpoint { get; set; }

        [JsonProperty("token_endpoint_auth_methods_supported")]
        public List<string> TokenEndpointAuthMethodsSupported { get; set; }

        [JsonProperty("jwks_uri")]
        public Uri JwksUri { get; set; }

        [JsonProperty("response_modes_supported")]
        public List<string> ResponseModesSupported { get; set; }

        [JsonProperty("subject_types_supported")]
        public List<string> SubjectTypesSupported { get; set; }

        [JsonProperty("id_token_signing_alg_values_supported")]
        public List<string> IdTokenSigningAlgValuesSupported { get; set; }

        [JsonProperty("http_logout_supported")]
        public bool HttpLogoutSupported { get; set; }

        [JsonProperty("frontchannel_logout_supported")]
        public bool FrontchannelLogoutSupported { get; set; }

        [JsonProperty("end_session_endpoint")]
        public Uri EndSessionEndpoint { get; set; }

        [JsonProperty("response_types_supported")]
        public List<string> ResponseTypesSupported { get; set; }

        [JsonProperty("scopes_supported")]
        public List<string> ScopesSupported { get; set; }

        [JsonProperty("issuer")]
        public Uri Issuer { get; set; }

        [JsonProperty("claims_supported")]
        public List<string> ClaimsSupported { get; set; }

        [JsonProperty("request_uri_parameter_supported")]
        public bool RequestUriParameterSupported { get; set; }

        [JsonProperty("userinfo_endpoint")]
        public Uri UserinfoEndpoint { get; set; }

        [JsonProperty("tenant_region_scope")]
        public string TenantRegionScope { get; set; }

        [JsonProperty("tenant_region_sub_scope")]
        public string TenantRegionSubScope { get; set; }

        [JsonProperty("cloud_instance_name")]
        public string CloudInstanceName { get; set; }

        [JsonProperty("cloud_graph_host_name")]
        public string CloudGraphHostName { get; set; }

        [JsonProperty("msgraph_host")]
        public string MsgraphHost { get; set; }

        [JsonProperty("rbac_url")]
        public Uri RbacUrl { get; set; }
    }
}
