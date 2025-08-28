using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace selenium_api_automation.Pages
{
    public class DogApiPage
    {
        private  IWebDriver driver;
        private  WebDriverWait wait;


        private  By DemoLink = By.LinkText("Demo");
        private By ListBreedsButton = By.CssSelector("[data-action='click->dogs#listBreeds']");
        private By FirstBreedApiUrl = By.CssSelector("[data-action='click->dogs#breedClicked']");
        //private By ApiUrlLink = By.XPath("/html/body/main/div/div[2]/div/a");
        private By ApiUrlLink = By.CssSelector("a[href*='/api/v2/breeds/']");
        private By BreedIdInput = By.Id("breedId");
        private By GetBreedButton = By.CssSelector("[data-action='click->dogs#getBreed']");

        public DogApiPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickDemo()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(DemoLink)).Click();
        }

        public void ClickListBreeds()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ListBreedsButton)).Click();
        }

        public void ClickFirstBreedApiUrl()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(FirstBreedApiUrl)).Click();
        }

        public void ClickApiUrlLink()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ApiUrlLink)).Click();
        }

        public void GetBreedById(string breedId)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(BreedIdInput)).SendKeys(breedId);
            wait.Until(ExpectedConditions.ElementToBeClickable(GetBreedButton)).Click();
        }
        public void ClickApiUrlLinkAndSwitch()
        {
            var link = wait.Until(ExpectedConditions.ElementToBeClickable(ApiUrlLink));
            link.Click();

            wait.Until(driver => driver.WindowHandles.Count > 1);

            string newTab = driver.WindowHandles.Last();
            driver.SwitchTo().Window(newTab);

            wait.Until(d => d.Url.Contains("api/v2/breeds/"));
        }

        public string GetPageTitle() => driver.Title;
        public string GetCurrentUrl() => driver.Url;
    }
}