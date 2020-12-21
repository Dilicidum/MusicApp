using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public DateTime DateOfLastActivity { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; } 
        public virtual ICollection<Song> SongsUploaded { get; set; } 
        public  virtual ICollection<Avatar> Avatars { get; set; }
        public virtual ICollection<UserGenre> PreferredGenres { get; set; }
    }
}
