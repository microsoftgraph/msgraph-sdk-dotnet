
namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using Microsoft.Graph.Models;
    using Microsoft.Kiota.Abstractions;
    using Microsoft.Kiota.Serialization.Json;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources;
    using Microsoft.Graph.Models.ODataErrors;
    using Microsoft.Kiota.Abstractions.Serialization;

    public class OneNoteTests : GraphTestBase
    {
        private OnenotePage testPage;
        private Notebook testNotebook;
        private static string firstSectionID;

        public OneNoteTests() : base() {
            // Get a page of OneNote sections.
            var sectionPage = graphClient.Me
                                                                    .Onenote
                                                                    .Sections
                                                                    .GetAsync()
                                                                    .Result;

            // Get a handle to the first section.
            firstSectionID = sectionPage.Value[0].Id;
        }

        internal async Task TestPageCleanUp()
        {
            await graphClient.Me.Onenote.Pages[testPage.Id].DeleteAsync();
        }

        /// <summary>
        /// Get the OneNote notebooks.
        /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/notebook_get
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteGetNotebooks()
        {
            try
            {
                var notebooksPage = await graphClient.Me
                                                                                 .Onenote
                                                                                 .Notebooks
                                                                                 .GetAsync();

                Assert.True(notebooksPage.Value.Count > 0);
                Assert.NotNull(notebooksPage.Value[0].Id);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// List a user's OneNote pages. You can also do this for groups.
        /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/onenote_list_pages
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteListPages()
        {
            try
            {
                var pageCollection = await graphClient.Me
                                                                              .Onenote
                                                                              .Pages
                                                                              .GetAsync();

                Assert.True(pageCollection.Value.Count > 0);
                Assert.NotNull(pageCollection.Value[0].Id);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// List a user's OneNote sections. You can also do this for groups.
        /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/onenote_list_sections
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteListSections()
        {
            try
            {
                var sectionsCollection = await graphClient.Me
                                                                                     .Onenote
                                                                                     .Sections
                                                                                     .GetAsync();

                Assert.True(sectionsCollection.Value.Count > 0);
                Assert.NotNull(sectionsCollection.Value[0].Id);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// List a user's OneNote section groups. You can also do this for groups.
        /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/onenote_list_sectiongroups
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteGetSectionGroups()
        {
            try
            {
                var sectionGroupCollection = await graphClient.Me
                                                                                              .Onenote
                                                                                              .SectionGroups
                                                                                              .GetAsync();

                Assert.True(sectionGroupCollection.Value.Count > 0);
                Assert.NotNull(sectionGroupCollection.Value[0].Id);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Lists a user's notebooks with the section object expanded.
        /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/onenote_list_notebooks
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteGetNotebooksExpandSection()
        {
            try
            {
                var notebooksPage = await graphClient.Me
                                                                                 .Onenote
                                                                                 .Notebooks
                                                                                 .GetAsync(requestConfiguration => requestConfiguration.QueryParameters.Expand = new string[] { "sections" });

                Assert.True(notebooksPage.Value.Count > 0);
                Assert.NotNull(notebooksPage.Value[0].Id);
                Assert.NotNull(notebooksPage.Value[0].Sections);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Lists the notebooks that the usr recetly used.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteGetRecentNotebooks()
        {
            try
            {
                var recentNotebooksPage = await graphClient.Me
                                                                                                 .Onenote
                                                                                                 .Notebooks
                                                                                                 //.GetRecentNotebooks(true)
                                                                                                 .GetAsync();

                Assert.True(recentNotebooksPage.Value.Count > 0);
                Assert.NotNull(recentNotebooksPage.Value[0].DisplayName);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Preview the contents of a OneNote page.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNotePagePreview()
        {
            try
            {
                // Get a page of OneNote pages
                var pageCollection = await graphClient.Me
                                                                                     .Onenote
                                                                                     .Sections[firstSectionID]
                                                                                     .Pages
                                                                                     .GetAsync();

                // Get a handle to the first section.
                string pageId = pageCollection.Value[0].Id;

                // URL to update a page. https://graph.microsoft.com/v1.0/me/onenote/sections/{id}/pages/{id}/preview
                OnenotePagePreview pagePreview = await graphClient.Me
                                                                  .Onenote
                                                                  .Pages[pageId]
                                                                  .Preview
                                                                  .GetAsync();

                Assert.NotNull(pagePreview);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Get a resource from an existing page.
        /// </summary>
        /// <returns>Task</returns>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteGetResource()
        {
            try
            {
                //graphClient.Sites[""].

                // This resource is from a page created with OneNoteAddPageMultipart.
                // Page Id: 1-c57153f8dc2245b291b83015961fdccd!114-4ad43aa2-8e35-42e6-b9ca-8be860a8af11
                string resourceId = "1-03dd7ea8053b488f9c3ce14c09e1b833!1-4ad43aa2-8e35-42e6-b9ca-8be860a8af11";
                Stream resource = await graphClient.Me.Onenote.Resources[resourceId].Content.GetAsync();

                Assert.NotNull(resource);
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Try and fail to create a notebook with invalid chars.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteTryCreateNotebookWithInvalidChars()
        {
            try
            {
                var newNotebook = new Notebook()
                {
                    DisplayName = $"Notebook created from test, ?*\\/:<>|'"
                };

                Notebook notebook = await graphClient.Me.Onenote.Notebooks.PostAsync(newNotebook);
            }
            catch (ApiException e)
            {
                Assert.Contains("The notebook name value contains invalid characters", e.Message);
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Create a notebook.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteCreateNotebook()
        {
            try
            {
                testNotebook = new Notebook()
                {
                    DisplayName = $"Notebook created from test, {DateTime.Now.ToString("yyyy.mm.dd.hh.mm.ss")}"
                };

                Notebook notebook = await graphClient.Me.Onenote.Notebooks.PostAsync(testNotebook);
                Assert.NotNull(notebook);
                Assert.Equal(testNotebook.DisplayName, notebook.DisplayName);
            }
            catch (ApiException e)
            {
                Assert.Contains(e.Message, "The notebook name value contains invalid characters");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// OneNoteAddPageHtmlWorkaround is a workaround test. We've since added functionality to address this in the client library.
        /// See OneNoteCreatePageWithHtml() for how this is done.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteAddPageHtmlWorkaround()
        {
            try
            {
                // Get the request information for adding a page.
                string title = "OneNoteAddPageHtml test created this";
                string htmlBody = $"<!DOCTYPE html><html><head><title>{title}</title></head>" +
                                    "<body>Generated from the test</body></html> ";

                var requestInformation = graphClient.Me.Onenote.Sections[firstSectionID].Pages.ToPostRequestInformation(null);
                requestInformation.SetStreamContent(new MemoryStream(Encoding.UTF8.GetBytes(htmlBody)),"text/html");
                requestInformation.Headers.Add("Content-Type","text/html");

                // Send the request and get the response.
                var responseHandler = new NativeResponseHandler();
                requestInformation.AddRequestOptions(new []{new ResponseHandlerOption{ResponseHandler = responseHandler}});
                await graphClient.RequestAdapter.SendNoContentAsync(requestInformation);
                HttpResponseMessage response = responseHandler.Value as HttpResponseMessage;

                // Get the OneNote page that we created.
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize into OneNotePage object.
                    var content = await response.Content.ReadAsStreamAsync();
                    testPage = await KiotaJsonSerializer.DeserializeAsync<OnenotePage>(content, CancellationToken.None);

                    Assert.NotNull(testPage);
                    Assert.Contains(testPage.Title, title);
                    Assert.Null(testPage.Content);

                    await TestPageCleanUp();
                }
                else
                    throw new ServiceException(await response.Content.ReadAsStringAsync());
            }
            catch (ApiException e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// OneNoteAddPageHtmlWithStreamWorkaround is a workaround test. We've since added functionality to address this in the client library.
        /// See OneNoteCreatePageWithHtml() for how this is done.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteAddPageHtmlWithStreamWorkaround()
        {
            try
            {
                // Get the request URL for adding a page. You don't have to use the request builder to
                // get the URL. We use it here for convenience.
                var requestInformation = graphClient.Me.Onenote.Sections[firstSectionID].Pages.ToGetRequestInformation();

                // Create the request body.
                string title = "OneNoteAddPageHtmlWithStream test created this";
                string htmlBody = $"<!DOCTYPE html><html><head><title>{title}</title></head><body>Generated from the test</body></html> ";
                byte[] byteArray = Encoding.ASCII.GetBytes(htmlBody);

                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    // Create the stream body.
                    requestInformation.Headers.Add("Content-Type","text/html");
                    requestInformation.HttpMethod = Method.POST;

                    // Create the request message and add the content.
                    requestInformation.SetStreamContent(stream,"text/html");

                }

                // Deserialize into OneNotePage object.
                // Send the request and get the response.
                var content = await graphClient.RequestAdapter.SendPrimitiveAsync<Stream>(requestInformation);
                testPage = await KiotaJsonSerializer.DeserializeAsync<OnenotePage>(content, CancellationToken.None);

                Assert.NotNull(testPage);
                Assert.Contains(testPage.Title, title);

                await TestPageCleanUp();

            }
            catch (ODataError e)
            {
                Assert.Fail($"Error code: {e.Error.Code}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// OneNoteAddPageMultipartWorkaround is a workaround test. We've since added functionality to address this in the client library.
        /// See OneNoteCreatePageWithMultipart() for how this is done.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteAddPageMultipartWorkaround()
        {
            try
            {
                // Get the request URL for adding a page.
                var requestInformation = graphClient.Me.Onenote.Sections[firstSectionID].Pages.ToGetRequestInformation();
                string title = "OneNoteAddPageMultipart test created this";
                string htmlBody = $@"<!DOCTYPE html><html><head><title>{title}</title></head>
                                    <body>Generated from the test
                                        <p>
                                            <img src=""name:imageBlock1"" alt=""an image on the page"" width=""300"" />
                                        </p>
                                    </body></html>";

                string boundary = "MultiPartBoundary32541";
                string contentType = "multipart/form-data; boundary=" + boundary;

                // Create the presentation part.
                StringContent presentation = new StringContent(htmlBody);
                presentation.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                presentation.Headers.ContentDisposition.Name = "Presentation";
                presentation.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                using (Stream ms = ResourceHelper.GetResourceAsStream(ResourceHelper.Hamilton))
                {
                    // Create the image part.
                    StreamContent image = new StreamContent(ms);
                    image.Headers.ContentDisposition = new ContentDispositionHeaderValue(@"form-data") { Name = "imageBlock1" };
                    image.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                    // Put the multiparts togeter
                    MultipartContent multiPartContent = new MultipartContent("form-data", boundary);
                    multiPartContent.Add(presentation);
                    multiPartContent.Add(image);

                    // Create the request message and add the content.
                    requestInformation.HttpMethod = Method.POST;
                    requestInformation.Headers.Add("Content-Type",contentType);
                    requestInformation.SetStreamContent(await image.ReadAsStreamAsync(),"application/octet-stream");

                    // Deserialize into OneNotePage object.
                    testPage = await graphClient.RequestAdapter.SendAsync<OnenotePage>(requestInformation,OnenotePage.CreateFromDiscriminatorValue);

                    Assert.NotNull(testPage);
                    Assert.True(testPage.GetType() == typeof(OnenotePage));
                    Assert.Contains(testPage.Title, title);

                    await TestPageCleanUp();
                }
            }
            catch (ODataError e)
            {
                Assert.Fail($"Error code: {e.Error.Code}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// This is a workaround for updating a page.
        /// We can't support generation for the update scenario.
        /// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/page_update
        /// The service expects PATCH https://graph.microsoft.com/v1.0/me/onenote/pages/{id}/content with a
        /// body that includes a JSON object that describes the PATCH. We generate a dummy object that is
        /// supposed to be set with the properties PATCH.
        /// Issue: metadata describes a onenotePatchContent action. This scenario would probably generate correctly.
        /// This conflicts with the documentation.
        /// Issue: The documented form we cannot generate from our metadata. Docs say that we PATCH to the content structural property
        /// It is supposed to PATCH a OnenotePatchContentCommand. The content property is actually a stream. Metadata and service don't match.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteUpdatePage()
        {
            try
            {
                // Get a page of OneNote pages
                var pageCollection = await graphClient.Me.Onenote.Sections[firstSectionID].Pages.GetAsync();

                // Get a handle to the first section.
                string pageId = pageCollection.Value[0].Id;

                // URL to update a page. https://graph.microsoft.com/v1.0/me/onenote/sections/{id}/pages/{id}/content
                var requestInformation = graphClient.Me.Onenote.Pages[pageId].Content.ToGetRequestInformation();

                // Create the patch command to update thebody of the OneNote page.
                OnenotePatchContentCommand updateBodyCommand = new OnenotePatchContentCommand() {
                    //Action = OnenotePatchActionType.Append,
                    Target = "body",
                    Content = @"<table><tr><td><p><b>Brazil</b></p></td><td><p>Germany</p></td></tr>
                                   <tr><td><p>France</p></td><td><p><b>Italy</b></p></td></tr>
                                   <tr><td><p>Netherlands</p></td><td><p><b>Spain</b></p></td></tr>
                                   <tr><td><p>Argentina</p></td><td><p><b>Germany</b></p></td></tr>
                            </table>",
                    Position = OnenotePatchInsertPosition.After
                };

                List<OnenotePatchContentCommand> commands = new List<OnenotePatchContentCommand> { updateBodyCommand };

                // Create the request message.
                requestInformation.HttpMethod = Method.PATCH;

                // Serialize the OnenotePatchContentCommand object and add to the request.
                var serializer = new JsonSerializationWriter();
                serializer.WriteCollectionOfObjectValues<OnenotePatchContentCommand>(string.Empty,commands);

                requestInformation.SetStreamContent(serializer.GetSerializedContent(),"application/octet-stream");
                requestInformation.Headers.Add("Content-Type", "application/json");

                // Send the request and get the response.
                await graphClient.RequestAdapter.SendNoContentAsync(requestInformation);
            }
            catch (ODataError e)
            {
                Assert.Fail($"Error code: {e.Error.Code}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Add a page by using HTML passed in a stream.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteCreatePageWithHtmlStream()
        {
            string testString = ". Choose positive.";

            // Create the request body.
            string htmlBody = $"<!DOCTYPE html><html><head><title>OneNoteAddPageHtmlWithStream test created this{testString}</title></head>" +
                                    "<body>Generated from the test with the partial</body></html> ";
            byte[] byteArray = Encoding.ASCII.GetBytes(htmlBody);

            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                // Create a OneNote page.
                var requestInformation =
                    graphClient.Me.Onenote.Sections[firstSectionID].Pages.ToGetRequestInformation();
                requestInformation.HttpMethod = Method.POST;
                requestInformation.Headers.Add("Content-Type","text/html");
                testPage = await graphClient.RequestAdapter.SendAsync(requestInformation,OnenotePage.CreateFromDiscriminatorValue);
            }

            Assert.NotNull(testPage);
            Assert.Contains(testString, testPage.Title);

            await TestPageCleanUp();
        }

        /// <summary>
        /// Add a page from HTML
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteAddPageWithHtml()
        {
            string testString = ". Choose positive.";

            // Create the request body.
            string htmlBody = $"<!DOCTYPE html><html><head><title>OneNoteAddPageHtmlWithStream test created this{testString}</title></head>" +
                                    "<body>Generated from the test with the partial</body></html> ";

            var requestInformation =
                graphClient.Me.Onenote.Sections[firstSectionID].Pages.ToGetRequestInformation();
            requestInformation.HttpMethod = Method.POST;
            requestInformation.SetStreamContent(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlBody)),"application/octet-stream");
            requestInformation.Headers.Add("Content-Type","text/html");
            testPage = await graphClient.RequestAdapter.SendAsync(requestInformation,OnenotePage.CreateFromDiscriminatorValue);

            Assert.NotNull(testPage);
            Assert.Contains(testString, testPage.Title);

            await TestPageCleanUp();
        }

        /// <summary>
        /// Add a multi-part page.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task OneNoteAddPageWithMultipart()
        {
            try
            {
                string title = "OneNoteAddPageMultipart test created this";
                string htmlBody = $@"<!DOCTYPE html><html><head><title>{title}</title></head>
                                    <body>Generated from the test
                                        <p>
                                            <img src=""name:imageBlock1"" alt=""an image on the page"" width=""300"" />
                                        </p>
                                    </body></html>
        ";

                string boundary = "MultiPartBoundary32541";
                string contentType = "multipart/form-data; boundary=" + boundary;

                // Create the presentation part.
                StringContent presentation = new StringContent(htmlBody);
                presentation.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                presentation.Headers.ContentDisposition.Name = "Presentation";
                presentation.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                StreamContent image;

                // Get an image stream.
                using (Stream ms = ResourceHelper.GetResourceAsStream(ResourceHelper.Hamilton))
                {
                    // Create the image part.
                    image = new StreamContent(ms);
                    image.Headers.ContentDisposition = new ContentDispositionHeaderValue(@"form-data");
                    image.Headers.ContentDisposition.Name = "imageBlock1";
                    image.Headers.ContentType = new MediaTypeHeaderValue("image/png");

                    // Put the multiparts together
                    MultipartContent multiPartContent = new MultipartContent("form-data", boundary);
                    multiPartContent.Add(presentation);
                    multiPartContent.Add(image);

                    // Get the multiPart stream and then send the request to add a page using the stream.
                    var requestInformation =
                        graphClient.Me.Onenote.Sections[firstSectionID].Pages.ToGetRequestInformation();
                    requestInformation.HttpMethod = Method.POST;
                    requestInformation.SetStreamContent(await multiPartContent.ReadAsStreamAsync(),"application/octet-stream");
                    requestInformation.Headers.Add("Content-Type",contentType);
                    testPage = await graphClient.RequestAdapter.SendAsync(requestInformation,OnenotePage.CreateFromDiscriminatorValue);
                }

                Assert.NotNull(testPage);
                Assert.True(testPage.GetType() == typeof(OnenotePage));
                Assert.Contains(testPage.Title, htmlBody);

                await TestPageCleanUp();
            }
            catch (ODataError e)
            {
                Assert.Fail($"Error code: {e.Error.Code}");
            }

            catch (Exception e)
            {
                Assert.Fail($"Error code: {e.Message}");
            }
        }

        /// <summary>
        /// Test the custom 'Root' partial request builder and accessing Onenote notebook collection.
        /// </summary>
        /// <returns></returns>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task It_accesses_a_sites_OneNote_notebooks()
        {
            try
            {
                Site site = await graphClient.Sites["root"].GetAsync();
                Assert.NotNull(site);

                var notebooks = await graphClient.Sites[site.Id].Onenote.Notebooks.GetAsync();
                Assert.NotNull(notebooks);
            }
            catch (Exception)
            {
                Assert.Fail("An unexpected exception was thrown. This test case failed.");
            }
        }
    }
}
