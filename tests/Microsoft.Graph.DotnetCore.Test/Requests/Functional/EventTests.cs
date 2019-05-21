// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;
    public class EventTests : GraphTestBase
    {
        // https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_events
        // https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/singlevaluelegacyextendedproperty_post_singlevalueextendedproperties
        // https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/extended-properties-overview
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task EventCreateExtendedProperty()
        {
            var myEvent = new Microsoft.Graph.Event();
            myEvent.Subject = "Lunch with my friend";
            myEvent.Body = new ItemBody() { ContentType = BodyType.Text, Content = "Catch up on old times." };
            myEvent.Start = new DateTimeTimeZone() { DateTime = "2017-05-29T12:00:00", TimeZone = "Pacific Standard Time" };
            myEvent.End = new DateTimeTimeZone() { DateTime = "2017-05-29T13:00:00", TimeZone = "Pacific Standard Time" };
            myEvent.Location = new Location() { DisplayName = "In.gredients" };
            myEvent.SingleValueExtendedProperties = new EventSingleValueExtendedPropertiesCollectionPage();


            var myCustomIdentifier = "String {66f5a359-4659-4830-9070-00040ec6ac6e} Name courseId";

            var myCustomExtendedProperty = new SingleValueLegacyExtendedProperty()
            {
                Id = myCustomIdentifier,
                Value = "1234567"
            };

            myEvent.SingleValueExtendedProperties.Add(myCustomExtendedProperty);

            // Create the event with the extended property in the service. 
            var mySyncdEvent = await graphClient.Me.Calendar.Events.Request()
                                                                   .AddAsync(myEvent);

            // Get the event with the extended property.
            var mySyncdEventWithExtendedProperty = await graphClient.Me
                                                                    .Calendar
                                                                    .Events
                                                                    .Request()
                                                                    .Expand($"singleValueExtendedProperties($filter=id eq '{myCustomIdentifier}')")
                                                                    .GetAsync();

            Assert.NotNull(mySyncdEventWithExtendedProperty[0].SingleValueExtendedProperties);

            // Delete the event we just created.
            await graphClient.Me.Events[mySyncdEventWithExtendedProperty[0].Id].Request().DeleteAsync();
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task EventGetCalendarView()
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

        /// <summary>
        /// Test FindMeetingTimes and custom duration serliazation.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task EventFindMeetingsTimes()
        {
            User me = await graphClient.Me.Request().GetAsync();

            // Get the first three users in the org as attendees unless user is the organizer.
            var orgUsers = await graphClient.Users.Request().GetAsync();
            List<Attendee> attendees = new List<Attendee>();
            for (int i = 0; i < 3; ++i)
            {
                if (orgUsers[i].Mail == me.Mail)
                    continue; // Skip the organizer.

                Attendee attendee = new Attendee();
                attendee.EmailAddress = new EmailAddress();
                attendee.EmailAddress.Address = orgUsers[i].Mail;
                attendees.Add(attendee);
            }

            // Create a duration with an ISO8601 duration.
            Duration durationFromISO8601 = new Duration("PT1H");
            MeetingTimeSuggestionsResult resultsFromISO8601 = await graphClient.Me.FindMeetingTimes(attendees,
                                                                                                        null,
                                                                                                        null,
                                                                                                        durationFromISO8601,
                                                                                                        2,
                                                                                                        true,
                                                                                                        false,
                                                                                                        10.0).Request().PostAsync();

            // Create a duration with a TimeSpan.
            Duration durationFromTimeSpan = new Duration(new TimeSpan(1, 0, 0));
            MeetingTimeSuggestionsResult resultsFromTimeSpan = await graphClient.Me.FindMeetingTimes(attendees,
                                                                                                         null,
                                                                                                         null,
                                                                                                         durationFromTimeSpan,
                                                                                                         2,
                                                                                                         true,
                                                                                                         false,
                                                                                                         10.0).Request().PostAsync();

            Assert.NotNull(resultsFromTimeSpan);
            // Make sure that our custom serialization results are the same for both scenarios.
            // DurationConverter.cs and Duration.cs


            List<MeetingTimeSuggestion> suggestionsFromISO8601 = new List<MeetingTimeSuggestion>(resultsFromISO8601.MeetingTimeSuggestions);
            List<MeetingTimeSuggestion> suggestionsFromTimeSpan = new List<MeetingTimeSuggestion>(resultsFromTimeSpan.MeetingTimeSuggestions);

            Assert.Equal(suggestionsFromISO8601[0].MeetingTimeSlot.Start.DateTime,
                            suggestionsFromTimeSpan[0].MeetingTimeSlot.Start.DateTime);
        }
    }
}
