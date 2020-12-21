using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Album Album { get; set; } = new Album();
        public ICollection<ArtistGenre> ArtistGenre { get; set; } = new List<ArtistGenre>();
            
    }
}
