using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models.Resources;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;
using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.Models.Responses;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController:ControllerBase
    {
        private UserManager<User> userManager;
        private IMapper mapper;
        private ITokenGenerator tokenGenerator;
        public RegistrationController(UserManager<User> userManager, IMapper mapper,
            ITokenGenerator tokenGenerator)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.tokenGenerator = tokenGenerator;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        
        [HttpPost]
        public async Task<ActionResult<UserResponse>> Register(UserRegistrationModel userRegistrationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var UserFounded = await userManager.FindByNameAsync(userRegistrationModel.UserName);
            if (UserFounded == null)
            {
                User UserToBeRegistrated = mapper.Map<User>(userRegistrationModel);
                var result = await userManager.CreateAsync(UserToBeRegistrated,userRegistrationModel.Password);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(UserToBeRegistrated.UserName);
                    var userResponse = await tokenGenerator.GenerateToken(user);
                    
                    return userResponse;
                }
                else
                {
                    string i = "";
                    foreach(var x in result.Errors)
                    {
                        i+=x.Description;
                    }
                    return BadRequest(i);
                }
            }
            else
            {
                return Unauthorized("UserName has already been taken");
            }
        }

        [HttpGet]
        [Authorize]
        public string GetThis()
        {
            return "this";
        }
    }
}
