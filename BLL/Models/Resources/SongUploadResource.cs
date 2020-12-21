using BLL.Models.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Resources
{
    public class SongUploadResource
    {
        public string SongName { get; set; }
        public string Year { get; set; }
        public string Artist { get; set; }
        public IFormFile Song { get; set; }
        public IFormFile Cover { get; set; }
        public List<GenreDTO> genres { get; set; } = new List<GenreDTO>();
        public User UserWhoUploaded { get; set; }
    }
}
