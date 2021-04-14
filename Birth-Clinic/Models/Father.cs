using System.ComponentModel.DataAnnotations;

namespace Birth_Clinic.Models
{
    public class Father
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Parent parent { get; set; }
    }
}