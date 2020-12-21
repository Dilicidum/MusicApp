using BLL.Models.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRegistrationService
    {
        Task<string> RegisterUser(UserRegistrationModel userRegistrationModel);
    }
}
