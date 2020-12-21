using BLL.Models.DTOs;
using BLL.Models.Resources;
using BLL.Models.Responses;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
namespace BLL.Interfaces
{
    public interface IAvatarService
    {
        Task<ImageUploadResult> AddAvatar(IFormFile file,string userId);
        Task<GetResourceResult> GetLastAvatar(User user);
        Task RemoverLastAvatar(User user,Avatar avatar);
    }
}
