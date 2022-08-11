using System.Collections.Generic;
using AutoTestMate.Calculator.Models;
using AutoTestMate.MsTest.Infrastructure.Core;
using AutoTestMate.MsTest.Infrastructure.Helpers;
using AutoTestMate.MsTest.Web.Core;
using Castle.MicroKernel.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Calculator.Tests
{
    [TestClass]
    public class CalculatorTests : WebTestBase
    {
        public ICalculatorPage CalculatorPage => TestManager.Container.Resolve<ICalculatorPage>();
        
        [TestMethod]
        [DataRow("1,+,1", 2)]
        [DataRow("1,3,-,4", 9)]
        [DataRow("2,*,3", 6)]
        [DataRow("1,0,0,/,2,5", 4)]
        [DataRow("1,+,2,*,(,4,-,6,)", -3)]
        [DataRow("4,*,(,3,-,4,/,2,)", 4)]
        public void CalculateDataRowTest(string ops, double expected)
        {
            TestManager.TestContext.WriteLine($"Operation: {ops.Replace(",", " ")} = {expected}");
            
            var calcPage = GetPage<CalculatorPage>()
                .Open()
                .Calculate(ops)
                .AssertValue(expected);
        }
        
        [TestMethod]
        [DataRow("4,*,(,3,-,4,/,2,)", 4)]
        public void CalculateDataRowTestSingle(string ops, double expected)
        {
            TestManager.TestContext.WriteLine($"Operation: {ops.Replace(",", " ")} = {expected}");
            
            var calcPage = GetPage<CalculatorPage>()
                .Open()
                .Calculate(ops)
                .AssertValue(expected);
        }
        
        [TestMethod]
        public void CalculateDataRowTestGroup()
        {
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

            foreach (var operation in operations)
            {
                TestManager.TestContext.WriteLine($"Operation: {operation.Key.Replace(",", " ")} = {operation.Value}");
                
                calcPage
                    .Calculate(operation.Key)
                    .Clear()
                    .AssertValue(operation.Value);
            }
        }
    }
}
