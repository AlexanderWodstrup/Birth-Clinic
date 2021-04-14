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
                    var BirthRooms = unitOfWork.Rooms.GetBirthRooms();
                    foreach (var BirthRoom in BirthRooms)
                    {
                        Console.WriteLine(BirthRoom);
                    }
                    Console.WriteLine("All room listed");
                    break;
                case "MaternityRoom":
                    rooms = unitOfWork.Rooms.GetMatenityRooms();
                    foreach (var room in rooms)
                    {
                        Console.WriteLine(room);
                    }
                    Console.WriteLine("All room listed");
                    break;
                case "RestRoom":
                    rooms = unitOfWork.Rooms.GetRestRooms();
                    foreach (var room in rooms)
                    {
                        Console.WriteLine(room);
                    }
                    Console.WriteLine("All room listed");
                    break;
            }
        }
    }
}
