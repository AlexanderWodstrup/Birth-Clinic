﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        protected override void OnModelCreating(ModelBuilder ob)
        {
            ob.Entity<Mother>().HasKey(m => new {m.FirstName, m.LastName});

            ob.Entity<Father>().HasKey(f => new {f.FirstName, f.LastName});
        }
    }
}
