using System.Runtime.CompilerServices;
using AutoTestMate.MsTest.Playwright.Constants;
using AutoTestMate.MsTest.Playwright.Core;
using AutoTestMate.MsTest.Playwright.Core.Attributes;

namespace AutoTestMate.Playwright.Samples.Web.Models
{
    public partial class GoogleSearchPage : PlaywrightBasePage, IGoogleSearchPage
    {
        public GoogleSearchPage([CallerMemberName] string testName = null) : base(testName)
        {
        }

        [Retry(Amount = 3, Interval = 200)]
        public virtual GoogleSearchPage Open()
        {
            Driver.Navigate().GoToUrl(ConfigurationReader.GetConfigurationValue(MsTest.Web.Constants.Configuration.BaseUrlKey));
            return this;
        }

        public GoogleSearchPage AddSearchText(string text)
        {
            SearchTextBox.VisibleWait();
            SearchTextBox.Click();
            SearchTextBox.SendKeys(text);

            return this;
        }

        public GoogleSearchPage ClickSearchBox()
        {
            SearchTextBox.VisibleWait();
            SearchTextBox.Click();

            return this;
        }

        public GoogleSearchPage ClickSearchButton()
        {
            SearchButton.VisibleWait();
            SearchButton.Click();

            return this;
        }
    }
}
