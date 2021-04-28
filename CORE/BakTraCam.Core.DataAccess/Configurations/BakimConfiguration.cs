using BakTraCam.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.DataAccess.Configurations
{
    public class BakimConfiguration : IEntityTypeConfiguration<BakimEntity>
    {
        public void Configure(EntityTypeBuilder<BakimEntity> builder)
        {
            builder.ToTable("tBakim", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Ad).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Aciklama).IsRequired().HasMaxLength(100);
            builder.Property(a => a.BaslangicTarihi).IsRequired();
            builder.Property(a => a.Gerceklestiren1).IsRequired();
            builder.Property(a => a.Gerceklestiren2).IsRequired();
            builder.Property(a => a.Gerceklestiren3).IsRequired();
            builder.Property(a => a.Gerceklestiren4).IsRequired();
            builder.Property(a => a.Sorumlu1).IsRequired();
            builder.Property(a => a.Sorumlu2).IsRequired();
            builder.Property(a => a.Tip).IsRequired();
            builder.Property(a => a.Durum).IsRequired();
        }
    }
}
