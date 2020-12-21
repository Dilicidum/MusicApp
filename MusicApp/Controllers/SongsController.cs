using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Models.Resources;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CloudinaryDotNet.Actions;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController:ControllerBase
    {
        private ISongService songService;
        private IMapper mapper;
        private UserManager<User> userManager;
        public SongsController(ISongService songService,IMapper mapper,UserManager<User> userManager)
        {
            this.songService = songService;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<SongUploadResource>> Upload([FromForm]SongUploadResource song)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            song.UserWhoUploaded = user;

            await songService.AddSong(song);
            return Ok(song);
        }

        [HttpGet("SongCover")]
        public async Task<GetResourceResult> GetSongCoverById([FromQuery]int Id)
        {
            var cover = await songService.GetSongCoverById(Id);

            return cover;
        }

        [HttpGet("SongInfo")]
        public async Task<SongInfo> GetSongInfoById([FromQuery] int Id)
        {
            var songInfo = await songService.GetSongInfoById(Id);
            
            return songInfo;
        }

        [HttpGet("SongFile")]
        public async Task<GetResourceResult> GetSongSerializedById([FromQuery]int Id)
        {
            var song = await songService.GetSongSerialized(Id);
            return song;
        }

        [HttpGet("ApiSettings")]
        public async Task<ActionResult<ApiSettingDTO>> GetApiSettings([FromQuery] string apiName)
        {
            var result = await songService.GetApiToken(apiName);
            return result;
        }
    }
}
