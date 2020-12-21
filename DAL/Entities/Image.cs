using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public Avatar Avatar { get; set; }
        public Album Album { get; set; }
        public string PublicId { get; set; }
    }
}
