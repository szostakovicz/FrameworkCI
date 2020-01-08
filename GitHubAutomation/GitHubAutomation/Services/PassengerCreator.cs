using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class PassengerCreator
    {
        public static Passenger WithAllProperties()
        {
            return new Passenger(
                TestDataReader.GetData("FirstNamePassenger"),
                TestDataReader.GetData("SecondNamePassenger"),
                TestDataReader.GetData("Email"),
                TestDataReader.GetData("MobilePhone"),
                TestDataReader.GetData("Country")
                );
        }

        public static Passenger NoMobileInfo()
        {
            return new Passenger(
                TestDataReader.GetData("FirstNamePassenger"),
                TestDataReader.GetData("SecondNamePassenger"),
                TestDataReader.GetData("Email"),
                "",
                ""
                );
        }

        public static Passenger NoEmailInfo()
        {
            return new Passenger(
                TestDataReader.GetData("FirstNamePassenger"),
                TestDataReader.GetData("SecondNamePassenger"),
                "",
                TestDataReader.GetData("MobilePhone"),
                TestDataReader.GetData("Country")
                );
        }
    }
}
