using AutoMapper;
using BLL.Models.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.MappingProfiles
{
    public class ModelToResource:Profile
    {
        public ModelToResource()
        {
            CreateMap<User, UserDTO>();

            CreateMap<Image, ImageDTO>();
                

            CreateMap<Avatar, AvatarDTO>()
                .ForMember(dest => dest.ImageDTO, act => act.MapFrom(src => src.Image));

            CreateMap<Genre, GenreDTO>();

            CreateMap<Album, AlbumDTO>()
                .ForMember(dest => dest.Cover,act=>act.MapFrom(src=>src.Cover));

            CreateMap<Song, SongDTO>()
                .ForMember(dest => dest.SongSerialized, act => act.MapFrom(src => File.ReadAllBytes(src.PathToSong)));

            CreateMap<Song, SongInfo>()
                .ForMember(dest=>dest.User,act=>act.MapFrom(src=>src.User));
            CreateMap<Song, SongSerialized>()
                .ForMember(dest => dest.songSerialized,act=>act.MapFrom(src=>File.ReadAllBytes(src.PathToSongSerialized)));
            CreateMap<ApiSetting, ApiSettingDTO>()
                .ForMember(dest=>dest.Token,act=>act.MapFrom(src=>src.Acess_Token))
                .ForMember(dest=>dest.TimeExpired,act=>act.MapFrom(src=>src.DateOfBeingSet + TimeSpan.FromSeconds(src.ExpiresIn)));
        }
    }
}
