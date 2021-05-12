using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Interface;
using Birth_Clinic.Models;
using Birth_Clinic.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;

namespace Birth_Clinic.DummyData
{
    public class DatabaseSeed
    {
        public void AddFatherAndMother(AppDbContext context)
        {

            var collection = context.context.GetCollection<Parent>("Parents");
            var rand = new Random();

            Father newFather = new Father()
            {
                FirstName = "Peter",
                LastName = "Wann",
            };

            Mother newMother = new Mother()
            {
                FirstName = "Line",
                LastName = "Design",
            };

            Parent parent = new Parent()
            {
                Father = newFather,
                Mother = newMother,
                DueDate = DateTime.Now.AddMinutes(10),
            };

            parent.Clinicians = availableClinicians(parent.DueDate, context);
            parent.ClinicRooms = availableBirthRoom(parent.DueDate, context);

            Console.WriteLine(DateTime.Now);
            Console.WriteLine(parent.DueDate);
            collection.InsertOne(parent);


            var date2 = DateTime.Now.AddDays(1);
            Parent parent2 = new Parent()
            {
                DueDate = date2,
                Clinicians = availableClinicians(date2, context),
                ClinicRooms = availableBirthRoom(date2, context),

            };

            Father newFather2 = new Father()
            {
                FirstName = "Alexander",
                LastName = "Wodstrup",

            };

            Mother newMother2 = new Mother()
            {
                FirstName = "Ursula",
                LastName = "Flemmingsen",
            };
            parent2.Father = newFather2;
            parent2.Mother = newMother2;

            collection.InsertOne(parent2);

            var date3 = DateTime.Now.AddDays(2);
            Parent parent3 = new Parent()
            {
                DueDate = date3,
                Clinicians = availableClinicians(date3, context),
                ClinicRooms = availableBirthRoom(date3, context),

            };

            Father newFather3 = new Father()
            {
                FirstName = "Palle",
                LastName = "Nielsen",
            };

            Mother newMother3 = new Mother()
            {
                FirstName = "Francesca",
                LastName = "Musollini",
            };
            parent3.Father = newFather3;
            parent3.Mother = newMother3;

            collection.InsertOne(parent3);

            var date4 = DateTime.Now.AddDays(3);
            Parent parent4 = new Parent()
            {
                DueDate = date4,
                Clinicians = availableClinicians(date4, context),
                ClinicRooms = availableBirthRoom(date4, context),
            };

            Mother newMother4 = new Mother()
            {
                FirstName = "Karen",
                LastName = "Ingemann",
            };

            parent4.Mother = newMother4;

            collection.InsertOne(parent4);

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
                    Schedules = randomWorkSchedule(i, "midwife"),
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
                    Schedules = randomWorkSchedule(i, "nurse"),
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
                    Schedules = randomWorkSchedule(i, "sosu"),
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
                    Schedules = randomWorkSchedule(i, "doctor"),
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
                    Schedules = randomWorkSchedule(i, "secretary"),
                };
                unitOfWork.Clinicians.Add(Secretary);
            }

            Console.WriteLine("Workers seeded");

        }

        public List<ClinicRoom> availableBirthRoom(DateTime DueDate, AppDbContext context)
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(context);

            var birthroom = unitOfWork.Rooms.GetRoomsWithSchedule().Where(c => c is BirthRoom);

            List<ClinicRoom> newBirtRooms = new List<ClinicRoom>();

            var count = 0;
            foreach (var b in birthroom)
            {
                //var v in b.Schedules.OrderByDescending(c => c.ScheduleId)
                foreach (var v in b.Schedules)
                {
                    if (v.From < DueDate && v.To >= DueDate)
                    {
                    }
                    else if (count == 0)
                    {
                        count++;
                        newBirtRooms.Add(b);
                        //var newSchedule = new Schedule()
                        //{
                        //    From = DueDate.AddDays(-1000),
                        //    To = DueDate.AddDays(1000),
                        //};
                        //b.Schedules.Add(newSchedule); 
                    }
                    break;
                }
            }
            return newBirtRooms;
        }
        public List<Clinician> availableClinicians(DateTime DueDate, AppDbContext context)
        {


            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(context);
            var midwife = unitOfWork.Clinicians.GetCliniciansWorkingTimes().Where(c => c is MidWife).ToList();
            var doctor = unitOfWork.Clinicians.GetCliniciansWorkingTimes().Where(c => c is Doctor).ToList();
            var nurse = unitOfWork.Clinicians.GetCliniciansWorkingTimes().Where(c => c is Nurse).ToList();
            var sosu = unitOfWork.Clinicians.GetCliniciansWorkingTimes().Where(c => c is SOSU_Assistent).ToList();

            List<Clinician> newClinicians = new List<Clinician>();

            var count = 0;
            foreach (var m in midwife)
            {
                foreach (var v in m.Schedules)
                {
                    if (v.From < DueDate && v.To >= DueDate && count == 0)
                    {
                        newClinicians.Add(m);
                        count++;
                    }
                }
            }

            count = 0;
            foreach (var m in doctor)
            {

                foreach (var v in m.Schedules)
                {
                    if (v.From < DueDate && v.To >= DueDate && count == 0)
                    {
                        newClinicians.Add(m);
                        count++;
                    }

                }
            }

            count = 0;
            foreach (var m in nurse)
            {

                foreach (var v in m.Schedules)
                {
                    if (v.From < DueDate && v.To >= DueDate && count == 0)
                    {
                        newClinicians.Add(m);
                        count++;
                    }

                }
            }

            count = 0;
            foreach (var m in sosu)
            {

                foreach (var v in m.Schedules)
                {
                    if (v.From < DueDate && v.To >= DueDate && count == 0)
                    {
                        newClinicians.Add(m);
                        count++;
                    }

                }
            }

            return newClinicians;

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
            var randomDay = DateTime.Now.AddDays(rand.Next(0, 5)).AddHours(rand.Next(0, 24));
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




        public List<Schedule> randomWorkSchedule(int i, string worker)
        {
            int startWorkTime;
            int morning;
            int midday;
            if (worker == "midwife")
            {
                morning = 3;
                midday = 6;
            }
            else if (worker == "doctor")
            {
                morning = 1;
                midday = 1;
            }
            else if (worker == "secretary")
            {
                morning = 1;
                midday = 0;
            }
            else
            {
                morning = 6;
                midday = 12;
            }

            if (i <= morning)
            {
                startWorkTime = 8;
            }
            else if (i <= midday && i > morning)
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
                    From = DateTime.Now.AddDays(0).Date + new TimeSpan(startWorkTime,0,0),
                    To = (DateTime.Now.AddDays(0).Date + new TimeSpan(startWorkTime,0,0)).AddHours(8),
                },
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
                }
            };

            return Schedules;

        }

        public bool WipeDatabase(AppDbContext db)
        {
            db.context.Client.DropDatabase("BirthClinicDb");

            Console.WriteLine("Database cleared");

            return true;
        }
    }
}
