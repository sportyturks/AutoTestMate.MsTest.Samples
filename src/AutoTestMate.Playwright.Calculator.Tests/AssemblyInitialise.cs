using AutoTestMate.MsTest.Playwright.Core;
using Castle.MicroKernel.Registration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Playwright.Calculator.Tests
{
    [TestClass]
    public class AssemblyInitialise
    {
        [AssemblyInitialize]
        public static void Initialise(TestContext testContext)
        {
            PlaywrightTestManager.Instance.OnInitialiseAssemblyDependencies(testContext);
            PlaywrightTestManager.Instance.Container.Register(Classes
                .FromAssemblyNamed($"AutoTestMate.Playwright.Calculator.Models.dll").BasedOn(typeof(PlaywrightBasePage)).LifestyleTransient());
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            PlaywrightTestManager.Instance.OnDisposeAssemblyDependencies();
        }
    }
}
