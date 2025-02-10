using System.Threading.Tasks;
using AutoTestMate.MsTest.Playwright.Core;
using AutoTestMate.MsTest.Playwright.Extensions;
using AutoTestMate.Playwright.Samples.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AutoTestMate.Playwright.Samples.Web.Tests;

[TestClass]
public class SampleDataDrivenTests : PlaywrightTestBase
{
    public override string TestMethod => ReflectionExtensions.GetPropValue<string>(TestContext, "Context._testMethod.DisplayName");
    
    [RetryTestMethod(numberOfAttempts: 3)]
    [DataRow("Latest News", DisplayName = "GoogleSearchDataRowTest_1")]
    [DataRow("Automation Testing", DisplayName = "GoogleSearchDataRowTest_2")]
    [DataRow("Selenium Grid", DisplayName = "GoogleSearchDataRowTest_3")]
    public async Task GoogleSearchDataRowTest(string search)
    {
        var googleSearchPage = GetPage<GoogleSearchPage>(TestMethod);
        TestManager.TestContext.WriteLine($"Test DataRow Google search for {search}");

        await googleSearchPage.Open().ConfigureAwait(false);
        await googleSearchPage.AddSearchText(search).ConfigureAwait(false);
        await googleSearchPage.ClickSearchBox().ConfigureAwait(false);
        await googleSearchPage.ClickSearchButton().ConfigureAwait(false);

        Assert.IsNotNull(ConfigurationReader);
    }
}