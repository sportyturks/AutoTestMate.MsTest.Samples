using AutoTestMate.MsTest.Infrastructure.Core;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.MsTest.Web.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AutoTestMate.Calculator.Models
{
    public partial class CalculatorPage : BasePage, ICalculatorPage
    {

        private uint timeout = 10;
       
        public CalculatorPage([CallerMemberName] string testName = null) : base(testName)
        {
            timeout = uint.Parse(ConfigurationReader.Settings["Timeout"]);
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
        public void Calculate(string ops)
        {
            var opKeys = ops.Split(",");
            foreach (var opKey in opKeys)
            {
                Ops[opKey].Click();
            }
            ResultBtn.VisibleWait();
            ResultBtn.Click();
            WaitForReady(timeout);
        }

        public void WaitForReady(uint waitSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitSeconds));
            wait.Until(driver =>
            {
                bool isSpinnerHidden = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return isSpinnerHidden()");
                return isSpinnerHidden;
            });
        }

    }
}
