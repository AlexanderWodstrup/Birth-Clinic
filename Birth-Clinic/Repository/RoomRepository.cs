using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Interface;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Birth_Clinic.Repository
{
    public class RoomRepository : Repository<ClinicRoom>, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context) { }

        public IEnumerable<ClinicRoom> GetBirthRooms()
        {
            return _context.Rooms.Where(r => r is BirthRoom).ToList();
        }
        public IEnumerable<ClinicRoom> GetMatenityRooms()
        {
            return _context.Rooms.Where(r => r is MaternityRoom).ToList();
        }
        public IEnumerable<ClinicRoom> GetRestRooms()
        {
            return _context.Rooms.Where(r => r is RestRoom).ToList();
        }

        public IEnumerable<ClinicRoom> GetRoomsWithSchedule()
        {
            return _context.Rooms.Include(r => r.Schedules).ToList();
        }
    }
}
