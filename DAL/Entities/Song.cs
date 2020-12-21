using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfUploaded { get; set; }
        public User User { get; set; } = new User();
        public string UserId { get; set; }
        public ICollection<PlaylistSong> Playlists { get; set; } = new List<PlaylistSong>();
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public Album Album { get; set; }
        public string PublicId { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public string PathToSong { get; set; }
        public string PathToSongSerialized { get; set; }
        public Song()
        {
            
        }
    }
}
