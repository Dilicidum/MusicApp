using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models.Responses;
using DAL.Interfaces;
using DAL.Entities;
using BLL.Helpers;
using BLL.Models.DTOs;
using Microsoft.Extensions.Options;
using AutoMapper;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI;
namespace BLL.Services
{
    public class SpotifyService:ISpotifyService
    {
        private IUnitOfWork unitOfWork;
        private SpotifySettings spotifySettings;
        private IMapper mapper;
        public SpotifyService(IUnitOfWork unitOfWork, IOptions<SpotifySettings> spotifySetting,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.spotifySettings = new SpotifySettings()
            {
                ApiKey = spotifySetting.Value.ApiKey,
                ApiSecret = spotifySetting.Value.ApiSecret,
                ApplicationName = spotifySetting.Value.ApplicationName
            };
        }

        public async Task<ApiSettingDTO> GetAcessToken()
        {
            var apiSetting = await unitOfWork.ApiSettingRepository.GetLastStreamingTokenByApiName("Spotify");
            if(apiSetting.RefreshToken != null)
            {
                var newResponse = await new OAuthClient().RequestToken(
                new AuthorizationCodeRefreshRequest(spotifySettings.ApiKey, spotifySettings.ApiSecret, apiSetting.RefreshToken));
                ApiSetting newApiSetting = new ApiSetting()
                {
                    ApiName = "Spotify",
                    Type = TokenType.Streaming,
                    Acess_Token = newResponse.AccessToken,
                    ExpiresIn = newResponse.ExpiresIn,
                    DateOfBeingSet = newResponse.CreatedAt,
                    RefreshToken = apiSetting.RefreshToken
                };
                await unitOfWork.ApiSettingRepository.AddAsync(newApiSetting);
                await unitOfWork.Commit();
                var apiSettingDTO = mapper.Map<ApiSettingDTO>(newApiSetting);
                return apiSettingDTO;
            }

            ApiSettingDTO apiSettingDTO1 = new ApiSettingDTO();
            return apiSettingDTO1;

            
        }

        public async Task<ApiSettingDTO> GetRefreshedToken(string acessToken)
        {
            var apiSetting = await unitOfWork.ApiSettingRepository.GetLastStreamingTokenByApiName("Spotify");

            var newResponse = await new OAuthClient().RequestToken(
            new TokenSwapTokenRequest(new Uri("http://localhost64010/api/Spotify"), apiSetting.RefreshToken));
            ApiSetting newApiSetting = new ApiSetting()
            {
                Acess_Token = newResponse.AccessToken,
                ExpiresIn = newResponse.ExpiresIn,
                DateOfBeingSet = newResponse.CreatedAt,
            };
            await unitOfWork.ApiSettingRepository.AddAsync(newApiSetting);
            await unitOfWork.Commit();
            var apiSettingDTO = mapper.Map<ApiSettingDTO>(newApiSetting);
            return apiSettingDTO;
        }
    }
}
