using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class SongConfiguration:IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasOne(c => c.Album).WithMany(c => c.Songs);
            builder.HasOne(c => c.User).WithMany(c => c.SongsUploaded).HasForeignKey(c=>c.UserId);
        }
    }
}
