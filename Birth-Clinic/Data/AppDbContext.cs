using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birth_Clinic.Interface;
using Birth_Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Birth_Clinic.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<ClinicRoom> Rooms { get; set; }
        public DbSet<Clinician> Clinicians { get; set; }
        public DbSet<Parent> Parents { get; set; }
        protected override void OnModelCreating(ModelBuilder ob)
        {
            ob.Entity<Clinician>().HasKey(c => c.ClinicianId);

            ob.Entity<ClinicRoom>().HasKey(cr => cr.RoomId);

            ob.Entity<Father>().HasKey(f => new {f.FirstName, f.LastName});
            ob.Entity<Mother>().HasKey(m => new {m.FirstName, m.LastName});

            ob.Entity<Parent>().HasKey(p => p.ParentId);

            ob.Entity<Parent>()
                .HasOne<Father>(p => p.Father)
                .WithOne(f => f.Parent);

            ob.Entity<Parent>()
                .HasOne<Mother>(p => p.Mother)
                .WithOne(f => f.Parent);


            // Skriv i rapport/kode, at det kun virkede med dette hack
            ob.Entity<BirthRoom>();
            ob.Entity<MaternityRoom>();
            ob.Entity<RestRoom>();
            ob.Entity<Doctor>();
            ob.Entity<MidWife>();
            ob.Entity<Nurse>();
            ob.Entity<Secretary>();
            ob.Entity<SOSU_Assistent>();
        }
    }
}
