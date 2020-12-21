using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Responses
{
    public class ResultResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public bool Succeeded { get; set; }
    }
}
