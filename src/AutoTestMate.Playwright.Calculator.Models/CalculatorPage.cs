using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoTestMate.MsTest.Infrastructure.Helpers;
using AutoTestMate.MsTest.Playwright.Constants;
using AutoTestMate.MsTest.Playwright.Core;
using AutoTestMate.MsTest.Playwright.Core;
using AutoTestMate.MsTest.Playwright.Core.Attributes;
using AutoTestMate.MsTest.Playwright.Extensions;
using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTestMate.Playwright.Calculator.Models
{
    public class CalculatorPage : PlaywrightBasePage
    {
        public const string CalculatorSelector = "body > div > main > div > h1";
        public const string ResultId = "txtResult";
        public const string AddId = "add";
        public const string SubId = "sub";
        public const string MulId = "mul";

        public const string DivId = "div";
        public const string ObId = "ob"; // open bracket button
        public const string CbId = "cb"; // closed bracket button
        public const string ResultBtnId = "result";
        private IPage _page => PlaywrightDriver.CurrentPage;

        public void LoadOperations()
        {
            for (var i = 0; i < 10; i++)
            {
                NumButtons.Add(_page.Locator($"[id='{i}']")); // Assuming button IDs are in the format "btn0", "btn1", etc.
            }

            Ops = new Dictionary<string, ILocator>()
            {
                { "+", Add },
                { "-", Sub },
                { "*", Mul },
                { "/", Div },
                { "(", _page.Locator($"[id='ob']") },
                { ")", _page.Locator($"[id='cb']")  }
            };

            for (var i = 0; i < 10; i++)
            {
                Ops.Add(i.ToString(), NumButtons[i]);
            }
        }

        public IElementHandle Calculator => AsyncHelper.RunSync(() =>  _page.QuerySelectorAsync($"{CalculatorSelector}"));
        public ILocator Result => _page.Locator($"[id='{ResultId}']");
        public List<ILocator> NumButtons { get; private set; }
        public ILocator  Add => _page.Locator($"[id='{AddId}']");
        public ILocator  Sub => _page.Locator($"[id='{SubId}']");
        public ILocator  Mul => _page.Locator($"[id='{MulId}']");
        public ILocator  Div => _page.Locator($"[id='{DivId}']");
        public ILocator  Ob => _page.Locator($"[id='{ObId}']");
        public ILocator  Cb => _page.Locator($"[id='{CbId}']");
        public ILocator  ResultBtn => _page.Locator($"[id='{ResultBtnId}']");
        public ILocator  Clr => _page.Locator($"[id='clr']");
        public ILocator  Zero => _page.Locator($"[id='0']");
        public ILocator  One => _page.Locator($"[id='1']");
        public ILocator  Two => _page.Locator($"[id='2']");
        public ILocator  Three => _page.Locator($"[id='3']");
        public ILocator  Four => _page.Locator($"[id='4']");
        public ILocator  Five => _page.Locator($"[id='5']");
        public ILocator  Six => _page.Locator($"[id='6']");
        public ILocator  Seven => _page.Locator($"[id='7']");
        public ILocator  Eight => _page.Locator($"[id='8']");
        public ILocator Nine => _page.Locator($"[id='9']");
        public IDictionary<string, ILocator> Ops { get; private set; } = new Dictionary<string, ILocator>();

        public CalculatorPage([CallerMemberName] string testName = null) : base(testName)
        {
            NumButtons = [];
        }

        public CalculatorPage Open()
        {
            AsyncHelper.RunSync(() => _page.GotoAsync(ConfigurationReader.GetConfigurationValue("CalculatorHomePageUrl")));
            LoadOperations();
            return this;
        }

        /// <summary>
        /// Calculates an arithmetic operation based on a comma-separated list of operands and operators
        /// </summary>
        /// <param name="ops">A comma-separated list of operands and operators which form the expression. Example: 2,+,2 for 2 + 2</param>
        public virtual CalculatorPage Calculate(string ops)
        {
            var opKeys = ops.Split(",");
            foreach (var opKey in opKeys)
            {
                AsyncHelper.RunSync(() => Ops[opKey].ClickAsync());
            }
            AsyncHelper.RunSync(() => ResultBtn.ClickAsync());

            //WaitForReady(8);
            return this;
        }

        public virtual CalculatorPage WaitForReady(int waitSeconds)
        {
            AsyncHelper.RunSync(() => Task.Delay(waitSeconds * 1000));
            
            return this;
        }

        [Retry(Amount = 3, Interval = 200)]
        public virtual CalculatorPage Clear()
        {
            AsyncHelper.RunSync(() => Clr.ClickAsync());
            return this;
        }
        
        public virtual CalculatorPage AssertValue(double expected)
        {
            var value = AsyncHelper.RunSync(() => Result.InputValueAsync());
            Assert.AreEqual(expected.ToString(CultureInfo.InvariantCulture), value);
            
            return this;
        }

    }
}
