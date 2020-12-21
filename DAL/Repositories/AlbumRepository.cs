using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AlbumRepository: Repository<Album>, IAlbumRepository
    {
        private ApplicationDbContext Context
        {
            get { return context as ApplicationDbContext; }
        }
        
        public DbSet<Album> dbSet { get; }

        public AlbumRepository(ApplicationDbContext context) : base(context) { dbSet = Context.Set<Album>(); }
    }
}
