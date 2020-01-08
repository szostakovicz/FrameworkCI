using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    public class Route
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }

        public Route(string departureCity, string arrivalCity)
        {
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
        }
    }
}
