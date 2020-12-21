using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DAL.Entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfCreated { get; set; }
        public User User { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
    }
}
