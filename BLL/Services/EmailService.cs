using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmailService : IEmailService
    {
        private IUnitOfWork unitOfWork;
        public EmailService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> CheckEmailAlreadyTaken(string email)
        {
            var user =await unitOfWork.UserRepository.GetUserByEmail(email);
            if(user==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
