using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.DTOs
{
    public class ImageDTO
    {
        public byte[] ImageSerialized { get; set; }
        public AvatarDTO AvatarDTO { get; set; }
        public string PublicId { get; set; }
    }
}
