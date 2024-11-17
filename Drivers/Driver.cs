using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Mobile.Drivers
{
    public class Driver
    {
        private static AndroidDriver _driver;
        private static readonly AppiumOptions capabilities = new AppiumOptions();

        public static void Initialize()
        {
            if (_driver != null) return; // Prevent re-initialization

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

        public static AndroidDriver GetDriver()
        {
            return _driver;
        }

        public static void Quit()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null; // Set to null after quitting
            }
        }
    }
}