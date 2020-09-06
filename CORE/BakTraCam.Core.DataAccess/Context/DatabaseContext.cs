using BakTraCam.Core.DataAccess.Repositores;
using BakTraCam.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.DataAccess.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<BakimEntity> tBakim { get; set; }
        DbSet<BakimciEntity> tBakimci { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly();
           
        }
    }
}
