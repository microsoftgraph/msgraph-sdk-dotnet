// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Core
{
    using System.Linq;

    public static class StringHelper
    {
        /// <summary>
        /// Converts the type string to title case.
        /// </summary>
        /// <param name="typeString">The type string.</param>
        /// <returns>The converted string.</returns>
        public static string ConvertTypeToTitleCase(string typeString)
        {
            if (!string.IsNullOrEmpty(typeString))
            {
                var stringSegments = typeString.Split('.').Select(
                    segment => string.Concat(segment.Substring(0, 1).ToUpperInvariant(), segment.Substring(1)));
                return string.Join(".", stringSegments);
            }

            return typeString;
        }

        /// <summary>
        /// Converts the type string to lower camel case.
        /// </summary>
        /// <param name="typeString">The type string.</param>
        /// <returns>The converted string.</returns>
        public static string ConvertTypeToLowerCamelCase(string typeString)
        {
            if (!string.IsNullOrEmpty(typeString))
            {
                var stringSegments = typeString.Split('.').Select(
                    segment => string.Concat(segment.Substring(0, 1).ToLowerInvariant(), segment.Substring(1)));
                return string.Join(".", stringSegments);
            }

            return typeString;
        }
    }
}
