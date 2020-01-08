using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"));
        }

        public static Route WithEmptyArrivalCity()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), "");
        }

        public static Route WithEmptyDepatureCity()
        {
            return new Route("", TestDataReader.GetData("ArrivalCity"));
        }

        public static Route WithTheSamePlace()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("DepartureCity"));
        }

    }
}
