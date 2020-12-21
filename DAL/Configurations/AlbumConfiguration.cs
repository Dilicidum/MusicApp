using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class AlbumConfiguration:IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasOne(c => c.Cover).WithOne(c => c.Album).HasForeignKey<Album>(c=>c.Id);
            builder.HasMany(c => c.Songs).WithOne(c => c.Album);
            builder.HasMany(c => c.Artists).WithOne(c => c.Album);
        }
    }
}
