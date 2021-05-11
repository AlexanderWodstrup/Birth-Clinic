using System;
using Birth_Clinic.Models;
using MongoDB.Driver;

namespace Birth_Clinic_Mongo
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient _client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase context = _client.GetDatabase("BirthClinicTest-Db");

            var _parents = context.GetCollection<Parent>("Parents");

            var parent = new Parent(
            {
                Mother = new Mother({FirstName = "Din",LastName = "Mor",})
            })
            

        }
    }
}
