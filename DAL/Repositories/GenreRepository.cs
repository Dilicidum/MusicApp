using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class GenreRepository:Repository<Genre>,IGenreRepository
    {
        public ApplicationDbContext Context
        {
            get { return context; }
        }

        public DbSet<Genre> dbSet { get; }

        public GenreRepository(ApplicationDbContext context):base(context)
        {
            dbSet = Context.Set<Genre>();
        }
    }
}
