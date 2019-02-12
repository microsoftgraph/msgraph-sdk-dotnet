// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------


namespace Microsoft.Graph
{
    using System.Threading.Tasks;
    /// <summary>
    /// An IGraphStorageProvider interface
    /// </summary>
    public interface IGraphStorageProvider
    {
        Task SetStorageItemAsync(string itemId, object item);
        Task<object> GetStorageItemAsync(string itemId);
    }
}
