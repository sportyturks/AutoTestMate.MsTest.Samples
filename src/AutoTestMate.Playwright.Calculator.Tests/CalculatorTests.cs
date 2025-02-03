using System.Collections.Generic;
using AutoTestMate.Playwright.Calculator.Models;
using AutoTestMate.MsTest.Playwright.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Playwright.Calculator.Tests
{
    [TestClass]
    public class CalculatorTests : PlaywrightTestBase
    {
        [RetryTestMethod(numberOfAttempts: 3)]
        [DataRow("4,*,(,3,-,4,/,2,)", 4)]
        public void CalculateDataRowTestSingle(string ops, double expected)
        {
            LoggingUtility.Info($"Operation: {ops.Replace(",", " ")} = {expected}", true);
            
            var calcPage = GetPage<CalculatorPage>()
                .Open()
                .Calculate(ops)
                .AssertValue(expected);
        }
        
        [RetryTestMethod(numberOfAttempts: 3)]
        public void CalculateDataRowTestGroup()
        {
            const int testIterations = 4;
            var calcPage = GetPage<CalculatorPage>()
                .Open();

            var operations = new Dictionary<string, double>()
            {
                { "1,+,1", 2 },
                { "1,3,-,4", 9 },
                { "2,*,3", 6 },
                { "1,0,0,/,2,5", 4 },
                { "1,+,2,*,(,4,-,6,)", -3 },
                { "4,*,(,3,-,4,/,2,)", 4 },
            };
            
            for (var i = 0; i < testIterations; i++)
            {
                foreach (var operation in operations)
                {
                    LoggingUtility.Info($"Operation: {operation.Key.Replace(",", " ")} = {operation.Value}", true);

                    calcPage
                        .Calculate(operation.Key)
                        .Clear()
                        .AssertValue(operation.Value);
                }
            }
        }
    }
}
