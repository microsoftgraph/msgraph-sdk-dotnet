// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class DeltaQueryTests: GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task DeltaLinkDriveItem()
        {
            // Get our first delta page.
            var driveItemDeltaCollectionPage = await graphClient.Me.Drive.Root.Delta().Request().GetAsync();

            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (driveItemDeltaCollectionPage.NextPageRequest != null)
            {
                driveItemDeltaCollectionPage = await driveItemDeltaCollectionPage.NextPageRequest.GetAsync();
            }

            // At this point we're up to date. messagesDeltaCollectionPage now has a deltalink.  
            object deltaLink;

            // Now let's use the deltalink to make sure there aren't any changes. There shouldn't be.
            if (driveItemDeltaCollectionPage.AdditionalData.TryGetValue("@odata.deltaLink", out deltaLink))
            {
                driveItemDeltaCollectionPage.InitializeNextPageRequest(graphClient, deltaLink.ToString());
                driveItemDeltaCollectionPage = await driveItemDeltaCollectionPage.NextPageRequest.GetAsync();
            }
            Assert.NotNull(deltaLink);
            Assert.Equal(driveItemDeltaCollectionPage.Count, 0);

            // Create file to change.
            var excelTest = new ExcelTests();
            var fileId = await excelTest.OneDriveCreateTestFile("_testDeltaLinkFile.xlsx");


            // Now let's use the deltalink to make sure there aren't any changes. 
            if (driveItemDeltaCollectionPage.AdditionalData.TryGetValue("@odata.deltaLink", out deltaLink))
            {
                driveItemDeltaCollectionPage.InitializeNextPageRequest(graphClient, deltaLink.ToString());
                driveItemDeltaCollectionPage = await driveItemDeltaCollectionPage.NextPageRequest.GetAsync();
            }

            // We expect two changes, one new item, and the root folder will have a change.
            Assert.Equal(driveItemDeltaCollectionPage.Count, 2);


            // Delete the file
            await excelTest.OneDriveDeleteTestFile(fileId, 5000);
        }

        // TODO: Before enabling these tests, we need to cleanup our test data.
        [Fact(Skip = "No CI set up for functional tests. Before enabling these tests, we need to cleanup our test data.")]
        public async Task DeltaLinkMessages()
        {
            // Get our first delta page.
            var messagesDeltaCollectionPage = await graphClient.Me.MailFolders["inbox"].Messages.Delta().Request().GetAsync();

            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (messagesDeltaCollectionPage.NextPageRequest != null)
            {
                messagesDeltaCollectionPage = await messagesDeltaCollectionPage.NextPageRequest.GetAsync();
            }

            // At this point we're up to date. messagesDeltaCollectionPage now has a deltalink.  
            object deltaLink;

            // Now let's use the deltalink to make sure there aren't any changes. There shouldn't be.
            if (messagesDeltaCollectionPage.AdditionalData.TryGetValue("@odata.deltaLink", out deltaLink))
            {
                messagesDeltaCollectionPage.InitializeNextPageRequest(graphClient, deltaLink.ToString());
                messagesDeltaCollectionPage = await messagesDeltaCollectionPage.NextPageRequest.GetAsync();
            }
            Assert.NotNull(deltaLink);
            Assert.Equal(messagesDeltaCollectionPage.Count, 0);

            // Create a new message.
            //CreateNewMessage();

            // Now let's use the deltalink to make sure there aren't any changes. We expect to see a new message.
            if (messagesDeltaCollectionPage.AdditionalData.TryGetValue("@odata.deltaLink", out deltaLink))
            {
                messagesDeltaCollectionPage.InitializeNextPageRequest(graphClient, deltaLink.ToString());
                messagesDeltaCollectionPage = await messagesDeltaCollectionPage.NextPageRequest.GetAsync();
            }

            // We expect two changes, one new item, and the root folder will have a change.
            Assert.Equal(messagesDeltaCollectionPage.Count, 2);
        }

        [Fact(Skip = "No CI set up for functional tests. Before enabling these tests, we need to cleanup our test data.")]
        public async Task UserDeltaLink()
        {
            // Get our first delta page.
            var userDeltaCollectionPage = await graphClient.Users.Delta().Request().GetAsync();

            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (userDeltaCollectionPage.NextPageRequest != null)
            {
                userDeltaCollectionPage = await userDeltaCollectionPage.NextPageRequest.GetAsync();
            }

            // At this point we're up to date. userDeltaCollectionPage now has a deltalink.  
            object deltaLink;

            // Now let's use the deltalink to make sure there aren't any changes. We won't test this collection
            // since other tests could be making changes to the users in the org.
            if (userDeltaCollectionPage.AdditionalData.TryGetValue("@odata.deltaLink", out deltaLink))
            {
                userDeltaCollectionPage.InitializeNextPageRequest(graphClient, deltaLink.ToString());
                userDeltaCollectionPage = await userDeltaCollectionPage.NextPageRequest.GetAsync();
            }
            Assert.NotNull(deltaLink);
        }

        [Fact(Skip = "No CI set up for functional tests. Before enabling these tests, we need to cleanup our test data.")]
        public async Task GroupDeltaLink()
        {
            // Get our first delta page.
            var groupDeltaCollectionPage = await graphClient.Groups.Delta().Request().GetAsync();

            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (groupDeltaCollectionPage.NextPageRequest != null)
            {
                groupDeltaCollectionPage = await groupDeltaCollectionPage.NextPageRequest.GetAsync();
            }

            // At this point we're up to date. groupDeltaCollectionPage now has a deltalink.  
            object deltaLink;

            // Now let's use the deltalink to make sure there aren't any changes.
            if (groupDeltaCollectionPage.AdditionalData.TryGetValue("@odata.deltaLink", out deltaLink))
            {
                groupDeltaCollectionPage.InitializeNextPageRequest(graphClient, deltaLink.ToString());
                groupDeltaCollectionPage = await groupDeltaCollectionPage.NextPageRequest.GetAsync();

                // This could be false in case a change has occurred to a group since the last deltapage.
                Assert.True((groupDeltaCollectionPage.Count == 0), "groupDeltaCollectionPage has unexpected entry.");
            }
            Assert.NotNull(deltaLink);

            // Let's test what happens when we add a group.

            // Create a group. There can only be a single planner plan per group.
            var myGroup = new Group();
            myGroup.Description = "A temporary group.";
            myGroup.DisplayName = "Test group";
            myGroup.GroupTypes = new List<string>() { "Unified" };
            myGroup.MailEnabled = true;
            myGroup.MailNickname = "BobTestGroup";
            myGroup.SecurityEnabled = false;

            // Call Graph service API to create the new group.
            var syncdGroup = await graphClient.Groups.Request().AddAsync(myGroup);

            // Lets add a member to the group.
            var userToAddToGroup = new User();
            userToAddToGroup.Id = "ff1fa027-1a7a-4041-aac7-77bd88af7c9f";
            await graphClient.Groups[syncdGroup.Id].Members.References.Request().AddAsync(userToAddToGroup);


            // Call with the deltalink. We have to wait since there is some latency between the time that the 
            // group is created and the time when the delta is registered.
            await Task.Delay(10000);
            groupDeltaCollectionPage.InitializeNextPageRequest(graphClient, deltaLink.ToString());
            groupDeltaCollectionPage = await groupDeltaCollectionPage.NextPageRequest.GetAsync();

            Assert.True((groupDeltaCollectionPage.Count == 1));

            // Clean up the group we created.
            var headers = new HeaderOption("Content-type", "application/json"); // Need this due to bug. Can't delete without this.
            await graphClient.Groups[syncdGroup.Id].Request().DeleteAsync();
        }
    }
}
