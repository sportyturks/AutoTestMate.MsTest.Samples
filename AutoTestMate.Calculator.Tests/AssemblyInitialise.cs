using AutoTestMate.MsTest.Web.Core;
using Castle.MicroKernel.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Calculator.Tests
{
    [TestClass]
    public class AssemblyInitialise
    {
        [AssemblyInitialize]
        public static void Initialise(TestContext testContext)
        {
            WebTestManager.Instance().OnInitialiseAssemblyDependencies(testContext);
            WebTestManager.Instance().Container.Register(Classes.FromAssemblyNamed($"AutoTestMate.Calculator.Models.dll").BasedOn(typeof(BasePage)).LifestyleTransient());
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            WebTestManager.Instance().OnDisposeAssemblyDependencies();
        }
    }
}
