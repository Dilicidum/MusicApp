using BLL.Models.DTOs;
using BLL.Models.Resources;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
namespace BLL.Interfaces
{
    public interface ISongService
    {
        Task AddSong(SongUploadResource songUploadResource);
        Task<IEnumerable<SongDTO>> GetSongs();
        Task<GetResourceResult> GetSongCoverById(int id);
        Task<SongInfo> GetSongInfoById(int id);
        Task<GetResourceResult> GetSongSerialized(int id);
        Task<ApiSettingDTO> GetApiToken(string Name);
    }
}
