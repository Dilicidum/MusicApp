using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class AlbumArtistConfiguration:IEntityTypeConfiguration<AlbumArtist>
    {
        public void Configure(EntityTypeBuilder<AlbumArtist> builder)
        {
            builder.HasKey(c => new { c.AlbumId, c.ArtistId });
            //builder.HasOne(c => c.Album).WithMany(c => c.Artists).HasForeignKey(c=>c.AlbumId);
            //builder.HasOne(c => c.Artist).WithMany(c => c.Albums).HasForeignKey(c=>c.ArtistId);
        }
    }
}
