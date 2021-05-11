using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Birth_Clinic.Interface
{
    public class Clinician
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClinicianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
