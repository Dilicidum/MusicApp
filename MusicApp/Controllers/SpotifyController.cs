using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.Models.Responses;
using BLL.Models.DTOs;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotifyController:ControllerBase
    {
        private ISpotifyService spotifyService;
        public SpotifyController(ISpotifyService spotifyService)
        {
            this.spotifyService = spotifyService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("Ok from Spotify))");
        }

        [HttpGet("Token")]
        public async Task<ActionResult<ApiSettingDTO>> GetAcessToken()
        {
            var result = await spotifyService.GetAcessToken();
            return result;
        }

        [HttpGet("RefreshedToken")]
        public async Task<ActionResult<ApiSettingDTO>> GetNewAcessToken([FromQuery] string token)
        {
            var result = await spotifyService.GetRefreshedToken(token);
            return result;
        }
    }
}
