using Automation.Browser;
using Automation.BrowserCommands;
using Automation.Providers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.IO;

namespace Automation
{
    public class Tests:TestBase
    {
        
        [Test]
        public void Test1()
        {
            string browsername = "";
            string name = Driver.GetType().FullName;
            ICapabilities capabilities = ((RemoteWebDriver)Driver.WrappedDriver).Capabilities;
            string browserName = string.Empty;
            if (capabilities.HasCapability("browserName"))
            {
                browserName = capabilities.GetCapability("browserName").ToString();
            }
            Driver.Manage().Window.Maximize();
            Assert.Pass();
        }
    }
}