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
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xunit;
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

        public async Task OneDriveSearchForTestFile(string fileName = "_excelTestResource.xlsx")
        {
            // Check that this item hasn't already been created. 
            // https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_search
            var searchResults = await graphClient.Me.Drive.Root.Search(fileName).Request().GetAsync();
            foreach (var r in searchResults)
            {
                if (r.Name != fileName)
                    continue;
                else
                {
                    Assert.True(false, "Test cleanup is not removing the test Excel file from the test tenant. Please check the cleanup code.");
                }
            }
        }

        public async Task<string> OneDriveCreateTestFile(string fileName)
        {
            var excelWorkbook = new DriveItem()
            {
                Name = fileName,
                File = new Microsoft.Graph.File()
            };

            // Create the Excel file.
            // https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_search
            var excelWorkbookDriveItem = await graphClient.Me.Drive.Root.Children.Request().AddAsync(excelWorkbook);
            //var excelWorkbookDriveItem = await graphClient.Me.Drive.Root.Children.Request().Filter($"name eq '{fileName}'").GetAsync();
            //await OneDriveDeleteTestFile(excelWorkbookDriveItem.CurrentPage.FirstOrDefault().Id, 3000);
            Assert.NotNull(excelWorkbookDriveItem);

            return excelWorkbookDriveItem.Id;
        }

        public async Task OneDriveUploadTestFileContent(string fileId)
        {
            DriveItem excelDriveItem;
            using (Stream ms = ResourceHelper.GetResourceAsStream(ResourceHelper.ExcelTestResource))
            {
                //Upload content to the file.
                //https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_uploadcontent
                excelDriveItem = await graphClient.Me.Drive.Items[fileId].Content.Request().PutAsync<DriveItem>(ms);
            }

            Assert.NotNull(excelDriveItem);
        }

        public async Task OneDriveDeleteTestFile(string fileId, int delayInMilliseconds = 0)
        {
            try
            {
                // Get the item. The service tracks when the resource was last read and 
                // gives an error if we try to delete after an update. 
                DriveItem w = await graphClient.Me.Drive.Items[fileId].Request().GetAsync();

                var headers = new List<Option>()
                {
                    //new HeaderOption("if-match", w.ETag) // There is an intermittent bug with eTag. Informed PM.
                    new HeaderOption("if-match", "*")
                };

                // Adding this since there is latency between OneDrive and the Excel WAC. Use when 
                // you PATCH/POST/PUT to the workbook before you DELETE in test.
                if (delayInMilliseconds > 0)
                {
                    await Task.Delay(delayInMilliseconds);
                }

                // Delete the workbook.
                // https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/item_delete
                await graphClient.Me.Drive.Items[fileId].Request(headers).DeleteAsync();
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                if (e.Error.Code == "resourceModified")
                    Assert.True(false, "Error code: " + e.Error.Code + ", message: " + e.Error.Message);
                else
                    Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact(Skip = "No CI set up for functional tests")]
        public async Task ExcelGetUpdateRange()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelGetUpdateRangeTestFile.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // GET https://graph.microsoft.com/beta/me/drive/items/012KW42LDENXUUPCMYQJDYX3CLZMORQKGT/workbook/worksheets/Sheet1/Range(address='A1')
                var rangeToUpdate = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets["GetUpdateRange"]
                                                              .Range("A1")
                                                              .Request()
                                                              .GetAsync();

                // Forming the JSON for the updated values
                var arr = rangeToUpdate.Values as JArray;
                var arrInner = arr[0] as JArray;
                arrInner[0] = $"{arrInner[0] + "C"}"; // JToken

                // Create a dummy WorkbookRange object so that we only PATCH the values we want to update.
                var dummyWorkbookRange = new WorkbookRange();
                dummyWorkbookRange.Values = arr;

                // Update the range values.
                var workbookRange = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets["GetUpdateRange"]
                                                              .Range("A1")
                                                              .Request()
                                                              .PatchAsync(dummyWorkbookRange);

                Assert.NotNull(workbookRange);
                Assert.True(workbookRange.Values.ToString() == dummyWorkbookRange.Values.ToString());
                Assert.True(workbookRange.Text.ToString() == workbookRange.Values.ToString());

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelChangeNumberFormat()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelChangeNumberFormatTestFile.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);
                var excelWorksheetId = "ChangeNumberFormat";
                var rangeAddress = "E2";

                // Forming the JSON for 
                var arr = JArray.Parse(@"[['$#,##0.00;[Red]$#,##0.00']]"); // Currency format

                var dummyWorkbookRange = new WorkbookRange();
                dummyWorkbookRange.NumberFormat = arr;


                var workbookRange = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets[excelWorksheetId]
                                                              .Range(rangeAddress)
                                                              .Request()
                                                              .PatchAsync(dummyWorkbookRange);

                Assert.NotNull(workbookRange);
                Assert.True(arr.ToString() == workbookRange.NumberFormat.ToString());

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelAbsFunc()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelAbsFuncTestFile.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Get the absolute value of -10
                var inputNumber = JToken.Parse("-10");

                var workbookFunctionResult = await graphClient.Me.Drive.Items[excelFileId].Workbook.Functions.Abs(inputNumber).Request().PostAsync();

                Assert.NotNull(workbookFunctionResult);
                Assert.Equal("10", workbookFunctionResult.Value.ToString());

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelSetFormula()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelSetFormulaTestFile.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Forming the JSON for updating the formula
                var arr = JArray.Parse(@"[['=A4*B4']]");

                // We want to use a dummy workbook object so that we only send the property we want to update.
                var dummyWorkbookRange = new WorkbookRange();
                dummyWorkbookRange.Formulas = arr;

                var workbookRange = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets["SetFormula"]
                                                              .Range("C4")
                                                              .Request()
                                                              .PatchAsync(dummyWorkbookRange);

                Assert.NotNull(workbookRange);
                Assert.True(arr.ToString() == workbookRange.Formulas.ToString());

                await OneDriveDeleteTestFile(excelFileId, 5000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelAddTableUsedRange()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelAddTableUsedRange.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Get the used range of this worksheet. This results in a call to the service.
                var workbookRange = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets["AddTableUsedRange"]
                                                              .UsedRange()
                                                              .Request()
                                                              .GetAsync();


                // Create the dummy workbook object. Must use the AdditionalData property for this. 
                var dummyWorkbookTable = new WorkbookTable();
                var requiredPropsCreatingTableFromRange = new Dictionary<string, object>();
                requiredPropsCreatingTableFromRange.Add("address", workbookRange.Address);
                requiredPropsCreatingTableFromRange.Add("hasHeaders", false);
                dummyWorkbookTable.AdditionalData = requiredPropsCreatingTableFromRange;

                // Create a table based on the address of the workbookRange. 
                // This results in a call to the service.
                // https://graph.microsoft.io/en-us/docs/api-reference/v1.0/api/tablecollection_add
                var workbookTable = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets["AddTableUsedRange"]
                                                              .Tables
                                                              .Add(false, workbookRange.Address)
                                                              .Request()
                                                              .PostAsync();

                Assert.NotNull(workbookTable);

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelAddRowToTable()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelAddRowToTable.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Create the table row to insert. This assumes that the table has 2 columns.
                // You'll want to make sure you give a JSON array that matches the size of the table.
                var newWorkbookTableRow = new WorkbookTableRow();
                newWorkbookTableRow.Index = 0;
                var myArr = JArray.Parse("[[\"ValueA2\",\"ValueA3\"]]");
                newWorkbookTableRow.Values = myArr;

                //// Insert a new row. This results in a call to the service.
                var workbookTableRow = await graphClient.Me.Drive.Items[excelFileId]
                                                                 .Workbook
                                                                 .Tables["Table1"]
                                                                 .Rows
                                                                 .Request()
                                                                 .AddAsync(newWorkbookTableRow);

                Assert.NotNull(workbookTableRow);

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelSortTableOnFirstColumnValue()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelSortTableOnFirstColumnValue.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Create the sorting options.
                var sortField = new WorkbookSortField()
                {
                    Ascending = true,
                    SortOn = "Value",
                    Key = 0
                };

                var workbookSortFields = new List<WorkbookSortField>() { sortField };

                // Sort the table. This results in a call to the service.
                await graphClient.Me.Drive.Items[excelFileId].Workbook.Tables["Table2"]
                                                                          .Sort
                                                                          .Apply(true, "", workbookSortFields)
                                                                          .Request()
                                                                          .PostAsync();

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelFilterTableValues()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelFilterTableValues.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Filter the table. This results in a call to the service.
                await graphClient.Me.Drive.Items[excelFileId]
                                          .Workbook
                                          .Tables["FilterTableValues"]
                                          .Columns["1"] // This is a one based index.
                                          .Filter
                                          .ApplyValuesFilter(JArray.Parse("[\"2\"]"))
                                          .Request()
                                          .PostAsync();

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelCreateChartFromTable()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelCreateChartFromTable.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Get the table range.
                var tableRange = await graphClient.Me.Drive.Items[excelFileId]
                                                           .Workbook
                                                           .Tables["CreateChartFromTable"] // Set in excelTestResource.xlsx
                                                           .Range()
                                                           .Request()
                                                           .GetAsync();

                // Create a chart based on the table range.
                var workbookChart = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets["CreateChartFromTable"] // Set in excelTestResource.xlsx
                                                              .Charts
                                                              .Add("ColumnStacked", "Auto", tableRange.Address)
                                                              .Request()
                                                              .PostAsync();

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "Something happened. Error code: " + e.Error.Code);
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelGetImageFromChart()
        {
            string excelFileId = string.Empty;
            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelGetImageFromChart.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Get the table range.
                var tableRange = await graphClient.Me.Drive.Items[excelFileId]
                                                            .Workbook
                                                            .Tables["CreateChartFromTable"] // Set in excelTestResource.xlsx
                                                            .Range()
                                                            .Request()
                                                            .GetAsync();

                // Create a chart based on the table range.
                var workbookChart = await graphClient.Me.Drive.Items[excelFileId]
                                                                .Workbook
                                                                .Worksheets["CreateChartFromTable"] // Set in excelTestResource.xlsx
                                                                .Charts
                                                                .Add("ColumnStacked", "Auto", tableRange.Address)
                                                                .Request()
                                                                .PostAsync();

                // Sometimes the creation of the chart takes too long and the new chart resource isn't accessible.
                await Task.Delay(1000);

                // Workaround since the metadata description isn't correct as it states it returns a string and not the 
                // actual JSON object, and since the service doesn't accept the fully qualified name that the client emits
                // even though it should accept the FQN.
                string chartResourceUrl = graphClient.Me.Drive.Items[excelFileId]
                                                        .Workbook
                                                        .Worksheets["CreateChartFromTable"] // Set in excelTestResource.xlsx
                                                        .Charts[workbookChart.Name]
                                                        .Request()
                                                        .RequestUrl;

                string urlToGetImageFromChart = String.Format("{0}/{1}", chartResourceUrl, "image(width=400)");

                HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Get, urlToGetImageFromChart);

                // Send the request and get the response.
                HttpResponseMessage response = await graphClient.HttpProvider.SendAsync(hrm);

                // Get the JsonObject page that we created.
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    JObject imageObject = JObject.Parse(content);
                    JToken obj = imageObject.GetValue("value");

                    Assert.NotNull(obj);
                }
                else
                    throw new ServiceException(
                        new Error
                        {
                            Code = response.StatusCode.ToString(),
                            Message = await response.Content.ReadAsStringAsync()
                        });

                // Test cleanup.
                await OneDriveDeleteTestFile(excelFileId);
            }
            catch (Microsoft.Graph.ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.False(true, $"Something happened. Error code: {e.Error.Code}");
            }
        }

        [Fact (Skip = "No CI set up for functional tests")]
        public async Task ExcelProtectWorksheet()
        {
            string excelFileId = string.Empty;

            try
            {
                excelFileId = await OneDriveCreateTestFile("_excelProtectWorksheet.xlsx");
                await OneDriveUploadTestFileContent(excelFileId);

                // Protect the worksheet.
                await graphClient.Me.Drive.Items[excelFileId]
                                          .Workbook
                                          .Worksheets["ProtectWorksheet"]
                                          .Protection
                                          .Protect()
                                          .Request()
                                          .PostAsync();

                var dummyWorkbookRange = new WorkbookRange()
                {
                    Values = JArray.Parse("[[\"This should not work\"]]")
                };

                // Try to write to the worksheet. Expect an exception.
                var workbookRange = await graphClient.Me.Drive.Items[excelFileId]
                                                              .Workbook
                                                              .Worksheets["ProtectWorksheet"] // Set in excelTestResource.xlsx 
                                                              .Cell(1, 1)
                                                              .Request()
                                                              .PatchAsync(dummyWorkbookRange);
            }
            catch (ServiceException e)
            {
                Assert.Equal("AccessDenied", e.Error.Code, true);
            }


            try
            {
                // Unprotect the worksheet.
                await graphClient.Me.Drive.Items[excelFileId]
                                          .Workbook
                                          .Worksheets["ProtectWorksheet"]
                                          .Protection
                                          .Unprotect()
                                          .Request()
                                          .PostAsync();

                await OneDriveDeleteTestFile(excelFileId, 3000);
            }
            catch (ServiceException e)
            {
                await OneDriveDeleteTestFile(excelFileId, 3000);
                Assert.True(false, "The unprotect call failed to remove protection from the worksheet. Error code: " + e.Error.Code);
            }
        }

        //public async Task ExcelTestTemplate()
        //{
        //    // Before you add a test, setup your test resource in /Resources/excelTestResource.xlsx. Add test data to a new sheet.
        //    try
        //    {
        //        // Creates a test Excel file for each test.
        //        var excelFileId = await OneDriveCreateTestFile("_excelCHANGETHIS.xlsx");
        //        await OneDriveUploadTestFileContent(excelFileId);


        //        await OneDriveDeleteTestFile(excelFileId, 3000);
        //    }
        //    catch (Microsoft.Graph.ServiceException e)
        //    {
        //        Assert.Fail("Something happened. Error code: {0}", e.Error.Code);
        //    }
        //}
    }
}