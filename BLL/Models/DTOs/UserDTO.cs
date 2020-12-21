using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; }
        public DateTime DateOfRegistration { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
