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
        public int ClinicianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public List<Schedule> Schedules { get; set; }
        public Parent Parent { get; set; }

        
    }
}
