using System;
using System.ComponentModel.DataAnnotations;

namespace Birth_Clinic.Models
{
    public class Child
    {
        [Key]

        public int ChildId { get; set; }

        public Parent Parents { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Birth Birth { get; set; }
    }
}