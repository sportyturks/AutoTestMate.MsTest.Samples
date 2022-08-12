using System.IO;
using System.Reflection;
using AutoTestMate.MsTest.Infrastructure.Attributes;
using AutoTestMate.MsTest.Infrastructure.Helpers;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.Samples.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Samples.Web.Tests
{
    [TestClass]
    public class SampleTests : WebTestBase
    {
        [TestMethod]
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

        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "5", SheetName = "TableTwo")]
        public void GoogleSearchTestSimple()
        {
            var googleSearchPage = GetPage<GoogleSearchPage>();

            googleSearchPage
                .Open()
                .AddSearchText("Latest News")
                .ClickSearchBox()
                .ClickSearchButton();

            var configurationReader = GetConfigurationReader();

            Assert.IsNotNull(configurationReader);
            Assert.IsTrue(configurationReader.GetConfigurationValue("RowKey") == "5");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldFour").ToLower() == "sheep");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldFive").ToLower() == "have");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldSix").ToLower() == "you");
        }
        
        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "3", SheetName = "TableOne")]
        public void GoogleSearchTestContainerExample()
        {
            var googleSearchPage = GetPage<GoogleSearchPage>();

            googleSearchPage
                .Open()
                .AddSearchText("Dependency Injection")
                .ClickSearchBox()
                .ClickSearchButton();

            var configurationReader = GetConfigurationReader();

            Assert.IsNotNull(ConfigurationReader);
            Assert.IsTrue(configurationReader.GetConfigurationValue("RowKey") == "3");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldOne").ToLower() == "over");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldTwo").ToLower() == "the");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldThree").ToLower() == "tree");
        }

        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "8", SheetName = "TableThree")]
        public void GoogleSearchTest()
        {
            var googleSearchPage = GetPage<GoogleSearchPage>();
            var s = ConfigurationReader.Settings;
            var search = $"{s["FieldSeven"]} {s["FieldEight"]} {s["FieldNine"]}";
            TestManager.TestContext.WriteLine($"Test ExcelData Google search for {search}");

            googleSearchPage
                .Open()
                .AddSearchText(search)
                .ClickSearchBox()
                .ClickSearchButton();

            Assert.IsNotNull(ConfigurationReader);
        }
    }
}
