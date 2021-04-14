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
                .Where(d => d.DueDate >= DateTime.Now.Date && d.DueDate < DateTime.Now.AddDays(3));

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
    }
}
