// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.Graph.Drives.Item.Items.Item.Permissions;
    using Microsoft.Graph.Models;
    using Microsoft.Graph.Drives.Item.Items.Item.Children;
    using Microsoft.Graph.Drives.Item.Items.Item.CreateLink;
    using Microsoft.Graph.Drives.Item.Items.Item.Invite;
    using Microsoft.Graph.Models.ODataErrors;

    public class OneDriveTests : GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveSharedWithMe()
        {

            var sharedDriveItems = await graphClient.Drives["driveId"].SharedWithMe.GetAsSharedWithMeGetResponseAsync();
            var permissionsPage = await graphClient.Drives["driveId"].Items[sharedDriveItems.Value[0].Id].Permissions.GetAsync();
            var permissions = new List<Permission>();
            permissions.AddRange(permissionsPage.Value);

            while (permissionsPage.OdataNextLink != null)
            {
                permissionsPage = await new PermissionsRequestBuilder(permissionsPage.OdataNextLink,graphClient.RequestAdapter).GetAsync();
                permissions.AddRange(permissionsPage.Value);
            }
            foreach (var permission in permissions)
            {
                Assert.NotNull(permission.Id);
                Assert.NotNull(permission.Roles);
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
                var driveItems = await graphClient.Drives["driveId"].Items["itemId"].Children.GetAsync();

                foreach (var item in driveItems.Value)
                {
                    // Let's download the first file we get in the response.
                    if (item.File != null)
                    {
                        // We'll use the file metadata to determine size and the name of the downloaded file
                        // and to get the download URL.
                        var driveItemInfo = await graphClient.Drives["driveId"].Items[item.Id].GetAsync();

                        // Get the download URL. This URL is preauthenticated and has a short TTL.
                        object downloadUrl;
                        driveItemInfo.AdditionalData.TryGetValue("@microsoft.graph.downloadUrl", out downloadUrl);

                        // Get the number of bytes to download. calculate the number of chunks and determine
                        // the last chunk size.
                        if (driveItemInfo.Size != null)
                        {
                            long size = driveItemInfo.Size.Value;
                            int numberOfChunks = Convert.ToInt32(size / DefaultChunkSize);
                            // We are incrementing the offset cursor after writing the response stream to a file after each chunk.
                            // Subtracting one since the size is 1 based, and the range is 0 base. There should be a better way to do
                            // this but I haven't spent the time on that.
                            int lastChunkSize = Convert.ToInt32(size % DefaultChunkSize) - numberOfChunks - 1;
                            if (lastChunkSize > 0) { numberOfChunks++; }

                            // Create a file stream to contain the downloaded file.
                            using FileStream fileStream = System.IO.File.Create((driveItemInfo.Name));
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
            catch (ODataError e)
            {
                Assert.Fail($"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveNextPageRequest()
        {
            try
            {
                var driveItems = new List<DriveItem>();

                var driveItemsPage = await graphClient.Drives["driveId"].Items["itemId"].Children.GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Top = 4);

                Assert.NotNull(driveItemsPage);

                driveItems.AddRange(driveItemsPage.Value);

                while (driveItemsPage.OdataNextLink != null)
                {
                    driveItemsPage = await new ChildrenRequestBuilder(driveItemsPage.OdataNextLink,graphClient.RequestAdapter).GetAsync();
                    driveItems.AddRange(driveItemsPage.Value);
                }
            }
            catch (ODataError e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_downloadcontent
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveGetContent()
        {
            try
            {
                var driveItems = await graphClient.Drives["driveId"].Items["itemId"].Children.GetAsync();

                foreach (var item in driveItems.Value)
                {
                    // Let's download the first file we get in the response.
                    if (item.File != null)
                    {
                        var driveItemContent = await graphClient.Drives["driveId"].Items[item.Id].Content.GetAsync();
                        Assert.NotNull(driveItemContent);
                        Assert.IsType<MemoryStream>(driveItemContent);
                        return;
                    }
                }
            }
            catch (ODataError e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveGetSetPermissions()
        {
            try
            {
                var driveItems = await graphClient.Drives["driveId"]
                                                     .Items["itemId"]
                                                     .Children
                                                     .GetAsync();

                foreach (var item in driveItems.Value)
                {
                    // Let's get the first file in the response and expand the permissions set on it.
                    if (item.File != null)
                    {
                        // Get the permissions on the first file in the response.
                        var driveItem = await graphClient.Drives["driveId"]
                                                            .Items[item.Id]
                                                            .GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Expand = new []{"permissions"});
                        Assert.NotNull(driveItem);

                        // Set permissions
                        var perm = new Permission();
                        perm.Roles = new List<string>() { "write" };
                        if (driveItem.Permissions.Count > 0)
                        {
                            var permission = await graphClient.Drives["driveId"]
                                                                 .Items[driveItem.Id]
                                                                 .Permissions[driveItem.Permissions[0].Id]
                                                                 .PatchAsync(perm, requestConfiguration => requestConfiguration.Headers.Add("if-match",driveItem.CTag));
                        }
                        break;
                    }
                }
            }
            catch (ODataError e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Error.Code);
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
                var driveItems = await graphClient.Drives["driveId"].SearchWithQ("employee services").GetAsSearchWithQGetResponseAsync();

                // Expecting two results.
                Assert.Equal(2, driveItems.Value.Count);

            }
            catch (ODataError e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        // Assumption: test tenant has a file name that starts with 'Timesheet'.
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneDriveCreateSharingLink()
        {
            try
            {
                var itemToShare = await graphClient.Drives["driveId"].Items["itemId"]
                                                            .Children
                                                            .GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Filter = "startswith(name,'Timesheet')");

                Assert.StartsWith("Timesheet", itemToShare.Value[0].Name);

                var requestBody = new CreateLinkPostRequestBody { Type = "edit", Scope = "organization" };
                var permission = await graphClient.Drives["driveId"].Root
                                                           .ItemWithPath(itemToShare.Value[0].Name)
                                                           .CreateLink
                                                           .PostAsync(requestBody);

                Assert.Equal("organization", permission.Link.Scope);
                Assert.Equal("edit", permission.Link.Type);
                Assert.NotNull(permission.Link.WebUrl);

            }
            catch (ODataError e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Error.Code);
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
                var itemToShare = await graphClient.Drives["driveId"].Items["itemId"]
                                                            .Children
                                                            .GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Filter = "startswith(name,'Timesheet')");
                Assert.StartsWith("Timesheet", itemToShare.Value[0].Name);

                var me = await graphClient.Me.GetAsync();
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
                var invitePostBody = new InvitePostRequestBody
                {
                    Recipients = recipients,
                    Message = "Checkout the Invite feature!",
                    Roles = roles,
                    SendInvitation = true,
                    RequireSignIn = true
                };
                var inviteCollection = await graphClient.Drives["driveId"]
                                                           .Root
                                                           .ItemWithPath(itemToShare.Value[0].Name)
                                                           .Invite
                                                           .PostAsInvitePostResponseAsync(invitePostBody);

                Assert.Equal("Alex Wilber", inviteCollection.Value[0].GrantedTo.User.DisplayName);
            }
            catch (ODataError e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }
    }
}
