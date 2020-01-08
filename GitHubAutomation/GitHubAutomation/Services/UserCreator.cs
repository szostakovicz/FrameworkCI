using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class UserCreator
    {
        public static User ReservationFlightProperties()
        {
            return new User(TestDataReader.GetData("ReservationCode"), TestDataReader.GetData("FirstName"), TestDataReader.GetData("LastName"));
        }
    }
}
