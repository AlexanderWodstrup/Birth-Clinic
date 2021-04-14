using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Birth_Clinic.Repository
{
    public class ParentRepository : Repository<Parent>, IParentRepository
    {
        public ParentRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Parent> GetOnGoingBirths()
        {
            return _context.Parents.Include(p => p.Mother).Include(p => p.Father).ToList();
        }
    }
}
