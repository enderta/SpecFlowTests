using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium; 
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using SpecFlowProject.Support;


namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private WebDriver _driver;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _driver = _scenarioContext.Get<WebDriver>("driver");
        }

        [Given(@"the application is launched")]
        public void GivenTheApplicationIsLaunched()
        {
            Console.WriteLine("Application is launched");
            Thread.Sleep(5000);
        }

        [When(@"I enter the username ""(.*)""")]
        public void WhenIEnterTheUsername(string user)
        {
            
           
            var start = new Point(340, 311);
            var end = new Point(299, 2236);
           
            Utils.PerformSwipe(_driver, start, end);


            _driver.FindElement(MobileBy.AccessibilityId("test-Username")).SendKeys(user);
        }

        [When(@"I enter the password ""(.*)""")]
        public void WhenIEnterThePassword(string password)
        {
            _driver.FindElement(MobileBy.AccessibilityId("test-Password")).SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _driver.FindElement(MobileBy.AccessibilityId("test-LOGIN")).Click();
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            Assert.That(
                _driver.FindElement(By.XPath("//android.widget.TextView[@text='PRODUCTS']")).Text, Is.EqualTo("PRODUCTS"));
            Console.WriteLine("Login successful");
        }
    }
}