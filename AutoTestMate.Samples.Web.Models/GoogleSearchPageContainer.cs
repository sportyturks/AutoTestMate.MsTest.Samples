using AutoTestMate.MsTest.Infrastructure.Core.MethodManager;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.MsTest.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutoTestMate.Samples.Web.Models
{
    public class GoogleSearchPageContainer : BasePageContainer, IGoogleSearchPageContainer
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
