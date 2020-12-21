using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Interfaces
{
    public interface ISongRepository:IRepository<Song>
    {
        Task<int> GetLastSongId();

        Task<Song> GetSongInfoById(int id);

        Task<Image> GetSongCoverById(int id);

        Task<Song> GetSongFullInfoById(int id);
    }
}
