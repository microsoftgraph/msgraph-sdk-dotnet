// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Core.Test.Mocks
{
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class MockCompressedContent : HttpContent
    {
        private readonly HttpContent originalContent;

        public MockCompressedContent(HttpContent httpContent)
        {
            originalContent = httpContent;

            foreach (KeyValuePair<string, IEnumerable<string>> header in originalContent.Headers)
                Headers.TryAddWithoutValidation(header.Key, header.Value);
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            Stream compressedStream = new GZipStream(stream, CompressionMode.Compress, true);

            return originalContent.CopyToAsync(compressedStream).ContinueWith(t =>
            {
                if (compressedStream != null)
                {
                    compressedStream.Dispose();
                }
            });
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}
