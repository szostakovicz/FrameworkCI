using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    public class User
    {
        public string ReservationCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string reservationCode, string firstName, string lastName)
        {
            ReservationCode = reservationCode;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
