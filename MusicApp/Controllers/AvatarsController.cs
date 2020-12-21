using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Models.Resources;
using BLL.Services;
using DAL.Configurations;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Core;
namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarsController:ControllerBase
    {
        private UserManager<User> userManager;
        private IMapper mapper;
        private IAvatarService avatarService;
        public AvatarsController(IMapper mapper,IAvatarService avatarService, UserManager<User> userManager)
        {
            this.avatarService = avatarService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpDelete("Last")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteLastAvatar()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = (await userManager.FindByIdAsync(userId));
            Avatar avatarToBeRemoved = user.Avatars.LastOrDefault();
            await avatarService.RemoverLastAvatar(user, avatarToBeRemoved);
            return Ok();
        }

    }
}
