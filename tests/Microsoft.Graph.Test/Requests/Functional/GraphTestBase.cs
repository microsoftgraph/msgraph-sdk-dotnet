// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests.Functional
{
    using Microsoft.Graph;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    [Ignore]
    [TestClass]
    public class GraphTestBase
    {
        private readonly string clientId;
        private readonly string userName;
        private readonly string password;
        private readonly string contentType = "application/x-www-form-urlencoded";
        // Don't use password grant in your apps. Only use for legacy solutions and automated testing.
        private readonly string grantType = "password"; 
        private readonly string tokenEndpoint = "https://login.microsoftonline.com/common/oauth2/token";
        private readonly string resourceId = "https%3A%2F%2Fgraph.microsoft.com%2F";

        private static string accessToken = string.Empty;
        private static string tokenForUser = null;
        private static System.DateTimeOffset expiration;

        protected static GraphServiceClient graphClient = null;

        public GraphTestBase()
        {
            // Setup for CI
            clientId = System.Environment.GetEnvironmentVariable("test_client_id");
            userName = System.Environment.GetEnvironmentVariable("test_user_name");
            password = System.Environment.GetEnvironmentVariable("test_password");

            GetAuthenticatedClient();
        }

        // Get an access token and provide a GraphServiceClient.
        private void GetAuthenticatedClient()
        {
            if (graphClient == null)
            {
                // Create Microsoft Graph client.
                try
                {
                    graphClient = new GraphServiceClient(
                        "https://graph.microsoft.com/v1.0",
                        new DelegateAuthenticationProvider(
                            async (requestMessage) =>
                            {
                                string token;
                                if (accessToken == string.Empty)
                                    token = await getAccessTokenUsingPasswordGrant();
                                else
                                    token = accessToken;
                                requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);

                            }));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Could not create a graph client: " + ex.Message);
                }
            }
        }

        private async Task<string> getAccessTokenUsingPasswordGrant()
        {
            JObject jResult = null;
            String urlParameters = String.Format(
                    "grant_type={0}&resource={1}&client_id={2}&username={3}&password={4}",
                    grantType,
                    resourceId,
                    clientId,
                    userName,
                    password
            );

            HttpClient client = new HttpClient();
            var createBody = new StringContent(urlParameters, System.Text.Encoding.UTF8, contentType);

            HttpResponseMessage response = await client.PostAsync(tokenEndpoint, createBody);

            if (response.IsSuccessStatusCode)
            {
                Task<string> responseTask = response.Content.ReadAsStringAsync();
                responseTask.Wait();
                string responseContent = responseTask.Result;
                jResult = JObject.Parse(responseContent);
            }
            accessToken = (string)jResult["access_token"];

            if (!String.IsNullOrEmpty(accessToken))
            {
                //Set AuthenticationHelper values so that the regular MSAL auth flow won't be triggered.
                tokenForUser = accessToken;
                expiration = DateTimeOffset.UtcNow.AddHours(5);
            }

            return accessToken;
        }
    }
}
