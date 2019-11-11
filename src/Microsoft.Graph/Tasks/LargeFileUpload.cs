// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Task to help with uploading a file to One drive using resume-able uploads
    /// </summary>
    public class LargeFileUpload
    {
        private ChunkedUploadProvider UploadProvider { get; }

        /// <summary>
        /// Task to help with resume able large file uploads. Generates slices based on <paramref name="session"/>
        /// information, and can control uploading of requests using <paramref name="client"/>
        /// </summary>
        /// <param name="session">Session information of type <see cref="UploadSession"/>></param>
        /// <param name="client">Client used to upload slices.</param>
        /// <param name="uploadStream">Readable, seekable stream to be uploaded. Length of session is determined via uploadStream.Length</param>
        /// <param name="maxChunkSize">Max size of each chunk to be uploaded. Multiple of 320 KiB (320 * 1024) is required.
        /// If less than 0, default value of 5 MiB is used. .</param>
        public LargeFileUpload(UploadSession session, IBaseClient client, Stream uploadStream, int maxChunkSize = -1)
        {
            this.UploadProvider = new ChunkedUploadProvider(session,client, uploadStream , maxChunkSize);
        }

        /// <summary>
        /// Write a slice of data using the UploadChunkRequest.
        /// </summary>
        /// <param name="request">The UploadChunkRequest to make the request with.</param>
        /// <param name="exceptionTrackingList">A list of exceptions to use to track progress. ChunkedUpload may retry.</param>
        public async Task<UploadChunkResult> UploadSliceAsync(UploadChunkRequest request, ICollection<Exception> exceptionTrackingList)
        {
            return await this.UploadProvider.GetChunkRequestResponseAsync(request, exceptionTrackingList).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the series of requests needed to complete the upload session. Call <see cref="GetUploadSessionStatusAsync"/>
        /// first to update the internal session information.
        /// </summary>
        /// <param name="options">Options to be applied to each request.</param>
        /// <returns>All requests currently needed to complete the upload session.</returns>
        public virtual IEnumerable<UploadChunkRequest> GetUploadSlicesRequests(IEnumerable<Option> options = null)
        {
            return this.UploadProvider.GetUploadChunkRequests(options);
        }

        /// <summary>
        /// Upload the whole session.
        /// </summary>
        /// <param name="maxTries">Number of times to retry entire session before giving up.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        /// <param name="progressCallback"><see cref="IProgressCallback"/> object to monitor the progress of the upload.</param>
        /// <returns>Item information returned by server.</returns>
        public async Task<DriveItem> UploadAsync(IProgressCallback progressCallback = null, int maxTries = 3, IEnumerable<Option> options = null )
        {
            return await this.UploadProvider.UploadAsync(maxTries, options, progressCallback).ConfigureAwait(false);
        }

        /// <summary>
        /// Get info about the upload session and resume from where it left off.
        /// </summary>
        /// <param name="maxTries">Number of times to retry entire session before giving up.</param>
        /// <param name="options">Query and header option name value pairs for the request.</param>
        /// <param name="progressCallback"><see cref="IProgressCallback"/> object to monitor the progress of the upload.</param>
        /// <returns>Item information returned by server.</returns>
        public async Task<DriveItem> ResumeAsync(IProgressCallback progressCallback = null , int maxTries = 3, IEnumerable<Option> options = null)
        {
            var uploadSession = await this.GetUploadSessionStatusAsync().ConfigureAwait(false);
            var uploadExpirationTime = uploadSession.ExpirationDateTime ?? DateTimeOffset.Now;
            // validate that the upload can still be resumed.
            if (DateTimeOffset.Compare(uploadExpirationTime, DateTimeOffset.Now) <= 0)
            {
                throw new ClientException(
                    new Error
                    {
                        Code = GeneratedErrorConstants.Codes.NotAllowed,
                        Message = "Upload session expired. Upload cannot resume"
                    });
            }
            return await this.UploadAsync( progressCallback, maxTries, options ).ConfigureAwait(false); ;
        }

        /// <summary>
        /// Get the status of the session. Stores returned session internally.
        /// Updates internal list of ranges remaining to be uploaded (according to the server).
        /// </summary>
        /// <returns><see cref="UploadSession"/>> returned by the server.</returns>
        public async Task<UploadSession> GetUploadSessionStatusAsync()
        {
            return await this.UploadProvider.UpdateSessionStatusAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Delete the session.
        /// </summary>
        /// <returns>Once returned task is complete, the session has been deleted.</returns>
        public async Task<UploadSession> DeleteSessionAsync()
        {
            return await this.UploadProvider.DeleteSession().ConfigureAwait(false);
        }
    }
}