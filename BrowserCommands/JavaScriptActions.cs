using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

        public void JsClick(IWebElement webElement, double secondsToWait = 20, bool pageWontReachComplete = false) 
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].click;", webElement);
            if (!pageWontReachComplete) 
            {
                JsVerifyPageCompleteState(secondsToWait);
            }
        }

        public void JsHover(IWebElement webElement, int duration = 1000) 
        {
            string javaScript = "var evObj = document.createEvent('MouseEvents');" +
                    "evObj.initMouseEvent(\"mouseover\",true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);" +
                    "arguments[0].dispatchEvent(evObj);";
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript(javaScript, webElement);
            Thread.Sleep(TimeSpan.FromMilliseconds(duration));
        }

        public void JsType(IWebElement webElement, string value) 
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            executor.ExecuteScript("arguments[0].value=arguments[1];", webElement, value);
        }

        public void JsDropDowSelect(IWebElement webElement, string initialValue, string expectedValue) 
        {
            if (webElement.GetAttribute("value").Equals(initialValue)) 
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].value=arguments[1];", webElement, expectedValue);
            }
        }

        public void JsScrollUntilElement(IWebElement webElement) 
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguements[0].scrollIntoview(true);", webElement);
        }

        internal bool Highlight(IWebElement highlightElement, double secondsToWait = 5)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;", highlightElement);
            return true;
        }

    }
    }

