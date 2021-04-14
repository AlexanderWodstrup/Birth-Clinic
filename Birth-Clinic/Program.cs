using System;
using Birth_Clinic.Data;
using Birth_Clinic.DummyData;

namespace Birth_Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseSeed Seeder = new DatabaseSeed();
            using (var context = new AppDbContext())
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Commands:");
                    Console.WriteLine("Clear   ::: Clear database");
                    Console.WriteLine("Seed    ::: Seed database with dummydata");
                    Console.WriteLine("Exit    ::: Closes the program");
                    Console.Write("> ");
                    var command = Console.ReadLine();
                    switch (command)
                    {
                        case "Seed" or "seed":
                            Console.Clear();
                            Seeder.AddRooms(context);
                            Seeder.AddWorkers(context);
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
