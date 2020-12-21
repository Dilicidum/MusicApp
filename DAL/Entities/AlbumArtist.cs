using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class AlbumArtist
    {
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }

    }
}
