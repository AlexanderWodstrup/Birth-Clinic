using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using MongoDB.Driver;

namespace Birth_Clinic.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IMongoDatabase _context;

        public Repository(AppDbContext tmp)
        {
            _context = tmp.context;
        }

        //public TEntity Get(int id)
        //{
            
        //    return _context.Set<TEntity>().Find(id);
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return _context.Set<TEntity>().ToList();
        //}

        //public void Add(TEntity entity)
        //{
        //    Console.WriteLine("Entity added");
        //    _context.Set<TEntity>().Add(entity);
        //}

        //public void Remove(TEntity entity)
        //{
        //    _context.Set<TEntity>().Remove(entity);
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _context.Set<TEntity>().Where(predicate);
        //}

        //public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _context.Set<TEntity>().SingleOrDefault(predicate);
        //}
    }
}
