using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;
using MongoDB.Bson.Serialization.Attributes;

namespace Birth_Clinic.Models
{
    public class Schedule
    {
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime From { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime To { get; set; }
    }
}
