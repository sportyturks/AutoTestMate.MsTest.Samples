using AutoTestMate.Calculator.Models;
using AutoTestMate.MsTest.Infrastructure.Core;
using AutoTestMate.MsTest.Web.Core;
using Castle.MicroKernel.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Calculator.Tests
{
    [TestClass]
    public class CalculatorTests : WebTestBase
    {
        public ICalculatorPage CalculatorPage => TestManager.Container.Resolve<ICalculatorPage>();

        [TestInitialize]
        public override void OnTestInitialise()
        {
            base.OnTestInitialise();

            TestManager.Container.Register(Component.For<ICalculatorPage>().ImplementedBy<CalculatorPage>().OverridesExistingRegistration().LifestyleTransient());
        }

        [TestMethod]
        [DataRow("1,+,1", 2)]
        [DataRow("1,3,-,4", 9)]
        [DataRow("2,*,3", 6)]
        [DataRow("1,0,0,/,2,5", 4)]
        [DataRow("1,+,2,*,(,4,-,6,)", -3)]
        [DataRow("4,*,(,3,-,4,/,2,)", 4)]
        public void CalculateDataRowTest(string ops, double expected)
        {
            var calcPage = new CalculatorPage();
            TestManager.TestContext.WriteLine($"Operation: {ops.Replace(",", " ")} = {expected}");

            calcPage
                .Open()
                .Calculate(ops);

            calcPage.AssertValue(expected);
        }
    }
}
