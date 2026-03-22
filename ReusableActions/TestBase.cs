using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightDemo1.EnvironmentFunctions;
using PlaywrightDemo1.PageClasses;
using PlaywrightDemo1.Variables;
using System.Threading.Tasks;

[assembly: Parallelizable(ParallelScope.All)]
[assembly: LevelOfParallelism(5)]

namespace PlaywrightDemo1.ReusableActions
{
    public abstract class TestBase
    {
        protected IPlaywright playwright;
        protected IBrowser browser;
        protected IBrowserContext browserContext;
        protected IPage page;
        protected AppSettings AppSettings { get; private set; }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            AppSettings = EnvironmentHandler.LoadAppSettings();
        }


        [SetUp]
        public async Task Setup()
        {
            playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            browserContext = await browser.NewContextAsync();
            page = await browserContext.NewPageAsync();
            
        }

        [TearDown]
        public async Task TearDown()
        {
            
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            //if (page != null) await page.CloseAsync();
            //if (browserContext != null) await browserContext.CloseAsync();
            //if (browser != null) await browser.CloseAsync();
            //playwright?.Dispose();
        }
    }
}
