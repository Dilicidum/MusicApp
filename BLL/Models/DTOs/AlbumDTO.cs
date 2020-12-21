using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.DTOs
{
    public class AlbumDTO
    {
        public string Name { get; set; }
        public ICollection<SongDTO> Songs { get; set; } = new List<SongDTO>();
        public ImageDTO Cover { get; set; }
        public string AlbumGroup { get; set; }
        public string AlbumType { get; set; }
        public List<ArtistDTO> Artists { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public Dictionary<string, string> ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<SpotifyAPI.Web.Image> Images { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDatePrecision { get; set; }
        public Dictionary<string, string> Restrictions { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
