
namespace AutoTestMate.Playwright.Samples.Web.Models
{
    public partial class GoogleSearchPage
    {
	    public IWebElement SearchTextBox => Driver.FindElement(By.XPath("//textarea[@name='q']"));

	    public IWebElement ResultSearchButton => Driver.FindElement(By.XPath("//button[@aria-label='Google Search']"));

	    public IWebElement SearchButton => Driver.FindElement(By.XPath("//div//input[@value='Google Search']"));
    }
}
