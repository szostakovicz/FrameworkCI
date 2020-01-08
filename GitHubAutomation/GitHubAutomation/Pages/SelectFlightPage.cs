using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading.Tasks;

namespace GitHubAutomation.Pages
{
    public class SelectFlightPage
    {
        private IWebDriver driver;
        public string error;

        [FindsBy(How = How.XPath, Using = "//a[@class='infoFlightWrapperBtn j-priceSelector']")]
        private IWebElement FlightInput;

        [FindsBy(How = How.XPath, Using = "//a[@class='firstButton j-goToReturn']")]
        private IWebElement ChooseAndContinueButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='bookInfoBoxBasketBtn firstButton']")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='infoFlightWrapperBtn j-priceSelector']/div[@class='verticalAlignMiddle']/span[@class='price']")]
        private IWebElement InitialPriceLabel;

        public SelectFlightPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public SelectFlightPage SelectFlightInput()
        {
            FlightInput.Click();
            return this;
        }

        public SelectFlightPage ClickChooseAndContinueButton()
        {
            Task.Delay(2000).Wait();
            ChooseAndContinueButton.Click();
            return this;
        }

        public PassengerDetailsPage ClickContinueButton()
        {
            Task.Delay(5000).Wait();
            ContinueButton.Click();
            return new PassengerDetailsPage(driver);
        }

    }
}
