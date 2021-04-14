using System;
using System.ComponentModel.DataAnnotations;

namespace Birth_Clinic.Models
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }

        public Mother Mom { get; set; }

        public Father Dad { get; set; }

        public DateTime DueDate { get; set; }

        public BirthClinic BirthClinic { get; set; }
    }
}