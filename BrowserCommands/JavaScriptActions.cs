using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.BrowserCommands
{
    public partial class Actions
    {
        public void JsVerifyPageCompleteState(double secondsToWait = 30) 
        {
            try
            {
                new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait)).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            }

            catch 
            {
                if (!String.IsNullOrWhiteSpace(Driver.Url))
                {
                    throw new TimeoutException();
                }

                else 
                {
                    throw new TimeoutException();
                }
            }
        }
    }
}
