using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Models;

namespace Birth_Clinic.Repository
{
    public interface IParentRepository : IRepository<Parent>
    {
        public IEnumerable<Parent> GetOnGoingBirths();
    }
}
