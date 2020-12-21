using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserGenre
    {
        public string UserId { get; set; }
        public int GenreId { get; set; }
        public User User { get; set; }
        public Genre Genre { get; set; }
    }
}
