using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class ArtistGenreConfiguration:IEntityTypeConfiguration<ArtistGenre>
    {
        public void Configure(EntityTypeBuilder<ArtistGenre> builder)
        {
            builder.HasKey(c => new { c.ArtistId, c.GenreId });
            builder.HasOne(c => c.Genre).WithMany(c => c.Artists).HasForeignKey(c => c.GenreId);
            builder.HasOne(c => c.Artist).WithMany(c => c.ArtistGenre).HasForeignKey(c => c.ArtistId);

        }
    }
}
