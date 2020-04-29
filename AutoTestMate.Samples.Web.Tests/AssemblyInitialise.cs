using AutoTestMate.MsTest.Web.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Samples.Web.Tests
{
    [TestClass]
    public class AssemblyInitialise
    {
        [AssemblyInitialize]
        public static void Initialise(TestContext testContext)
        {
            WebTestManager.Instance().OnInitialiseAssemblyDependencies(testContext);
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            WebTestManager.Instance().OnDisposeAssemblyDependencies();
        }
    }
}
