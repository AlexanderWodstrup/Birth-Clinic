using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Repository;

namespace Birth_Clinic.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRoomRepository Rooms { get; }
        IClinicianRepository Clinicians { get; }
        IParentRepository Parents { get; }
        
    }
}
