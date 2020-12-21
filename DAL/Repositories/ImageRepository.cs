using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class ImageRepository:Repository<Image>,IImageRepository
    {
        private ApplicationDbContext Context
        {
            get { return context as ApplicationDbContext; }
        }

        public DbSet<Image> dbSet { get; }

        public ImageRepository(ApplicationDbContext context) : base(context) { dbSet = Context.Set<Image>(); }
    }
}
