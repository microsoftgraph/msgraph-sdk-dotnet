// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Graph.Core.Test.Requests
{
    [TestClass]
    public class ResponseHandlerTests
    {
        [TestMethod]
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
            Assert.AreEqual("123", user.Id);
            Assert.AreEqual("Joe", user.GivenName);
            Assert.AreEqual("Brown", user.Surname);
            Assert.AreEqual("OK", user.AdditionalData["statusCode"]);
            var headers = (JObject)(user.AdditionalData["responseHeaders"]);
            Assert.AreEqual("value", (string)headers["test"][0]);
        }
    }
}
