using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AlbumGenre> Albums { get; set; } = new List<AlbumGenre>();
        public ICollection<ArtistGenre> Artists { get; set; } = new List<ArtistGenre>();
        public ICollection<UserGenre> UserGenres { get; set; } = new List<UserGenre>();
    }
}
