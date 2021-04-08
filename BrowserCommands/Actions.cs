using Automation.ExceptionExtensions;
using Automation.Providers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void VerifyPageCompleteState(double secondsToWait=15) 
        {
            JsVerifyPageCompleteState(secondsToWait);
        }

        internal IWebElement DuplicationCheck(By by, double secondsToWait=30)
        {
            ReadOnlyCollection<IWebElement> elements = FindElements(by, secondsToWait);
            if (elements.Count > 1)
            {
                string[] byString = by.ToString().Split(new[] { ':' }, 2);
                string message = $"While Searching for the element with {byString[0].Remove(0, 3)}={byString[1]} multiple instance of element were found. Please create a unique locator and try again";
                throw new DuplicateIdException(message);
            }

            else 
            {
                return elements[0];
            }
        }
        public IWebElement FindElement(By by, double secondsToWait)
        {
            IWebElement element = DuplicationCheck(by, secondsToWait);
            return element;
        }

        public ReadOnlyCollection<IWebElement>FindElements(By by, double secondsToWait)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
                return Driver.FindElements(by);

            }

            catch
            {
                string[] byString = by.ToString().Split(new[] { ':' },2);
                throw new NoSuchElementException(message: $"After a {secondsToWait} seconds wait the element with {byString[0].Remove(0, 3)} could be found");
            }
        }

        public void ClickOn(IWebElement element, double secondsToWait = 20, bool pageWontReachComplete = false) 
        {
            if (!pageWontReachComplete)
            {
                JsVerifyPageCompleteState(secondsToWait);
            }

            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
                Highlight(element);
                element.Click();
                if (!pageWontReachComplete)
                {
                    JsVerifyPageCompleteState(secondsToWait);
                }
            }

            catch (Exception e)
            {
                throw new Exception($"ClickOn : {element} failed with error : {e.Message}");
            }
        }

        public void HoverOn(IWebElement webElement, int durationInMs) 
        {
            VerifyPageCompleteState();
            Highlight(webElement);
            JsHover(webElement,durationInMs);
        }

        public void HoverOn(IWebElement webElement) 
        {
            VerifyPageCompleteState();
            try
            {
                Highlight(webElement);
                var mouseOverAction = new OpenQA.Selenium.Interactions.Actions(Driver);
                mouseOverAction.MoveToElement(webElement).Perform();
            }

            catch (Exception e)
            {
                throw new Exception($"Failed to hover on the element {webElement} with error : {e.Message}");
            }
        }

        public void Type(IWebElement webElement,string value,double secondsToWait=20,bool pageWontReachComplete=false,bool skipValidation=true,bool clearText = true) 
        {
            if (!pageWontReachComplete) 
            {
                VerifyPageCompleteState(secondsToWait);
            }
            Highlight(webElement);
            if (clearText) 
            {
                ClearInputText(webElement);
            }
            webElement.SendKeys(value);
            try
            {
                if (!skipValidation)
                {
                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(secondsToWait));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webElement, value));
                }
            }

            catch (Exception e)
            {
                throw new Exception($"Type text for element {webElement} failed with error {e.Message}");
            }
            
        }

        public void ClearInputText(IWebElement webElement) 
        {
            try
            {
                if (ConfigurationProvider.WebDriver.BrowserName.ToString().ToLower() == "ie")
                {
                    JsType(webElement, "");
                }

                else 
                {
                    JsType(webElement, "");
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].dispatchEvent(new Event('input'));", webElement);
                }

            }

            catch(Exception e)
            {
                throw new Exception($"Failed to clear input text : {e.Message}");
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 

      


    }
}
