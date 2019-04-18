// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Xunit;
    using System.Threading.Tasks;
    public class BatchRequestTests: GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task JsonBatchRequest()
        {
            string token = await GetAccessTokenUsingPasswordGrant();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpRequestMessage httpRequestMessage1 = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me/");

            String body = "{" +
                            "\"displayName\": \"My Notebook\"" +
                          "}";
            HttpRequestMessage httpRequestMessage2 = new HttpRequestMessage(HttpMethod.Post, "https://graph.microsoft.com/v1.0/me/onenote/notebooks");
            httpRequestMessage2.Content = new StringContent(body, Encoding.UTF8, "application/json");

            BatchRequestStep requestStep1 = new BatchRequestStep("1", httpRequestMessage1, null);
            BatchRequestStep requestStep2 = new BatchRequestStep("2", httpRequestMessage2, new List<string> { "1" });

            BatchRequestContent batchRequestContent = new BatchRequestContent();
            batchRequestContent.AddBatchRequestStep(requestStep1);
            batchRequestContent.AddBatchRequestStep(requestStep2);

            HttpResponseMessage response = await httpClient.PostAsync("https://graph.microsoft.com/v1.0/$batch", batchRequestContent);

            BatchResponseContent batchResponseContent = new BatchResponseContent(response);
            Dictionary<string, HttpResponseMessage> responses = await batchResponseContent.GetResponsesAsync();
            HttpResponseMessage httpResponse = await batchResponseContent.GetResponseByIdAsync("1");
            string nextLink = await batchResponseContent.GetNextLinkAsync();

            Assert.True(responses.Count.Equals(2));
        }
    }
}
