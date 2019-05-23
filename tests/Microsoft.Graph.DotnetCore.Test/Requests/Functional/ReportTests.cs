// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    /// <summary>
    /// Ad hoc functional tests to make sure that the Reports API works.
    /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/report
    /// Your test app registration will require the Reports.Read.All which requires admin consent.
    /// </summary>
    public class ReportTests : GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ReportingGetUserCounts()
        {
            try
            {
                // Create the request message.
                string getOffice365ActiveUserCountsRequestUrl = graphClient.Reports.GetOffice365ActiveUserCounts("D7").Request().RequestUrl;
                HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, getOffice365ActiveUserCountsRequestUrl);

                await graphClient.AuthenticationProvider.AuthenticateRequestAsync(hrm);

                // Send the request and get the response. It will automatically follow the redirect to get the Report file.
                HttpResponseMessage response = await graphClient.HttpProvider.SendAsync(hrm);

                // Get the csv report file
                string csvReportFile = await response.Content.ReadAsStringAsync();

                Assert.Contains("Report", csvReportFile);
                Assert.Contains("Office 365", csvReportFile);
                Assert.Contains("Exchange", csvReportFile);
                Assert.Contains("SharePoint", csvReportFile);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.False(true, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }
    }
}
