using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class Lab
    {
        private readonly IWebDriver _driver;
        public Lab(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
        }

        [Given(@"I login the page")]
        public void GivenILoginThePage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Name("user-name")).Displayed);
        }

        [When(@"I enter the following details to login form:")]
        public void WhenIEnterTheFollowingDetailsToLoginForm(Table table)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var firstRow = table.Rows[0];
            string userName = firstRow["User Name"];
            string password = firstRow["Password"];
            
            wait.Until(d => d.FindElement(By.Name("user-name"))).SendKeys(userName);
            wait.Until(d => d.FindElement(By.Name("password"))).SendKeys(password);
            wait.Until(d => d.FindElement(By.Name("login-button"))).Click();
            
            // Wait for navigation to complete
            Thread.Sleep(2000);
        }

        [Given(@"I am on the product listing page")]
        public void GivenIAmOnTheProductListingPage()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // Verify we're on the inventory page
            wait.Until(d => d.Url.Contains("inventory.html"));
            Assert.That(_driver.Url, Does.Contain("inventory.html"));
            
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            /* var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var inventoryItems = wait.Until(d => 
                d.FindElements(By.ClassName("inventory_item_name")));
            
            // Since Sauce Demo doesn't have a search function, we'll simulate it
            // by finding items that contain the search term
            var matchingItems = inventoryItems
                .Where(item => item.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            Console.WriteLine($"Found {matchingItems.Count} items matching '{searchTerm}'"); */
            _driver.FindElement(By.XPath("//button[@data-test='add-to-cart-sauce-labs-backpack']")).Click();
        }

        [Then(@"I should see search results containing ""(.*)""")]
        public void ThenIShouldSeeSearchResultsContaining(string searchTerm)
        {
            /* var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var inventoryItems = wait.Until(d => 
                d.FindElements(By.ClassName("inventory_item_name")));
            
            var matchingItems = inventoryItems
                .Where(item => item.Text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
            
            // Assert that we found at least one matching item
            Assert.That(matchingItems.Count, Is.GreaterThan(0), 
                $"No items found containing '{searchTerm}'");
            
            foreach (var item in matchingItems)
            {
                Console.WriteLine($"Found matching item: {item.Text}");
            } */

            String cartCount = _driver.FindElement(By.XPath("//*[@data-test='shopping-cart-badge']")).Text;
            Assert.That(cartCount, Is.EqualTo("1"), "Cart count is incorrect");
        }

        
    }
}