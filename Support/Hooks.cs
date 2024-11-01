using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;


namespace SpecFlowProject.Support
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            var driver = new ChromeDriver();
            _scenarioContext["WebDriver"] = driver; // Store WebDriver in ScenarioContext
            driver.Manage().Window.Maximize();
            
        }

        [AfterScenario]
        public void CleanUpWebDriver()
        {
            var driver = (IWebDriver)_scenarioContext["WebDriver"];
            driver.Quit();
        }
    }
}
