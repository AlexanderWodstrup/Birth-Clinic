using Birth_Clinic.Models;

namespace Birth_Clinic.Interface
{
    public abstract class IClinicRoom
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public bool Availability { get; set; }
        public abstract void SetAvailability(bool state);
        public BirthClinic BirthClinic { get; set; }
    }
}
