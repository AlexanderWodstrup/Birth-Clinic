using System;
using System.ComponentModel.DataAnnotations;

namespace Birth_Clinic.Models
{
    public class Child
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}