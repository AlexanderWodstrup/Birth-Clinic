using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Birth_Clinic.Interface;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Birth_Clinic.Models
{
    public class Parent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ParentId { get; set; }
        [Required]
        [BsonElement("Mother")]
        public Mother Mother { get; set; }
        [BsonElement("Father")]
        public Father Father { get; set; }
        [BsonElement("Child")]
        public Child Child { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DueDate { get; set; }
        public List<Clinician> Clinicians { get; set; }
        public List<ClinicRoom> ClinicRooms { get; set; }
    }
}