using AutoTestMate.Calculator.Models;
using AutoTestMate.MsTest.Web.Core;
using AutoTestMate.MsTest.Web.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Calculator.Tests;

[TestClass]
public class CalculatorDataDrivenTests : WebTestBase
{
    public override string TestMethod => ReflectionExtensions.GetPropValue<string>(TestContext, "Context.testMethod.DisplayName");

    [TestMethod]
    [DataRow("1,+,1", 2, DisplayName = "CalculateDataRowTest_1")]
    [DataRow("1,3,-,4", 9, DisplayName = "CalculateDataRowTest_2")]
    [DataRow("2,*,3", 6, DisplayName = "CalculateDataRowTest_3")]
    [DataRow("1,0,0,/,2,5", 4, DisplayName = "CalculateDataRowTest_4")]
    [DataRow("1,+,2,*,(,4,-,6,)", -3, DisplayName = "CalculateDataRowTest_5")]
    [DataRow("4,*,(,3,-,4,/,2,)", 4, DisplayName = "CalculateDataRowTest_6")]
    public void CalculateDataRowTest(string ops, double expected)
    {

        LoggingUtility.Info($"Operation: {ops.Replace(",", " ")} = {expected}", true);

        var calcPage = GetPage<CalculatorPage>(TestMethod)
            .Open()
            .Calculate(ops)
            .AssertValue(expected);
    }
}