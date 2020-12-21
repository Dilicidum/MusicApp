using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class AlbumGenreConfiguration:IEntityTypeConfiguration<AlbumGenre>
    {
        public void Configure(EntityTypeBuilder<AlbumGenre> builder)
        {
            builder.HasKey(c => new { c.AlbumId, c.GenreId });
            builder.HasOne(c => c.Genre).WithMany(c => c.Albums).HasForeignKey(c => c.GenreId);
            builder.HasOne(c => c.Album).WithMany(c => c.Genres).HasForeignKey(c => c.AlbumId);
        }
    }
}
