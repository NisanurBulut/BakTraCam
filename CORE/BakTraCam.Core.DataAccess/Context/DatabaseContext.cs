using BakTraCam.Core.DataAccess.Configurations;
using BakTraCam.Core.DataAccess.Repositores;
using BakTraCam.Core.Entity;
using BakTraCam.Service.DataContract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BakTraCam.Core.DataAccess.Context
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<BakimEntity> tBakim { get; set; }
        DbSet<DuyuruEntity> tDuyuru { get; set; }
        DbSet<KullaniciEntity> tKullanici { get; set; }

        [IgnoreDataMember]
        DbSet<BakimModelBasic> Bakims { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly();
            modelBuilder.Entity<SelectModel>().HasNoKey().ToView("SelectModel");
            modelBuilder.ApplyConfiguration(new BakimConfiguration());
            modelBuilder.ApplyConfiguration(new DuyuruConfiguration());
            modelBuilder.ApplyConfiguration(new KullaniciConfiguration());
        }
    }
}
