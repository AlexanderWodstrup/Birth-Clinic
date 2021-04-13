using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birth_Clinic.Models
{
    public class Secretary
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public bool Availability { get; set; }
        public void SetAvailability(bool state)
        {
            Availability = state;
        }

        public BirthClinic BirthClinic { get; set; }
    }
}
