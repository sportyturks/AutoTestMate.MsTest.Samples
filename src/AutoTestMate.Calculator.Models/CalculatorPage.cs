using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.MsTest.Web.Core.Attributes;
using AutoTestMate.MsTest.Web.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Calculator.Models
{
    public class CalculatorPage : BasePage
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

        public virtual void LoadOperations()
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
        public IWebElement Clr => Driver.FindElement(By.Id("clr"));
        public IWebElement Zero => Driver.FindElement(By.Id("0"));
        public IWebElement One => Driver.FindElement(By.Id("1"));
        public IWebElement Two => Driver.FindElement(By.Id("2"));
        public IWebElement Three => Driver.FindElement(By.Id("3"));
        public IWebElement Four => Driver.FindElement(By.Id("4"));
        public IWebElement Five => Driver.FindElement(By.Id("5"));
        public IWebElement Six => Driver.FindElement(By.Id("6"));
        public IWebElement Seven => Driver.FindElement(By.Id("7"));
        public IWebElement Eight => Driver.FindElement(By.Id("8"));
        public IWebElement Nine => Driver.FindElement(By.Id("9"));
        public IDictionary<string, IWebElement> Ops { get; private set; } = new Dictionary<string, IWebElement>();

        public CalculatorPage([CallerMemberName] string testName = null) : base(testName)
        {
        }

        public CalculatorPage Open()
        {
            Driver.Navigate().GoToUrl($"{ConfigurationReader.GetConfigurationValue("CalculatorHomePageUrl")}");
            LoadOperations();
            return this;
        }

        /// <summary>
        /// Calculates an arithmetic operation based on a comma-separated list of operands and operators
        /// </summary>
        /// <param name="ops">A comma-separated list of operands and operators which form the expression. Example: 2,+,2 for 2 + 2</param>
        public virtual CalculatorPage Calculate(string ops)
        {
            var opKeys = ops.Split(",");
            foreach (var opKey in opKeys)
            {
                Ops[opKey].Click();
            }
            ResultBtn.VisibleWait();
            ResultBtn.Click();
            WaitForReady(8);
            return this;
        }

        public virtual CalculatorPage WaitForReady(uint waitSeconds)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitSeconds));
            try
            {
                wait.Until(driver =>
                {
                    if (driver == null)
                    {
                        return false;
                    }
                    
                    var isSpinnerHidden = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementById(\"spinner\") == null;");
                    
                    return isSpinnerHidden;
                });
            }
            catch
            {
                //do nothing and continue test
            }

            return this;
        }

        [Retry(Amount = 3, Interval = 200)]
        public virtual CalculatorPage Clear()
        {
            Clr.VisibleWait();
            Clr.Click();
            return this;
        }
        
        public virtual CalculatorPage AssertValue(double expected)
        {
            Result.VisibleWait();
            var value = Result.GetAttribute("value");
            Assert.AreEqual(expected.ToString(), value);
            
            return this;
        }

    }
}
