using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Avatar
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime TimeOfUploading { get; set; }
        public virtual Image Image { get; set; }
        public int ImageId { get; set; }
        public string UserId { get; set; }
    }
}
