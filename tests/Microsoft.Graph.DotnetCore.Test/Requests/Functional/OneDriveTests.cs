// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    public class OneDriveTests : GraphTestBase
    {
        // https://github.com/OneDrive/onedrive-sdk-csharp/blob/master/docs/chunked-uploads.md
        // https://dev.onedrive.com/items/upload_large_files.htm
        //[Fact(Skip ="incomplete")]
        //public async Task OneDriveUploadLargeFile()
        //{
        // try
        // {
        //    System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
        //    var buff = (byte[])converter.ConvertTo(Microsoft.Graph.DotnetCore.Test.Properties.Resources.hamilton, typeof(byte[]));
        //    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(buff))
        //    {
        //        // Describe the file to upload. Pass into CreateUploadSession, when the service works as expected.
        //        //var props = new DriveItemUploadableProperties();
        //        //props.Name = "_hamilton.png";
        //        //props.Description = "This is a pictureof Mr. Hamilton.";
        //        //props.FileSystemInfo = new FileSystemInfo();
        //        //props.FileSystemInfo.CreatedDateTime = System.DateTimeOffset.Now;
        //        //props.FileSystemInfo.LastModifiedDateTime = System.DateTimeOffset.Now;

        //        // Get the provider. 
        //        // POST /v1.0/drive/items/01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ:/_hamiltion.png:/microsoft.graph.createUploadSession
        //        // The CreateUploadSesssion action doesn't seem to support the options stated in the metadata.
        //        var uploadSession = await graphClient.Drive.Items["01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ"].ItemWithPath("_hamilton.png").CreateUploadSession().Request().PostAsync();

        //        var maxChunkSize = 320 * 1024; // 320 KB - Change this to your chunk size. 5MB is the default.
        //        var provider = new ChunkedUploadProvider(uploadSession, graphClient, ms, maxChunkSize);

        //        // Setup the chunk request necessities
        //        var chunkRequests = provider.GetUploadChunkRequests();
        //        var readBuffer = new byte[maxChunkSize];
        //        var trackedExceptions = new List<Exception>();
        //        DriveItem itemResult = null;

        //        //upload the chunks
        //        foreach (var request in chunkRequests)
        //        {
        //            // Do your updates here: update progress bar, etc.
        //            // ...
        //            // Send chunk request
        //            var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);

        //            if (result.UploadSucceeded)
        //            {
        //                itemResult = result.ItemResponse;
        //            }
        //        }

        //        // Check that upload succeeded
        //        if (itemResult == null)
        //        {
        //            // Retry the upload
        //            // ...
        //        }
        //    }
        //}
        //catch (Microsoft.Graph.ServiceException e)
        //{
        //    Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
        //}
        //}


        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveNextPageRequest()
        {
            try
            {
                var driveItems = new List<DriveItem>();

                var driveItemsPage = await graphClient.Me.Drive.Root.Children.Request().Top(4).GetAsync();

                Assert.NotNull(driveItemsPage);

                driveItems.AddRange(driveItemsPage.CurrentPage);

                while (driveItemsPage.NextPageRequest != null)
                {
                    driveItemsPage = await driveItemsPage.NextPageRequest.GetAsync();
                    driveItems.AddRange(driveItemsPage.CurrentPage);
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_downloadcontent
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveGetContent()
        {
            try
            {
                var driveItems = await graphClient.Me.Drive.Root.Children.Request().GetAsync();

                foreach (var item in driveItems)
                {
                    // Let's download the first file we get in the response.
                    if (item.File != null)
                    {
                        var driveItemContent = await graphClient.Me.Drive.Items[item.Id].Content.Request().GetAsync();
                        Assert.NotNull(driveItemContent);
                        Assert.IsType(typeof(Stream), driveItemContent);
                        return;
                    }
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }


        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveGetSetPermissions()
        {
            try
            {
                var driveItems = await graphClient.Me.Drive
                                                     .Root
                                                     .Children
                                                     .Request()
                                                     .GetAsync();

                foreach (var item in driveItems)
                {
                    // Let's get the first file in the response and expand the permissions set on it.
                    if (item.File != null)
                    {
                        // Get the permissions on the first file in the response.
                        var driveItem = await graphClient.Me.Drive
                                                            .Items[item.Id]
                                                            .Request()
                                                            .Expand("permissions")
                                                            .GetAsync();
                        Assert.NotNull(driveItem);

                        // Set permissions
                        var perm = new Permission();
                        perm.Roles = new List<string>() { "write" };
                        if (driveItem.Permissions.Count > 0)
                        {
                            var headerOptions = new List<HeaderOption>()
                            {
                                new HeaderOption("if-match", driveItem.CTag)
                            };

                            var permission = await graphClient.Me.Drive
                                                                 .Items[driveItem.Id]
                                                                 .Permissions[driveItem.Permissions[0].Id]
                                                                 .Request(headerOptions)
                                                                 .UpdateAsync(perm);
                        }
                        break;
                    }
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveSearchFile()
        {
            // Note: can't upload an item and immediately search for it. Seems like search index doesn't get immediately updated.
            // Tried applying a delay of 30sec and it made no difference.
            try
            {
                // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_search
                var driveItems = await graphClient.Me.Drive.Search("employee services").Request().GetAsync();

                // Expecting two results.
                Assert.Equal(2, driveItems.Count);

            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        // Assumption: test tenant has a file name that starts with 'Timesheet'.
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveCreateSharingLink()
        {
            try
            {
                var itemToShare = await graphClient.Me.Drive.Root
                                                            .Children
                                                            .Request()
                                                            .Filter("startswith(name,'Timesheet')")
                                                            .GetAsync();
                Assert.True(itemToShare[0].Name.StartsWith("Timesheet"));

                var permission = await graphClient.Me.Drive.Root
                                                           .ItemWithPath(itemToShare[0].Name)
                                                           .CreateLink("edit", "organization")
                                                           .Request()
                                                           .PostAsync();

                Assert.Equal("organization", permission.Link.Scope);
                Assert.Equal("edit", permission.Link.Type);
                Assert.NotNull(permission.Link.WebUrl);

            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        // Assumption: test tenant has a file name that starts with 'Timesheet'.
        // Assumption: there is a user with an email alias of alexd and a display name of Alex Darrow in the test tenant.
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveInvite()
        {
            try
            {
                // Get the item to share with another user.
                var itemToShare = await graphClient.Me.Drive.Root
                                                            .Children
                                                            .Request()
                                                            .Filter("startswith(name,'Timesheet')")
                                                            .GetAsync();
                Assert.True(itemToShare[0].Name.StartsWith("Timesheet"));

                var me = await graphClient.Me.Request().GetAsync();
                var domain = me.Mail.Split('@')[1];

                var recipients = new List<DriveRecipient>()
                {
                    new DriveRecipient()
                    {
                        Email = $"alexd@{domain}"
                    }
                };

                var roles = new List<string>()
                {
                    "write"
                };

                var inviteCollection = await graphClient.Me.Drive
                                                           .Root
                                                           .ItemWithPath(itemToShare[0].Name)
                                                           .Invite(recipients, true, roles, true, "Checkout the Invite feature!")
                                                           .Request()
                                                           .PostAsync();

                Assert.Equal("Alex Darrow", inviteCollection[0].GrantedTo.User.DisplayName);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }
    }
}
