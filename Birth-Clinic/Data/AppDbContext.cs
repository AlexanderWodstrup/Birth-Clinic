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

        public IMongoDatabase GetMongoContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            return client.GetDatabase("BirthClinicDb");

        }
    }
}
