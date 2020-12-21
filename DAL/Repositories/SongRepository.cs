using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Repositories
{
    public class SongRepository:Repository<Song>,ISongRepository
    {
        private ApplicationDbContext Context
        {
            get { return context as ApplicationDbContext; }
        }

        public DbSet<Song> dbSet { get; }

        public SongRepository(ApplicationDbContext context) : base(context) { dbSet = Context.Set<Song>(); }

        public async Task<int> GetLastSongId()
        {
            var song = (await context.Songs.ToListAsync()).LastOrDefault();
            int id = -1;
            if (song != null)
            {
                id = song.Id;
            }

            return id;
        }

        public async Task<Song> GetSongInfoById(int id)
        {
            Song song = await context.Songs.Where(c => c.Id == id).FirstOrDefaultAsync();

            return song;
        }

        public async Task<Image> GetSongCoverById(int id)
        {
            Song song = await context.Songs.Where(c => c.Id == id)
                .Include(c => c.Album).ThenInclude(c => c.Cover).FirstOrDefaultAsync();
            Image image = song.Album.Cover;
            return image;
        }

        public async Task<Song> GetSongFullInfoById(int id)
        {
            Song song = await context.Songs.Where(c => c.Id == id).Include(c => c.Album).ThenInclude(c => c.Artists)
                 .Include(c => c.Album).ThenInclude(c => c.Cover).Include(c=>c.User).FirstOrDefaultAsync();

            return song;
        }
    }
}
