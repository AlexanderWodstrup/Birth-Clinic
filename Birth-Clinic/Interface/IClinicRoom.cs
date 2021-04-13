using Birth_Clinic.Models;

namespace Birth_Clinic.Interface
{
    public abstract class ClinicRoom
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
