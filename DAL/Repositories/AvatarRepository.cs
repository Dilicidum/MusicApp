using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories
{
    public class AvatarRepository: Repository<Avatar>,IAvatarRepository
    {
        private ApplicationDbContext Context
        {
            get { return context as ApplicationDbContext; }
        }

        public DbSet<Avatar> dbSet { get; }

        public AvatarRepository(ApplicationDbContext context) : base(context) { dbSet = Context.Set<Avatar>(); }
    }
}
