// Support/Hooks.cs

using TechTalk.SpecFlow;
using Mobile.Drivers;
using OpenQA.Selenium.Appium.Android;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void SetupDriver()
    {
        Driver.Initialize(); // Initialize the driver
        var driver = Driver.GetDriver();
        _scenarioContext.Set(driver, "driver"); // Store the driver in ScenarioContext
    }

    [AfterScenario]
    public void TearDownDriver()
    {
        Driver.Quit(); // Quit the driver
    }
}