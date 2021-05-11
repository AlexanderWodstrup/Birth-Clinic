using System;
using Birth_Clinic.Data;
using Birth_Clinic.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Birth_Clinic.Models;
using MongoDB.Driver;

namespace Birth_Clinic.Repository
{
    public class ClinicianRepository : Repository<Clinician>, IClinicianRepository
    {
        private IMongoCollection<Clinician> ClinicianCollection;
        public ClinicianRepository(AppDbContext context) : base(context)
        {
            var ClinicianCollection = context.context.GetCollection<Clinician>("Clinician");
        }

        public IEnumerable<Clinician> GetCliniciansWorkingTimes()
        {
            return ClinicianCollection.Find(c => true).ToList();
            //return _context.Clinicians.Include(c => c.Schedules).ToList();
        }

        public List<Clinician> GetCliniciansAtWorkDuringDuedate()
        {
            return ClinicianCollection.Find(c => true).ToList();
            //return _context.Clinicians.Include(c => c.Schedules).ToList();
        }

        //public TEntity Get(int id)
        //{

        //    return _context.Set<TEntity>().Find(id);
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return _context.Set<TEntity>().ToList();
        //}

        public void Add(Clinician entity)
        {
            Console.WriteLine("Entity added");
            ClinicianCollection.InsertOne(entity);
        }

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
