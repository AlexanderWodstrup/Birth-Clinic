using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Birth_Clinic.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Birth_Clinic.Interface
{
    public class ClinicRoom
    {
        public string RoomName { get; set; }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ClinicRoomId { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<Parent> Parents { get; set; }

        public override string ToString()
        {
            return string.Format("Room: {0}.", RoomName);
        }
    }
}
