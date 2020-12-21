using AutoMapper;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Models.Resources;
using BLL.Models.Responses;
using DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UserController:ControllerBase
    {
        private IMapper mapper;
        private UserManager<User> userManager;
        private IAvatarService avatarService;
        private IUserService userService;
        private ILogger<UserController> logger;
        
        public UserController(IMapper mapper,UserManager<User> userManager,IAvatarService avatarService
            ,ILogger<UserController> logger,IUserService userService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.avatarService = avatarService;
            this.logger = logger;
            this.userService = userService;
        }

        [HttpGet("user/{Id}/Avatars")]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetUserAvatars(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            var avatars = mapper.Map<IEnumerable<ImageDTO>>(user.Avatars).ToList();
            return avatars;
        }

        [HttpGet("UserNameIsUnique")]
        public async Task<ActionResult<bool>> UserNameIsUnique([FromQuery]string UserName)
        {
            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        [HttpGet("{Id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UserDTO>> GetUserInfo(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            UserDTO userDTO = mapper.Map<UserDTO>(user);
            return userDTO;
        } 
    }
}
