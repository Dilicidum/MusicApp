using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private ApplicationDbContext context;

        private IAlbumRepository albumRepository;
        private IArtistRepository artistRepository;
        private IGenreRepository genreRepository;
        private IImageRepository imageRepository;
        private IPlaylistRepository playlistRepository;
        private ISongRepository songRepository;
        private IUserRepository userRepository;
        private IAvatarRepository avatarRepository;
        private IApiSettingRepository apiSettingRepository;
        public IAlbumRepository AlbumRepository => albumRepository = albumRepository ?? new AlbumRepository(context);
        public IArtistRepository ArtistRepository => artistRepository ?? new ArtistRepository(context);
        public IGenreRepository GenreRepository => genreRepository ?? new GenreRepository(context);
        public IImageRepository ImageRepository => imageRepository ?? new ImageRepository(context);
        public IPlaylistRepository PlaylistRepository => playlistRepository ?? new PlaylistRepository(context);
        public ISongRepository SongRepository => songRepository ?? new SongRepository(context);
        public IUserRepository UserRepository => userRepository ?? new UserRepository(context);
        public IAvatarRepository AvatarRepository => avatarRepository ?? new AvatarRepository(context);
        public IApiSettingRepository ApiSettingRepository => apiSettingRepository ?? new Api_SettingRepository(context);
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
