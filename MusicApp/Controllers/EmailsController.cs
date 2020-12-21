using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailsController:ControllerBase
    {
        private UserManager<User> userManager;
        private IEmailService emailService;
        public EmailsController(UserManager<User> userManager,IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }

        [HttpGet]
        public async Task<ActionResult<bool>> CheckEmailIsAlreadyTaken([FromQuery]string email)
        {
            var result = await( emailService.CheckEmailAlreadyTaken(email));
            return result;
        }
    }

}
