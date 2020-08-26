using AutoTestMate.MsTest.Infrastructure.Attributes;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.Samples.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Samples.Web.Tests
{
    [TestClass]
    public class SampleTests : WebTestBase
    {
        [TestInitialize]
        public override void OnTestInitialise()
        {
            base.OnTestInitialise();
        }
        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "8", SheetName = "TableThree")]
        public void EnsureCorrectFieldsAccessed()
        {
            var configurationReader = GetConfigurationReader();
            Assert.IsTrue(configurationReader.GetConfigurationValue("BrowserType") == "Chrome");
            Assert.IsTrue(configurationReader.GetConfigurationValue("RowKey") == "8");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldSeven") == "Climbed");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldEight") == "Up");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldNine") == "The");
            
            TestContext.WriteLine("Excel Attribute Passed with Flying Colors!");
        }

        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "5", SheetName = "TableTwo")]
        public void GoogleSearchTestSimple()
        {
            var googleSearchPage = new GoogleSearchPage();

            googleSearchPage
                .Open()
                .AddSearchText("Latest News")
                .ClickSearchBox()
                .ClickSearchButton();

            var configurationReader = GetConfigurationReader();
            Assert.IsNotNull(configurationReader);
            Assert.IsTrue(configurationReader.GetConfigurationValue("BrowserType") == "Chrome");
            Assert.IsTrue(configurationReader.GetConfigurationValue("RowKey") == "5");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldFour") == "Sheep");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldFive") == "Have");
            Assert.IsTrue(configurationReader.GetConfigurationValue("FieldSix") == "You");
        }
        
        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "3", SheetName = "TableOne")]
        public void GoogleSearchTestContainerExample()
        {
            var googleSearchPage = new GoogleSearchPage();

            googleSearchPage
                .Open()
                .AddSearchText("Dependency Injection")
                .ClickSearchBox()
                .ClickSearchButton();

            Assert.IsNotNull(ConfigurationReader);
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("BrowserType") == "Chrome");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("RowKey") == "3");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldOne") == "Over");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldTwo") == "The");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldThree") == "Tree");
        }
    }
}
