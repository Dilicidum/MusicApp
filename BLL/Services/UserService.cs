using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace BLL.Services
{
    public class UserService:IUserService
    {
        private IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task WriteTimeOfLogOut(User user)
        {
            await unitOfWork.UserRepository.ChangeLastTimeActivity(user);
            await unitOfWork.Commit();
        }
    }
}
