using System.ComponentModel.DataAnnotations;
using Birth_Clinic.Models;

namespace Birth_Clinic.Interface
{
    public abstract class ClinicRoom
    {
        public string RoomName { get; set; }
        [Key]
        public int RoomId { get; set; }
        public bool Availability { get; set; }

        public void SetAvailability(bool state)
        {
            Availability = state;
        }
        public BirthClinic BirthClinic { get; set; }
    }
}
