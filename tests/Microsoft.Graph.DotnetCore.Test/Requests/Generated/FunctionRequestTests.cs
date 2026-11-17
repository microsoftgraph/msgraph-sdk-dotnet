// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Moq;
using System;
using Microsoft.Kiota.Abstractions;
using Xunit;
using Microsoft.Graph.DotnetCore.Test.Mocks;
using Microsoft.Graph.Models.ODataErrors;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Generated
{
    public class FunctionRequestTests
    {
        /// <summary>
        /// Tests building a request for a function with no parameteres (delta).
        /// </summary>
        [Fact]
        public void NoParameters()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/drives/id/items/itemId/delta()", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Drives["id"].Items["itemId"].Delta.ToGetRequestInformation();
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }
        
        /// <summary>
        /// Tests building a request while passing a value to a function's only parameter, which is nullable (search).
        /// </summary>
        [Fact]
        public void OptionalParameter_ParameterSet()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var q = "value";

            var methodBaseUrl = string.Format("{0}/drives/id/items/itemId/search", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));
            var expectedRequestUrl = string.Format("{0}(q='{1}')", methodBaseUrl, q);

            var requestInformation = graphServiceClient.Drives["id"].Items["itemId"].SearchWithQ(q).ToGetRequestInformation();
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }
        
        /// <summary>
        /// Tests building a request while passing a value to a function's nullable parameter (reminderView).
        /// </summary>
        [Fact]
        public void RequiredAndOptionalParameters_AllParametersSet()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var startDateTime = "now";
            var endDateTime = "later";

            var methodBaseUrl = string.Format("{0}/users/TokenToReplace/reminderView", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));
            var expectedRequestUrl = string.Format("{0}(StartDateTime='{2}',EndDateTime='{1}')", methodBaseUrl, startDateTime, endDateTime);

            var requestInformation = graphServiceClient.Me.ReminderViewWithStartDateTimeWithEndDateTime(startDateTime, endDateTime).ToGetRequestInformation();
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests that an exception is thrown when null is passed during request building for a non-nullable function parameter (reminderView).
        /// </summary>
        [Fact]
        public void RequiredAndOptionalParameters_RequiredParameterNull()
        {
            var mockRequestAdapter = new Mock<IRequestAdapter>();
            var graphServiceClient = new GraphServiceClient(mockRequestAdapter.Object);
            try
            {
                Assert.Throws<ArgumentNullException>(() => graphServiceClient.Me.ReminderViewWithStartDateTimeWithEndDateTime("",""));
            }
            catch (ODataError exception)
            {
                Assert.Equal(
                    "startDateTime is a required parameter for this method request.",
                    exception.Error.Message);

                throw;
            }
        }

        /// <summary>
        /// Tests the Top() method on a function request that returns a collection (reminderView).
        /// </summary>
        [Fact]
        public void Top()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/reminderView(StartDateTime='now',EndDateTime='then')?%24top=1", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ReminderViewWithStartDateTimeWithEndDateTime("then","now").ToGetRequestInformation( requestConfiguration =>requestConfiguration.QueryParameters.Top =1 );
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }

        /// <summary>
        /// Tests the Skip() method on a function request that returns a collection (reminderView).
        /// </summary>
        [Fact]
        public void Skip()
        {
            var graphServiceClient = new GraphServiceClient(new MockAuthenticationProvider().Object);
            var expectedRequestUrl = string.Format("{0}/users/TokenToReplace/reminderView(StartDateTime='now',EndDateTime='then')?%24skip=1", string.Format(Constants.Url.GraphBaseUrlFormatString, "v1.0"));

            var requestInformation = graphServiceClient.Me.ReminderViewWithStartDateTimeWithEndDateTime("then","now").ToGetRequestInformation( requestConfiguration =>requestConfiguration.QueryParameters.Skip =1 );
            
            Assert.NotNull(requestInformation);
            Assert.Equal(new Uri(expectedRequestUrl), requestInformation.URI);
        }
    }
}
