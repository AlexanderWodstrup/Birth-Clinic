using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Interface;
using Microsoft.EntityFrameworkCore;

namespace Birth_Clinic.Repository
{
    public class ClinicianRepository : Repository<Clinician>, IClinicianRepository
    {
        public ClinicianRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Clinician> GetCliniciansWorkingTimes()
        {
            return _context.Clinicians.Include(c => c.Schedules).ToList();
        }

    }
}
