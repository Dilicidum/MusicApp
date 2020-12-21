using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models.DTOs;
using BLL.Models.Resources;
using DAL.Entities;
using SpotifyAPI.Web;
namespace API.MappingProfiles
{
    public class ResourceToModel:Profile
    {
        public ResourceToModel()
        {
            CreateMap<UserRegistrationModel, User>();
            CreateMap<UserLoginModel, User>();
            CreateMap<AvatarUploadResource, Avatar>();
            CreateMap<ImageDTO, DAL.Entities.Image>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<SongUploadResource, Song>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.SongName));
            CreateMap<FullTrack, SongDTO>();
            CreateMap<SimpleArtist, ArtistDTO>();
            CreateMap<SimpleAlbum, AlbumDTO>();
                
        }
    }
}
