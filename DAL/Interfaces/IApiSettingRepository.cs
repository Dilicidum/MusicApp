using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using System.Threading.Tasks;
namespace DAL.Interfaces
{
    public interface IApiSettingRepository:IRepository<ApiSetting>
    {
        Task<ApiSetting> GetLastApplicationTokenByApiName(string ApiName);
        Task<ApiSetting> GetLastSpotifyApiTokenByType(TokenType type, string ApiName = "Spotify");
        Task<ApiSetting> GetLastStreamingTokenByApiName(string ApiName = "Spotify");
    }
}
