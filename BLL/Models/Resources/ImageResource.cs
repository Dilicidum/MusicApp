using BLL.Models.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Resources
{
    public class ImageResource
    { 
        public IFormFile file { get; set; }

        public ImageResource(IFormFile file)
        {
            this.file = file;
        }

        public ImageResource() { }
    }
}
