using OpenQA.Selenium;

namespace AutoTestMate.Playwright.Calculator.Models
{
    public interface IHomePage
    {
        IWebElement Welcome { get; }
        IWebElement HomeMenu { get; }
        IWebElement CalculatorMenu { get; }
        IWebElement PrivacyMenu { get; }
        HomePage Open();
    }
}