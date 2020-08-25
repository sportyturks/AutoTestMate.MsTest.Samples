using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.MsTest.Web.Core.MethodManager;

namespace AutoTestMate.Samples.Web.Models
{
    public partial class GoogleSearchPageContainer : BasePageContainer, IGoogleSearchPageContainer
    {
        public GoogleSearchPageContainer(IWebTestMethodManager webTestMethodManager) : base(webTestMethodManager)
        {
        }

        public GoogleSearchPage Open()
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