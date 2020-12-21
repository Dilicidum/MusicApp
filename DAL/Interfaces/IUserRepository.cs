using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User> GetUserByEmail(string email);
        Task AddAvatarToUser(Avatar avatar);
        Task<User> GetFullInfo(string UserId);

        Task ChangeLastTimeActivity(User user);
        Task ChangeFirstName(string FirstName,User user);
        Task ChangeLastname(string LastName,User user);
        Task ChangeUsername(string UserName,User user);
    }
}
