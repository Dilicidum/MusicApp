using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.DTOs
{
    public class SongInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public UserDTO User { get; set; }
        public List<ArtistDTO> Artists { get; set; }
        
    }
}
