using AutoTestMate.MsTest.Infrastructure.Attributes;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.MsTest.Web.Extensions;
using AutoTestMate.Samples.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Samples.Web.Tests;

[TestClass]
public class SampleDataDrivenTests : WebTestBase
{
    public override string TestMethod => ReflectionExtensions.GetPropValue<string>(TestContext, "Context.testMethod.DisplayName");
    
    [TestMethod]
    [DataRow("Latest News", DisplayName = "GoogleSearchDataRowTest_1")]
    [DataRow("Automation Testing", DisplayName = "GoogleSearchDataRowTest_2")]
    [DataRow("Selenium Grid", DisplayName = "GoogleSearchDataRowTest_3")]
    public void GoogleSearchDataRowTest(string search)
    {
        var googleSearchPage = GetPage<GoogleSearchPage>(TestMethod);
        TestManager.TestContext.WriteLine($"Test DataRow Google search for {search}");

        googleSearchPage
            .Open()
            .AddSearchText(search)
            .ClickSearchBox()
            .ClickSearchButton();

        Assert.IsNotNull(ConfigurationReader);
    }
}