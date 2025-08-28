
using selenium_api_automation.Core;
using selenium_api_automation.Pages;


namespace SeleniumApiAutomation.Tests
{
    [TestFixture]
    public class DogApiTests : BaseTest
    {
        private DogApiPage dogApiPage;

        [SetUp]
        public void PageSetup()
        {
            dogApiPage = new DogApiPage(driver);

        }

        [Test]
        public void ValidUrlNavigationTest()
        {
            dogApiPage.GoToPage("https://dogapi.dog/");
            System.Threading.Thread.Sleep(1500);

            dogApiPage.ClickDemo();
            System.Threading.Thread.Sleep(1500);

            dogApiPage.ClickListBreeds();
            System.Threading.Thread.Sleep(1500);

            dogApiPage.ClickFirstBreedApiUrl();
            System.Threading.Thread.Sleep(1500);



            dogApiPage.ClickApiUrlLinkAndSwitch();

            Assert.That(dogApiPage.GetCurrentUrl(), Does.StartWith("https://dogapi.dog/api/v2/breeds/"),
                "URL does not match the expected breed API format.");

        }

        [Test]
        public void GetBreedByIdTest()
        {
            dogApiPage.GoToPage("https://dogapi.dog/");
            System.Threading.Thread.Sleep(1500);

            dogApiPage.ClickDemo();
            System.Threading.Thread.Sleep(1500);

            dogApiPage.GetBreedById("23");
            System.Threading.Thread.Sleep(1500);

            dogApiPage.ClickApiUrlLink();
            System.Threading.Thread.Sleep(1500);


            dogApiPage.ClickApiUrlLinkAndSwitch();


            Assert.That(dogApiPage.GetCurrentUrl(), Does.Contain("dogapi.dog/api/v2/breeds/23"), "URL does not contain the correct breed ID.");
        }
    }
}