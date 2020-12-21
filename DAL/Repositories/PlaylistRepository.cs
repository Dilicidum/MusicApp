using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class PlaylistRepository:Repository<Playlist>,IPlaylistRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<Playlist> dbSet { get; }

        public PlaylistRepository(ApplicationDbContext context):base(context) { dbSet = context.Set<Playlist>(); }
    }
}
