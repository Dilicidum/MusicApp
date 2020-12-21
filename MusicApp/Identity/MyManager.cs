using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

namespace API.Identity
{
    public class MyManager : UserManager<User>
    {
        private IUnitOfWork unitOfWork;
        private IMemoryCache memoryCache;
        public MyManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, 
            IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger,
            IUnitOfWork unitOfWork,IMemoryCache memoryCache) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.unitOfWork = unitOfWork;
            this.memoryCache = memoryCache;
        }
        [ResponseCache(Duration =300,Location = ResponseCacheLocation.Client)]
        public override async Task<User> FindByIdAsync(string userId)
        {
            User user = null;
            if(!memoryCache.TryGetValue(userId,out user))
            {
                user = await unitOfWork.UserRepository.GetFullInfo(userId);
                if (user != null)
                {
                    memoryCache.Set(userId, user, new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
                    });
                }
            }
            
            return user;
        }

        public override Task<IdentityResult> CreateAsync(User user, string password)
        {
            user.DateOfLastActivity = DateTime.Now;
            
            user.DateOfRegistration = DateTime.Now;
            
            return base.CreateAsync(user, password);
            
        }

        
        
    }
}
