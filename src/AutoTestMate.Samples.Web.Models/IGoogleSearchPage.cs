using OpenQA.Selenium;

namespace AutoTestMate.Samples.Web.Models
{
    public interface IGoogleSearchPage
    {
        IWebElement SearchTextBox { get; }
        IWebElement ResultSearchButton { get; }
        IWebElement SearchButton { get; }
        GoogleSearchPage Open();
        GoogleSearchPage AddSearchText(string text);
        GoogleSearchPage ClickSearchButton();
        void GoogleSearchPageAssertions();
    }

    public interface IGoogleSearchPageContainer
    {
        IWebElement SearchTextBox { get; }
        IWebElement ResultSearchButton { get; }
        IWebElement SearchButton { get; }
        GoogleSearchPageContainer Open();
        GoogleSearchPageContainer AddSearchText(string text);
        GoogleSearchPageContainer ClickSearchButton();
        void GoogleSearchPageAssertions();
    }
}