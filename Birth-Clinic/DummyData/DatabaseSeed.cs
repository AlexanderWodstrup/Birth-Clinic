using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Interface;
using Birth_Clinic.Models;
using Birth_Clinic.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Birth_Clinic.DummyData
{
    public class DatabaseSeed
    {
        public void AddRooms(AppDbContext context)
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(context);
            //Seeder 15 birthrooms i databasen
            for (int i = 1; i < 16; i++)
            {
                ClinicRoom BirthRoom = new BirthRoom()
                {
                    RoomName = "Birth Room - " + i,
                };
                unitOfWork.Rooms.Add(BirthRoom);
            }

            //Seeder 22 maternityrooms i databasen
            for (int i = 1; i < 23; i++)
            {
                ClinicRoom MaternityRoom = new MaternityRoom()
                {
                    RoomName = "Maternity Room - " + i,
                };
                unitOfWork.Rooms.Add(MaternityRoom);
            }

            //Seeder 5 restrooms i databasen
            for (int i = 1; i < 6; i++)
            {
                ClinicRoom RestRoom = new RestRoom()
                {
                    RoomName = "Rest Room - " + i,
                };
                unitOfWork.Rooms.Add(RestRoom);
            }

            unitOfWork.Complete();
            Console.WriteLine("Rooms seeded");
        }

        public void AddWorkers(AppDbContext context)
        {
            //10 Midwifes
            for (int i = 0; i < 10; i++)
            {
                Clinician Midwife = new MidWife()
                {
                    FirstName = randomFirstName(),
                    LastName = randomLastName(),
                    Salary = 10000
                };
                context.Clinicians.Add(Midwife);
            }
            

            //20 Nurses

            //20 SOSU assitens

            //5 Doctors

            //4 Secretary
            context.SaveChanges();
            Console.WriteLine("Workers seeded");
            
        }

        public string randomLastName()
        {
            string[] LastName =
            {
                "Storey", "O'Brien", "Easton",
                "Cohen", "Drew", "Trevino",
                "Rivera", "Stout", "Manning",
                "Legge", "Hansen", "Healy"
            };
            var rand = new Random();

            return LastName[rand.Next(LastName.Length)];
        }
        public string randomFirstName()
        {
            string[] FirstNames =
            {
                "Mercy", "Jovan", "Cassius",
                "Kara", "Roberto", "Brandan",
                "Maisha", "Scarlette", "Frank",
                "Peter", "Angelina", "Linda"
            };
            var rand = new Random();

            return FirstNames[rand.Next(FirstNames.Length)];
        }

        public bool WipeDatabase(bool onlyIfNoDatabase)
        {
            using (var db = new AppDbContext())
            {
                if (onlyIfNoDatabase && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                db.Database.EnsureDeleted();
                db.Database.Migrate();
                Console.WriteLine("Database cleared");
            }
            return true;
        }
    }
}
