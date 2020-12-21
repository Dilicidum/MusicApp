using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfPublished { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
        public List<AlbumGenre> Genres { get; set; } = new List<AlbumGenre>();
        public ICollection<Artist> Artists { get; set; } = new List<Artist>();
        public Image Cover { get; set; }
    }
}
