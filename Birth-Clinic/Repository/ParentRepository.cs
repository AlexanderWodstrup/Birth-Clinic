using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Birth_Clinic.Repository
{
    public class ParentRepository : Repository<Parent>, IParentRepository
    {
        private IMongoCollection<Parent> ParentCollection;
        public ParentRepository(AppDbContext context) : base(context)
        {
            ParentCollection = context.context.GetCollection<Parent>("Parents");
        }

        public IEnumerable<Parent> GetOnGoingBirths()
        {
            return ParentCollection.Find(p => true).ToList();
            //return _context.Parents.Include(p => p.Mother).Include(p => p.Father).ToList();
        }
    }
}
