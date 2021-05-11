﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Interface;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MongoDB.Driver;

namespace Birth_Clinic.Repository
{
    public class RoomRepository : Repository<ClinicRoom>, IRoomRepository
    {
        private IMongoCollection<ClinicRoom> RoomCollection;
        public RoomRepository(AppDbContext context) : base(context)
        {
            RoomCollection = context.context.GetCollection<ClinicRoom>("Rooms");
        }

        public IEnumerable<ClinicRoom> GetBirthRooms()
        {
            return RoomCollection.Find(r => r is BirthRoom == true).ToList();
            //return _context.Rooms.Where(r => r is BirthRoom).ToList();
        }
        public IEnumerable<ClinicRoom> GetMatenityRooms()
        {
            return RoomCollection.Find(r => r is MaternityRoom == true).ToList();
            //return _context.Rooms.Where(r => r is MaternityRoom).ToList();
        }
        public IEnumerable<ClinicRoom> GetRestRooms()
        {
            return RoomCollection.Find(r => r is RestRoom == true).ToList();
            //return _context.Rooms.Where(r => r is RestRoom).ToList();
        }

        public IEnumerable<ClinicRoom> GetRoomsWithSchedule()
        {
            return RoomCollection.Find(r => true).ToList();
            //return _context.Rooms.Include(r => r.Schedules).ToList();
        }
    }
}
