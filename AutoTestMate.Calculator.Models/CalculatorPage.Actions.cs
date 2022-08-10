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
using OpenQA.Selenium.DevTools.V101.DOM;

namespace AutoTestMate.Calculator.Models
{
    public partial class CalculatorPage : BasePage, ICalculatorPage
    {
        private readonly uint _timeout;

        public CalculatorPage([CallerMemberName] string testName = null) : base(testName)
        {
            _timeout = uint.Parse(ConfigurationReader.Settings["Timeout"]);
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
        public CalculatorPage Calculate(string ops)
        {
            var opKeys = ops.Split(",");
            foreach (var opKey in opKeys)
            {
                Ops[opKey].Click();
            }
            ResultBtn.VisibleWait();
            ResultBtn.Click();
            WaitForReady(_timeout);
            return this;
        }

        public CalculatorPage WaitForReady(uint waitSeconds)
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

        public CalculatorPage Clear()
        {
            Clr.VisibleWait();
            Clr.Click();
            return this;
        }

    }
}
