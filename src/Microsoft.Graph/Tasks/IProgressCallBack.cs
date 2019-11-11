// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    /// <summary>
    /// Interface for to enbale handling of progress/errors for a long upload process. 
    /// </summary>
    public interface IProgressCallback
    {
        /// <summary>
        /// Handler for the updating progress of the process
        /// </summary>
        /// <param name="current">Current number of bytes uploaded</param>
        /// <param name="max">Total number of bytes to be uploaded</param>
        void UpdateProgress(long current, long max);

        /// <summary>
        /// Handler for scenario when process completes successfully
        /// </summary>
        /// <param name="result">The resulting file from the upload.</param>
        void OnSuccess(DriveItem result);

        /// <summary>
        /// Handler for scenario when a failure/error occurs during the process.
        /// </summary>
        /// <param name="clientException"><see cref="ClientException"/> thrown in the event of a failure </param>
        void OnFailure(ClientException clientException);

    }
}
