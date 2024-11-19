using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions;
[Binding]
public class CehckOut
{
    private readonly ScenarioContext _scenarioContext;
    private WebDriver _driver;
    
    public CehckOut(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = _scenarioContext.Get<WebDriver>("driver");
    }
    
    [Given(@"I am logged in")]
    public void GivenIAmLoggedIn()
    {
        Console.WriteLine("I am logged in");
    }

    [When(@"I click on the product")]
    public void WhenIClickOnTheProduct()
    {
        _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().description(\"test-ADD TO CART\").instance(0)")).Click();
        Thread.Sleep(2000);
    }

    [When(@"I click on the add to cart button")]
    public void WhenIClickOnTheAddToCartButton()
    {
        _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().className(\"android.view.ViewGroup\").instance(13)")).Click();
        Thread.Sleep(2000);
    }

    [Then(@"I should see the product in the cart")]
    public void ThenIShouldSeeTheProductInTheCart()
    {
        var cart = _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"1\").instance(1)")).GetAttribute("text");
        Assert.That(cart, Is.EqualTo("1"));
    }

    [Then(@"I click on the checkout button")]
    public void ThenIClickOnTheCheckoutButton()
    {
       _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"CHECKOUT\")")).Click();
        Thread.Sleep(2000);
    }

    [Then(@"I fill in the details")]
    public void ThenIFillInTheDetails(Table table)
    {
        //table to dictionary
        Console.WriteLine(table.Rows[0]["First Name"]);
        Console.WriteLine(table.Rows[0]["Last Name"]);
        Console.WriteLine(table.Rows[0]["Zip Code"]);
        
        _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"First Name\")")).SendKeys(table.Rows[0]["First Name"]);
        _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Last Name\")")).SendKeys(table.Rows[0]["Last Name"]);
        _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"Zip/Postal Code\")")).SendKeys(table.Rows[0]["Zip Code"]);
        _driver.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"CONTINUE\")")).Click();
    }
}