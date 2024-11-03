using OpenQA.Selenium;
using OpenQA.Selenium.Appium; 
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class MobileAppSteps
    { 
        private AndroidDriver? _driver;

    [OneTimeSetUp]
    public void SetUp()
    {
      var serverUri = new Uri("http://127.0.0.1:4723");
var options = new AppiumOptions();
options.AddAdditionalAppiumOption("platformName", "Android");
options.DeviceName = "R58M43YW9NE"; // Use DeviceName property instead
options.AutomationName = "UiAutomator2"; // Use AutomationName property instead
options.AddAdditionalAppiumOption("appium:uiautomator2ServerInstallTimeout", 60000);
options.AddAdditionalAppiumOption("appium:adbExecTimeout", 60000);
options.AddAdditionalAppiumOption("appium:autoGrantPermissions", true);
options.AddAdditionalAppiumOption("appium:ensureWebviewsHavePages", true);
options.AddAdditionalAppiumOption("appium:nativeWebScreenshot", true);
options.AddAdditionalAppiumOption("appium:connectHardwareKeyboard", true);
options.App = "/home/cyf/IdeaProjects/appiumSample/sauceLab.apk"; // Use App property instead
options.AddAdditionalAppiumOption("appium:appPackage", "com.swaglabsmobileapp");
options.AddAdditionalAppiumOption("appium:appActivity", "com.swaglabsmobileapp.MainActivity");

        _driver = new AndroidDriver(serverUri, options);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _driver?.Dispose();
    }

    [Test]
    public void SampleTest()
    {
        Thread.Sleep(5000);
        _driver?.FindElement(MobileBy.AccessibilityId("test-Username")).SendKeys("standard_user");
        _driver?.FindElement(MobileBy.AccessibilityId("test-Password")).SendKeys("secret_sauce");
        _driver?.FindElement(MobileBy.AccessibilityId("test-LOGIN")).Click();
        Thread.Sleep(5000);
           
        Assert.That(_driver?.FindElement(By.XPath("//android.widget.TextView[@text='PRODUCTS']")).Text, Is.EqualTo("PRODUCTS"));
 
    }
    }
}