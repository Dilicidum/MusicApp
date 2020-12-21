using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMineService
    {
        Task ChangeFirstName(string FirstName,User user);
        Task ChangeLastName(string LastName,User user);
        Task ChangeUserName(string UserName,User user);
    }
}
