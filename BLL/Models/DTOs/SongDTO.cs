using DAL.Entities;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using SpotifyAPI.Web;

namespace BLL.Models.DTOs
{
    public enum ItemType
    {
        Track = 0,
        Episode = 1
    }
    public class SongDTO
    {
        public string SongId { get; set; }
        public AlbumDTO Album { get; set; }
        public string Name { get; set; }
        public int Views { get; set; }
        public byte[] SongSerialized { get; set; }
        public string PublicId { get; set; }
        public string Href { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType Type { get; set; }
        public int TrackNumber { get; set; }
        public string PreviewUrl { get; set; }
        public int Popularity { get; set; }
        public Dictionary<string, string> Restrictions { get; set; }
        //public LinkedTrack LinkedFrom { get; set; }
        public bool IsPlayable { get; set; }
        public string Uri { get; set; }
        public string Id { get; set; }
        public Dictionary<string, string> ExternalUrls { get; set; }
        public Dictionary<string, string> ExternalIds { get; set; }
        public bool Explicit { get; set; }
        public int DurationMs { get; set; }
        public int DiscNumber { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public List<ArtistDTO> Artists { get; set; }
        public bool IsLocal { get; set; }
    }
}
