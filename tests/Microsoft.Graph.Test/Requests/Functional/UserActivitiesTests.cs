namespace Microsoft.Graph.Test.Requests.Functional
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Ignore]
    [TestClass]
    public class UserActivitiesTests : GraphTestBase
    {
        public UserActivity CreateUserActivity(string appActivityId)
        {
            var activity = new UserActivity()
            {
                AppActivityId = appActivityId,
                ActivitySourceHost = "https://graphexplorer.blob.core.windows.net",
                AppDisplayName = "Graph .NET SDK Test",
                ActivationUrl = "https://developer.microsoft.com/en-us/graph/graph-explorer",
                FallbackUrl = "https://developer.microsoft.com/en-us/graph/graph-explorer",
                VisualElements = new VisualInfo()
                {
                    Description = "A user activity made through the Graph .NET SDK tests",
                    BackgroundColor = "#008272",
                    DisplayText = "Graph .NET SDK Test User Activity",
                    Attribution = new ImageInfo()
                    {
                        IconUrl = "https://graphexplorer.blob.core.windows.net/explorerIcon.png",
                        AlternateText = "Microsoft .NET SDK",
                        AddImageQuery = false,
                    },
                },
            };
            return activity;
        }

        public ActivityHistoryItem CreateHistory()
        {
            var history = new ActivityHistoryItem()
            {
                StartedDateTime = DateTimeOffset.UtcNow.AddMinutes(-5),
                LastActiveDateTime = DateTimeOffset.UtcNow,
                Id = Guid.NewGuid().ToString(),
            };
            return history;
        }

        [TestMethod]
        public async Task ActivitiesCreateActivityAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestCreateActivity");

                // Create the user activity
                var request = new UserActivitiesCollectionPutRequest(graphClient.Me.RequestUrl + "/activities", graphClient, null);
                var createResponse = await request.AddUserActivityAsync(activity);

                Assert.IsNotNull(createResponse, "Unexpected results, the results contains a null collection.");

                // Get activities
                var getResponse = await graphClient.Me.Activities.Request().GetAsync();

                Assert.IsNotNull(getResponse, "Unexpected results, the results contains a null collection.");

                if (getResponse.First().Id != createResponse.Id)
                {
                    Assert.Fail("Ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: {0}", e.Error.Code);
            }
        }

        [TestMethod]
        public async Task ActivitiesCreateHistoryAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestCreateHistory");

                // Create the user activity
                var request = new UserActivitiesCollectionPutRequest(graphClient.Me.RequestUrl + "/activities", graphClient, null);
                var createActivityResponse = await request.AddUserActivityAsync(activity);

                Assert.IsNotNull(createActivityResponse, "Unexpected results, the results contains a null collection.");

                var activityId = createActivityResponse.Id;

                var history = CreateHistory();

                // Create the history item on the created activity
                var historyRequest = new UserActivityHistoryItemsCollectionPutRequest(graphClient.Me.Activities[activityId].RequestUrl + "/historyItems", 
                    graphClient, null);
                var createHistoryResponse = await historyRequest.AddActivityHistoryAsync(history);

                Assert.IsNotNull(createHistoryResponse, "Unexpected results, the results contains a null collection.");

                // Get activities with expand historyItems
                var getResponse = await graphClient.Me.Activities.Request().Expand("historyItems").GetAsync();

                Assert.IsNotNull(getResponse, "Unexpected results, the results contains a null collection.");

                if (getResponse.First().Id != createActivityResponse.Id)
                {
                    Assert.Fail("Activity ids not equal in create and get responses");
                }

                if (getResponse.First().HistoryItems.FirstOrDefault() == null ||
                    !getResponse.First().HistoryItems.Any(x => x.Id == createHistoryResponse.Id))
                {
                    Assert.Fail("History ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: {0}", e.Error.Code);
            }
        }


        [TestMethod]
        public async Task ActivitiesGetRecentActivities()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestGetRecent");

                // Create the user activity
                var request = new UserActivitiesCollectionPutRequest(graphClient.Me.RequestUrl + "/activities", graphClient, null);
                var createActivityResponse = await request.AddUserActivityAsync(activity);

                Assert.IsNotNull(createActivityResponse, "Unexpected results, the results contains a null collection.");

                var activityId = createActivityResponse.Id;

                var history = CreateHistory();

                // Create the history item on the user activity
                var historyRequest = new UserActivityHistoryItemsCollectionPutRequest(graphClient.Me.Activities[activityId].RequestUrl + "/historyItems",
                    graphClient, null);
                var createHistoryResponse = await historyRequest.AddActivityHistoryAsync(history);

                Assert.IsNotNull(createHistoryResponse, "Unexpected results, the results contains a null collection.");

                // Get recent user activities
                var getRecentResponse = await graphClient.Me.Activities.Recent().Request().Expand("historyItems").GetAsync();

                Assert.IsNotNull(getRecentResponse, "Unexpected results, the results contains a null collection.");

                if (getRecentResponse.First().Id != createActivityResponse.Id)
                {
                    Assert.Fail("Activity ids not equal in create and get responses");
                }

                if (getRecentResponse.First().HistoryItems.FirstOrDefault() == null ||
                    !getRecentResponse.First().HistoryItems.Any(x => x.Id == createHistoryResponse.Id))
                {
                    Assert.Fail("History ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: {0}", e.Error.Code);
            }
        }

        [TestMethod]
        public async Task ActivitiesDeleteActivityAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestDeleteActivity");

                // Create the user activity
                var request = new UserActivitiesCollectionPutRequest(graphClient.Me.RequestUrl + "/activities", graphClient, null);
                var createResponse = await request.AddUserActivityAsync(activity);

                Assert.IsNotNull(createResponse, "Unexpected results, the results contains a null collection.");

                var activityId = createResponse.Id;

                // Delete the user activity
                await graphClient.Me.Activities[activityId].Request().DeleteAsync();

                // Get activities
                var getResponse = await graphClient.Me.Activities.Request().GetAsync();

                Assert.IsNotNull(getResponse, "Unexpected results, the results contains a null collection.");

                if (getResponse.Any(x => x.Id == createResponse.Id))
                {
                    Assert.Fail("Activity has not been deleted");
                }
            }
            catch (ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: {0}", e.Error.Code);
            }
        }

        [TestMethod]
        public async Task ActivitiesDeleteHistoryAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestDeleteHistory");

                // Create the user activity
                var request = new UserActivitiesCollectionPutRequest(graphClient.Me.RequestUrl + "/activities", graphClient, null);
                var createActivityResponse = await request.AddUserActivityAsync(activity);

                Assert.IsNotNull(createActivityResponse, "Unexpected results, the results contains a null collection.");

                var activityId = createActivityResponse.Id;

                var history = CreateHistory();

                // Create the history item on the created activity
                var historyRequest = new UserActivityHistoryItemsCollectionPutRequest(graphClient.Me.Activities[activityId].RequestUrl + "/historyItems",
                    graphClient, null);
                var createHistoryResponse = await historyRequest.AddActivityHistoryAsync(history);

                Assert.IsNotNull(createHistoryResponse, "Unexpected results, the results contains a null collection.");

                var historyId = createHistoryResponse.Id;

                await graphClient.Me.Activities[activityId].HistoryItems[historyId].Request().DeleteAsync();

                // Get activities with expand historyItems
                var getResponse = await graphClient.Me.Activities.Request().Expand("historyItems").GetAsync();

                Assert.IsNotNull(getResponse, "Unexpected results, the results contains a null collection.");

                if (getResponse.First().Id != createActivityResponse.Id)
                {
                    Assert.Fail("Activity ids not equal in create and get responses");
                }

                if (getResponse.First().HistoryItems?.FirstOrDefault() != null &&
                    getResponse.First().HistoryItems.Any(x => x.Id == createHistoryResponse.Id))
                {
                    Assert.Fail("History ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: {0}", e.Error.Code);
            }
        }
    }
}
