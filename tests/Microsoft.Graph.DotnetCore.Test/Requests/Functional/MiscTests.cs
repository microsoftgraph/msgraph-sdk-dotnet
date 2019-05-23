namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    public class MiscTests: GraphTestBase
    {
        /// <summary>
        /// This test will fail since the service doesn't expect Odata.type=extension. This is a break in the naming pattern that the service expects.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task GroupCreateExtension()
        {
            // Get a groups collection. We'll use the first entry to add the extension. Results in a call to the service.
            IGraphServiceGroupsCollectionPage groupPage = await graphClient.Groups.Request().GetAsync();

            // Create the extension property.
            OpenTypeExtension newExtension = new OpenTypeExtension();
            newExtension.ExtensionName = "com.contoso.trackingKey";
            newExtension.AdditionalData = new Dictionary<string, object>();
            newExtension.AdditionalData.Add("trackingKeyMajor", "ABC");
            newExtension.AdditionalData.Add("trackingKeyMinor", "123");

            try
            {
                // Add an extension to the group. Results in a call to the service.
                var extension = await graphClient.Groups[groupPage[0].Id].Extensions.Request().AddAsync(newExtension);

                // Delete the extension. Results in a call to the service.
                await graphClient.Groups[groupPage[0].Id].Extensions["com.contoso.trackingKey"].Request().DeleteAsync();
            }
            catch (ServiceException e)
            {
                Assert.True(false, e.Error.ToString());
            }
        }

        /// <summary>
        /// Manual test to determine whether the client library supports setting a custom timeout.
        /// https://github.com/microsoftgraph/msgraph-sdk-dotnet/pull/214/files
        /// This test requires that you can have Fiddler or some other mechanism to delay the response.
        /// For example, I used the Fiddler autoresponder with a captured response and set the latency in the responder.
        /// I set the autoresponder latency to 10 seconds, and the client's timeout to 7 sec (2 minutes).
        /// You'll need to remove the Ignore attribute to run this as well. 
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ManualAdHocTimeoutTest()
        {
            graphClient.HttpProvider.OverallTimeout = new TimeSpan(0, 0, 0, 0, 7);
            try
            {
                User me = await graphClient.Me.Request().GetAsync();

                Assert.True(false, "Expected an exception if this was setup correctly.");
            }
            catch (ServiceException ex)
            {
                Assert.IsType(typeof(TaskCanceledException), ex.InnerException);
            }
        }
    }
}
