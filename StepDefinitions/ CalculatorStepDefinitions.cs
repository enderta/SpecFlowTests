using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
   [Binding]
    public class CalculatorStepDefinitions
    {
        private readonly IWebDriver _driver;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"]; // Retrieve WebDriver from ScenarioContext
        }

        [Given("I navigate to Google")]
        public void GivenINavigateToGoogle()
        {
            _driver.Navigate().GoToUrl("http://google.com");
        }
    }
}
