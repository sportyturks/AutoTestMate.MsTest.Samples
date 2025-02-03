using System.Runtime.CompilerServices;
using AutoTestMate.MsTest.Playwright.Core;
using OpenQA.Selenium;

namespace AutoTestMate.Playwright.Calculator.Models
{
    public class HomePage : PlaywrightBase
    {

        public const string WelcomeSelector = "body > div > main > div > h1";
        public const string HomeMenuXPath = "/html/body/header/nav/div/div/ul/li[1]/a";
        public const string CalculatorMenuXPath = "/html/body/header/nav/div/div/ul/li[2]/a";
        public const string PrivacyMenuXPath = "/html/body/header/nav/div/div/ul/li[3]/a";


        public IWebElement Welcome => Driver.FindElement(By.CssSelector(WelcomeSelector));
        public IWebElement HomeMenu => Driver.FindElement(By.XPath(HomeMenuXPath));
        public IWebElement CalculatorMenu => Driver.FindElement(By.XPath(CalculatorMenuXPath));
        public IWebElement PrivacyMenu => Driver.FindElement(By.XPath(PrivacyMenuXPath));

        public HomePage([CallerMemberName] string testName = null) : base(testName)
        {
        }

        public HomePage Open()
        {
            Driver.Navigate().GoToUrl(ConfigurationReader.GetConfigurationValue("CalculatorHomePageUrl"));
            return this;
        }
    }
}
