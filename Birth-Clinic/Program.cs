using System;
using System.Linq;
using Birth_Clinic.Data;
using Birth_Clinic.DummyData;
using Birth_Clinic.FunctionCalls;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Birth_Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            DatabaseSeed.AddFatherAndMother();


            ClinicFunctions.checkBirth();
        }


    }
}
