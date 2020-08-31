using AutoTestMate.MsTest.Infrastructure.Core;
using AutoTestMate.MsTest.Web.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AutoTestMate.Calculator.Models
{
    public partial class HomePage : BasePage, IHomePage
    {

        private uint timeout = 10;

        public HomePage([CallerMemberName] string testName = null) : base(testName)
        {
            timeout = uint.Parse(ConfigurationReader.Settings["Timeout"]);
        }

        public HomePage Open()
        {
            Driver.Navigate().GoToUrl(ConfigurationReader.GetConfigurationValue("CalculatorHomePageUrl"));
            return this;
        }

    }
}
