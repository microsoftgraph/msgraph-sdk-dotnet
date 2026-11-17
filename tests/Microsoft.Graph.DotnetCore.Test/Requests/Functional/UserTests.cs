// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using Microsoft.Graph.Users.Item.GetMailTips;
    using Microsoft.Graph.Users.Item.GetMemberGroups;
    using AssignLicensePostRequestBody = Microsoft.Graph.Users.Item.AssignLicense.AssignLicensePostRequestBody;
    using Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources;
    using Microsoft.Graph.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.Graph.Models.ODataErrors;

    public class UserTests : GraphTestBase
    {
        [Fact(Skip = "No CI set up for functional tests - add email addresses to run this test.")]
        public async Task UserGetMailtipsTestEnumFlags()
        {
            try
            {
                var emailAddresses = new List<string>
                {
                    "katiej@MOD810997.onmicrosoft.com", 
                    "garretv@MOD810997.onmicrosoft.com",
                    "annew@MOD810997.onmicrosoft.com"
                };

                var mailTipsOptions = MailTipsType.AutomaticReplies | MailTipsType.MailboxFullStatus;

                var requestBody = new GetMailTipsPostRequestBody()
                {
                    EmailAddresses = emailAddresses, MailTipsOptions = mailTipsOptions
                };
                var mailTipsCollectionPage = await graphClient.Me.GetMailTips.PostAsGetMailTipsPostResponseAsync(requestBody);

                foreach (var mt in mailTipsCollectionPage.Value)
                {
                    // All of the supplied users should have an email address.
                    Assert.NotNull(mt.EmailAddress);
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Message);
            }
        }

        // Currently (10/5/2016), you can only set the mailboxsettings directly on the property, 
        // not with a patched user. Opened issue against service API.
        [Fact(Skip = "No CI set up for functional tests. The service doesn't yet support PATCH on entity with mailboxsettings")]
        public async Task UserGetSetAutomaticReply()
        {
            var user = await graphClient.Me.GetAsync( requestConfiguration => requestConfiguration.QueryParameters.Select = new []{"mailboxsettings"});

            await graphClient.Me.PatchAsync(user);

            /* Notes
             * 
             * GET https://graph.microsoft.com/v1.0/me?$select=mailboxsettings 
             * 
             * RESPONSE
             * 
             * {
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users(mailboxSettings)/$entity",
                    "id": "c8616fa2-6a9e-4196-9912-e7fbea37fbd1@d0b7ccde-8426-4e94-a77b-a53e1bcd66c6",
                    "mailboxSettings": {
                        "automaticRepliesSetting": {
                            "status": "alwaysEnabled",
                            "externalAudience": "all",
                            "scheduledStartDateTime": {
                                "dateTime": "2016-09-30T21:00:00.0000000",
                                "timeZone": "UTC"
                            },
                            "scheduledEndDateTime": {
                                "dateTime": "2016-10-01T21:00:00.0000000",
                                "timeZone": "UTC"
                            },
                            "internalReplyMessage": "<html>\n<body>\nI am currently on vacation.\n</body>\n</html>\n",
                            "externalReplyMessage": ""
                        },
                        "timeZone": "Pacific Standard Time",
                        "language": {
                            "locale": "en-US",
                            "displayName": "English (United States)"
                        }
                    }
                }
             * GET https://graph.microsoft.com/v1.0/me/mailboxsettings
             * 
             * RESPONSE
             * 
             * {
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users('c8616fa2-6a9e-4196-9912-e7fbea37fbd1')/mailboxSettings",
                    "automaticRepliesSetting": {
                        "status": "alwaysEnabled",
                        "externalAudience": "all",
                        "scheduledStartDateTime": {
                            "dateTime": "2016-09-30T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "scheduledEndDateTime": {
                            "dateTime": "2016-10-01T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "internalReplyMessage": "<html>\n<body>\nI am currently on vacation. Sorry :(\n</body>\n</html>\n",
                        "externalReplyMessage": ""
                    },
                    "timeZone": "Pacific Standard Time",
                    "language": {
                        "locale": "en-US",
                        "displayName": "English (United States)"
                    }
                }
             * This PATCH is successful
             * PATCH https://graph.microsoft.com/v1.0/me/mailboxsettings
             * 
             * {
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users('c8616fa2-6a9e-4196-9912-e7fbea37fbd1')/mailboxSettings",
                    "automaticRepliesSetting": {
                        "status": "alwaysEnabled",
                        "externalAudience": "all",
                        "scheduledStartDateTime": {
                            "dateTime": "2016-09-30T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "scheduledEndDateTime": {
                            "dateTime": "2016-10-01T21:00:00.0000000",
                            "timeZone": "UTC"
                        },
                        "internalReplyMessage": "<html>\n<body>\nI am currently on vacation. Sorry :(\n</body>\n</html>\n",
                        "externalReplyMessage": ""
                    },
                    "timeZone": "Pacific Standard Time",
                    "language": {
                        "locale": "en-US"
                    }
                }
             * This PATCH is unsuccessful
             * PATCH https://graph.microsoft.com/v1.0/me
             * 
             * {
             *      "id": "c8616fa2-6a9e-4196-9912-e7fbea37fbd1@d0b7ccde-8426-4e94-a77b-a53e1bcd66c6",
                    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#users(mailboxSettings)/$entity"
                    "mailboxSettings": {
                        "automaticRepliesSetting": {
                            "status": "alwaysEnabled",
                            "externalAudience": "all",
                            "scheduledStartDateTime": {
                                "dateTime": "10/03/2016 07:00:00",
                                "timeZone": "UTC"
                            },
                            "scheduledEndDateTime": {
                                "dateTime": "10/04/2016 07:00:00",
                                "timeZone": "UTC"
                            },
                            "internalReplyMessage": "<html>\n<body>\nI am currently on vacation. Sorry :(\n</body>\n</html>\n",
                            "externalReplyMessage": ""
                        },
                        "timeZone": "Pacific Standard Time",
                        "language": {
                            "locale": "en-US",
                            "displayName": "English (United States)"
                        }
                    },
                }
             */
        }

        // Filter on displayname
        // https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/41
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserFilterStartsWith()
        {
            try
            {
                var usersQuery = await graphClient.Users.GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Filter = "startswith(displayName,'A')");
                foreach (User u in usersQuery.Value)
                {
                    Assert.StartsWith("A", u.DisplayName, StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (ODataError e)
            {
                Assert.Fail($"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        // Get the test user's photo.
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserGetPhoto()
        {
            try
            {
                // Gets the user's photo.
                // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/profilephoto_get
                // GET https://graph.microsoft.com/v1.0/me/photo/$value
                var originalPhoto = await graphClient.Me.Photo.Content.GetAsync();

                Assert.NotNull(originalPhoto);
            }
            catch (ODataError e)
            {
                if (e.Error.Code == "ErrorItemNotFound")
                {
                    Assert.Fail("We didn't get a photo back from the service. Check that the target account has a photo.");
                }
                else
                {
                    Assert.Fail("Something happened. Catch the HTTP traffic and find out what happened.");
                }
            }
        }

        // Update the test user's photo
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserUpdatePhoto()
        {
            try
            {
                using (Stream ms = ResourceHelper.GetResourceAsStream(ResourceHelper.Hamilton))
                {
                    // Sets the user's photo.
                    // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/profilephoto_update
                    // PUT https://graph.microsoft.com/v1.0/me/photo/$value
                    await graphClient.Me.Photo.Content.PutAsync(ms);
                }
            }
            catch (ODataError e)
            {
                Assert.Fail($"Something happened, check out a trace. Error code: {e.Error.Code}");
            }
        }

        // Get the test user.
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserGetUser()
        {
            try
            {
                var user = await graphClient.Me.GetAsync();
                Assert.NotNull(user.UserPrincipalName);
            }
            catch (ODataError e)
            {
                Assert.Fail($"Something happened. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserGetManager()
        {
            try
            {
                var managerDirObj = (User)await graphClient.Me.Manager.GetAsync();

                Assert.NotNull(managerDirObj);
                Assert.False(managerDirObj.DisplayName == "", "The display name of the user's manager is not set.");
            }
            catch (ODataError e)
            {
                Assert.Fail($"Something happened. Error code: {e.Error.Code}");
            }
        }

        // PUT https://graph.microsoft.com/v1.0/me/manager/$ref
        // {    "@odata.id": "https://graph.microsoft.com/v1.0/users/55aa3346-08cb-4e98-8567-879b039a72c1" }
        // http://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/user_post_manager
        // We are getting and setting the user's manager.
        // Must be an admin to set this
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserUpdateManager()
        {
            try
            {
                var managerDirObj = (User)await graphClient.Me.Manager.GetAsync();

                var reference = new ReferenceUpdate
                {
                    OdataId = managerDirObj.Id
                };
                await graphClient.Me.Manager.Ref.PutAsync(reference);
                Assert.NotNull(managerDirObj);
            }
            catch (ODataError e)
            {
                Assert.Fail($"Something happened. Error code: {e.Error.Code}");
            }
        }

        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserAssignLicense()
        {
            try
            {
                // This is expected to fail since we aren't providing licenses.
                var requestBody = new AssignLicensePostRequestBody
                {
                    AddLicenses = new List<AssignedLicense>(),
                    RemoveLicenses = new ()
                };
                var user = await graphClient.Me.AssignLicense.PostAsync(requestBody);
                Assert.Null(user);

            }
            catch (ODataError e)
            {
                Assert.Equal("Request_BadRequest", e.Error.Code);
            }
        }

        /// <summary>
        /// Tests building a request for an action with a required parameter that's set.
        /// Tests the get member groups action with a set parameter.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserGetMemberGroups_SecurityEnabledOnly_ValueSet()
        {
            try
            {
                var getMemberGroupsRequest = graphClient.Me.GetMemberGroups;
                var requestBody = new GetMemberGroupsPostRequestBody
                {
                    SecurityEnabledOnly = true
                };
                var directoryObjectGetMemberGroupsCollectionPage = await getMemberGroupsRequest.PostAsGetMemberGroupsPostResponseAsync(requestBody);

                Assert.NotNull(directoryObjectGetMemberGroupsCollectionPage);
                Assert.Equal("POST", getMemberGroupsRequest.ToPostRequestInformation(requestBody).HttpMethod.ToString());
                Assert.True(requestBody.SecurityEnabledOnly.Value);
            }
            catch (ODataError e)
            {
                Assert.Fail($"Something happened. Error code: {e.Error.Code}");
            }
        }

        /// <summary>
        /// Tests building a request for an action with a required parameter set to null.
        /// Tests the get member groups action without a set parameter, default is null.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests.")]
        public async Task UserGetMemberGroups_SecurityEnabledOnly_ValueNotSet()
        {
            try
            {
                var getMemberGroupsRequest = graphClient.Me.GetMemberGroups;
                var requestBody = new GetMemberGroupsPostRequestBody();
                var directoryObjectGetMemberGroupsCollectionPage = await getMemberGroupsRequest.PostAsGetMemberGroupsPostResponseAsync(requestBody);
            }
            catch (ODataError e)
            {
                Assert.Equal("Request_BadRequest", e.Error.Code);
            }
        }

        // Need admin perms.
        [Fact(Skip = "No CI set up for functional tests.")]
        // Addressing https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/28
        public async Task UpdateUser()
        {
            try
            {
                var me = await graphClient.Me.GetAsync();

                var oldMe = new User()
                {
                    GivenName = me.GivenName
                };

                var betterMe = new User()
                {
                    GivenName = "Beth"
                };

                // Update the user to Beth
                await graphClient.Users[me.UserPrincipalName].PatchAsync(betterMe);

                // Update the user back to me.
                await graphClient.Users[me.UserPrincipalName].PatchAsync(oldMe);
            }
            catch (ODataError e)
            {
                Assert.Fail($"Something happened. Error code: {e.Error.Code}");
            }
        }
    }
}
