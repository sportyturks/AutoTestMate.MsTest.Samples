using AutoTestMate.MsTest.Infrastructure.Attributes;
using AutoTestMate.MsTest.Infrastructure.Core;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.Samples.Web.Models;
using Castle.MicroKernel.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Samples.Web.Tests
{
    [TestClass]
    public class SampleTests1 : WebTestBase
    {
        public IGoogleSearchPage GoogleSearchPage => TestManager.Container.Resolve<IGoogleSearchPage>();

        [TestInitialize]
        public override void OnTestInitialise()
        {
            base.OnTestInitialise();

            var googleSearchPage = new GoogleSearchPage(TestMethod);
            TestManager.Container.Register(Component.For<IGoogleSearchPage>().Instance(googleSearchPage).OverridesExistingRegistration().LifestyleSingleton());
        }
        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "8", SheetName = "TableThree")]
        public void EnsureCorrectFieldsAccessed1()
        {
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("BrowserType") == "Chrome");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("RowKey") == "8");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldSeven") == "Climbed");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldEight") == "Up");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldNine") == "The");
            
            TestContext.WriteLine("Excel Attribute Passed with Flying Colors!");
        }

        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "5", SheetName = "TableTwo")]
        public void GoogleSearchTestSimple1()
        {
            var googleSearchPage = new GoogleSearchPage();

            googleSearchPage
                .Open()
                .AddSearchText("Latest News")
                .ClickSearchBox()
                .ClickSearchButton();

            Assert.IsNotNull(ConfigurationReader);
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("BrowserType") == "Chrome");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("RowKey") == "5");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldFour") == "Sheep");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldFive") == "Have");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldSix") == "You");
        }
        
        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "3", SheetName = "TableOne")]
        public void GoogleSearchTestContainerExample1()
        {
            var googleSearchPage = GoogleSearchPage;

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
