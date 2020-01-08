using NUnit.Framework;
using GitHubAutomation.Pages;
using GitHubAutomation.Tests;
using GitHubAutomation.Models;
using GitHubAutomation.Services;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class AlitaliaTests : CommonConditions
    {
        [Test]
        [Category("SearchTest")]
        public void BookingWithoutDestination()
        {
            #region TestData
            const string bookingWithoutDestinationErrorMessage = "Данные введены неверно";
            #endregion

            Route route = RouteCreator.WithEmptyArrivalCity();
            MainPage bookingWithoutDestination = new MainPage();

            bookingWithoutDestination
                .FillFieldFrom(route)
                .SelectDepartureDates(now.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .SelectArrivalDates(now.AddDays(9).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit();

            Assert.AreEqual(bookingWithoutDestination.GetErrorBookingWithoutDestination(), bookingWithoutDestinationErrorMessage);

        }

        [Test]
        [Category("CheckFlightTest")]
        public void SearchWithWrongReservationCode()
        {
            #region TestData
            const string expectedErrorMessage = "Указанный код бронирования недействителен.";
            #endregion

            User user = UserCreator.ReservationFlightProperties();
            MainPage searchWithWrongReservationCode = new MainPage();

            searchWithWrongReservationCode
                .GoToMyFlights()
                .FillReservationFlightFields(user)
                .FindReservedFlight();

            Assert.AreEqual(searchWithWrongReservationCode.GetErrorWrongReservationNumber(), expectedErrorMessage);

        }

        [Test]
        [Category("SearchTest")]
        public void SearchTicketsWithTheSameDepartureAndArrival()
        {
            #region TestData
            const string searchTicketsWithTheSameDepartureAndArrivalErrorMessage = "К сожалению, выполнение данной операции невозможно.";
            #endregion

            Route route = RouteCreator.WithTheSamePlace();
            MainPage searchTicketsWithTheSameDepartureAndArrival = new MainPage();

            searchTicketsWithTheSameDepartureAndArrival
                .FillFieldFrom(route)
                .FillFieldTo(route)
                .SelectDepartureDates(now.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .SelectArrivalDates(now.AddDays(9).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit()
                .FindMyFlight();

            Assert.AreEqual(searchTicketsWithTheSameDepartureAndArrival.GetErrorSearchFlightMessage(), searchTicketsWithTheSameDepartureAndArrivalErrorMessage);

        }

        [Test]
        [Category("SearchTest")]
        public void EnterAcceptableMaxCountOfAdults()
        {

            Route route = RouteCreator.WithAllProperties();
            MainPage acceptableMaxCountOfAdults = new MainPage();

            acceptableMaxCountOfAdults
                .FillFieldFrom(route)
                .FillFieldTo(route)
                .SelectDepartureDates(now.AddDays(2).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .SelectArrivalDates(now.AddDays(9).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit()
                .AddAdults(6);

            Assert.IsTrue(acceptableMaxCountOfAdults.AddAdultsButtonDisabled.Displayed);
        }

        [Test]
        [Category("SearchTest")]
        public void EnterTheArrivalDateEarlierThanTheDeparture()
        {
            #region TestData
            const string enterTheArrivalDateEarlierThanTheDepartureErrorMessage = "К сожалению, выполнение данной операции невозможно.";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            MainPage enterTheArrivalDateEarlierThanTheDeparture = new MainPage();

            enterTheArrivalDateEarlierThanTheDeparture
                .FillFieldFrom(route)
                .FillFieldTo(route)
                .SelectDepartureDates(now.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .SelectArrivalDates(now.AddDays(-9).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit()
                .FindMyFlight();

            Assert.AreEqual(enterTheArrivalDateEarlierThanTheDeparture.GetErrorSearchFlightMessage(), enterTheArrivalDateEarlierThanTheDepartureErrorMessage);

        }

        [Test]
        [Category("SearchTest")]
        public void OrderingTicketWithoutIndicatingMobilePhone()
        {
            #region TestData
            const string orderingTicketWithoutIndicatingMobilePhoneErrorMessage = "Поле «Номер телефона» является обязательным.";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            Passenger passengerCreator = PassengerCreator.NoMobileInfo();

            PassengerDetailsPage passengerDetails = new MainPage()
                .SelectOneWayLabel()
                .FillFieldFrom(route)
                .FillFieldTo(route)
                .SelectDepartureDates(now.AddDays(20).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit()
                .FindMyFlight()
                .SelectFlightInput()
                .ClickChooseAndContinueButton()
                .ClickContinueButton()
                .EnterFirstName(passengerCreator)
                .EnterSecondName(passengerCreator)
                .EnterEmail(passengerCreator)
                .CheckAgreement()
                .PressContinueButton();


            Assert.AreEqual(passengerDetails.GetErrorLabel(), orderingTicketWithoutIndicatingMobilePhoneErrorMessage);
        }

        [Test]
        [Category("SearchTest")]
        public void SearchForFlightsForTheYearAhead()
        {
            #region TestData
            const string searchForFlightsForTheYearAheadErrorMessage = "Нет рейсов, на эти даты. Изменить даты или вернуться на главную страницу для просмотра расписания.";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            MainPage searchForFlightsForTheYearAhead = new MainPage();

            searchForFlightsForTheYearAhead
                .FillFieldFrom(route)
                .FillFieldTo(route)
                .SelectDepartureDates(now.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .SelectArrivalDates(now.AddMonths(12).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit()
                .FindMyFlight();

            Assert.AreEqual(searchForFlightsForTheYearAhead.GetErrorSearchFlightMessage(), searchForFlightsForTheYearAheadErrorMessage);

        }

        [Test]
        [Category("SearchTest")]
        public void ForEachBabyOneAdultTest()
        {

            Route route = RouteCreator.WithAllProperties();
            MainPage forEachBabyOneAdultTest = new MainPage();

            forEachBabyOneAdultTest
                .FillFieldFrom(route)
                .FillFieldTo(route)
                .SelectDepartureDates(now.AddDays(2).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .SelectArrivalDates(now.AddDays(9).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit()
                .AddAdults(1)
                .AddBabies(2);

            Assert.IsTrue(forEachBabyOneAdultTest.SubAdultsButtonDisabled.Displayed);
        }

        [Test]
        [Category("SearchTest")]
        public void OrderingTicketWithoutCheckAgreement()
        {
            #region TestData
            const string orderingTicketWithoutCheckAgreementErrorMessage = "Вы должны подтвердить согласие";
            #endregion

            Route route = RouteCreator.WithAllProperties();
            Passenger passengerCreator = PassengerCreator.WithAllProperties();

            PassengerDetailsPage passengerDetails = new MainPage()
                .SelectOneWayLabel()
                .FillFieldFrom(route)
                .FillFieldTo(route)
                .SelectDepartureDates(now.AddDays(20).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit()
                .FindMyFlight()
                .SelectFlightInput()
                .ClickChooseAndContinueButton()
                .ClickContinueButton()
                .EnterFirstName(passengerCreator)
                .EnterSecondName(passengerCreator)
                .EnterEmail(passengerCreator)
                .EnterCountry(passengerCreator)
                .EnterMobilePhone(passengerCreator)
                .PressContinueButton();

            Assert.AreEqual(orderingTicketWithoutCheckAgreementErrorMessage, passengerDetails.GetCheckAgreementlabel());
        }

        [Test]
        [Category("SearchTest")]
        public void BookingWithoutDepartureCity()
        {
            #region TestData
            const string bookingWithoutDepartureCityErrorMessage = "Данные введены неверно";
            #endregion

            Route route = RouteCreator.WithEmptyDepatureCity();
            MainPage bookingWithoutDepartureCity = new MainPage();

            bookingWithoutDepartureCity
                .CleanFieldFrom()
                .FillFieldTo(route)
                .SelectDepartureDates(now.ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .SelectArrivalDates(now.AddDays(9).ToString("dd/MM/yyy", System.Globalization.CultureInfo.InvariantCulture))
                .Submit();

            Assert.AreEqual(bookingWithoutDepartureCityErrorMessage, bookingWithoutDepartureCity.GetErrorBookingWithoutDestination());

        }
    }
}
