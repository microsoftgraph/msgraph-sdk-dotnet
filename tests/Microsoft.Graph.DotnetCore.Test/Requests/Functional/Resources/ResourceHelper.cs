// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources
{
    using System.IO;
    using System.Reflection;
    public static class ResourceHelper
    {
        public const string TextFile = "textfile.txt";
        public const string Hamilton = "hamilton.PNG";
        public const string ExcelTestResource = "excelTestResource.xlsx";
        public static Stream GetResourceAsStream(string resourceName)
        {
            return typeof(ResourceHelper).GetTypeInfo().Assembly.GetManifestResourceStream($"Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources.{resourceName}");
        }
    }
}
