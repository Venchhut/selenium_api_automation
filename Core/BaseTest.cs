using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace selenium_api_automation.Core
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
        }
    }
}
