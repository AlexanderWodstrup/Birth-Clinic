using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Birth_Clinic.Models;

namespace Birth_Clinic.Interface
{
    public abstract class ClinicRoom
    {
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public List<Schedule> Schedules { get; set; }
        public Parent Parent { get; set; }
    }
}
