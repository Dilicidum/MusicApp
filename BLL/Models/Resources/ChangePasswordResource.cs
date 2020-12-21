using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models.Resources
{
    public class ChangePasswordResource
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Old Password is required")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "New Password is required")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Password`s does not match")]
        public string PasswordConfirmed { get; set; }
    }
}
