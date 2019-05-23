// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class UserActivitiesTests : GraphTestBase
    {
        Random r = new Random();

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
                StartedDateTime = DateTimeOffset.Now.AddMinutes(-60),
                LastActiveDateTime = DateTimeOffset.Now,
                UserTimezone = "Test" + r.Next()
            };
            return history;
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ActivitiesCreateActivityAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestCreateActivity");

                // Create the user activity
                var createResponse = await graphClient.Me.Activities.Request().AddUserActivityAsync(activity);

                Assert.NotNull(createResponse);

                // Get activities
                var getResponse = await graphClient.Me.Activities.Request().GetAsync();

                Assert.NotNull(getResponse);

                if (getResponse.First().Id != createResponse.Id)
                {
                    Assert.True(false, "Ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.True(false, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ActivitiesCreateHistoryAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestCreateHistory");

                // Create the user activity
                var createActivityResponse = await graphClient.Me.Activities.Request().AddUserActivityAsync(activity);

                Assert.NotNull(createActivityResponse);

                var activityId = createActivityResponse.Id;

                var history = CreateHistory();

                // Create the history item on the created activity
                var createHistoryResponse = await graphClient.Me.Activities[activityId].HistoryItems.Request().AddActivityHistoryAsync(history);

                Assert.NotNull(createHistoryResponse);

                // Get activities with expand historyItems
                var getResponse = await graphClient.Me.Activities.Request().Expand("historyItems").GetAsync();

                Assert.NotNull(getResponse);

                if (getResponse.First().Id != createActivityResponse.Id)
                {
                    Assert.False(true, "Activity ids not equal in create and get responses");
                }

                if (getResponse.First().HistoryItems.FirstOrDefault() == null ||
                    !getResponse.First().HistoryItems.Any(x => x.Id == createHistoryResponse.Id))
                {
                    Assert.False(true, "History ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.False(true, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ActivitiesGetRecentActivities()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestGetRecent");

                // Create the user activity
                var createActivityResponse = await graphClient.Me.Activities.Request().AddUserActivityAsync(activity);

                Assert.NotNull(createActivityResponse);

                var activityId = createActivityResponse.Id;

                var history = CreateHistory();

                // Create the history item on the user activity
                var createHistoryResponse = await graphClient.Me.Activities[activityId].HistoryItems.Request().AddActivityHistoryAsync(history);

                Assert.NotNull(createHistoryResponse);

                // Get recent user activities
                var getRecentResponse = await graphClient.Me.Activities.Recent().Request().Expand("historyItems").GetAsync();

                Assert.NotNull(getRecentResponse);

                if (getRecentResponse.First().Id != createActivityResponse.Id)
                {
                    Assert.False(true, "Activity ids not equal in create and get responses");
                }

                if (getRecentResponse.First().HistoryItems.FirstOrDefault() == null ||
                    !getRecentResponse.First().HistoryItems.Any(x => x.Id == createHistoryResponse.Id))
                {
                    Assert.False(true, "History ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.False(true, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ActivitiesDeleteActivityAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestDeleteActivity");

                // Create the user activity
                var createResponse = await graphClient.Me.Activities.Request().AddUserActivityAsync(activity);

                Assert.NotNull(createResponse);

                var activityId = createResponse.Id;

                // Delete the user activity
                await graphClient.Me.Activities[activityId].Request().DeleteAsync();

                // Get activities
                var getResponse = await graphClient.Me.Activities.Request().GetAsync();

                Assert.NotNull(getResponse);

                if (getResponse.Any(x => x.Id == createResponse.Id))
                {
                    Assert.False(true, "Activity has not been deleted");
                }
            }
            catch (ServiceException e)
            {
                Assert.False(true, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ActivitiesDeleteHistoryAndGetBack()
        {
            try
            {
                var activity = CreateUserActivity("graphSdkTestDeleteHistory");

                // Create the user activity
                var createActivityResponse = await graphClient.Me.Activities.Request().AddUserActivityAsync(activity);

                Assert.NotNull(createActivityResponse);

                var activityId = createActivityResponse.Id;

                var history = CreateHistory();

                // Create the history item on the created activity
                var createHistoryResponse = await graphClient.Me.Activities[activityId].HistoryItems.Request().AddActivityHistoryAsync(history);

                Assert.NotNull(createHistoryResponse);

                var historyId = createHistoryResponse.Id;

                await graphClient.Me.Activities[activityId].HistoryItems[historyId].Request().DeleteAsync();

                // Get activities with expand historyItems
                var getResponse = await graphClient.Me.Activities.Request().Expand("historyItems").GetAsync();

                Assert.NotNull(getResponse);

                if (getResponse.First().Id != createActivityResponse.Id)
                {
                    Assert.True(false, "Activity ids not equal in create and get responses");
                }

                if (getResponse.First().HistoryItems?.FirstOrDefault() != null &&
                    getResponse.First().HistoryItems.Any(x => x.Id == createHistoryResponse.Id))
                {
                    Assert.True(false, "History ids not equal in create and get responses");
                }
            }
            catch (ServiceException e)
            {
                Assert.True(false, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }
    }
}
