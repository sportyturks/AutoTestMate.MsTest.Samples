using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutoTestMate.Calculator.Models
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
        IDictionary<string, IWebElement> Ops { get; }
        CalculatorPage Open();
        void Calculate(string ops);
        void AssertValue(double expected);
    }
}