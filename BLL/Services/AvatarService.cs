using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Models.Resources;
using BLL.Models.Responses;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using BLL.Helpers;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.ResponseCaching;
namespace BLL.Services
{
    public class AvatarService : IAvatarService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private Cloudinary cloudinary;
        public AvatarService(IUnitOfWork unitOfWork,IMapper mapper,IOptions<CloudinarySetting> options)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Account acc = new Account()
            {
                Cloud = options.Value.CloudName,
                ApiKey = options.Value.ApiKey,
                ApiSecret = options.Value.ApiSecret
            };

            cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddAvatar(IFormFile file,string userId)
        {
            var uploadResult = new ImageUploadResult();
            User user = await unitOfWork.UserRepository.GetFullInfo(userId);
            
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                };

                uploadResult = await cloudinary.UploadAsync(uploadParams);

                Image image = new Image()
                {
                    PublicId = uploadResult.PublicId
                };

                Avatar avatar = new Avatar()
                {
                    Image = image,
                    TimeOfUploading = DateTime.Now,
                    UserId = userId
                };
                user.Avatars.Add(avatar);
                
            
            await unitOfWork.Commit();

            return uploadResult;
        }

        
        public async Task<GetResourceResult> GetLastAvatar(User user)
        {
            //Avatar avatar = user.Avatars.LastOrDefault();
            User user1 = await unitOfWork.UserRepository.GetFullInfo(user.Id);
            Avatar avatar = user1.Avatars.LastOrDefault();
            if (avatar != null)
            {
                avatar.Image = await unitOfWork.ImageRepository.GetByIdAsync(avatar.ImageId);
                var resourceResult = await cloudinary.GetResourceAsync(avatar.Image.PublicId);
                AvatarDTO avatarDTO = mapper.Map<AvatarDTO>(avatar);
                return resourceResult;
            }

            GetResourceResult getResource = new GetResourceResult();
            return getResource;
        }

        public async Task RemoverLastAvatar(User user, Avatar avatar)
        {
            user.Avatars.Remove(avatar);
            unitOfWork.AvatarRepository.Remove(avatar);
            await unitOfWork.Commit();
        }
    }
}
