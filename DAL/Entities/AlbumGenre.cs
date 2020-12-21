using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class AlbumGenre
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public Album Album { get; set; }
    }
}
