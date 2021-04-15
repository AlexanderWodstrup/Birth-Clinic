using System;
using System.Linq;
using Birth_Clinic.Data;
using Birth_Clinic.DummyData;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Birth_Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseSeed Seeder = new DatabaseSeed();
            Display.Display display = new Display.Display();
            using (var context = new AppDbContext())
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Commands:");
                    Console.WriteLine("List    ::: List Rooms");
                    Console.WriteLine("CW      ::: See alle clinician working times");
                    Console.WriteLine("Ongoing ::: Births which is due within the hour");
                    Console.WriteLine("Check   ::: Checks planned births for the next 3 days");
                    Console.WriteLine("Clear   ::: Clear database");
                    Console.WriteLine("Seed    ::: Seed database with dummydata");
                    Console.WriteLine("Exit    ::: Closes the program");
                    Console.Write("> ");
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "List" or "list":
                            Console.Clear();
                            display.ShowRooms(context);
                            break;
                        case "CW" or "cw":
                            Console.Clear();
                            display.ShowClinicianAvailability(context);
                            display.ShowRoomsAvailability(context);
                            break;
                        case "Ongoing" or "ongoing":
                            Console.Clear();
                            display.ShowOngoingBirths();
                            
                            break;
                        case "Check" or "check":
                            Console.Clear();
                            display.checkBirth();
                            break;
                        case "Seed" or "seed":
                            Console.Clear();
                            Seeder.AddRooms(context);
                            Seeder.AddWorkers(context);
                            Seeder.AddFatherAndMother();
                            break;
                        case "Clear" or "clear":
                            Console.Clear();
                            Seeder.WipeDatabase(false);
                            break;
                        case "Exit" or "exit":
                            return;
                    }
                } while (true);
            }
            
            
        }


    }
}
