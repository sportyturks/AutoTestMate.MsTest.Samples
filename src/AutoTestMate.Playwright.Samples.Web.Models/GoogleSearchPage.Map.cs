
using AutoTestMate.MsTest.Playwright.Constants;
using Microsoft.Playwright;

namespace AutoTestMate.Playwright.Samples.Web.Models
{
    public partial class GoogleSearchPage
    {
	    public ILocator SearchTextBox => _page.Locator("//textarea[@name='q']").First;
	    public ILocator ResultSearchButton => _page.Locator("//button[@aria-label='Google Search']");
	    public ILocator SearchButton => _page.Locator("//div//input[@value='Google Search']").First;
    }
}
