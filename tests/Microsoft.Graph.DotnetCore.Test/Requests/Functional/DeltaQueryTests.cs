// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.Graph.Models;

    public class DeltaQueryTests: GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task DeltaLinkDriveItem()
        {
            // Get our first delta page.
            var driveItemDeltaCollectionPage = await graphClient.Drives["driveId"].Items["itemId"].Delta.GetAsDeltaGetResponseAsync();

            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (driveItemDeltaCollectionPage.OdataNextLink != null)
            {
                driveItemDeltaCollectionPage = await new Microsoft.Graph.Drives.Item.Items.Item.Delta.DeltaRequestBuilder(driveItemDeltaCollectionPage.OdataNextLink, graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }

            // Now let's use the deltalink to make sure there aren't any changes. There shouldn't be.
            if (driveItemDeltaCollectionPage.OdataDeltaLink != null)
            {
                driveItemDeltaCollectionPage = await new Microsoft.Graph.Drives.Item.Items.Item.Delta.DeltaRequestBuilder(driveItemDeltaCollectionPage.OdataDeltaLink, graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }
            Assert.Empty(driveItemDeltaCollectionPage.Value);

            // Create file to change.
            var excelTest = new ExcelTests();
            var fileId = await excelTest.OneDriveCreateTestFile("_testDeltaLinkFile.xlsx");


            // Now let's use the deltalink to make sure there aren't any changes. 
            if (driveItemDeltaCollectionPage.OdataDeltaLink != null)
            {
                driveItemDeltaCollectionPage = await new Microsoft.Graph.Drives.Item.Items.Item.Delta.DeltaRequestBuilder(driveItemDeltaCollectionPage.OdataDeltaLink, graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }

            // We expect two changes, one new item, and the root folder will have a change.
            Assert.Equal(2, driveItemDeltaCollectionPage.Value.Count);


            // Delete the file
            await excelTest.OneDriveDeleteTestFile(fileId, 5000);
        }

        // TODO: Before enabling these tests, we need to cleanup our test data.
        [Fact(Skip = "No CI set up for functional tests. Before enabling these tests, we need to cleanup our test data.")]
        public async Task DeltaLinkMessages()
        {
            // Get our first delta page.
            var messagesDeltaCollectionPage = await graphClient.Me.MailFolders["inbox"].Messages.Delta.GetAsDeltaGetResponseAsync();

            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (messagesDeltaCollectionPage.OdataNextLink != null)
            {
                messagesDeltaCollectionPage = await new Microsoft.Graph.Users.Item.MailFolders.Item.Messages.Delta.DeltaRequestBuilder(messagesDeltaCollectionPage.OdataNextLink,graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }
            
            // Now let's use the deltalink to make sure there aren't any changes. There shouldn't be.
            if (messagesDeltaCollectionPage.OdataDeltaLink != null)
            {
                messagesDeltaCollectionPage = await new Microsoft.Graph.Users.Item.MailFolders.Item.Messages.Delta.DeltaRequestBuilder(messagesDeltaCollectionPage.OdataNextLink,graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }
            Assert.Empty(messagesDeltaCollectionPage.Value);

            // Create a new message.
            // CreateNewMessage();

            // Now let's use the deltalink to make sure there aren't any changes. We expect to see a new message.
            if (messagesDeltaCollectionPage.OdataDeltaLink != null)
            {
                messagesDeltaCollectionPage = await new Microsoft.Graph.Users.Item.MailFolders.Item.Messages.Delta.DeltaRequestBuilder(messagesDeltaCollectionPage.OdataNextLink,graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }

            // We expect two changes, one new item, and the root folder will have a change.
            Assert.Equal(2, messagesDeltaCollectionPage.Value.Count);
        }

        [Fact(Skip = "No CI set up for functional tests. Before enabling these tests, we need to cleanup our test data.")]
        public async Task UserDeltaLink()
        {
            // Get our first delta page.
            var userDeltaCollectionPage = await graphClient.Users.Delta.GetAsDeltaGetResponseAsync();
            //var userDeltaCollectionPage = userDeltaCollectionPageResult.Value;
            
            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (userDeltaCollectionPage.OdataNextLink != null)
            {
                userDeltaCollectionPage = await new Microsoft.Graph.Users.Delta.DeltaRequestBuilder(userDeltaCollectionPage.OdataNextLink, graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }

            // Now let's use the deltalink to make sure there aren't any changes. We won't test this collection
            // since other tests could be making changes to the users in the org.
            if (userDeltaCollectionPage.OdataDeltaLink != null)
            {
                userDeltaCollectionPage = await new Microsoft.Graph.Users.Delta.DeltaRequestBuilder(userDeltaCollectionPage.OdataDeltaLink, graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }
        }

        [Fact(Skip = "No CI set up for functional tests. Before enabling these tests, we need to cleanup our test data.")]
        public async Task GroupDeltaLink()
        {
            // Get our first delta page.
            var groupDeltaCollectionPage = await graphClient.Groups.Delta.GetAsDeltaGetResponseAsync();

            // Go through all of the delta pages so that we can get the delta link on the last page.
            while (groupDeltaCollectionPage.OdataNextLink != null)
            {
                groupDeltaCollectionPage = await new Microsoft.Graph.Groups.Delta.DeltaRequestBuilder(groupDeltaCollectionPage.OdataNextLink,graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();
            }

            // Now let's use the deltalink to make sure there aren't any changes.
            if (groupDeltaCollectionPage.OdataDeltaLink != null)
            {
                groupDeltaCollectionPage = await new Microsoft.Graph.Groups.Delta.DeltaRequestBuilder(groupDeltaCollectionPage.OdataDeltaLink,graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();

                // This could be false in case a change has occurred to a group since the last deltapage.
                Assert.True((groupDeltaCollectionPage.Value.Count == 0), "groupDeltaCollectionPage has unexpected entry.");
            }
            // Let's test what happens when we add a group.

            // Create a group. There can only be a single planner plan per group.
            var myGroup = new Group
            {
                Description = "A temporary group.", DisplayName = "Test group", GroupTypes = new List<string>() { "Unified" },
                MailEnabled = true,
                MailNickname = "BobTestGroup",
                SecurityEnabled = false
            };

            // Call Graph service API to create the new group.
            var syncdGroup = await graphClient.Groups.PostAsync(myGroup);

            // Lets add a member to the group.
            var userToAddToGroup = new ReferenceCreate()
            {
                OdataId = "ff1fa027-1a7a-4041-aac7-77bd88af7c9f"
            };
            await graphClient.Groups[syncdGroup.Id].Members.Ref.PostAsync(userToAddToGroup);


            // Call with the deltalink. We have to wait since there is some latency between the time that the 
            // group is created and the time when the delta is registered.
            await Task.Delay(10000);
            groupDeltaCollectionPage = await new Microsoft.Graph.Groups.Delta.DeltaRequestBuilder(groupDeltaCollectionPage.OdataDeltaLink,graphClient.RequestAdapter).GetAsDeltaGetResponseAsync();

            Assert.True((groupDeltaCollectionPage.Value.Count == 1));

            // Clean up the group we created.
            await graphClient.Groups[syncdGroup.Id].DeleteAsync(requestConfiguration => requestConfiguration.Headers.Add("Content-type","application/json"));// Need this due to bug. Can't delete without this.
        }
    }
}
