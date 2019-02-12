// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using static Microsoft.Graph.CoreConstants;

    public class NationalCloudAuthProviderFactory
    {
        private Dictionary<string, Func<IAuthenticationProvider>> _authProviders;
        private IGraphStorageProvider _graphStorageProvider;
        private const string _nationalCloudCacheKey = "graph_national_cloud";
        /// <summary>
        /// Create a new NationalCloudAuthProviderFactory
        /// </summary>
        /// <param name="graphStorageProvider">An optional storage provider to store mapping of domains to national clouds</param>
        public NationalCloudAuthProviderFactory(IGraphStorageProvider graphStorageProvider = null)
        {
            _authProviders = new Dictionary<string, Func<IAuthenticationProvider>>();
            _graphStorageProvider = graphStorageProvider ?? new StaticGraphStorageProvider();
        }

        /// <summary>
        /// Adds an <see cref="IAuthenticationProvider"/> that's configured for a national cloud.
        /// </summary>
        /// <param name="nationalCloud">The national cloud for the auth provider.</param>
        /// <param name="authenticationProvider">An auth provider configured for the national cloud.</param>
        public void AddProvider(string nationalCloud, IAuthenticationProvider authenticationProvider)
        {
            _authProviders.Add(nationalCloud, () => authenticationProvider);
        }

        /// <summary>
        /// Adds an <see cref="IAuthenticationProvider"/> that's configured for a national cloud.
        /// </summary>
        /// <param name="nationalCloud">The national cloud for the auth provider.</param>
        /// <param name="authenticationProvider">A delegate that returns an auth provider configured for the national cloud.</param>
        public void AddProvider(string nationalCloud, Func<IAuthenticationProvider> authenticationProvider)
        {
            _authProviders.Add(nationalCloud, authenticationProvider);
        }

        /// <summary>
        /// Gets an auth provider configured to a user or tenant national cloud.
        /// </summary>
        /// <param name="domainIdentifier">A UserPrincipalName or tenantDomain that will be used to get a national cloud.</param>
        /// <returns></returns>
        public async Task<IAuthenticationProvider> GetProviderForUserAsync(string domainIdentifier)
        {
            if (string.IsNullOrEmpty(domainIdentifier)) return null;

            int atIndex = domainIdentifier.IndexOf('@');
            string usersDomain = string.Empty;

            if (atIndex != -1)
                usersDomain = domainIdentifier.Substring(atIndex + 1);
            else
                usersDomain = domainIdentifier;

            // check if tenant is in our cache
            string nationalCloudCache = (await _graphStorageProvider.GetStorageItemAsync(usersDomain + _nationalCloudCacheKey)) as string;

            if (nationalCloudCache == null)
                // if null, get openid config
                nationalCloudCache = await GetDomainNationalCloudAsync(usersDomain);

            _authProviders.TryGetValue(nationalCloudCache, out Func<IAuthenticationProvider> authenticationProviderDelegate);

            return authenticationProviderDelegate?.Invoke();
        }

        private async Task<string> GetDomainNationalCloudAsync(string usersDomain)
        {
            string nationalCloud = CoreConstants.NationalClouds.Global;
            // if not, is it mooncake?
            if (usersDomain.EndsWith(".cn"))
                nationalCloud = NationalClouds.China;
            else
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://login.microsoftonline.com/" + usersDomain + "/v2.0/.well-known/openid-configuration");

                // get openid config
                string responseString = await response.Content.ReadAsStringAsync();

                OpenIdConfiguration openIdConfig = JsonConvert.DeserializeObject<OpenIdConfiguration>(responseString);

                switch (openIdConfig.CloudInstanceName)
                {
                    case "microsoftonline.de":
                        nationalCloud = NationalClouds.Germany;
                        break;
                    case "microsoftonline.us":
                        if (openIdConfig.TenantRegionSubScope != "DODC")
                            nationalCloud = NationalClouds.USGov;
                        break;
                    case "microsoftonline.com":
                        if (openIdConfig.TenantRegionSubScope == "USG" || openIdConfig.TenantRegionSubScope == "DODC")
                            nationalCloud = NationalClouds.USGov;
                        break;
                }
            }
            return nationalCloud;
        }
    }
}
