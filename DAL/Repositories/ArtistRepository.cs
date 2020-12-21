using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ArtistRepository:Repository<Artist>,IArtistRepository
    {
        private ApplicationDbContext Context
        {
            get { return context as ApplicationDbContext; }
        }

        public DbSet<Artist> dbSet;

        public ArtistRepository(ApplicationDbContext context) : base(context) { dbSet = Context.Set<Artist>(); }
    }
}
