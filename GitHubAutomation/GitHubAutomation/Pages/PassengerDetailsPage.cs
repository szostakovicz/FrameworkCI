using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;

namespace GitHubAutomation.Pages
{
    public class PassengerDetailsPage
    {
        private IWebDriver Driver;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'nomeAdulto_1']")]
        private IWebElement FirstNameFieldFrom;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'cognomeAdulto_1']")]
        private IWebElement SecondNameFieldFrom;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'email']")]
        private IWebElement EmailFieldFrom;

        [FindsBy(How = How.XPath, Using = "//select[@id = 'prefissoRecapito_1']")]
        private IWebElement CountryFieldFrom;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'valoreRecapito_1']")]
        private IWebElement MobilePhoneFieldFrom;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'rteSize12']")]
        private IWebElement checkAgreementFieldFrom;

        [FindsBy(How = How.XPath, Using = "//a[@id = 'datiPasseggeroSubmit']")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.XPath, Using = "//div[@id = 'valoreRecapito_1_error']")]
        private IWebElement Errorlabel;

        [FindsBy(How = How.XPath, Using = "//div[@id = 'checkAgreement_error']")]
        private IWebElement CheckAgreementlabel;


        [FindsBy(How = How.XPath, Using = "//span[@id = 'priceToPay']")]
        private IWebElement LabelPriceToPay;


        public PassengerDetailsPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public PassengerDetailsPage EnterFirstName(Passenger passenger)
        {
            FirstNameFieldFrom.SendKeys(passenger.FirstNamePassenger);
            return this;
        }

        public PassengerDetailsPage EnterSecondName(Passenger passenger)
        {
            SecondNameFieldFrom.SendKeys(passenger.SecondNamePassenger);
            return this;
        }

        public PassengerDetailsPage EnterEmail(Passenger passenger)
        {
            EmailFieldFrom.SendKeys(passenger.Email);
            return this;
        }

        public PassengerDetailsPage EnterCountry(Passenger passenger)
        {
            CountryFieldFrom.SendKeys(passenger.Country);
            return this;
        }

        public PassengerDetailsPage EnterMobilePhone(Passenger passenger)
        {
            MobilePhoneFieldFrom.SendKeys(passenger.MobilePhone);
            return this;
        }

        public PassengerDetailsPage CheckAgreement()
        {
            checkAgreementFieldFrom.Click();
            return this;
        }

        public PassengerDetailsPage PressContinueButton()
        {
            ContinueButton.Click();
            return this;
        }

        public string GetErrorLabel()
        {
            return Errorlabel.Text;
        }

        public string GetCheckAgreementlabel()
        {
            return CheckAgreementlabel.Text;
        }

    }
}
