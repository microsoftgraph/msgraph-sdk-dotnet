// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    public class OneDriveTests : GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveSharedWithMe()
        {

            var sharedDriveItems = await graphClient.Me.Drive.SharedWithMe().Request().GetAsync();
            var permissionsPage = await graphClient.Me.Drive.Items[sharedDriveItems[0].Id].Permissions.Request().GetAsync();
            var permissions = new List<Permission>();
            permissions.AddRange(permissionsPage.CurrentPage);

            while (permissionsPage.NextPageRequest != null)
            {
                permissionsPage = await permissionsPage.NextPageRequest.GetAsync();
                permissions.AddRange(permissionsPage.CurrentPage);
            }
            foreach (var permission in permissions)
            {
                Assert.NotNull(permission.Id);
                Assert.NotNull(permission.Roles);
            }
        }

        // https://github.com/OneDrive/onedrive-sdk-csharp/blob/master/docs/chunked-uploads.md
        // https://dev.onedrive.com/items/upload_large_files.htm
        [Fact(Skip = "incomplete")]
        public async Task OneDriveUploadLargeFile()
        {
            try
            {
                using (Stream stream = ResourceHelper.GetResourceAsStream(ResourceHelper.Hamilton))
                {
                    // Describe the file to upload. Pass into CreateUploadSession, when the service works as expected.
                    //var props = new DriveItemUploadableProperties();
                    //props.Name = "_hamilton.png";
                    //props.Description = "This is a pictureof Mr. Hamilton.";
                    //props.FileSystemInfo = new FileSystemInfo();
                    //props.FileSystemInfo.CreatedDateTime = System.DateTimeOffset.Now;
                    //props.FileSystemInfo.LastModifiedDateTime = System.DateTimeOffset.Now;

                    // Get the provider. 
                    // POST /v1.0/drive/items/01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ:/_hamiltion.png:/microsoft.graph.createUploadSession
                    // The CreateUploadSesssion action doesn't seem to support the options stated in the metadata.
                    var uploadSession = await graphClient.Drive.Items["01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ"].ItemWithPath("_hamilton.png").CreateUploadSession().Request().PostAsync();

                    var maxChunkSize = 320 * 1024; // 320 KB - Change this to your chunk size. 5MB is the default.
                    var provider = new ChunkedUploadProvider(uploadSession, graphClient, stream, maxChunkSize);

                    // Setup the chunk request necessities
                    var chunkRequests = provider.GetUploadChunkRequests();
                    var readBuffer = new byte[maxChunkSize];
                    var trackedExceptions = new List<Exception>();
                    DriveItem itemResult = null;

                    //upload the chunks
                    foreach (var request in chunkRequests)
                    {
                        // Do your updates here: update progress bar, etc.
                        // ...
                        // Send chunk request
                        var result = await provider.GetChunkRequestResponseAsync(request, readBuffer, trackedExceptions);

                        if (result.UploadSucceeded)
                        {
                            itemResult = result.ItemResponse;
                        }
                    }

                    // Check that upload succeeded
                    if (itemResult == null)
                    {
                        // Retry the upload
                        // ...
                    }
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        /// <summary>
        /// Based of the documentation: https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/item_downloadcontent
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveDownloadLargeFile()
        {
            // Based on question by Pavan Tiwari, 11/26/2012, and answer by Simon Mourier
            // https://stackoverflow.com/questions/13566302/download-large-file-in-small-chunks-in-c-sharp

            const long DefaultChunkSize = 50 * 1024; // 50 KB, TODO: change chunk size to make it realistic for a large file.
            long ChunkSize = DefaultChunkSize;
            long offset = 0;                         // cursor location for updating the Range header.
            byte[] bytesInStream;                    // bytes in range returned by chunk download.

            try
            {
                // Get the collection of drive items. We'll only use one.
                IDriveItemChildrenCollectionPage driveItems = await graphClient.Me.Drive.Root.Children.Request().GetAsync();

                foreach (var item in driveItems)
                {
                    // Let's download the first file we get in the response.
                    if (item.File != null)
                    {
                        // We'll use the file metadata to determine size and the name of the downloaded file
                        // and to get the download URL.
                        var driveItemInfo = await graphClient.Me.Drive.Items[item.Id].Request().GetAsync();

                        // Get the download URL. This URL is preauthenticated and has a short TTL.
                        object downloadUrl;
                        driveItemInfo.AdditionalData.TryGetValue("@microsoft.graph.downloadUrl", out downloadUrl);

                        // Get the number of bytes to download. calculate the number of chunks and determine
                        // the last chunk size.
                        long size = (long)driveItemInfo.Size;
                        int numberOfChunks = Convert.ToInt32(size / DefaultChunkSize);
                        // We are incrementing the offset cursor after writing the response stream to a file after each chunk. 
                        // Subtracting one since the size is 1 based, and the range is 0 base. There should be a better way to do
                        // this but I haven't spent the time on that.
                        int lastChunkSize = Convert.ToInt32(size % DefaultChunkSize) - numberOfChunks - 1;
                        if (lastChunkSize > 0) { numberOfChunks++; }

                        // Create a file stream to contain the downloaded file.
                        using (FileStream fileStream = System.IO.File.Create((driveItemInfo.Name)))
                        {
                            for (int i = 0; i < numberOfChunks; i++)
                            {
                                // Setup the last chunk to request. This will be called at the end of this loop.
                                if (i == numberOfChunks - 1)
                                {
                                    ChunkSize = lastChunkSize;
                                }

                                // Create the request message with the download URL and Range header.
                                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, (string)downloadUrl);
                                req.Headers.Range = new System.Net.Http.Headers.RangeHeaderValue(offset, ChunkSize + offset);

                                // We can use the the client library to send this although it does add an authentication cost.
                                // HttpResponseMessage response = await graphClient.HttpProvider.SendAsync(req);
                                // Since the download URL is preauthenticated, and we aren't deserializing objects, 
                                // we'd be better to make the request with HttpClient.
                                var client = new HttpClient();
                                HttpResponseMessage response = await client.SendAsync(req);

                                using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                                {
                                    bytesInStream = new byte[ChunkSize];
                                    int read;
                                    do
                                    {
                                        read = responseStream.Read(bytesInStream, 0, (int)bytesInStream.Length);
                                        if (read > 0)
                                            fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                                    }
                                    while (read > 0);
                                }
                                offset += ChunkSize + 1; // Move the offset cursor to the next chunk.
                            }
                        }
                        return;
                    }
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, $"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

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
                        Assert.IsType(typeof(MemoryStream), driveItemContent);
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
                        Email = $"alexW@{domain}"
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

                Assert.Equal("Alex Wilber", inviteCollection[0].GrantedTo.User.DisplayName);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }
    }
}
