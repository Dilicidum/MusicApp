using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MineService:IMineService
    {
        private IUnitOfWork unitOfWork;
        
        public MineService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task ChangeFirstName(string FirstName,User user)
        {
            await unitOfWork.UserRepository.ChangeFirstName(FirstName, user);
            await unitOfWork.Commit();
        }

        public async Task ChangeLastName(string LastName,User user)
        {
            await unitOfWork.UserRepository.ChangeLastname(LastName, user);
            await unitOfWork.Commit();
        }

        public async Task ChangeUserName(string UserName,User user)
        {
            
            await unitOfWork.UserRepository.ChangeUsername(UserName,user);
            
            await unitOfWork.Commit();
        }
    }
}
