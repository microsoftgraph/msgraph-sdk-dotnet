// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.Test.Requests.Functional
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;
    using static Microsoft.Graph.CoreConstants;

    [Ignore]
    [TestClass]
    public class NationalCloudTests: GraphTestBase
    {
        // Tests the GetProviderForUserAsync.
        [TestMethod]
        public async Task GetProviderForUser()
        {
            var providerFactory = new NationalCloudAuthProviderFactory();
            providerFactory.AddProvider(NationalClouds.Global, () => new TestAuthProvider(NationalClouds.Global));
            providerFactory.AddProvider(NationalClouds.China, () => new TestAuthProvider(NationalClouds.China));
            providerFactory.AddProvider(NationalClouds.Germany, () => new TestAuthProvider(NationalClouds.Germany));
            providerFactory.AddProvider(NationalClouds.USGov, () => new TestAuthProvider(NationalClouds.USGov));

            IAuthenticationProvider authProvider = await providerFactory.GetProviderForUserAsync("<UPN or tenant domain>");

            Assert.IsNotNull(authProvider);
            Assert.AreEqual((authProvider as TestAuthProvider).CloudName, NationalClouds.Global);
        }
    }
}
