using System.Collections.Generic;
using Microsoft.Playwright;

namespace AutoTestMate.Playwright.Calculator.Models
{
    public interface ICalculatorPage
    {
        IElementHandle Calculator { get; }
        ILocator Result { get; }
        ILocator Add { get; }
        ILocator Sub { get; }
        ILocator Mul { get; }
        ILocator Div { get; }
        ILocator Ob { get; }
        ILocator Cb { get; }
        ILocator ResultBtn { get; }
        ILocator Clr { get; }
        IDictionary<string, ILocator> Ops { get; }
        CalculatorPage Open();
        CalculatorPage Calculate(string ops);
        CalculatorPage AssertValue(double expected);
        CalculatorPage Clear();
    }
}