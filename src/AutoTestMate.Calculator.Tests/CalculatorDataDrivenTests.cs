using System.Collections.Generic;
using System.Reflection;
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

    [TestMethod]
    [DynamicData(nameof(GetDynamicData), DynamicDataSourceType.Method)]
    public void CalculateDynamicDataTest(string ops, double expected, string _)
    {

        LoggingUtility.Info($"Operation: {ops.Replace(",", " ")} = {expected}", true);

        var calcPage = GetPage<CalculatorPage>(TestMethod)
            .Open()
            .Calculate(ops)
            .AssertValue(expected);
    }
    
    [TestMethod]
    [DynamicData(nameof(GetDynamicData2), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetTestDisplayNames))]
    public void CalculateDynamicDataSpecificNameTest(string testName, string ops, double expected)
    {

        LoggingUtility.Info($"Operation: {ops.Replace(",", " ")} = {expected}", true);

        var calcPage = GetPage<CalculatorPage>(TestMethod)
            .Open()
            .Calculate(ops)
            .AssertValue(expected);
    }

    public static IEnumerable<object[]> GetDynamicData()
    {
        return new[]
        {
            new object[] { "1,+,1", 2, "TC_Calc_1" },
            new object[] { "1,3,-,4", 9, "TC_Calc_2" },
            new object[] { "2,*,3", 6, "TC_Calc_3" },
            new object[] { "1,0,0,/,2,5", 4, "TC_Calc_4" },
            new object[] { "1,+,2,*,(,4,-,6,)", -3, "TC_Calc_5" },
            new object[] { "4,*,(,3,-,4,/,2,)", 4, "TC_Calc_6" }
        };
    }
    public static IEnumerable<object[]> GetDynamicData2()
    {
        return new[]
        {
            new object[] { "TC_Calc_1", "1,+,1", 2 },
            new object[] { "TC_Calc_2", "1,3,-,4", 9,},
            new object[] { "TC_Calc_3", "2,*,3", 6},
            new object[] { "TC_Calc_4", "1,0,0,/,2,5", 4 },
            new object[] { "TC_Calc_5", "1,+,2,*,(,4,-,6,)", -3 },
            new object[] { "TC_Calc_6", "4,*,(,3,-,4,/,2,)", 4 }
        };
    }
    public static string GetTestDisplayNames(MethodInfo methodInfo, object[] values)
    {
        var name = (string)values[0];
        return $"{methodInfo.Name}({name})";
    }
}