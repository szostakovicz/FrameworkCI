using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    public class Passenger
    {
        public string FirstNamePassenger { get; set; }
        public string SecondNamePassenger { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Country { get; set; }

        public Passenger(string firstName, string secondName, string email, string mobilePhone, string country)
        {
            FirstNamePassenger = firstName;
            SecondNamePassenger = secondName;
            Email = email;
            MobilePhone = mobilePhone;
            Country = country;
        }
    }
}
