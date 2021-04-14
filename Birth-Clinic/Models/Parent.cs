using System;
using System.ComponentModel.DataAnnotations;

namespace Birth_Clinic.Models
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }

        public string MotherName { get; set; }
        public Mother Mother { get; set; }

        public string FatherName { get; set; }
        public Father Father { get; set; }

        public DateTime DueDate { get; set; }
        public BirthClinic BirthClinic { get; set; }
    }
}