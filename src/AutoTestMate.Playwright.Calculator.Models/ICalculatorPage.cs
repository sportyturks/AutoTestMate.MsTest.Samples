using System.Collections.Generic;
using OpenQA.Selenium;

namespace AutoTestMate.Playwright.Calculator.Models
{
    public interface ICalculatorPage
    {
        IWebElement Calculator { get; }
        IWebElement Result { get; }
        IWebElement Add { get; }
        IWebElement Sub { get; }
        IWebElement Mul { get; }
        IWebElement Div { get; }
        IWebElement Ob { get; }
        IWebElement Cb { get; }
        IWebElement ResultBtn { get; }
        IWebElement Clr { get; }
        IDictionary<string, IWebElement> Ops { get; }
        CalculatorPage Open();
        CalculatorPage Calculate(string ops);
        CalculatorPage AssertValue(double expected);
        CalculatorPage Clear();
    }
}