using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace QAzando.Framework.Pages
{
    public class BaseSettings
    {
        public IWebDriver Driver;
        public TimeSpan ImplicitWaitTimeout = TimeSpan.FromSeconds(5);

        public BaseSettings(IWebDriver driver)
        {
            Driver = driver;
            SetImplicitWait(ImplicitWaitTimeout);
        }
        public void LoadConfigAndNavigate()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fixtures", "config.json");
            string json = File.ReadAllText(jsonPath);
            var config = JObject.Parse(json);
            string baseUrl = config["BaseUrl"].ToString();

            Driver.Navigate().GoToUrl(baseUrl);
        }

        public void SetImplicitWait(TimeSpan timeout)
        {
            Driver.Manage().Timeouts().ImplicitWait = timeout;
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
