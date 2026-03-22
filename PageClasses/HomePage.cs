using Microsoft.Playwright;
using PlaywrightDemo1.EnvironmentFunctions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlaywrightDemo1.PageClasses
{
    public class HomePage : BasePage
    {
        public HomePage(IPage page) : base(page) { }
        public override ILocator ReadyLocator => MenuButton;

        public override string Title => "Products";
        private ILocator MenuButton => page.Locator("#react-burger-menu-btn");
    }
}
