using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Data;
using Birth_Clinic.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Birth_Clinic.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Rooms = new RoomRepository(_context);
            Clinicians = new ClinicianRepository(_context);
            Parents = new ParentRepository(_context);
        }
        public IRoomRepository Rooms { get; private set; }
        public IClinicianRepository Clinicians { get; private set; }
        public IParentRepository Parents { get; private set; }
        
    }
}
