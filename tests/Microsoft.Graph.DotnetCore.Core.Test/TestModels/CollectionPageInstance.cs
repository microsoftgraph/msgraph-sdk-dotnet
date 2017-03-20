// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Microsoft.Graph.DotnetCore.Core.Test.TestModels
{
    /// <summary>
    /// Test class for testing serialization of an IEnumerable of Date.
    /// </summary>
    [DataContract]
    public class CollectionPageInstance : CollectionPage<DerivedTypeClass>, ICollectionPageInstance
    {
    }
}
