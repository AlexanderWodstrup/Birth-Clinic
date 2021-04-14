using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.UnitOfWork;

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
            
            var Rooms = unitOfWork.Rooms.GetRoomsWithSchedule();
            foreach (var room in Rooms)
            {
                var count = 0;
                var total = room.Schedules.Count;
                DateTime lastTime;
                foreach (var s in room.Schedules)
                {
                    while (count < total)
                    {
                        if (DateTime.Now < s.From && count == 0)
                        {
                            Console.WriteLine("Room: " + room.RoomName + " is available from " + DateTime.Now + " to " + s.From);
                            lastTime = s.To;
                        }

                        if (DateTime.Now < s.From && count > 0)
                        {
                            Console.WriteLine("Room: " + room.RoomName + " is available from " + lastTime.ToString() + " to " + s.From);
                            lastTime = s.To;
                        }
                        count++;
                    }
                }
            }
        }
    }
}
