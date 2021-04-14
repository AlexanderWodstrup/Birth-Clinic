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
    }
}
