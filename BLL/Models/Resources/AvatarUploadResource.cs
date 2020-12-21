using BLL.Models.DTOs;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Resources
{
    public class AvatarUploadResource
    {
        public ImageResource avatar { get; set; }
        public User User { get; set; }

        public DateTime TimeOfUploading { get; set; }
    }
}
