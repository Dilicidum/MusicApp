using DAL.Configurations;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; } 
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<ApiSetting> ApiSettings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AlbumConfiguration());
            builder.ApplyConfiguration(new ArtistConfiguration());
            ///builder.ApplyConfiguration(new AlbumArtistConfiguration());
            builder.ApplyConfiguration(new AlbumGenreConfiguration());
            builder.ApplyConfiguration(new ArtistGenreConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new PlaylistConfiguration());
            builder.ApplyConfiguration(new SongConfiguration());
            builder.ApplyConfiguration(new PlaylistConfiguration());
            builder.ApplyConfiguration(new PlaylistSongConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
            builder.ApplyConfiguration(new UserGenreConfiguration());
            builder.ApplyConfiguration(new AvatarConfiguration());
            builder.Entity<ApiSetting>().Ignore(c => c.IsExpired);
            
            builder.Entity<ApiSetting>().Property(c => c.Type)
                .HasConversion<string>();
        }
    }
}
