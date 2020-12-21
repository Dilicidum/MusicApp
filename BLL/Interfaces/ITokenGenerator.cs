using BLL.Models.Responses;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITokenGenerator
    {
        Task<UserResponse> GenerateToken(User user);
    }
}
