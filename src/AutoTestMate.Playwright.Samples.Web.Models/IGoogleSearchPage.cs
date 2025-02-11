
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutoTestMate.Playwright.Samples.Web.Models
{
    public interface IGoogleSearchPage
    {
        ILocator SearchTextBox { get; }
        ILocator ResultSearchButton { get; }
        ILocator SearchButton { get; }
        Task<GoogleSearchPage> Open();
        Task<GoogleSearchPage> AddSearchText(string text);
        Task<GoogleSearchPage> ClickSearchButton();
        Task GoogleSearchPageAssertions();
    }
}