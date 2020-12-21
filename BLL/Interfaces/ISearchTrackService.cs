using System;
using System.Collections.Generic;
using System.Text;
using BLL.Models.DTOs;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using BLL.Models.Responses;
namespace BLL.Interfaces
{
   public interface ISearchTrackService
    {
        Task<IEnumerable<SongDTO>> GetTracks(string query,string type,string market="US",
            int limit = 5,int offset=0);

        Task<string> GetSpotifyAcessTokenAsync();
    }
}
