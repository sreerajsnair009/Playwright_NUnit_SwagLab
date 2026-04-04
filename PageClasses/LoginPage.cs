using Microsoft.Playwright;
using PlaywrightDemo1.EnvironmentFunctions;
using PlaywrightDemo1.Variables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.PageClasses
{
    public class LoginPage : BasePage
    {
        public LoginPage(IPage page) : base(page) { }
       
        private ILocator Username => page.Locator("#user-name");
        private ILocator Password => page.Locator("#password");
        private ILocator LoginButton => page.Locator("#login-button");
        private ILocator LoginError => page.Locator("xpath=//h3[@data-test='error']");

        public override ILocator ReadyLocator => LoginButton;

        public override string Title => throw new NotImplementedException();

        public async Task LaunchApplication()
        {
            await page.GotoAsync("https://www.saucedemo.com/");
            await WaitForPageLoadAsync();
        }
        public override async Task WaitForPageLoadAsync(int timeOutInMillisec = 30000)
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await ReadyLocator.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = timeOutInMillisec
            });
        }

        public async Task<HomePage> Login(string username, string password)
        {
            TestLogger.Info($"Logging in with username '{username}' and password '{password}'");
            await Username.FillAsync(username);
            await Password.FillAsync(password);
            await LoginButton.ClickAsync();
            return new HomePage(page);
        }

        public async Task<string> GetLoginError()
        {
            return await LoginError.TextContentAsync(); 
        }
    }
}
