using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Async = System.Threading.Tasks;

namespace Microsoft.Graph.Test.Requests.Functional
{
    /// <summary>
    /// Ad hoc functional tests to make sure that the Reports API works.
    /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/report
    /// Your test app registration will require the Reports.Read.All which requires admin consent.
    /// </summary>
    [Ignore]
    [TestClass]
    public class ReportTests : GraphTestBase
    {
        [TestMethod]
        public async Async.Task ReportingGetUserCounts()
        {
            try
            {
                // Create the request message.
                string getOffice365ActiveUserCountsRequestUrl = graphClient.Reports.GetOffice365ActiveUserCounts("D7").Request().RequestUrl;
                HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, getOffice365ActiveUserCountsRequestUrl);

                // Inject the access token into the request.
                await graphClient.AuthenticationProvider.AuthenticateRequestAsync(hrm);

                // Send the request and get the response. It will automatically follow the redirect to get the Report file.
                HttpResponseMessage response = await graphClient.HttpProvider.SendAsync(hrm);

                // Get the csv report file
                string csvReportFile = await response.Content.ReadAsStringAsync();

                StringAssert.Contains(csvReportFile, "Report", "Expected: 'Report', it isn't in the file.");
                StringAssert.Contains(csvReportFile, "Office 365", "Expected: 'Office 365', it isn't in the file.");
                StringAssert.Contains(csvReportFile, "Exchange", "Expected: 'Exchange', it isn't in the file.");
                StringAssert.Contains(csvReportFile, "SharePoint", "Expected: 'SharePoint', it isn't in the file.");
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: {0}", e.Error.Code);
            }
        }
    }
}
