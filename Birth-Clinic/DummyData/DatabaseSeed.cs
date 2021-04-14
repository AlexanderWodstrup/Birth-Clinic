﻿using System;
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
        public void AddFatherAndMother()
        {
            using var context = new AppDbContext();

            Parent parent = new Parent()
            {
                DueDate = DateTime.Now,

            };

            Father newFather = new Father()
            {
                FirstName = "Peter",
                LastName = "Wann",
                Parent = parent,
            };

            Mother newMother = new Mother()
            {
                FirstName = "Line",
                LastName = "Design",
                Parent = parent,
            };
            parent.Father = newFather;
            parent.Mother = newMother;
            context.Add(newFather);
            context.Add(newMother);
            context.Add(parent);
        

            Parent parent2 = new Parent()
            {
                DueDate = DateTime.Now.AddDays(3)

            };

            Father newFather2 = new Father()
            {
                FirstName = "Alexander",
                LastName = "Wodstrup",
                Parent = parent2,
            };

            Mother newMother2 = new Mother()
            {
                FirstName = "Ursula",
                LastName = "Flemmingsen",
                Parent = parent2,
            };
            parent2.Father = newFather2;
            parent2.Mother = newMother2;
            context.Add(newFather2);
            context.Add(newMother2);
            context.Add(parent2);

            Parent parent3 = new Parent()
            {
                DueDate = DateTime.Now.AddDays(5),

            };

            Father newFather3 = new Father()
            {
                FirstName = "Palle",
                LastName = "Nielsen",
                Parent = parent3,
            };

            Mother newMother3 = new Mother()
            {
                FirstName = "Francesca",
                LastName = "Musollini",
                Parent = parent3,
            };
            parent3.Father = newFather3;
            parent3.Mother = newMother3;
            context.Add(newFather3);
            context.Add(newMother3);
            context.Add(parent3);

            Parent parent4 = new Parent()
            {
                DueDate = DateTime.Now.AddDays(2),

            };

            //Father newFather4 = new Father()
            //{
            //    FirstName = "August",
            //    LastName = "Andersen",
            //    Parent = parent4,
            //};

            Mother newMother4 = new Mother()
            {
                FirstName = "Karen",
                LastName = "Ingemann",
                Parent = parent4,
            };
            //parent4.Father = newFather4;
            parent4.Mother = newMother4;
            //context.Add(newFather4);
            context.Add(newMother4);
            context.Add(parent4);
            context.SaveChanges();
            Console.WriteLine("Father and Mother seeded");
        }
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
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(context);
            //10 Midwifes
            for (int i = 0; i < 10; i++)
            {
                Clinician Midwife = new MidWife()
                {
                    FirstName = randomFirstName(),
                    LastName = randomLastName(),
                    Salary = 10000,
                    Schedules = randomWorkSchedule(i),
                };
                unitOfWork.Clinicians.Add(Midwife);
            }
            

            //20 Nurses
            for (int i = 0; i < 20; i++)
            {
                Clinician Nurse = new Nurse()
                {
                    FirstName = randomFirstName(),
                    LastName = randomLastName(),
                    Salary = 8000,
                    Schedules = randomWorkSchedule(i),
                };
                unitOfWork.Clinicians.Add(Nurse);
            }

            //20 SOSU assitens
            for (int i = 0; i < 20; i++)
            {
                Clinician SOSU = new SOSU_Assistent()
                {
                    FirstName = randomFirstName(),
                    LastName = randomLastName(),
                    Salary = 10,
                    Schedules = randomWorkSchedule(i),
                };
                unitOfWork.Clinicians.Add(SOSU);
            }

            //5 Doctors
            for (int i = 0; i < 5; i++)
            {
                Clinician Doctor = new Doctor()
                {
                    FirstName = randomFirstName(),
                    LastName = randomLastName(),
                    Salary = 50000,
                    Schedules = randomWorkSchedule(i),
                };
                unitOfWork.Clinicians.Add(Doctor);
            }

            //4 Secretary
            for (int i = 0; i < 4; i++)
            {
                Secretary Secretary = new Secretary()
                {
                    FirstName = randomFirstName(),
                    LastName = randomLastName(),
                    Salary = 2500,
                    Schedules = randomWorkSchedule(i),
                };
                unitOfWork.Clinicians.Add(Secretary);
            }

            unitOfWork.Complete();
            Console.WriteLine("Workers seeded");
            
        }

        public string randomLastName()
        {
            string[] LastName =
            {
                "Storey", "O'Brien", "Easton",
                "Cohen", "Drew", "Trevino",
                "Rivera", "Stout", "Manning",
                "Legge", "Hansen", "Healy",
                "Larsen", "Flynn", "Brady",
                "Yang", "Ford", "Shepherd"
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
                "Peter", "Angelina", "Linda",
                "Lylah", "Louie", "Indiana",
                "Jimmy", "Eli", "Amalia"
            };
            var rand = new Random();

            return FirstNames[rand.Next(FirstNames.Length)];
        }

        public List<Schedule> randomWorkSchedule(int i)
        {
            int startWorkTime;
            if (i <= 2)
            {
                startWorkTime = 8;
            }
            else if (i <= 5 && i > 2)
            {
                startWorkTime = 16;
            }
            else
            {
                startWorkTime = 00;
            }
            List<Schedule> Schedules = new List<Schedule>()
            {
                new Schedule()
                {
                    From = DateTime.Now.AddDays(1).Date + new TimeSpan(startWorkTime,0,0),
                    To = (DateTime.Now.AddDays(1).Date + new TimeSpan(startWorkTime,0,0)).AddHours(8),
                },
                new Schedule()
                {
                    From = DateTime.Now.AddDays(2).Date + new TimeSpan(startWorkTime,0,0),
                    To = (DateTime.Now.AddDays(2).Date + new TimeSpan(startWorkTime,0,0)).AddHours(8),
                },
                new Schedule()
                {
                    From = DateTime.Now.AddDays(3).Date + new TimeSpan(startWorkTime,0,0),
                    To = (DateTime.Now.AddDays(3).Date + new TimeSpan(startWorkTime,0,0)).AddHours(8),
                },
                new Schedule()
                {
                    From = DateTime.Now.AddDays(4).Date + new TimeSpan(startWorkTime,0,0),
                    To = (DateTime.Now.AddDays(4).Date + new TimeSpan(startWorkTime,0,0)).AddHours(8),
                },
                new Schedule()
                {
                    From = DateTime.Now.AddDays(5).Date + new TimeSpan(startWorkTime,0,0),
                    To = (DateTime.Now.AddDays(5).Date + new TimeSpan(startWorkTime,0,0)).AddHours(8),
                }
            };

            return Schedules;

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
