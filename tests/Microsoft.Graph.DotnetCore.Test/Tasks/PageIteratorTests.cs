// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Graph.DotnetCore.Test.Requests.Functional;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

/**

Spec
    https://github.com/microsoftgraph/msgraph-sdk-design/blob/master/tasks/PageIteratorTask.md
**/

namespace Microsoft.Graph.DotnetCore.Test.Tasks
{
    public class PageIteratorTests : GraphTestBase
    {
        private PageIterator<Event> eventPageIterator;
        private const string nextPageSubject = "";

        [Fact(Skip = "No CI set up for e2e tests")]
        public async Task PageIteratorDevTest()
        {
            // Get an initial page results to populate the iterator.
            IUserEventsCollectionPage iUserEventsCollectionPage = await graphClient.Me.Events.Request().Top(2).GetAsync();
            
            // Create the function to process each entity returned in the pages.
            Func<Event,bool> processEachEvent = (e) =>
            {
                bool shouldContinue = true;

                //if (e.Subject.Contains("Latin"))
                //    shouldContinue = false;
                Debug.WriteLine($"Event subject: {e.Subject}");
                return shouldContinue;
            }; 

            // This requires the dev to specify the generic type in the CollectionPage.
            eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, iUserEventsCollectionPage, processEachEvent);

            await eventPageIterator.IterateAsync();

            Assert.Equal(PagingState.Complete, eventPageIterator.State);
        }

