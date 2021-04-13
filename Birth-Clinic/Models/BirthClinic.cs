using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Birth_Clinic.Models
{
    public class BirthClinic
    {
        public string Name { get; set; }
        public List<IClinicRoom> ClinicRooms { get; set; }
    }
}
