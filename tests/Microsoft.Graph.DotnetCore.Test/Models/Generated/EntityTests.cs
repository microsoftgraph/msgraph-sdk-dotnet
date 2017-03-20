// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Models.Generated
{
    public class EntityTests
    {
        [Fact]
        public void AbstractEntity_DefaultConstructorGeneration()
        {
            var entityType = typeof(Entity);
            var constructors = entityType.GetConstructors(
                BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Equal(1, constructors.Count());

            var defaultConstructor = constructors.First();
            Assert.False(defaultConstructor.IsPrivate);
            Assert.False(defaultConstructor.IsPublic);
            Assert.False(defaultConstructor.IsStatic);
            Assert.False(defaultConstructor.GetParameters().Any());
        }
    }
}