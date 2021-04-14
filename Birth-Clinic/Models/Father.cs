using System.ComponentModel.DataAnnotations;

namespace Birth_Clinic.Models
{
    public class Father
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int ParentId { get; set; }   
        public Parent Parent { get; set; }
    }
}