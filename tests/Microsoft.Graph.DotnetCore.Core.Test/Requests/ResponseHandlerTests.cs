// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Requests
{
    using Newtonsoft.Json.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    public class ResponseHandlerTests
    {
        [Fact]
        public async Task HandleUserResponse()
        {
            // Arrange
            var responseHandler = new ResponseHandler(new Serializer());
            var hrm = new HttpResponseMessage()
            {
                Content = new StringContent(@"{
                    ""id"": ""123"",
                    ""givenName"": ""Joe"",
                    ""surName"": ""Brown"",
                    ""@odata.type"":""test""
                }", Encoding.UTF8, "application/json")
            };
            hrm.Headers.Add("test", "value");

            // Act
            var user = await responseHandler.HandleResponse<User>(hrm);

            //Assert
            Assert.Equal("123", user.Id);
            Assert.Equal("Joe", user.GivenName);
            Assert.Equal("Brown", user.Surname);
            Assert.Equal("OK", user.AdditionalData["statusCode"]);
            var headers = (JObject)(user.AdditionalData["responseHeaders"]);
            Assert.Equal("value", (string)headers["test"][0]);
        }
    }
}
