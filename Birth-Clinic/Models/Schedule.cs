using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;

namespace Birth_Clinic.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ClinicRoom ClinicRoom { get; set; }
        public Clinician Clinician { get; set; }
    }
}
