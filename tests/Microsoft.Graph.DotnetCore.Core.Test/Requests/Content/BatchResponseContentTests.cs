// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests.Content
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using Xunit;
    using System.Threading.Tasks;

    public class BatchResponseContentTests
    {
        [Fact]
        public async Task BatchResponseContent_InitializeWithNoContentAsync()
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            BatchResponseContent batchResponseContent = new BatchResponseContent(httpResponseMessage);

            Dictionary<string, HttpResponseMessage> responses = await batchResponseContent.GetResponsesAsync();
            HttpResponseMessage httpResponse = await batchResponseContent.GetResponseByIdAsync("1");

            Assert.NotNull(responses);
            Assert.Null(httpResponse);
            Assert.True(responses.Count.Equals(0));
        }

        [Fact]
        public async Task BatchResponseContent_InitializeWithEmptyResponseContentAsync()
        {
            string jsonResponse = "{ responses: [] }";
            HttpContent content = new StringContent(jsonResponse);
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            httpResponseMessage.Content = content;

            BatchResponseContent batchResponseContent = new BatchResponseContent(httpResponseMessage);

            Dictionary<string, HttpResponseMessage> responses = await batchResponseContent.GetResponsesAsync();
            HttpResponseMessage httpResponse = await batchResponseContent.GetResponseByIdAsync("1");

            Assert.NotNull(responses);
            Assert.Null(httpResponse);
            Assert.True(responses.Count.Equals(0));
        }

        [Fact]
        public void BatchResponseContent_InitializeWithNullResponseMessage()
        {
            ClientException ex = Assert.Throws<ClientException>(() => new BatchResponseContent(null));

            Assert.Equal(ErrorConstants.Codes.InvalidArgument, ex.Error.Code);
            Assert.Equal(string.Format(ErrorConstants.Messages.NullParameter, "httpResponseMessage"), ex.Error.Message);
        }

        [Fact]
        public async Task BatchResponseContent_GetResponsesAsync()
        {
            string responseJSON = "{\"responses\":"
                +"[{"
                    +"\"id\": \"1\","
                    +"\"status\":200,"
                    + "\"headers\":{\"Cache-Control\":\"no-cache\",\"OData-Version\":\"4.0\",\"Content-Type\":\"application/json;odata.metadata=minimal;odata.streaming=true;IEEE754Compatible=false;charset=utf-8\"},"
                    + "\"body\":{\"@odata.context\":\"https://graph.microsoft.com/v1.0/$metadata#users/$entity\",\"displayName\":\"MOD Administrator\",\"jobTitle\":null,\"id\":\"9f4fe8ea-7e6e-486e-b8f4-VkHdanfIomf\"}"
                + "},"
                +"{"
                    +"\"id\": \"2\","
                    +"\"status\":200,"
                    + "\"headers\":{\"Cache-Control\":\"no-store, no-cache\",\"OData-Version\":\"4.0\",\"Content-Type\":\"application/json;odata.metadata=minimal;odata.streaming=true;IEEE754Compatible=false;charset=utf-8\"},"
                    + "\"body\":{\"@odata.context\":\"https://graph.microsoft.com/v1.0/$metadata#drives/$entity\",\"createdDateTime\":\"2019-01-12T09:05:38Z\",\"description\":\"\",\"id\":\"b!random-VkHdanfIomf\",\"lastModifiedDateTime\":\"2019-03-06T06:59:04Z\",\"name\":\"OneDrive\",\"webUrl\":\"https://m365x751487-my.sharepoint.com/personal/admin_m365x751487_onmicrosoft_com/Documents\",\"driveType\":\"business\",\"createdBy\":{\"user\":{\"displayName\":\"System Account\"}},\"lastModifiedBy\":{\"user\":{\"displayName\":\"System Account\"}},\"owner\":{\"user\":{\"email\":\"admin@M365x751487.OnMicrosoft.com\",\"id\":\"6b4fa8ea-7e6e-486e-a8f4-d00a5b23488c\",\"displayName\":\"MOD Administrator\"}},\"quota\":{\"deleted\":0,\"remaining\":1099509670098,\"state\":\"normal\",\"total\":1099511627776,\"used\":30324}}"
                + "},"
                +"{"
                    +"\"id\": \"3\","
                    +"\"status\":201,"
                    + "\"headers\":{\"Location\":\"https://graph.microsoft.com/v1.0/users/9f4fe8ea-7e6e-486e-a8f4-nothing-here/onenote/notebooks/1-zyz-a1c1-441a-8b41-9378jjdd2\",\"Preference-Applied\":\"odata.include-annotations=*\",\"Cache-Control\":\"no-cache\",\"OData-Version\":\"4.0\",\"Content-Type\":\"application/json;odata.metadata=minimal;odata.streaming=true;IEEE754Compatible=false;charset=utf-8\"},"
                    + "\"body\":{\"@odata.context\":\"https://graph.microsoft.com/v1.0/$metadata#users('9f4fe8ea-7e6e-486e-a8f4-nothing-here')/onenote/notebooks/$entity\",\"id\":\"1-9f4fe8ea-7e6e-486e-a8f4-nothing-here\",\"self\":\"https://graph.microsoft.com/v1.0/users/9f4fe8ea-7e6e-486e-a8f4-nothing-here/onenote/notebooks/1-9f4fe8ea-7e6e-486e-a8f4-nothing-here\",\"createdDateTime\":\"2019-03-06T08:08:09Z\",\"displayName\":\"My Notebook -442293399\",\"lastModifiedDateTime\":\"2019-03-06T08:08:09Z\"}"
                + "}]}";

            HttpContent content = new StringContent(responseJSON);
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = content;

            BatchResponseContent batchResponseContent = new BatchResponseContent(httpResponseMessage);

            Dictionary<string, HttpResponseMessage> responses = await batchResponseContent.GetResponsesAsync();

            Assert.NotNull(responses);
            Assert.True(responses.Count.Equals(3));
            Assert.False(responses["1"].Headers.CacheControl.NoStore);
            Assert.True(responses["2"].Headers.CacheControl.NoCache);
            Assert.True(responses["2"].Headers.CacheControl.NoStore);
            Assert.Equal(responses["3"].StatusCode, HttpStatusCode.Created);
        }

        [Fact]
        public async Task BatchResponseContent_GetResponseByIdAsync()
        {
            string responseJSON = "{\"responses\":"
                + "[{"
                    + "\"id\": \"1\","
                    + "\"status\":200,"
                    + "\"headers\":{\"Cache-Control\":\"no-cache\",\"OData-Version\":\"4.0\",\"Content-Type\":\"application/json;odata.metadata=minimal;odata.streaming=true;IEEE754Compatible=false;charset=utf-8\"},"
                    + "\"body\":{\"@odata.context\":\"https://graph.microsoft.com/v1.0/$metadata#users/$entity\",\"displayName\":\"MOD Administrator\",\"jobTitle\":null,\"id\":\"9f4fe8ea-7e6e-486e-b8f4-VkHdanfIomf\"}"
                + "},"
                + "{"
                    + "\"id\": \"2\"," 
                    + "\"status\":409,"
                    + "\"headers\" : {\"Cache-Control\":\"no-cache\"},"
                    + "\"body\":{\"error\": {\"code\": \"20117\",\"message\": \"An item with this name already exists in this location.\",\"innerError\":{\"request-id\": \"nothing1b13-45cd-new-92be873c5781\",\"date\": \"2019-03-22T23:17:50\"}}}"
                +"}]}";

            HttpContent content = new StringContent(responseJSON);
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            httpResponseMessage.Content = content;

            BatchResponseContent batchResponseContent = new BatchResponseContent(httpResponseMessage);

            HttpResponseMessage response = await batchResponseContent.GetResponseByIdAsync("2");

            Assert.NotNull(response);
            Assert.Equal(response.StatusCode, HttpStatusCode.Conflict);
            Assert.True(response.Headers.CacheControl.NoCache);
        }
    }
}
