using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
namespace SpecFlowProject.Pages
{
    public class LoginPage
    {
         
                      public void Login(IWebDriver driver, string userName, string Pass)
            {
                driver.FindElement(By.Name("user-name")).SendKeys(userName);
                driver.FindElement(By.Name("password")).SendKeys(Pass);
                driver.FindElement(By.Name("login-button")).Click();
            }

    }
}