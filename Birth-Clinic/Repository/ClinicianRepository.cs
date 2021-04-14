using System;
using Birth_Clinic.Data;
using Birth_Clinic.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Birth_Clinic.Repository
{
    public class ClinicianRepository : Repository<Clinician>, IClinicianRepository
    {
        public ClinicianRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Clinician> GetCliniciansWorkingTimes()
        {
            return _context.Clinicians.Include(c => c.Schedules).ToList();
        }

        public List<Clinician> GetCliniciansAtWorkDuringDuedate()
        {
         
            return _context.Clinicians.Include(c => c.Schedules).ToList();
        }

    }
}