        [Fact(Skip = "No CI set up for e2e tests")]
        public async Task DeltaPageIteratorDevTest()
        {
            // Get an initial page results to populate the iterator.
            var messagesDeltaCollectionPage = await graphClient.Me
                                                             .MailFolders["inbox"]
                                                             .Messages
                                                             .Delta()
                                                             .Request()
                                                             .GetAsync();
           
            // Create the function to process each entity returned in the pages.
            Func<Message, bool> processEachMessage = (e) =>
            {
                Debug.WriteLine($"Message subject: {e.Subject}");
                return true;
            };

            // This requires the dev to specify the generic type in the CollectionPage.
            var messagePageIterator = PageIterator<Message>.CreatePageIterator(graphClient, 
                                                            messagesDeltaCollectionPage, 
                                                            processEachMessage);

            await messagePageIterator.IterateAsync();

            Assert.Equal(PagingState.Delta, messagePageIterator.State);

            var me = await graphClient.Me.Request().GetAsync();
            var recipients = new List<Recipient>()
            {
                new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Address = me.Mail
                    }
                }
            };

            var message = new Message()
            {
                Subject = "Message sent after deltatoken received.",
                ToRecipients = recipients
            };
            await graphClient.Me.SendMail(message, true).Request().PostAsync();

            await Task.Delay(3000);

            await messagePageIterator.ResumeAsync();

            Assert.Equal(PagingState.Delta, messagePageIterator.State);
        }

        [Fact]
        public async Task Given_Concrete_CollectionPage_It_Throws_RuntimeBinderException()
        {
            var page = new CollectionPage<Event>()
            {
                AdditionalData = new Dictionary<string, object>()
            };

            page.AdditionalData.Add("@odata.nextlink", "testnextlink");

            eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, page, (e) => { return true; });
            await Assert.ThrowsAsync<RuntimeBinderException>(() => eventPageIterator.IterateAsync());
        }

        [Fact]
        public void Given_Null_CollectionPage_It_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PageIterator<Event>.CreatePageIterator(graphClient, null, (e) => { return true; }));
        }

        [Fact]
        public void Given_Null_Delegate_It_Throws_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PageIterator<Event>.CreatePageIterator(graphClient, new CollectionPage<Event>(), null));
        }

        [Fact]
        public async Task Given_Concrete_Generated_CollectionPage_It_Iterates_Page_Items()
        {
            int inputEventCount = 17;
            var page = new UserEventsCollectionPage();
            page.AdditionalData = new Dictionary<string, object>();
            for (int i = 0; i < inputEventCount; i++)
            {
                page.Add(new Event() { Subject = $"Subject{i.ToString()}" });
            }

            List<Event> events = new List<Event>();

            eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, page, (e) => 
            {
                events.Add(e);
                return true;
            });

            await eventPageIterator.IterateAsync();

            Assert.Equal(inputEventCount, events.Count);
        }

        [Fact]
        public async Task Given_Concrete_Generated_CollectionPage_It_Stops_Iterating_Pageitems()
        {
            int inputEventCount = 17;
            var page = new UserEventsCollectionPage();
            for (int i = 0; i < inputEventCount; i++)
            {
                page.Add(new Event() { Subject = $"Subject{i.ToString()}" });
            }

            List<Event> events = new List<Event>();

            eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, page, (e) =>
            {
                if (e.Subject == "Subject7")
                    return false;
                
                events.Add(e);
                return true;
            });

            await eventPageIterator.IterateAsync();

            Assert.Equal(7, events.Count);
            Assert.Equal(PagingState.Paused, eventPageIterator.State);
        }

        [Fact]
        public async Task Given_CollectionPage_It_Stops_Iterating_Across_Pages()
        {
            // Create the 17 events to initiallize the original collection page.
            List<Event> testEvents = new List<Event>();
            int inputEventCount = 17;
            for (int i = 0; i < inputEventCount; i++)
            {
                testEvents.Add(new Event() { Subject = $"Subject{i.ToString()}" });
            }

            // Create the 5 events to initialize the next collection page.
            UserEventsCollectionPage nextPage = new UserEventsCollectionPage();
            int nextPageEventCount = 5;
            for (int i = 0; i < nextPageEventCount; i++)
            {
                nextPage.Add(new Event() { Subject = $"Subject for next page events: {i.ToString()}" });
            }

            // Create the CancellationTokenSource to test the cancellation of paging in the delegate.
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var pagingToken = cancellationTokenSource.Token;

            // Create the delegate to process each entity returned in the pages. The delegate will cancel 
            // paging when the target subject is encountered.
            Func<Event, bool> processEachEvent = (e) =>
            {
                bool shouldContinue = true;

                if (e.Subject.Contains("Subject3"))
                {
                    cancellationTokenSource.Cancel();
                }

                if (e.Subject.Contains("Subject for next page events"))
                {
                    Assert.True(false, "Unexpectedly paged the next page of results.");
                }

                return shouldContinue;
            };

            Mocks.MockUserEventsCollectionRequest mockUserEventsCollectionRequest = new Mocks.MockUserEventsCollectionRequest(nextPage);
            var mockUserEventsCollectionPage = new Mocks.MockUserEventsCollectionPage(testEvents, mockUserEventsCollectionRequest) as IUserEventsCollectionPage;

            eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, mockUserEventsCollectionPage, processEachEvent);
            await eventPageIterator.IterateAsync(pagingToken);

            Assert.True(cancellationTokenSource.IsCancellationRequested, "The delegate page iterator did not cancel requests to fetch more pages.");
        }

        [Fact]
        public async Task Given_CollectionPage_It_Iterates_Across_Pages()
        {
            // Create the 17 events to initiallize the original collection page.
            List<Event> originalCollectionPageEvents = new List<Event>();
            int inputEventCount = 17;
            for (int i = 0; i < inputEventCount; i++)
            {
                originalCollectionPageEvents.Add(new Event() { Subject = $"Subject{i.ToString()}" });
            }

            // Create the 5 events to initialize the next collection page.
            UserEventsCollectionPage nextPage = new UserEventsCollectionPage();
            int nextPageEventCount = 5;
            for (int i = 0; i < nextPageEventCount; i++)
            {
                nextPage.Add(new Event() { Subject = $"Subject for next page events: {i.ToString()}" });
            }
            nextPage.AdditionalData = new Dictionary<string, object>();

            bool reachedNextPage = false;

            // Create the delegate to process each entity returned in the pages. The delegate will 
            // signal that we reached an event in the next page.
            Func<Event, bool> processEachEvent = (e) =>
            {
                if (e.Subject.Contains("Subject for next page events"))
                {
                    reachedNextPage = true;
                    return false;
                }

                return true;
            };

            Mocks.MockUserEventsCollectionRequest mockUserEventsCollectionRequest = new Mocks.MockUserEventsCollectionRequest(nextPage);
            var mockUserEventsCollectionPage = new Mocks.MockUserEventsCollectionPage(originalCollectionPageEvents, mockUserEventsCollectionRequest, "nextlink") as IUserEventsCollectionPage;

            eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, mockUserEventsCollectionPage, processEachEvent);
            await eventPageIterator.IterateAsync();

            Assert.True(reachedNextPage, "The delegate page iterator did not reach the next page.");
            Assert.Equal(PagingState.Paused, eventPageIterator.State);
        }

        [Fact]
        public async Task Given_CollectionPage_It_Handles_Empty_NextPage()
        {
            try
            {
                // Create the 17 events to initiallize the original collection page.
                List<Event> originalCollectionPageEvents = new List<Event>();
                int inputEventCount = 17;
                for (int i = 0; i < inputEventCount; i++)
                {
                    originalCollectionPageEvents.Add(new Event() { Subject = $"Subject{i.ToString()}" });
                }

                // Create empty next collection page.
                UserEventsCollectionPage nextPage = new UserEventsCollectionPage();

                // Create the delegate to process each entity returned in the pages. 
                Func<Event, bool> processEachEvent = (e) =>
                {
                    return true;
                };
                
                Mocks.MockUserEventsCollectionRequest mockUserEventsCollectionRequest = new Mocks.MockUserEventsCollectionRequest(nextPage);
                var mockUserEventsCollectionPage = new Mocks.MockUserEventsCollectionPage(originalCollectionPageEvents, mockUserEventsCollectionRequest) as IUserEventsCollectionPage;

                eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, mockUserEventsCollectionPage, processEachEvent);
                await eventPageIterator.IterateAsync();
            }
            catch (Exception)
            {
                Assert.True(false, "Unexpected exception occurred when next page contains no elements.");
            }
        }

        [Fact]
        public void Given_PageIterator_It_Has_PagingState_NotStarted()
        {
            // Arrange
            List<Event> originalCollectionPageEvents = new List<Event>();
            UserEventsCollectionPage nextPage = new UserEventsCollectionPage();
                      
            Mocks.MockUserEventsCollectionRequest mockUserEventsCollectionRequest = new Mocks.MockUserEventsCollectionRequest(nextPage);
            var mockUserEventsCollectionPage = new Mocks.MockUserEventsCollectionPage(originalCollectionPageEvents, mockUserEventsCollectionRequest, "nextlink") as IUserEventsCollectionPage;
            
            // Act
            eventPageIterator = PageIterator<Event>.CreatePageIterator(graphClient, mockUserEventsCollectionPage, (e) => { return true; });

            // Assert
            Assert.Equal<PagingState>(PagingState.NotStarted, eventPageIterator.State);
        }
    }
}
