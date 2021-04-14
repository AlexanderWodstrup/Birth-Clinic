using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Birth_Clinic.Interface;

namespace Birth_Clinic.Models
{
    public class Parent
    {
        public int ParentId { get; set; }
        public Mother Mother { get; set; }
        public Father Father { get; set; }
        public DateTime DueDate { get; set; }
        public List<Clinician> Clinicians { get; set; }
        public List<ClinicRoom> ClinicRooms { get; set; }
    }
}