using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Birth_Clinic.Models
{
    public class Father
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int FatherId { get; set; }   
        [ForeignKey("ParentId")]
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
    }
}