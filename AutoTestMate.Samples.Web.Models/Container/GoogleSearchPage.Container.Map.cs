using OpenQA.Selenium;

namespace AutoTestMate.Samples.Web.Models
{
    public partial class GoogleSearchPageContainer
    {
	    public IWebElement SearchTextBox => Driver.FindElement(By.XPath("//div//input[@title='Search']"));

	    public IWebElement ResultSearchButton => Driver.FindElement(By.XPath("//button[@aria-label='Google Search']"));

	    public IWebElement SearchButton => Driver.FindElement(By.XPath("//div//input[@value='Google Search']"));
    }
}
