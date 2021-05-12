using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Models;
using Birth_Clinic.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Birth_Clinic.Display
{
    public class Display
    {
        public void ShowRooms(AppDbContext context)
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(context);

            Console.WriteLine("What room are you searching for?");
            Console.WriteLine("Options:");
            Console.WriteLine("BirthRoom");
            Console.WriteLine("MaternityRoom");
            Console.WriteLine("RestRoom");
            Console.Write("> ");
            var command = Console.ReadLine();
            switch (command)
            {
                case "BirthRoom":
                    Console.Clear();
                    var BirthRooms = unitOfWork.Rooms.GetBirthRooms();
                    foreach (var BirthRoom in BirthRooms)
                    {
                        Console.WriteLine(BirthRoom);
                    }

                    Console.WriteLine("All room listed");
                    break;
                case "MaternityRoom":
                    Console.Clear();
                    var MaternityRooms = unitOfWork.Rooms.GetMatenityRooms();
                    foreach (var MaternityRoom in MaternityRooms)
                    {
                        Console.WriteLine(MaternityRoom);
                    }

                    Console.WriteLine("All room listed");
                    break;
                case "RestRoom":
                    Console.Clear();
                    var RestRooms = unitOfWork.Rooms.GetRestRooms();
                    foreach (var RestRoom in RestRooms)
                    {
                        Console.WriteLine(RestRoom);
                    }

                    Console.WriteLine("All room listed");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid room");
                    break;
            }

        }

        public void ShowClinicianAvailability(AppDbContext context)
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(context);

            var clinicianWorkings = unitOfWork.Clinicians.GetCliniciansWorkingTimes();

            foreach (var clinicianWorking in clinicianWorkings)
            {
                foreach (var s in clinicianWorking.Schedules)
                {
                    if (s.To < DateTime.Now.AddDays(5))
                    {
                        Console.WriteLine(
                            "Type: " + clinicianWorking.ToString().Replace("Birth_Clinic.Models.", "")
                                     + " Name: " + clinicianWorking.FirstName + " " + clinicianWorking.LastName +
                                     " Date: " + s.From + " - " + s.To
                        );
                    }
                }

            }

            Console.WriteLine();
            Console.WriteLine("All clinicians who's at work the five days and their schedules");
        }

        public void ShowRoomsAvailability(AppDbContext context)
        {
            IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork(context);
            DateTime lastTime = new DateTime();
            var Rooms = unitOfWork.Rooms.GetRoomsWithSchedule();
            foreach (var room in Rooms)
            {
                var count = 0;
                var total = room.Schedules.Count;

                foreach (var s in room.Schedules
                    .Where(s => s.From >= DateTime.Now.Date && s.To < DateTime.Now.AddDays(5))
                    .OrderBy(f => f.From.Date.Hour))
                {
                    if (DateTime.Now < s.From && count == 0 && s.From <= DateTime.Now.AddDays(5))
                    {
                        Console.WriteLine("Room: " + room.RoomName + " is available from " + DateTime.Now + " to " +
                                          s.From);
                        lastTime = s.To;
                        count++;
                    }
                    else if (s.From < DateTime.Now.AddDays(5))
                    {
                        Console.WriteLine("Room: " + room.RoomName + " is available from " + lastTime + " to " +
                                          s.From);
                        lastTime = s.To;
                        count++;
                    }

                    if (count == total)
                    {
                        Console.WriteLine("Room: " + room.RoomName + " is available from " + lastTime + " to TBD.");
                    }

                }
            }
        }

        public void checkBirth()
        {
            var context = new AppDbContext();

            var parentsCollection = context.context.GetCollection<Parent>("Parents");

            var parents = parentsCollection.Find(d =>
                d.DueDate >= DateTime.Now.Date && d.DueDate < DateTime.Now.AddDays(3)).ToList();


                //context.Parents.Include(f => f.Father).Include(m => m.Mother).Where(d => d.DueDate >= DateTime.Now.Date && d.DueDate < DateTime.Now.AddDays(3)).OrderBy(p => p.DueDate.Date);

            Console.WriteLine("Incoming duedates in the next three days: ");
            foreach (var p in parents)
            {
                if (p.Father != null)
                {
                    Console.WriteLine(
                        $"{p.DueDate.ToString("dd/MM/yyyy")}, Fathers name is {p.Father.FirstName} and Mothers name is {p.Mother.FirstName}");
                }
                else
                {
                    Console.WriteLine(
                        $"{p.DueDate.ToString("dd/MM/yyyy")}, There is no father and Mothers name is {p.Mother.FirstName}");
                }
            }
        }

        public void ShowOngoingBirths(AppDbContext context)
        {

            var parentsCollection = context.context.GetCollection<Parent>("Parents");

            //var test = parentsCollection.Find(p => p.Father.FirstName == "Peter").FirstOrDefault();

            //Console.WriteLine(test.DueDate);


            var filter1 =
                Builders<Parent>.Filter.And(
                    Builders<Parent>.Filter.Lt(x => x.DueDate, DateTime.Now.AddHours(1)),
                    Builders<Parent>.Filter.Gte(x => x.DueDate, DateTime.Now)
                    );
            

            var parents = parentsCollection
                .Find(filter1).ToList();

            

            //var parents = context.Parents
            //    .Include(f => f.Father)
            //    .Include(m => m.Mother)
            //    .Include(c => c.Clinicians)
            //    .Include(cr => cr.ClinicRooms)
            //    .Where(d => d.DueDate >= DateTime.Now && d.DueDate < DateTime.Now.AddHours(1))
            //    .OrderBy(p => p.DueDate.Date);

            Console.WriteLine("Ongoing births:");

            foreach (var parent in parents)
            {
                Console.WriteLine("Mother: " + parent.Mother.FirstName + " " + parent.Mother.LastName);
                if (parent.Father != null)
                {
                    Console.WriteLine("Father: " + parent.Father.FirstName + " " + parent.Father.LastName);
                }
                
                Console.WriteLine("DueDate: " + parent.DueDate);
                foreach (var c in parent.ClinicRooms)
                {
                    Console.WriteLine("Birthroom: " + c.RoomName);
                }

                Console.Write("Clinicians: ");
                foreach (var c in parent.Clinicians)
                {
                    Console.Write(c.ToString().Replace("Birth_Clinic.Models.", "") + ", Name: " + c.FirstName + " " +
                                  c.LastName + ", ");
                }
            }

        }
    }
}
