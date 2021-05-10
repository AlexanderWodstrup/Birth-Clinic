using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Birth_Clinic.Data
{
    public class AppDbContext
    {
        private MongoClient client = new MongoClient("mongodb://localhost:27017");
        public IMongoDatabase context;

        public AppDbContext()
        {
            context = client.GetDatabase("BirthClinicDb");
        }
    }
}
