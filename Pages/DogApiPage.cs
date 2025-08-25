using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;


namespace selenium_api_automation.Pages
{
    public class DogApiPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        

        private readonly By DemoLink = By.LinkText("Demo");
        private readonly By ListBreedsButton = By.CssSelector("[data-action='click->dogs#listBreeds']");
        private readonly By FirstBreedApiUrl = By.CssSelector("[data-action='click->dogs#breedClicked']");
        private readonly By ApiUrlLink = By.XPath("/html/body/main/div/div[2]/div/a");
        private readonly By BreedIdInput = By.Id("breedId");
        private readonly By GetBreedButton = By.CssSelector("[data-action='click->dogs#getBreed']");

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


        public void SwitchToNewTab()
        {
            wait.Until(driver => driver.WindowHandles.Count > 1);

            string originalTab = driver.CurrentWindowHandle;

            string newTab = driver.WindowHandles.FirstOrDefault(handle => handle != originalTab);

            if (!string.IsNullOrEmpty(newTab))
            {
                driver.SwitchTo().Window(newTab);
            }
        }

        public string GetPageTitle() => driver.Title;
        public string GetCurrentUrl() => driver.Url;
    }
}
