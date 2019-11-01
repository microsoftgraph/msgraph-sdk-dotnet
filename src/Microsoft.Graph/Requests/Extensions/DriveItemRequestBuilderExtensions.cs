// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph
{
    using System;

    /// <summary>
    /// The type  DriveItemRequestBuilder.
    /// </summary>
    public partial class DriveItemRequestBuilder
    {
        /// <summary>
        /// Gets children request.
        /// <returns>The children request.</returns>
        /// </summary>
        public IDriveItemRequestBuilder ItemWithPath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (!path.StartsWith("/"))
                {
                    path = string.Format("/{0}", path);
                }
            }

            // Encode the path in accordance with the one drive spec 
            // https://docs.microsoft.com/en-us/onedrive/developer/rest-api/concepts/addressing-driveitems
            UriBuilder builder = new UriBuilder(this.RequestUrl);
            builder.Path += string.Format(":{0}:", path);

            return new DriveItemRequestBuilder(
                builder.Uri.OriginalString,
                this.Client);
        }
    }
}
