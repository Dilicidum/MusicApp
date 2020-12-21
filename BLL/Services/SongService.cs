using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Models.Resources;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using BLL.Helpers;
using SpotifyAPI.Web;
namespace BLL.Services
{
    public class SongService:ISongService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private Cloudinary cloudinary;
        private SpotifySettings spotifySetting;
        public SongService(IUnitOfWork unitOfWork,IMapper mapper,IOptions<CloudinarySetting> options,
            IOptions<SpotifySettings> optionsSpotify)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Account acc = new Account()
            {
                Cloud = options.Value.CloudName,
                ApiKey = options.Value.ApiKey,
                ApiSecret = options.Value.ApiSecret
            };
            spotifySetting = new SpotifySettings()
            {
                ApiKey = optionsSpotify.Value.ApiKey,
                ApiSecret = optionsSpotify.Value.ApiSecret,
                ApplicationName = optionsSpotify.Value.ApplicationName
            };
            cloudinary = new Cloudinary(acc);
        }

        public async Task AddSong(SongUploadResource songUploadResource)
        {
            using var stream = songUploadResource.Song.OpenReadStream();
            var audioUploadParams = new VideoUploadParams
            {
                File = new FileDescription(songUploadResource.SongName,stream),
            };
            var audioUploadResult = await cloudinary.UploadAsync(audioUploadParams);

            int lastSongId = await unitOfWork.SongRepository.GetLastSongId();
            int newSongId = lastSongId + 1;
            
            Song song = mapper.Map<Song>(songUploadResource);
            song.TimeOfUploaded = DateTime.Now;
            song.PublicId = audioUploadResult.PublicId;
            song.Album = new Album();
            song.Album.Cover = new DAL.Entities.Image();
            song.Album.Name = song.Name;
            song.Album.TimeOfPublished = DateTime.Now;
            song.UserId = songUploadResource.UserWhoUploaded.Id;
            Artist artist = new Artist();
            artist.Name = songUploadResource.Artist;
            
            List<AlbumGenre> genresToAdd = new List<AlbumGenre>();
            var genres = mapper.Map<IEnumerable<Genre>>(songUploadResource.genres);
            foreach(var genre in genres)
            {
                AlbumGenre albumGenre = new AlbumGenre();
                albumGenre.Genre = genre;
                albumGenre.Album = song.Album;
                genresToAdd.Add(albumGenre);
            }

            //song.Album.Genres.AddRange(genresToAdd);

            using var stream1 = songUploadResource.Cover.OpenReadStream();
            var coverUploadParams = new ImageUploadParams
            {
                File = new FileDescription(songUploadResource.SongName, stream1),
            };
            var coverUploadResult = await cloudinary.UploadAsync(coverUploadParams);
            
            song.Album.Cover.PublicId = coverUploadResult.PublicId;
            await unitOfWork.SongRepository.AddAsync(song);
            await unitOfWork.Commit();
        }

        public async Task<IEnumerable<SongDTO>> GetSongs()
        {
            var songs = await unitOfWork.SongRepository.GetAllAsync();
            var songsDTO = mapper.Map <IEnumerable<SongDTO>>(songs);
            return songsDTO;
        }

        public async Task<GetResourceResult> GetSongCoverById(int id)
        {
            DAL.Entities.Image cover = await unitOfWork.SongRepository.GetSongCoverById(id);
            GetResourceResult getResourceResult = new GetResourceResult();
            if (cover != null)
            {
                getResourceResult = await cloudinary.GetResourceAsync(cover.PublicId);
            }
            
            //ImageDTO coverDTO = mapper.Map<ImageDTO>(cover);
            return getResourceResult;
        }

        public async Task<SongInfo> GetSongInfoById(int id)
        {
            var song = await unitOfWork.SongRepository.GetSongFullInfoById(id);
            var songInfo = mapper.Map<SongInfo>(song);
            return songInfo;
        }

        public async Task<GetResourceResult> GetSongSerialized(int id)
        {
            var song = await unitOfWork.SongRepository.GetByIdAsync(id);
            GetResourceResult getResourceResult = new GetResourceResult();
            
            
            if (song != null)
            {
                getResourceResult = await cloudinary.GetResourceAsync(song.PublicId);
            }
            var res = cloudinary.Api.UrlVideoUp.BuildUrl(song.PublicId + ".mp3");
            getResourceResult.Url = res;
            return getResourceResult;
        }

        public async Task<ApiSettingDTO> GetApiToken(string Name)
        {
            var currentApiSettings = await unitOfWork.ApiSettingRepository.GetLastApplicationTokenByApiName(Name);
            ApiSettingDTO apiSettingDTO = new ApiSettingDTO();
            if (currentApiSettings != null)
            {
                apiSettingDTO = mapper.Map<ApiSettingDTO>(currentApiSettings);
                return apiSettingDTO;
            }

            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest(spotifySetting.ApiKey, spotifySetting.ApiSecret);

            var response = await new OAuthClient(config).RequestToken(request);
            ApiSetting apiSetting = new ApiSetting()
            {
                ApiName = "Spotify",
                DateOfBeingSet = DateTime.Now,
                Acess_Token = response.AccessToken
            };
            var x = response.ExpiresIn;
            apiSettingDTO.Token = response.AccessToken;
            apiSettingDTO.ApiName = "spotify";
            await unitOfWork.ApiSettingRepository.AddAsync(apiSetting);
            await unitOfWork.Commit();
            return apiSettingDTO;
        }
    }
}
