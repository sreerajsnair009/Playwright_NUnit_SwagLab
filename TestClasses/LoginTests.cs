using Microsoft.Playwright;
using PlaywrightDemo1.CustomAttributes;
using PlaywrightDemo1.DataModels;
using PlaywrightDemo1.DataProvider;
using PlaywrightDemo1.EnvironmentFunctions;
using PlaywrightDemo1.PageClasses;
using PlaywrightDemo1.ReusableActions;
using PlaywrightDemo1.Variables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.TestClasses
{
    [Parallelizable(ParallelScope.All)]
    public class LoginTests : TestBase
    {
        [Test]
        [JIRAKey("TC001")]
        [Category("Smoke")]
        public async Task TC001_LoginWithStandardUser()
        {
            LoginPage loginPage = new LoginPage(page);
            await loginPage.LaunchApplication();
            HomePage homePage = await loginPage.Login(AppSettings.Username, AppSettings.Password);
            await homePage.WaitForPageLoadAsync();
            TestLogger.Pass("Test Pass");
        }

        [Test]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.LoginDataProvider))]
        [JIRAKey("TC002")]
        public async Task TC002_InvalidLogin(LoginUser loginUser)
        {
            LoginPage loginPage = new LoginPage(page);
            await loginPage.LaunchApplication();
            await loginPage.Login(loginUser.Username, loginUser.Password);
            string loginError = await loginPage.GetLoginError();
            if(loginError == loginUser.LoginError)
            {
                TestLogger.Pass("Successfully verified the Login error...");
            }
            else
            {
                TestLogger.Fail($"Login error verification failed... Actual: '{loginError}'. Expected: '{loginUser.LoginError}'");
            }
        }
    }
}
