using BakTraCam.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Core.DataAccess.Configurations
{
    public class KullaniciConfiguration : IEntityTypeConfiguration<KullaniciEntity>
    {
        public void Configure(EntityTypeBuilder<KullaniciEntity> builder)
        {
            builder.ToTable("tDuyuru", "dbo");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Ad).IsRequired().HasMaxLength(50);
            builder.Property(a => a.UnvanId).IsRequired();
        }
    }
}
