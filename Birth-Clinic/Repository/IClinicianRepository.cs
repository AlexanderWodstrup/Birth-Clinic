using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;

namespace Birth_Clinic.Repository
{
    public interface IClinicianRepository : IRepository<Clinician>
    {
        public IEnumerable<Clinician> GetCliniciansWorkingTimes();

        public List<Clinician> GetCliniciansAtWorkDuringDuedate();

        public void Add(Clinician entity);
    }
}
