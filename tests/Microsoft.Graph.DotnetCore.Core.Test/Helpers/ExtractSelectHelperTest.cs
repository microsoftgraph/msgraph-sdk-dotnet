// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Core.Test.Helpers
{
    public class ExtractSelectHelperTest
    {
        /// <summary>
        /// Simple base class to use as a template parameter for testing
        /// </summary>
        private class EventBase
        {
            public DateTimeOffset CreatedDateTime { get; set; }
        }

        /// <summary>
        /// Simple class to use as a template parameter for testing
        /// </summary>
        private class Event : EventBase
        {
            public string Body { get; set; }

            public string Subject { get; set; }

        }

        /// <summary>
        /// Simple recursive class to use as a template parameter for testing
        /// </summary>
        private class User
        {
            public string DisplayName { get; set; }

            public User Manager { get; set; }

        }

        [Fact]
        public void ArgumentNullOnNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => this.TestExtractMembers<Event>(null));
        }

        [Fact]
        public void SingleMemberAnonymousTypeImplicitMember()
        {
            Expression<Func<Event, object>> expression = (theEvent) => new { theEvent.Body };
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("body", s);
        }

        [Fact]
        public void SingleMemberAnonymousTypeExplicitMember()
        {
            Expression<Func<Event, object>> expression = (theEvent) => new { NotBody = theEvent.Body };
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("body", s);
        }

        [Fact]
        public void MultiMemberAnonymousTypeImplicitMember()
        {
            Expression<Func<Event, object>> expression = (theEvent) => new { theEvent.Body, theEvent.Subject };
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("body,subject", s);
        }

        [Fact]
        public void MultiMemberAnonymousTypeExplicitMember()
        {
            Expression<Func<Event, object>> expression = (theEvent) => new { Body = theEvent.Body, NotSubject = theEvent.Subject };
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("body,subject", s);
        }

        [Fact]
        public void MultiMemberAnonymousTypeImplicitExplicitMemberMix()
        {
            Expression<Func<Event, object>> expression = (theEvent) => new { theEvent.Body, NotSubject = theEvent.Subject };
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("body,subject", s);
        }

        [Fact]
        public void NonMemberArgumentType()
        {
            string greeting = "Hello";
            Expression<Func<Event, object>> expression = (theEvent) => new { theEvent.Body, greeting };
            this.TestErrorExtractMembers(expression);
        }

        [Fact]
        public void LiftedButMatchingType()
        {
            Event liftee = new Event();
            Expression<Func<Event, object>> expression = (theEvent) => new { theEvent.Body, liftee.Subject };
            this.TestErrorExtractMembers(expression);
        }

        [Fact]
        public void SimpleMemberAccess()
        {
            Expression<Func<Event, object>> expression = (theEvent) => theEvent.Body;
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("body", s);
        }

        [Fact]
        public void TraversalNotIncluded()
        {
            Expression<Func<User, object>> expression = (theUser) => new { ((User)theUser.Manager).DisplayName };
            this.TestErrorExtractMembers(expression);
        }

        [Fact]
        public void SimpleMemberFromBaseType()
        {
            Expression<Func<Event, object>> expression = (theEvent) => theEvent.CreatedDateTime;
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("createdDateTime", s);
        }

        [Fact]
        public void SingleMemberAnonymousTypeImplicitMemberFromBaseType()
        {
            Expression<Func<Event, object>> expression = (theEvent) => new { theEvent.CreatedDateTime };
            string s = this.TestExtractMembers(expression);
            Assert.Equal<string>("createdDateTime", s);
        }

        /// <summary>
        /// Helper for positive test cases
        /// </summary>
        private string TestExtractMembers<T>(Expression<Func<T, object>> expression)
        {
            string error;
            string s = ExpressionExtractHelper.ExtractMembers(expression, out error);

            // Repetitive asserts go here.
            Assert.NotNull(s);
            Assert.Null(error);
            return s;
        }

        /// <summary>
        /// Helper for negative test cases
        /// </summary>
        private void TestErrorExtractMembers<T>(Expression<Func<T, object>> expression)
        {
            string error;
            string s = ExpressionExtractHelper.ExtractMembers(expression, out error);

            // Repetitive asserts go here.
            Assert.Null(s);
            Assert.NotNull(error);
            Assert.True(error.Length > 10);
        }

    }
}

