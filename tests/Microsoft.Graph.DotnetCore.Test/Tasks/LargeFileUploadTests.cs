// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

/**
Spec
    https://github.com/microsoftgraph/msgraph-sdk-design/blob/master/tasks/FileUploadTask.md
**/

namespace Microsoft.Graph.DotnetCore.Test.Tasks
{
    using Microsoft.Graph.DotnetCore.Test.Requests.Functional;
    using Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class LargeFileUploadTests : GraphTestBase
    {
        [Fact]
        public void ThrowsArgumentExceptionOnInvalidChunkSize()
        {
            using (Stream stream = new MemoryStream())
            {
                // Arrange
                UploadSession uploadSession = new UploadSession { NextExpectedRanges = new List<string>() };
                int maxChunkSize = 1000;//invalid chunk size that is not a multiple of 320

                // Act 
                var exception = Assert.Throws<ArgumentException>(() => new LargeFileUpload(uploadSession, graphClient, stream, maxChunkSize));

                // Assert
                Assert.Equal("maxChunkSize", exception.ParamName);
            }
        }

        [Fact]
        public void BreaksDownStreamIntoRangesCorrectly()
        {
            byte[] mockData = new byte[1000000];//create a stream of about 1M so we can split it into a few 320K chunks
            using (Stream stream = new MemoryStream(mockData))
            {
                // Arrange
                UploadSession uploadSession = new UploadSession { 
                    NextExpectedRanges = new List<string>() { "0-" },
                    UploadUrl = "http://localhost",
                    ExpirationDateTime = DateTimeOffset.Parse("2019-11-07T06:39:31.499Z")
                };

                int maxChunkSize = 320 * 1024;

                // Act 
                LargeFileUpload fileUpload = new LargeFileUpload(uploadSession, graphClient, stream, maxChunkSize);
                var uploadSlices = fileUpload.GetUploadSlicesRequests();


                // Assert
                //We have only 4 chunks
                Assert.Equal(4, uploadSlices.Count());

                long currentRangeBegins = 0;
                foreach (var uploadSlice in uploadSlices)
                {
                    Assert.Equal(stream.Length, uploadSlice.TotalSessionLength);
                    Assert.Equal(currentRangeBegins, uploadSlice.RangeBegin);
                    currentRangeBegins += maxChunkSize;
                }

                //The last chunk is a abit smaller than the rest
                var lastUploadSlice = uploadSlices.Last();
                Assert.Equal(stream.Length - 1, lastUploadSlice.RangeEnd);
                Assert.Equal(stream.Length % maxChunkSize, lastUploadSlice.RangeLength); //verify the last chunk is 
            }
        }

        [Fact(Skip = "No CI set up for e2e tests")]
        public async Task UploadLargeFileInChunks()
        {
            try
            {
                using (Stream stream = ResourceHelper.GetResourceAsStream(ResourceHelper.Hamilton))
                {
                    // Get the provider. 
                    // POST /v1.0/drive/items/01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ:/_hamiltion.png:/microsoft.graph.createUploadSession
                    var uploadSession = await graphClient.Drive.Items["01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ"].ItemWithPath("_hamilton.png").CreateUploadSession().Request().PostAsync();

                    var maxChunkSize = 320 * 1024; // 320 KB - Change this to your chunk size. 5MB is the default.
                    var largeFileUpload = new LargeFileUpload(uploadSession, graphClient, stream, maxChunkSize);

                    // Setup the chunk request necessities
                    var slicesRequests = largeFileUpload.GetUploadSlicesRequests();
                    var trackedExceptions = new List<Exception>();
                    DriveItem itemResult = null;

                    //upload the chunks
                    foreach (var request in slicesRequests)
                    {
                        // Do your updates here: update progress bar, etc.
                        // ...
                        // Send chunk request
                        var result = await largeFileUpload.UploadSliceAsync(request, trackedExceptions);

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
            catch (ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        [Fact(Skip = "No CI set up for e2e tests")]
        public async Task UploadLargeFileWithOutCallBacks()
        {
            try
            {
                using (Stream stream = ResourceHelper.GetResourceAsStream(ResourceHelper.Hamilton))
                {
                    // Get the provider. 
                    // POST /v1.0/drive/items/01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ:/_hamiltion.png:/microsoft.graph.createUploadSession
                    var uploadSession = await graphClient.Drive.Items["01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ"].ItemWithPath("_hamilton.png").CreateUploadSession().Request().PostAsync();

                    var maxChunkSize = 320 * 1024; // 320 KB - Change this to your chunk size. 5MB is the default.
                    var largeFileUpload = new LargeFileUpload(uploadSession, graphClient, stream, maxChunkSize);

                    // Setup the chunk request necessities
                    DriveItem uploadedFile = null;
                    try
                    {
                        uploadedFile = await largeFileUpload.UploadAsync();
                    }
                    catch (TaskCanceledException)
                    {
                        //try to refresh the upload info and resume the upload from where we left off.
                        uploadedFile = await largeFileUpload.ResumeAsync();
                    }
                    
                    //Sucessful Upload
                    Assert.NotNull(uploadedFile.Id);
                }
            }
            catch (ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        [Fact(Skip = "incomplete")]
        public async Task UploadLargeFileWithCallBacks()
        {
            try
            {
                using (Stream stream = ResourceHelper.GetResourceAsStream(ResourceHelper.Hamilton))
                {
                    // Get the provider. 
                    // POST /v1.0/drive/items/01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ:/_hamiltion.png:/microsoft.graph.createUploadSession
                    var uploadSession = await graphClient.Drive.Items["01KGPRHTV6Y2GOVW7725BZO354PWSELRRZ"].ItemWithPath("_hamilton.png").CreateUploadSession().Request().PostAsync();

                    var maxChunkSize = 320 * 1024; // 320 KB - Change this to your chunk size. 5MB is the default.
                    var largeFileUpload = new LargeFileUpload(uploadSession, graphClient, stream, maxChunkSize);

                    // Setup the chunk request necessities
                    DriveItem uploadedFile = null;
                    var uploadProgressMonitor = new TestFileUploadProgress();

                    try
                    {
                        uploadedFile = await largeFileUpload.UploadAsync(uploadProgressMonitor);
                    }
                    catch (TaskCanceledException)
                    {
                        //try to refresh the upload info and resume the upload from where we left off.
                        uploadedFile = await largeFileUpload.ResumeAsync(uploadProgressMonitor);
                    }

                    //Sucessful Upload
                    Assert.NotNull(uploadedFile.Id);
                }
            }
            catch (ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }
    }

    internal class TestFileUploadProgress : IProgressCallback
    {
        public void OnFailure(ClientException clientException)
        {
            Console.WriteLine("Error occured during upload");
            Console.WriteLine(clientException.Message);
        }

        public void OnSuccess(DriveItem result)
        {
            Console.WriteLine($"File uploaded successfully with id : {result.Id}");
        }

        public void UpdateProgress(long current, long max)
        {
            long progress = (current / max) * 100;
            Console.WriteLine($"Uploaded {current} bytes of {max} bytes. {progress} % completed");
        }
    }
}