using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoTestMate.MsTest.Playwright.Constants;
using AutoTestMate.MsTest.Playwright.Core;
using AutoTestMate.MsTest.Playwright.Core.Attributes;
using Microsoft.Playwright;

namespace AutoTestMate.Playwright.Samples.Web.Models
{
    public partial class GoogleSearchPage : PlaywrightBasePage
    {
        private IPage _page => PlaywrightDriver.CurrentPage;
        public GoogleSearchPage([CallerMemberName] string testName = null) : base(testName)
        {
        }

        [Retry(Amount = 3, Interval = 200)]
        public virtual async Task<GoogleSearchPage> Open()
        {
            await _page.GotoAsync(ConfigurationReader.GetConfigurationValue("BaseUrl")).ConfigureAwait(false);
            return this;
        }

        public virtual async Task<GoogleSearchPage> AddSearchText(string text)
        {
            await SearchTextBox.WaitForAsync().ConfigureAwait(false);
            await SearchTextBox.ClickAsync().ConfigureAwait(false);
            await SearchTextBox.TypeAsync(text).ConfigureAwait(false);
            return this;
        }

        public virtual async Task<GoogleSearchPage> ClickSearchBox()
        {
            await SearchTextBox.WaitForAsync().ConfigureAwait(false);
            await SearchTextBox.ClickAsync().ConfigureAwait(false);

            return this;
        }

        public virtual async Task<GoogleSearchPage> ClickSearchButton()
        {
            await SearchButton.WaitForAsync().ConfigureAwait(false);
            await SearchButton.ClickAsync().ConfigureAwait(false);

            return this;
        }
    }
}
