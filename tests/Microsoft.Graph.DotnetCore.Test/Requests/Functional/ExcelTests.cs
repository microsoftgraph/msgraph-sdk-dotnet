// ------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.  Licensed under the MIT License.  See License in the project root for license information.
// ------------------------------------------------------------------------------

// README before adding tests here.
// If you are adding tests for Excel, please do the following:
// -- Use the template at the bottom of this file.  Make sure to create test file per test method and then delete your resource.
// -- Add worksheets to Requests\Functional\Resources\excelTestResource to target for your test case. Do not touch existing sheets.

namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using Microsoft.Graph.DotnetCore.Test.Requests.Functional.Resources;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.Graph.Models;
    using Microsoft.Graph.Models.ODataErrors;

    /// <summary>
    /// The tests in this class cover the Excel REST API.
    /// </summary>

    public class ExcelTests : GraphTestBase
    {
        [Fact (Skip = "No CI set up for functional tests")]
        public async Task OneDriveCreateDeleteExcelWorkbook()
        {
            await OneDriveSearchForTestFile();
            var fileId = await OneDriveCreateTestFile("_excelTestResource.xlsx");
            await OneDriveUploadTestFileContent(fileId);
            await OneDriveDeleteTestFile(fileId, 5000);
        }

        private async Task OneDriveSearchForTestFile(string fileName = "_excelTestResource.xlsx")
        {
            // Check that this item hasn't already been created.
            // https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_search
            var searchResults = await graphClient.Drives["driveId"].Items[""].SearchWithQ(fileName).GetAsSearchWithQGetResponseAsync();
            foreach (var r in searchResults.Value)
            {
                if (r.Name != fileName)
                    continue;
                else
                {
                    Assert.Fail("Test cleanup is not removing the test Excel file from the test tenant. Please check the cleanup code.");
                }
            }
        }

        public async Task<string> OneDriveCreateTestFile(string fileName)
        {
            var excelWorkbook = new DriveItem()
            {
                Name = fileName,
                File = new FileObject()
            };

            // Create the Excel file.
            // https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_search
            // TODO fix the metadata
            // var excelWorkbookDriveItem = await graphClient.Drives["driveId"].Root.Children.PostAsync(excelWorkbook);
            var excelWorkbookDriveItem = await graphClient.Drives["driveId"].Items[""].Children[""].GetAsync();

            //var excelWorkbookDriveItem = await graphClient.Me.Drive.Root.Children.Request().Filter($"name eq '{fileName}'").GetAsync();
            //await OneDriveDeleteTestFile(excelWorkbookDriveItem.CurrentPage.FirstOrDefault().Id, 3000);
            Assert.NotNull(excelWorkbookDriveItem);

            return excelWorkbookDriveItem.Id;
        }

        private async Task OneDriveUploadTestFileContent(string fileId)
        {
            using Stream ms = ResourceHelper.GetResourceAsStream(ResourceHelper.ExcelTestResource);
            //Upload content to the file.
            //https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_uploadcontent
            await graphClient.Drives["driveId"].Items[fileId].Content.PutAsync(ms);
        }

        internal async Task OneDriveDeleteTestFile(string fileId, int delayInMilliseconds = 0)
        {
            try
            {
                // Get the item. The service tracks when the resource was last read and
                // gives an error if we try to delete after an update.
                DriveItem w = await graphClient.Drives["driveId"].Items[fileId].GetAsync();

                // Adding this since there is latency between OneDrive and the Excel WAC. Use when
                // you PATCH/POST/PUT to the workbook before you DELETE in test.
                if (delayInMilliseconds > 0)
                {
                    await Task.Delay(delayInMilliseconds);
                }

                // Delete the workbook.
                // https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_delete
                await graphClient.Drives["driveId"].Items[fileId].DeleteAsync(requestConfiguration => requestConfiguration.Headers.Add("if-match","*"));
            }
            catch (ODataError e)
            {
                if (e.Error.Code == "resourceModified")
                    Assert.Fail("Error code: " + e.Error.Code + ", message: " + e.Error.Message);
                else
                    Assert.Fail("Something happened. Error code: " + e.Error.Code);
            }
        }
    }
}
