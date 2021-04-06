using Automation.Browser;
using Automation.Providers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Automation
{
    public abstract class TestBase
    {
        public IWebDriver Driver;
        public TestBase()
        {

        }

        [SetUp]
        public void Setup()
        {
            var driverConfig = ConfigurationProvider.WebDriver;
            var logger = new Logger("logger", InternalTraceLevel.Info, TextWriter.Null);
            Driver = new WebDriverFactory().GetWebDriver(driverConfig, logger);
        }

        [TearDown]
        public void TearDown() 
        {
            Driver.Close();
        }
        [OneTimeSetUp]

        public void OnTimeSetup() 
        {
            Console.WriteLine("OnetimeSetup");
        }

        

    }
}
