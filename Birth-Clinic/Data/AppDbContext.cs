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
        protected override void OnModelCreating(ModelBuilder ob)
        {
            ob.Entity<Clinician>().HasKey(c => new { c.FirstName, c.LastName });
            ob.Entity<ClinicRoom>().HasKey(bc => bc.RoomId);
            ob.Entity<BirthClinic>().HasKey(bc => bc.Name);
            ob.Entity<BirthRoom>();
            ob.Entity<RestRoom>();
            ob.Entity<MaternityRoom>();
            ob.Entity<MidWife>();
            ob.Entity<Doctor>();
            ob.Entity<Nurse>();
            ob.Entity<Secretary>();
            ob.Entity<SOSU_Assistent>();
        }
    }
}
