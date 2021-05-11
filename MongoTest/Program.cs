using System;
using Birth_Clinic.Models;
using MongoDB.Driver;

namespace MongoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                MongoClient _client = new MongoClient("mongodb://localhost:27017");
                IMongoDatabase context = _client.GetDatabase("BirthClinicTest-Db");

                var _parents = context.GetCollection<Parent>("Parents");

                var parent = new Parent()
                {
                    Mother = new Mother(){FirstName = "Din",LastName = "Mor"},
                    Father = new Father(){FirstName = "Din",LastName = "Far"},
                    DueDate = DateTime.Now.AddDays(2),
                    Child = new Child() {DateOfBirth = DateTime.Now.Date.AddDays(2),FirstName = "Din",LastName = "Søn"},
                };

                _parents.InsertOne(parent);


            }
}
    }
}
