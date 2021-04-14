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
        public void AddFatherAndMother()
        {
            using var context = new AppDbContext();
            var rand = new Random();
            Parent parent = new Parent()
            {
                DueDate = DateTime.Now.AddMinutes(10),
                //ClinicRooms = //Lav function der tjekker fra DueDate(-1 time) til from og ser om der er et 4 timers interval hvor der kan tilføjes en parrent? hvis ikke så kig på næste birth room osv osv. hvis ikke der er plads find det birth room der er tættest på duedate
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
                DueDate = DateTime.Now.AddDays(3).AddHours(rand.Next(1,24))

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
                DueDate = DateTime.Now.AddDays(5).AddHours(rand.Next(1, 24)),

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
                DueDate = DateTime.Now.AddDays(2).AddHours(rand.Next(1, 24)),

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
                    Schedules = randomBirthRoomSchedule(),
                };
                unitOfWork.Rooms.Add(BirthRoom);
            }
            unitOfWork.Complete();

            //Seeder 22 maternityrooms i databasen
            for (int i = 1; i < 23; i++)
            {
                ClinicRoom MaternityRoom = new MaternityRoom()
                {
                    RoomName = "Maternity Room - " + i,
                    Schedules = randomMaternityRoomSchedule(),
                };
                unitOfWork.Rooms.Add(MaternityRoom);
            }
            unitOfWork.Complete();

            //Seeder 5 restrooms i databasen
            for (int i = 1; i < 6; i++)
            {
                ClinicRoom RestRoom = new RestRoom()
                {
                    RoomName = "Rest Room - " + i,
                    Schedules = randomRestRoomSchedule(),
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
        public List<Schedule> randomRestRoomSchedule()
        {
            var rand = new Random();
            var randomDay = DateTime.Now.AddDays(rand.Next(0, 5)).AddHours(rand.Next(0, 24));
            List<Schedule> schedules = new List<Schedule>()
            {
                new Schedule()
                {
                    From = randomDay,
                    To = randomDay.AddHours(4),
                },
                new Schedule()
                {
                    From = randomDay.AddHours(5),
                    To = randomDay.AddHours(9),
                },
                new Schedule()
                {
                    From = randomDay.AddHours(10),
                    To = randomDay.AddHours(14),
                }
            };
            return schedules;
        }
        public List<Schedule> randomMaternityRoomSchedule()
        {
            var rand = new Random();
            var randomDay = DateTime.Now.AddDays(rand.Next(0, 5)).AddHours(rand.Next(0, 24));
            List<Schedule> schedules = new List<Schedule>()
            {
                new Schedule()
                {
                    From = randomDay,
                    To = randomDay.AddDays(rand.Next(0,5)).AddHours(rand.Next(1,24))
                },
            };
            return schedules;
        }

        public List<Schedule> randomBirthRoomSchedule()
        {
            var rand = new Random();
            var randomDay = DateTime.Now.AddDays(rand.Next(0, 5)).AddHours(rand.Next(0,24));
            List<Schedule> schedules = new List<Schedule>()
            {

                new Schedule()
                {
                    From = randomDay,
                    To = randomDay.AddHours(rand.Next(1,24))
                },
                new Schedule()
                {
                    From = randomDay.AddDays(2),
                    To = randomDay.AddDays(2).AddHours(rand.Next(1,24)),
                },
                new Schedule()
                {
                    From = randomDay.AddDays(4),
                    To = randomDay.AddDays(4).AddHours(rand.Next(1,24)),
                }
            };
            return schedules;
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
