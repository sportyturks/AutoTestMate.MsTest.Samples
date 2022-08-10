using AutoTestMate.MsTest.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoTestMate.Calculator.Models
{
    public partial class CalculatorPage
    {
        public CalculatorPage AssertValue(double expected)
        {
            Result.VisibleWait();
            var value = Result.GetAttribute("value");
            Assert.AreEqual(expected.ToString(), value);
            
            return this;
        }
    }
}
