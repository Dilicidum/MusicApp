using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository AlbumRepository { get; }
        IArtistRepository ArtistRepository { get; }
        IGenreRepository GenreRepository { get; }
        IImageRepository ImageRepository { get; }
        IPlaylistRepository PlaylistRepository { get; }
        ISongRepository SongRepository { get; }
        IUserRepository UserRepository { get; }
        IAvatarRepository AvatarRepository { get; }
        IApiSettingRepository ApiSettingRepository { get; }
        Task<int> Commit();
    }
}
