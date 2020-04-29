using AutoTestMate.MsTest.Infrastructure.Attributes;
using AutoTestMate.MsTest.Infrastructure.Core;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.Samples.Web.Models;
using Castle.MicroKernel.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Samples.Web.Tests
{
    [TestClass]
    public class SampleTests : WebTestBase
    {
        public IGoogleSearchPage GoogleSearchPage => TestManager.Container.Resolve<IGoogleSearchPage>();

        [TestInitialize]
        public override void OnTestInitialise()
        {
            base.OnTestInitialise();

            TestManager.Container.Register(Component.For<IGoogleSearchPage>().ImplementedBy<GoogleSearchPage>().OverridesExistingRegistration().LifestyleTransient());
        }

        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "8", SheetName = "TableThree")]
        public void EnsureCorrectFieldsAccessed()
        {
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("RowKey") == "8");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldSeven") == "Climbed");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldEight") == "Up");
            Assert.IsTrue(ConfigurationReader.GetConfigurationValue("FieldNine") == "The");
            
            TestContext.WriteLine("Excel Attribute Passed with Flying Colors!");
        }

        [TestMethod]
        [ExcelClosedTestData(FileLocation = @"./Data", FileName = "NurseryRhymesBook.xlsx", RowKey = "8", SheetName = "TableThree")]
        public void GoogleSearchTest()
        {
            var googleSearchPage = GoogleSearchPage;

            googleSearchPage
                .Open()
                .AddSearchText("Latest News")
                .ClickSearchBox()
                .ClickSearchButton();

            Assert.IsNotNull(ConfigurationReader);
        }
    }
}
