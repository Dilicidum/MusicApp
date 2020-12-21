using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using BLL.Helpers;
using SpotifyAPI.Web;
using BLL.Interfaces;
using BLL.Models.Responses;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartsController:ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly LastFmSetting lastFmSetting;
        private readonly SpotifySettings spotifySettings;
        private readonly ISearchTrackService searchTrackService;

        public ChartsController(IOptions<LastFmSetting> options,IHttpClientFactory httpClientFactory
            ,IOptions<SpotifySettings> optionsSpotify,ISearchTrackService searchTrackService)
        {
            this.httpClientFactory = httpClientFactory;
            this.searchTrackService = searchTrackService;
            lastFmSetting = new LastFmSetting()
            {
                ApiKey = options.Value.ApiKey,
                ApplicationName = options.Value.ApplicationName,
                SecretKey = options.Value.SecretKey
            };

            spotifySettings = new SpotifySettings()
            {
                ApiKey = optionsSpotify.Value.ApiKey,
                ApiSecret = optionsSpotify.Value.ApiSecret,
                ApplicationName = optionsSpotify.Value.ApplicationName
            };
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            string code = "AQDzPOzp3TnEO4UvI_YTyxKEFpAOSGvfug90KgPZWNGij_DZanrgv6ma8XcbIxYMcVmp7IRmoGic5mI0EKC94R3tA3imDeC6RCxajew0KDQWcrj42uhEjAZjIUbBlj6Vodrxjv9n1l43Uy74EvR_oL-Ww9k8MO0g8SXeB93Xkcn63dVYBr25CntSlk0ixf1UcsNShxyOfrQvFDRHRHvqhfshijKSuNjfhw";
            //var res = await searchTrackService.GetSpotifyAcessTokenAsync();
            OAuthClient oAuthClient = new OAuthClient();
            
            Uri uri = new Uri("http://localhost:4200");
            AuthorizationCodeTokenRequest authorizationCodeTokenRequest = new AuthorizationCodeTokenRequest(
                this.spotifySettings.ApiKey,
                this.spotifySettings.ApiSecret,
                code,
                uri);
            var response = await oAuthClient.RequestToken(authorizationCodeTokenRequest);
            //var newResponse = await new OAuthClient().RequestToken(
            //new TokenSwapTokenRequest(new Uri("http://localhost64010/api/Charts"), response.RefreshToken));


            return Ok(response);
        }

        [HttpGet("Charts")]
        public async Task<ActionResult> Try([FromQuery] string song)
        {
            var client = httpClientFactory.CreateClient("LastFm");
            string clientRequest = $" /2.0/?method=track.search&track={song}&api_key={lastFmSetting.ApiKey}&format=json";
            var request = new HttpRequestMessage(HttpMethod.Get, clientRequest);
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                return Ok(responseStream);
            }
            else
            {
                return Ok(response.Content);
            }
        }

        [HttpGet("Spotify/AuthToken")]
        public async Task<ActionResult<string>> GetSpotifyAuthToken()
        {
            var loginRequest = new LoginRequest(
            new Uri("http://localhost:4200/"),
            this.spotifySettings.ApiKey,
            LoginRequest.ResponseType.Code)
            {
                Scope = new[] { Scopes.Streaming,Scopes.UserReadEmail,Scopes.UserReadPrivate}
            };
            var uri = loginRequest.ToUri();

            return Ok(uri);
        }

        
    }
}
