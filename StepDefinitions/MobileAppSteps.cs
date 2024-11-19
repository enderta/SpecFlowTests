using OpenQA.Selenium;
using OpenQA.Selenium.Appium; 
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interactions;
using System.Drawing;

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
options.DeviceName = "R58M43YW9NE";
options.AutomationName = "UiAutomator2"; 
options.AddAdditionalAppiumOption("appium:uiautomator2ServerInstallTimeout", 60000);
options.AddAdditionalAppiumOption("appium:adbExecTimeout", 60000);
options.AddAdditionalAppiumOption("appium:autoGrantPermissions", true);
options.AddAdditionalAppiumOption("appium:ensureWebviewsHavePages", true);
options.AddAdditionalAppiumOption("appium:nativeWebScreenshot", true);
options.AddAdditionalAppiumOption("appium:connectHardwareKeyboard", true);
options.App = "/home/cyf/IdeaProjects/appiumSample/sauceLab.apk"; 
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
         var loginButton =  _driver?.FindElement(MobileBy.AccessibilityId("test-LOGIN"));
        Utils2.TapElement(_driver, loginButton);
     
        Thread.Sleep(5000);
           
        Assert.That(_driver?.FindElement(MobileBy.AndroidUIAutomator("new UiSelector().text(\"PRODUCTS\")")).Text, Is.EqualTo("PRODUCTS"));
 var start = new Point(0, 650);
var end = new Point(473, 650);
  Utils2.Swipe(_driver, start, end );

 
    }
    }
}