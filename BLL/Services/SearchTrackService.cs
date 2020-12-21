using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using BLL.Interfaces;
using System.Threading.Tasks;
using BLL.Models.DTOs;
using Microsoft.Extensions.Options;
using BLL.Helpers;
using SpotifyAPI.Web;
using AutoMapper;
using DAL.Entities;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Http;
using BLL.Models.Responses;

namespace BLL.Services
{
    public class SearchTrackService:ISearchTrackService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private SpotifySettings spotifySetting;
        public SearchTrackService(IUnitOfWork unitOfWork,IOptions<SpotifySettings> spotifySetting,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.spotifySetting = new SpotifySettings()
            {
                ApiKey = spotifySetting.Value.ApiKey,
                ApiSecret = spotifySetting.Value.ApiSecret,
                ApplicationName = spotifySetting.Value.ApplicationName
            };
        }

        public async Task<IEnumerable<SongDTO>> GetTracks(string query, string type, 
            string market = "", int limit = 5, int offset = 0)
        {
            string acessToken = await GetSpotifyAcessTokenAsync();
            var spotify = new SpotifyClient(acessToken);
            
            TrackRequest trackRequest = new TrackRequest();
            
            SearchRequest searchRequest = new SearchRequest(SearchRequest.Types.Track, query)
            {
                Market = market,
                Limit = limit,
                Offset = offset,
                IncludeExternal = SearchRequest.IncludeExternals.Audio
            };
            
            var result = await spotify.Search.Item(searchRequest);

            List<SongDTO> songs = new List<SongDTO>();
            
            foreach (var i in result.Tracks.Items)
            {
                var song = mapper.Map<SongDTO>(i);
                songs.Add(song);
            }
            
            return songs;
        }

        public async Task<string> GetSpotifyAcessTokenAsync()
        {
            //UserResponse userResponse = new UserResponse();
            var currentApiSettings = await unitOfWork.ApiSettingRepository.GetLastStreamingTokenByApiName("Spotify");
            if(currentApiSettings != null && currentApiSettings.Type == TokenType.Application)
            {
                //userResponse.TimeTokenExpired = DateTime.Parse(currentApiSettings.ExpiresIn.ToString());
                //userResponse.Token = currentApiSettings.Acess_Token;
                //userResponse.UserId = currentApiSettings.
                return currentApiSettings.Acess_Token;
            }
            
            var config = SpotifyClientConfig.CreateDefault();
            var request = new ClientCredentialsRequest(spotifySetting.ApiKey, spotifySetting.ApiSecret);
            var response = await new OAuthClient(config).RequestToken(request);

            ApiSetting apiSetting = new ApiSetting()
            {
                ApiName = "Spotify",
                DateOfBeingSet = DateTime.Now,
                Acess_Token = response.AccessToken,
                Type = TokenType.Application,
                ExpiresIn = response.ExpiresIn,
            };
            
            await unitOfWork.ApiSettingRepository.AddAsync(apiSetting);
            await unitOfWork.Commit();
            return response.AccessToken;
        }
    }
}
