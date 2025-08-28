using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_api_automation.Core
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [OneTimeSetUp] 
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [OneTimeTearDown] 
        public void TearDown()
        {
            //driver?.Quit();
            //driver?.Dispose();
        }
    }
}
