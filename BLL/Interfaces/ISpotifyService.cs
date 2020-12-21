using System;
using System.Collections.Generic;
using System.Text;
using BLL.Models.Responses;
using System.Threading.Tasks;
using BLL.Models.DTOs;
namespace BLL.Interfaces
{
    public interface ISpotifyService
    {
        Task<ApiSettingDTO> GetAcessToken();
        Task<ApiSettingDTO> GetRefreshedToken(string acessToken);
    }
}
