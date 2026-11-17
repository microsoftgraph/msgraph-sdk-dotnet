// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using Microsoft.Graph.Models;
    using Microsoft.Graph.Users.Item.SendMail;
    using Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Xunit;
    using Microsoft.Kiota.Abstractions;
    using System.Globalization;

    public class MailTests : GraphTestBase
    {
        public async System.Threading.Tasks.Task<Message> createEmail(string emailBody)
        {
            // Get the test user.
            var me = await graphClient.Me.GetAsync();

            var subject = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            var message = new Message
            {
                Subject = subject, 
                Body = new ItemBody
                {
                    Content = emailBody
                },
                ToRecipients = new List<Recipient>()
                {
                    new Recipient()
                    {
                        EmailAddress = new EmailAddress()
                        {
                            Address = me.Mail
                        }
                    }
                }
            };

            return message;
        }

        // Tests the SendMail action.
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task MailSendMail()
        {
            try
            {
                var message = await createEmail("Sent from the MailSendMail test.");

                var sendMailBody = new SendMailPostRequestBody
                {
                    Message = message,
                    SaveToSentItems = true
                };
                // Send email to the test user.
                await graphClient.Me.SendMail.PostAsync(sendMailBody);

                // Check the we found the sent email in the sent items folder.
                var mailFolderMessagesCollectionPage = await graphClient.Me.MailFolders["sentitems"].Messages.GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Filter = "Subject eq '" + message.Subject + "'");

                Assert.NotNull(mailFolderMessagesCollectionPage);
            }
            catch (ApiException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Message);
            }
        }

        //// Test that we can set an attachment on a mail, send it, and then retrieve it.
        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task MailSendMailWithFileAttachment()
        {
            try
            {
                var message = await createEmail("Sent from the MailSendMailWithAttachment test.");

                var attachment = new FileAttachment();
                attachment.OdataType = "#microsoft.graph.fileAttachment";
                attachment.Name = "MyFileAttachment.txt";
                using (Stream ms = ResourceHelper.GetResourceAsStream(ResourceHelper.TextFile))
                using (BinaryReader reader = new BinaryReader(ms))
                {
                    attachment.ContentBytes = reader.ReadBytes((int)ms.Length);
                }

                message.Attachments = new List<Attachment>();
                message.Attachments.Add(attachment);

                var sendMailBody = new SendMailPostRequestBody
                {
                    Message = message,
                    SaveToSentItems = true
                };
                await graphClient.Me.SendMail.PostAsync(sendMailBody);
            }
            catch (ApiException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Message);
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task MailGetMailWithFileAttachment()
        {
            try
            {
                // Find messages with attachments.
                var messageCollection = await graphClient.Me.Messages.GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Filter = "hasAttachments eq true");

                if (messageCollection.Value.Count > 0)
                {
                    // Get information about attachments on the first message that has attachments.
                    var attachments = await graphClient.Me.Messages[messageCollection.Value[0].Id]
                                                          .Attachments
                                                          .GetAsync();

                    // Get an attachment.
                    var attachmment = await graphClient.Me.Messages[messageCollection.Value[0].Id]
                                                          .Attachments[attachments.Value[0].Id]
                                                          .GetAsync();

                    if (attachmment is FileAttachment)
                        Assert.NotNull((attachmment as FileAttachment).ContentBytes);
                }
            }
            catch (ApiException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Message);
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async System.Threading.Tasks.Task MailNextPageRequest()
        {
            try
            {
                var messages = new List<Message>();

                var messagePage = await graphClient.Me.Messages.GetAsync();

                messages.AddRange(messagePage.Value);

                while (messagePage.OdataNextLink != null)
                {
                    messagePage = await new Users.Item.Messages.MessagesRequestBuilder(messagePage.OdataNextLink, graphClient.RequestAdapter).GetAsync();
                    messages.AddRange(messagePage.Value);
                }
            }
            catch (ApiException e)
            {
                Assert.Fail("Something happened, check out a trace. Error code: " + e.Message);
            }
        }
    }
}
