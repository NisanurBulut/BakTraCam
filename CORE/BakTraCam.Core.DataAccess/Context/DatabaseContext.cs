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
        DbSet<BakimEntity> Bakims { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly();
           
        }
    }
}
