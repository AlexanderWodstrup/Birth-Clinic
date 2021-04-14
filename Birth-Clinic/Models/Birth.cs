using System.ComponentModel.DataAnnotations;

namespace Birth_Clinic.Models
{
    public class Birth
    {
        [Key]

        public int BirthId { get; set; }

        public Child Child { get; set; }

        public Mother Mother { get; set; }

    }
}