using AutoTestMate.MsTest.Infrastructure.Core.MethodManager;
using AutoTestMate.MsTest.Playwright.Constants;
using AutoTestMate.MsTest.Playwright.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Playwright.Samples.Web.Models
{
    public class GoogleSearchPageContainer : PlaywrightBasePageContainer, IGoogleSearchPageContainer
    {
        public GoogleSearchPageContainer(ITestMethodManager testMethodManager, TestContext testContext) : base(testMethodManager, testContext)
        {
        }
        public IWebElement SearchTextBox => Driver.FindElement(By.XPath("//div//input[@title='Search']"));

        public IWebElement ResultSearchButton => Driver.FindElement(By.XPath("//button[@aria-label='Google Search']"));

        public IWebElement SearchButton => Driver.FindElement(By.XPath("//div//input[@value='Google Search']"));

        public GoogleSearchPageContainer Open()
        {
            Driver.Navigate().GoToUrl(ConfigurationReader.GetConfigurationValue(MsTest.Web.Constants.Configuration.BaseUrlKey));
            return this;
        }

        public GoogleSearchPageContainer AddSearchText(string text)
        {
            SearchTextBox.VisibleWait();
            SearchTextBox.Click();
            SearchTextBox.SendKeys(text);

            return this;
        }

        public GoogleSearchPageContainer ClickSearchBox()
        {
            SearchTextBox.VisibleWait();
            SearchTextBox.Click();

            return this;
        }

        public GoogleSearchPageContainer ClickSearchButton()
        {
            SearchButton.VisibleWait();
            SearchButton.Click();

            return this;
        }
        public void GoogleSearchPageAssertions()
        {

        }
    }
}
