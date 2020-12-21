using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class PlaylistSongConfiguration:IEntityTypeConfiguration<PlaylistSong>
    {
        public void Configure(EntityTypeBuilder<PlaylistSong> builder)
        {
            builder.HasKey(c => new { c.PlaylistId, c.SongId });
            builder.HasOne(c => c.Song).WithMany(c => c.Playlists).HasForeignKey(c => c.SongId);
            builder.HasOne(c => c.Playlist).WithMany(c => c.PlaylistSongs).HasForeignKey(c => c.PlaylistId);
        }
    }
}
