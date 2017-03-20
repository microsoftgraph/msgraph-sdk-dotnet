// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    public class EventTests : GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task EventGetCalendarView()
        {
            try
            {
                // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/user_list_calendarview
                var queryOptions = new List<QueryOption>()
                {
                    new QueryOption("startDateTime", DateTime.Today.ToUniversalTime().ToString()),
                    new QueryOption("endDateTime", DateTime.Today.AddDays(1).ToUniversalTime().ToString())
                };

                var todaysEvents = await graphClient.Me.CalendarView.Request(queryOptions).GetAsync();
                Assert.NotNull(todaysEvents);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: {0}" + e.Error.Code);
            }
        }
    }
}
