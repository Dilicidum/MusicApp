using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Models.Resources;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class MineController:ControllerBase
    {
        private UserManager<User> userManager;
        private IAvatarService avatarService;
        private IMapper mapper;
        private IMineService mineService;
        public MineController(IMapper mapper, UserManager<User> userManager,IAvatarService avatarService,
            IMineService mineService)
        {
            this.mapper = mapper;
            this.mineService = mineService;
            this.userManager = userManager;
            this.avatarService = avatarService;
        }

        [HttpPut("Password")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult> ChangePassword(ChangePasswordResource changePasswordResource)
        {
            string oldPassword = changePasswordResource.OldPassword;
            string newPassword = changePasswordResource.Password;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            var passwordChangedResult = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (passwordChangedResult.Succeeded)
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(403);
            }
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            UserDTO userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
        }

        [HttpPut("{Settings}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ChangeUserSettings(UserDTO userDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            if (userDTO.FirstName != null)
            {
                await mineService.ChangeFirstName(userDTO.FirstName,user);
            }
            if(userDTO.LastName != null)
            {
                await mineService.ChangeLastName(userDTO.LastName,user);
            }
            if (userDTO.Email != null)
            {
                
            }
            if (userDTO.UserName != null)
            {
                await mineService.ChangeUserName(userDTO.UserName,user);
            }
            return Ok(user);
        }

        [HttpPost("Avatars")]
        public async Task<ActionResult<ImageUploadResult>> UploadAvatar(IFormFile file)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            var result = (await avatarService.AddAvatar(file,userId));
            user.FirstName = file.FileName;
            //await userManager.UpdateAsync(User);
            return result;
        }

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        [HttpGet("HasAvatars")]
        public async Task<ActionResult> HasAvatars()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            return Ok(user);
        }

        [HttpGet("Avatars/Last")]
        public async Task<ActionResult<GetResourceResult>> GetLastAvatar()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            var avatarDTO = await avatarService.GetLastAvatar(user);
            return avatarDTO;
        }

    }
}
