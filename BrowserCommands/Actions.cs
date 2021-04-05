using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.BrowserCommands
{
    public partial class Actions
    {
        public IWebDriver Driver;

        public Actions(IWebDriver Driver) 
        {
            this.Driver = Driver;
        }
    }
}
