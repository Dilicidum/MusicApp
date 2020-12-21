using AutoMapper;
using BLL.Interfaces;
using BLL.Models.Resources;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models.Responses;
using System.Security.Claims;
using API.Interfaces;
using API.Identity.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private ITokenGenerator tokenGenerator;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IMapper mapper;
        private IUserService userService;
        private IEmailSender emailSender;
        public LoginController(IMapper mapper,ITokenGenerator tokenGenerator,UserManager<User> userManager,
            SignInManager<User> signInManager,IUserService userService,IEmailSender emailSender)
        {
            this.mapper = mapper;
            this.signInManager = signInManager;
            this.tokenGenerator = tokenGenerator;
            this.userManager = userManager;
            this.userService = userService;
            this.emailSender = emailSender;
        }

        [HttpPost("ForgetPassword")]
        public async Task<ActionResult> ForgetPassword([FromBody]ForgetPasswordResource forgetPasswordResource)
        {
            var user = await userManager.FindByEmailAsync(forgetPasswordResource.Email);

            if(user == null)
            {
                return BadRequest("Error ocurred");
            }

            var token = userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Login",
                new { token = token.Result, email = user.Email }, Request.Scheme);
            string text = "Link is provided below, please follow the instructions";
            var message = new Message(new string[] { user.Email }, "Reset password",text + " " + callback);
            await emailSender.SendEmailAsync(message);
            bool sucess = true;
            return CreatedAtAction(nameof(ForgetPassword),new { resultOfSendingEmail = sucess,token = token});
        }

        [HttpGet("ResetPassword")]
        public ActionResult ResetPassword([FromQuery]string token, [FromQuery]string email)
        {
            //Response.Cookies.Append("userEmailResetPassword", email);
            //Response.Cookies.Append("tokenResetPassword", token);
            return Redirect($"http://localhost:4200/ResetPassword?token={token}&email={email}");
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            resetPasswordModel.Token =  resetPasswordModel.Token.Replace('%', '+');
            resetPasswordModel.Token = resetPasswordModel.Token.Replace(' ', '+');
            var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);

            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token,
                resetPasswordModel.Password);
            string r="";
            foreach(var i in resetPassResult.Errors)
            {
                r += i.Description + " ";
            }

            return Ok(resetPassResult.Succeeded + " " + r + resetPasswordModel.Token);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<UserResponse>> Login(UserLoginModel userLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await userManager.FindByNameAsync(userLoginModel.UserName);
            
            var result = await signInManager.PasswordSignInAsync(userLoginModel.UserName, 
                userLoginModel.Password,false,false);

            if (result.Succeeded)
            {
                //var user = await userManager.FindByNameAsync(userLoginModel.UserName);
                var response = await tokenGenerator.GenerateToken(user);
                return response;
            }
            else
            {
                return Unauthorized("Invalid User Name or Password");
            }
        }

        [HttpPost("LogOut")]
        public async Task<ActionResult> LogOut()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);
            await userService.WriteTimeOfLogOut(user);
            await signInManager.SignOutAsync();
            return Ok();
        }

        
    }
}
