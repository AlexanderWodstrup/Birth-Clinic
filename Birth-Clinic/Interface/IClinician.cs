using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Models;

namespace Birth_Clinic.Interface
{
    public abstract class Clinician
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public bool Availability { get; set; }
        public abstract void SetAvailability(bool state);
        public BirthClinic BirthClinic { get; set; }
    }
}
