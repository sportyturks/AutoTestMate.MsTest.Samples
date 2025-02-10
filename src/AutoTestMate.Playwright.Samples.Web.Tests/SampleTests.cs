using System.Threading.Tasks;
using AutoTestMate.MsTest.Infrastructure.Attributes;
using AutoTestMate.MsTest.Playwright.Core;
using AutoTestMate.Playwright.Samples.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Playwright.Samples.Web.Tests
{
    [TestClass]
    public class SampleTests : PlaywrightTestBase
    {
        [RetryTestMethod(numberOfAttempts: 3)]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "8", SheetName = "TableThree")]
        public void EnsureCorrectFieldsAccessed()
        {
            var configurationReader = GetConfigurationReader();

            Assert.IsTrue(configurationReader.GetConfigurationValue("RowKey") == "8");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldSeven").ToLower() == "climbed");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldEight").ToLower() == "up");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldNine").ToLower() == "the");


            TestContext.WriteLine("Excel Attribute Passed with Flying Colors!");
        }

        //[RetryTestMethod(numberOfAttempts: 3)]
        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "5", SheetName = "TableTwo")]
        public async Task GoogleSearchTestSimple()
        {
            var googleSearchPage = GetPage<GoogleSearchPage>();

            await googleSearchPage
                .Open();
            
            await googleSearchPage
                    .AddSearchText("Latest News").ConfigureAwait(false);
            await googleSearchPage
                    .ClickSearchBox().ConfigureAwait(false);
            await googleSearchPage
                    .ClickSearchButton();

            var configurationReader = GetConfigurationReader();

            Assert.IsNotNull(configurationReader);
            Assert.IsTrue(configurationReader.GetConfigurationValue("RowKey") == "5");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldFour").ToLower() == "sheep");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldFive").ToLower() == "have");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldSix").ToLower() == "you");
        }
        
        [RetryTestMethod(numberOfAttempts: 3)]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "3", SheetName = "TableOne")]
        public async Task GoogleSearchTestContainerExample()
        {
            var googleSearchPage = GetPage<GoogleSearchPage>();

            await googleSearchPage
                .Open().ConfigureAwait(false);
            
            googleSearchPage
                .AddSearchText("Dependency Injection").Result
                .ClickSearchBox().Result
                .ClickSearchButton();

            var configurationReader = GetConfigurationReader();

            Assert.IsNotNull(ConfigurationReader);
            Assert.IsTrue(configurationReader.GetConfigurationValue("RowKey") == "3");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldOne").ToLower() == "over");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldTwo").ToLower() == "the");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldThree").ToLower() == "tree");
        }

        [RetryTestMethod(numberOfAttempts: 3)]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "8", SheetName = "TableThree")]
        public async Task GoogleSearchTest()
        {
            var googleSearchPage = GetPage<GoogleSearchPage>();
            var s = ConfigurationReader.Settings;
            var search = $"{s["FieldSeven"]} {s["FieldEight"]} {s["FieldNine"]}";
            TestManager.TestContext.WriteLine($"Test ExcelData Google search for {search}");

            googleSearchPage
                .Open();
                await googleSearchPage
                .AddSearchText(search).Result
                .ClickSearchBox().Result
                .ClickSearchButton();

            Assert.IsNotNull(ConfigurationReader);
        }
    }
}
