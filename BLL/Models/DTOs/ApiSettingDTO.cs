using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
namespace BLL.Models.DTOs
{
    public class ApiSettingDTO
    {
        public string ApiName { get; set; }
        public string Token { get; set; }
        public DateTime TimeExpired { get; set; }
    }
}
