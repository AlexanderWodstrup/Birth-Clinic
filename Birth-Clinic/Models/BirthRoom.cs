using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;

namespace Birth_Clinic.Models
{
    public class BirthRoom : IClinicRoom
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public bool Availability { get; set; }

        public void SetAvailability(bool state)
        {
            Availability = state;
        }
        public BirthClinic BirthClinic { get; set; }
    }
}
