using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Microsoft.EntityFrameworkCore;

namespace Birth_Clinic.FunctionCalls
{
    public class ClinicFunctions
    {
        public static void checkBirth()
        {
            using var context = new AppDbContext();

            var parents = context.Parents
                .Include(f => f.Father)
                .Include(m => m.Mother)
                .Where(d => d.DueDate >= DateTime.Now.Date && d.DueDate < DateTime.Now.AddDays(3))
                .OrderBy(p => p.DueDate.Date);

            Console.WriteLine("Incoming duedates in the next three days: ");
            foreach (var p in parents)
            {
                if (p.Father != null)
                {
                    Console.WriteLine($"{p.DueDate.ToString("dd/MM/yyyy")}, Fathers name is {p.Father.FirstName} and Mothers name is {p.Mother.FirstName}");
                }
                else
                {
                    Console.WriteLine($"{p.DueDate.ToString("dd/MM/yyyy")}, There is no father and Mothers name is {p.Mother.FirstName}");
                }
            }
        }

        public static void ShowOngoingBirths()
        {
            using var context = new AppDbContext();

            var parents = context.Parents
                .Include(f => f.Father)
                .Include(m => m.Mother)
                .Include(c => c.Clinicians)
                .Include(cr => cr.ClinicRooms)
                .Where(d => d.DueDate >= DateTime.Now && d.DueDate < DateTime.Now.AddHours(1))
                .OrderBy(p => p.DueDate.Date);

            foreach (var parent in parents)
            {
                Console.WriteLine("Mother: " + parent.Mother.FirstName + " " + parent.Mother.LastName);
                Console.WriteLine("Father: " + parent.Father.FirstName + " " + parent.Father.LastName);
                Console.WriteLine("DueDate: " + parent.DueDate);
                foreach (var c in parent.ClinicRooms)
                {
                    Console.WriteLine("Birthroom: " + c.RoomName);
                }
                Console.Write("Clinicians: ");
                foreach (var c in parent.Clinicians)
                {
                    Console.Write(c.ToString().Replace("Birth_Clinic.Models.", "") + ", Name: " + c.FirstName + " " + c.LastName + ", ");
                }
            }

           

        }

    }
}
