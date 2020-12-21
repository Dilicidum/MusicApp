﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class PlaylistSong
    {
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
