using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public enum TokenType
    {
        Application,
        Streaming
    }
    public class ApiSetting
    {
        public int Id { get; set; }
        public string ApiName { get; set; }
        public string Acess_Token { get; set; }
        public DateTime DateOfBeingSet { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public TokenType Type { get; set; }
        public bool IsExpired { get
            {
                TimeSpan timeSpan = TimeSpan.FromHours(ExpiresIn);
                if (DateTime.Now >= DateOfBeingSet.Add(timeSpan))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } }
    }

}
