using OpenQA.Selenium;

namespace AutoTestMate.Samples.Web.Models
{
    public interface IGoogleSearchPageContainer
    {
        IWebElement SearchTextBox { get; }
        IWebElement ResultSearchButton { get; }
        IWebElement SearchButton { get; }
        GoogleSearchPage Open();
        GoogleSearchPage AddSearchText(string text);
        GoogleSearchPage ClickSearchButton();
        void GoogleSearchPageAssertions();
    }
}