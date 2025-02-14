using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoTestMate.MsTest.Playwright.Core;
using Microsoft.Playwright;


namespace AutoTestMate.Playwright.Calculator.Models
{
    public class HomePage : PlaywrightBasePage
    {
        public HomePage([CallerMemberName] string testName = null) : base(testName)
        {
        }
        private IPage _page => PlaywrightDriver.Page;

        public async Task<HomePage> Open()
        {
            await _page.GotoAsync(ConfigurationReader.GetConfigurationValue("CalculatorHomePageUrl")).ConfigureAwait(false);
            return this;
        }
    }
}
