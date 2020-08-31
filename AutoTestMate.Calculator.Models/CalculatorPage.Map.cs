using AutoTestMate.MsTest.Web.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace AutoTestMate.Calculator.Models
{
    public partial class CalculatorPage
    {
        public const string CalculatorSelector = "body > div > main > div > h1";
        public const string ResultId = "txtResult";
        public const string AddId = "add";
        public const string SubId = "sub";
        public const string MulId = "mul";
        public const string DivId = "div";
        public const string ObId = "ob"; // open bracket button
        public const string CbId = "cb"; // closed bracket button
        public const string ResultBtnId = "result";

        public void LoadOperations()
        {
            this.NumButtons = new List<IWebElement>();
            for (var i = 0; i < 10; i++)
            {
                NumButtons.Add(Driver.FindElement(By.Id(i.ToString())));
            }
            Ops = new Dictionary<string, IWebElement>() { { "+", Add }, { "-", Sub }, { "*", Mul }, { "/", Div }, { "(", Ob }, { ")", Cb } };
            for (var i = 0; i < 10; i++)
            {
                Ops.Add(i.ToString(), NumButtons[i]);
            }
        }

        public IWebElement Calculator => Driver.FindElement(By.CssSelector(CalculatorSelector));
        public IWebElement Result => Driver.FindElement(By.Id(ResultId));
        public List<IWebElement> NumButtons { get; private set; }
        public IWebElement Add => Driver.FindElement(By.Id(AddId));
        public IWebElement Sub => Driver.FindElement(By.Id(SubId));
        public IWebElement Mul => Driver.FindElement(By.Id(MulId));
        public IWebElement Div => Driver.FindElement(By.Id(DivId));
        public IWebElement Ob => Driver.FindElement(By.Id(ObId));
        public IWebElement Cb => Driver.FindElement(By.Id(CbId));
        public IWebElement ResultBtn => Driver.FindElement(By.Id(ResultBtnId));

        public IDictionary<string, IWebElement> Ops { get; private set; } = new Dictionary<string, IWebElement>();
    }
}
