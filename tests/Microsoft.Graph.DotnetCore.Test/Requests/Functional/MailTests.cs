// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    public class MailTests : GraphTestBase
    {

        public async Task<Message> createEmail(string emailBody)
        {
            // Get the test user.
            var me = await graphClient.Me.Request().GetAsync();

            var subject = DateTime.Now.ToString();

            var message = new Message();
            message.Subject = subject;
            message.Body = new ItemBody() { Content = emailBody };
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

            message.ToRecipients = recipients;

            return message;
        }

        // Tests the SendMail action.
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task MailSendMail()
        {
            try
            {
                var message = await createEmail("Sent from the MailSendMail test.");

                // Send email to the test user.
                await graphClient.Me.SendMail(message, true).Request().PostAsync();

                var query = new List<Option>()
                {
                    new QueryOption("filter", "Subject eq '" + message.Subject + "'")
                };

                // Check the we found the sent email in the sent items folder.
                var mailFolderMessagesCollectionPage = await graphClient.Me.MailFolders["sentitems"].Messages.Request(query).GetAsync();

                Assert.NotNull(mailFolderMessagesCollectionPage);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }

        //// Test that we can set an attachment on a mail, send it, and then retrieve it.
        //[Fact]
        //public async Task MailSendMailWithFileAttachment()
        //{
        //    try
        //    {
        //        var message = await createEmail("Sent from the MailSendMailWithAttachment test.");

        //        var attachment = new FileAttachment();
        //        attachment.ODataType = "#microsoft.graph.fileAttachment";
        //        attachment.Name = "MyFileAttachment.txt";
        //        attachment.ContentBytes = Microsoft.Graph.DotnetCore.Test.Properties.Resources.textfile;

        //        message.Attachments = new MessageAttachmentsCollectionPage();
        //        message.Attachments.Add(attachment);

        //        await graphClient.Me.SendMail(message, true).Request().PostAsync();
        //    }
        //    catch (Microsoft.Graph.ServiceException e)
        //    {
        //        Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
        //    }
        //}

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task MailGetMailWithFileAttachment()
        {
            try
            {
                // Find messages with attachments.
                var messageCollection = await graphClient.Me.Messages.Request()
                                                                     .Filter("hasAttachments eq true")
                                                                     .GetAsync();

                if (messageCollection.Count > 0)
                {
                    // Get information about attachments on the first message that has attachments.
                    var attachments = await graphClient.Me.Messages[messageCollection[0].Id]
                                                          .Attachments
                                                          .Request()
                                                          .GetAsync();

                    // Get an attachment.
                    var attachmment = await graphClient.Me.Messages[messageCollection[0].Id]
                                                          .Attachments[attachments[0].Id]
                                                          .Request()
                                                          .GetAsync();

                    if (attachmment is FileAttachment)
                        Assert.NotNull((attachmment as FileAttachment).ContentBytes);
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }


        [Fact(Skip = "No CI set up for functional tests")]
        public async Task MailNextPageRequest()
        {
            try
            {
                var messages = new List<Message>();

                var messagePage = await graphClient.Me.Messages.Request().GetAsync();

                messages.AddRange(messagePage.CurrentPage);

                while (messagePage.NextPageRequest != null)
                {
                    messagePage = await messagePage.NextPageRequest.GetAsync();
                    messages.AddRange(messagePage.CurrentPage);
                }
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                Assert.True(false, "Something happened, check out a trace. Error code: " + e.Error.Code);
            }
        }
    }
}
