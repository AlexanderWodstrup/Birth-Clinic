using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;

namespace Birth_Clinic.Repository
{
    public interface IRoomRepository : IRepository<ClinicRoom>
    {
        public IEnumerable<ClinicRoom> GetBirthRooms();
        public IEnumerable<ClinicRoom> GetMatenityRooms();
        public IEnumerable<ClinicRoom> GetRestRooms();
        public IEnumerable<ClinicRoom> GetRoomsWithSchedule();
        public void Add(ClinicRoom entity);
    }
}
