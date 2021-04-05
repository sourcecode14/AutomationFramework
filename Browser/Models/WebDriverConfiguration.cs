using Automation.Browser.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.Browser.Models
{
    public class WebDriverConfiguration
    {
        public BrowserName BrowserName { get; set; }
        public string ScreenshotsPath { get; set; }
        public int DefaultTimeout { get; set; }
        public string BrowserLanguage { get; set; }
    }
}
