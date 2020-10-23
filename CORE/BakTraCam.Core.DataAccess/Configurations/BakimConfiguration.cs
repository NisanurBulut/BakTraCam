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
            builder.ToTable("tBakim","dbo");
            builder.HasKey(a=>a.Id);
        }
    }
}
