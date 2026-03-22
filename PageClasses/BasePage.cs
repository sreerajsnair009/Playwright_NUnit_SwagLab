using Microsoft.Playwright;
using PlaywrightDemo1.EnvironmentFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.PageClasses
{
    public abstract class BasePage
    {
        protected readonly IPage page;
        private ILocator HeaderElement => page.Locator("xpath=//div[@data-test='secondary-header']/span");

        public BasePage(IPage page)
        {
            this.page = page;
        }

        public abstract ILocator ReadyLocator { get; }
        public abstract string Title { get; }
        
        public virtual async Task WaitForPageLoadAsync(int timeOutInMillisec = 30000)
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await ReadyLocator.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = timeOutInMillisec
            });
            string? actualPageTitle = await HeaderElement.TextContentAsync();
            if(actualPageTitle == Title)
            {
                TestLogger.Pass($"{Title} page loaded successfully...");
            }
            else
            {
                TestLogger.Fail($"Failed to load the page. Actual page title: {actualPageTitle}. Expected: '{Title}'");
            }
        }
    }
}
