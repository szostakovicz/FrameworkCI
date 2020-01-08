using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        private IWebDriver Driver;

        private readonly string Url = "https://www.alitalia.com/ru_ru/";

        [FindsBy(How = How.XPath, Using = "//input[@id = 'luogo-partenza--prenota-desk']")]
        private IWebElement AirportInputFieldFrom;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'luogo-arrivo--prenota-desk']")]
        private IWebElement AirportInputFieldTo;

        [FindsBy(How = How.XPath, Using = "//span[@class = 'icon-ico-select-white']")]
        private IWebElement SubmitBookingButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='labelErrorInfoStatoVolo']")]
        private IWebElement BookingWithoutDestinationErrorLabel;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'data-andata--prenota-desk']")]
        private IWebElement DepartureDateField;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'data-ritorno--prenota-desk']")]
        private IWebElement ArrivalDateField;

        [FindsBy(How = How.XPath, Using = "//a[@id = 'my-flights']")]
        private IWebElement MyFlightsTab;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'pnr']")]
        private IWebElement ReservationCodeField;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'firstName']")]
        private IWebElement FirstNameField;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'lastName']")]
        private IWebElement LastNameField;

        [FindsBy(How = How.XPath, Using = "//input[@id = 'cercamyFlightSubmit']")]
        private IWebElement SearchReservedFlightButton;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'submitHidden--prenota']")]
        private IWebElement FindFlightButton;

        [FindsBy(How = How.XPath, Using = "//form[@id='form-myFlightSearch']/div[@id='labelErrorInfoStatoVolo']")]
        private IWebElement WrongReservationNumberError;

        [FindsBy(How = How.XPath, Using = "//p[@class='genericErrorMessage__text']")]
        private IWebElement TheSameDepartureAndArrivalCitiesError;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'addAdults']")]
        private IWebElement AddAdultsButton;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'subAdults']")]
        private IWebElement SubAdultsButton;

        [FindsBy(How = How.XPath, Using = "//button[@id = 'addBabies']")]
        private IWebElement AddBabiesButton;

        [FindsBy(How = How.XPath, Using = "//button[@class = 'button plus no-active']")]
        public IWebElement AddAdultsButtonDisabled;

        [FindsBy(How = How.XPath, Using = "//button[@class = 'button minus no-active']")]
        public IWebElement SubAdultsButtonDisabled;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'input-wrap radio-wrap']")]
        public IWebElement OneWayLabel;

        public MainPage()
        {

            Driver = DriverSingleton.GetDriver();
            PageFactory.InitElements(Driver, this);
            Driver.Navigate().GoToUrl(Url);
        }

        public MainPage SelectOneWayLabel()
        {
            OneWayLabel.Click();
            return this;
        }

        public MainPage FillFieldFrom(Route route)
        {
            AirportInputFieldFrom.Clear();
            AirportInputFieldFrom.SendKeys(route.DepartureCity);
            return this;
        }

        public MainPage FillFieldTo(Route route)
        {
            AirportInputFieldTo.Clear();
            AirportInputFieldTo.SendKeys(route.ArrivalCity);
            return this;
        }

        public MainPage CleanFieldFrom()
        {
            AirportInputFieldFrom.Clear();
            return this;
        }

        public MainPage SelectDepartureDates(string DepartureDate)
        {
            DepartureDateField.Clear();
            DepartureDateField.SendKeys(DepartureDate);
            DepartureDateField.SendKeys(Keys.Enter);
            return this;
        }

        public MainPage SelectArrivalDates(string ArrivalDate)
        {
            ArrivalDateField.Clear();
            ArrivalDateField.SendKeys(ArrivalDate);
            return this;
        }

        public MainPage Submit()
        {
            SubmitBookingButton.Click();
            return this;
        }

        public MainPage GoToMyFlights()
        {
            MyFlightsTab.Click();
            return this;
        }

        public MainPage FillReservationFlightFields(User user)
        {
            ReservationCodeField.SendKeys(user.ReservationCode);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            return this;
        }

        public MainPage FindReservedFlight()
        {
            SearchReservedFlightButton.Click();
            return this;
        }

        public MainPage AddAdults(int countAdults)
        {
            for (int i = 1; i <= countAdults; i++)
                AddAdultsButton.Click();
            return this;
        }

        public MainPage AddBabies(int countAdults)
        {
            for (int i = 1; i <= countAdults; i++)
                AddBabiesButton.Click();
            return this;
        }

        public SelectFlightPage FindMyFlight()
        {
            FindFlightButton.Click();
            return new SelectFlightPage(Driver);
        }

        public bool SubAdultsButtonIsEnabled()
        {
            return SubAdultsButton.Enabled;
        }


        public string GetErrorWrongReservationNumber()
        {
            return WrongReservationNumberError.Text;
        }

        public string GetErrorBookingWithoutDestination()
        {
            return BookingWithoutDestinationErrorLabel.Text;
        }

        public string GetErrorSearchFlightMessage()
        {
            return TheSameDepartureAndArrivalCitiesError.Text;
        }
    }
}
