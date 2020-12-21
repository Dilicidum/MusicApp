using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.DTOs
{
    public class AvatarDTO
    {
        public DateTime TimeOfUploading { get; set; }
        public ImageDTO ImageDTO { get; set; }
        public UserDTO User { get; set; }
    }
}
