using BakTraCam.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.DataAccess.Configurations
{
    public class DuyuruConfiguration : IEntityTypeConfiguration<DuyuruEntity>
    {
        public void Configure(EntityTypeBuilder<DuyuruEntity> builder)
        {
            builder.ToTable("tDuyuru", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Aciklama).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Tarihi).IsRequired();
        }
    }
}
