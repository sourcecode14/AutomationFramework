using Automation.Browser.Models;
using Automation.Providers.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Automation.Providers
{
    public class ConfigurationProvider
    {
        
        private const string WebDriverConfigSectionName = "webdriver";
        private const string EnvironmentConfigSectionName = "environment";
        private const string FilePath = @"..\..\TestSettings.json";
        static string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
        private static readonly string SettingsPath = Path.Combine(assemblyPath, "TestSettings.json");

        public static WebDriverConfiguration WebDriver =>
            Load<WebDriverConfiguration>(WebDriverConfigSectionName);

        public static EnvironmentConfiguration Environment =>
            Load<EnvironmentConfiguration>(EnvironmentConfigSectionName);

        private static T Load<T>(string sectionName) 
        {
            return JObject.Parse(File.ReadAllText(SettingsPath)).SelectToken(sectionName).ToObject<T>();
        }
            
    }
}
