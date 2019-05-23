// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    public class ExtensionTests : GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ExtensionAddRoamingProfile()
        {
            try
            {
                var openTypeExtension = new OpenTypeExtension();
                openTypeExtension.ExtensionName = "com.contoso.mysettings2";
                openTypeExtension.AdditionalData = new Dictionary<string, object>();
                openTypeExtension.AdditionalData.Add("theme", "dark");

                var e = await graphClient.Me.Extensions.Request().AddAsync(openTypeExtension);

                Assert.NotNull(e);
                Assert.Equal(openTypeExtension.ExtensionName, e.Id); // The extension name and identifier should match.
            }
            catch (ServiceException e)
            {
                if (e.Error.Message == "An extension already exists with given id.")
                {
                    Assert.True(false, "The extension already exists. Delete the extension step missing." );
                }
            }
        }
    }
}
