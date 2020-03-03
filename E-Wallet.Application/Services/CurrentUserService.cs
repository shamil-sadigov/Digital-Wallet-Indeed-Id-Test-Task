using EWallet.Application.Helper;
using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly HttpContext httpContext;
        private readonly IRepository<User> userRepository;
        private User currentUserCached;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
                                  IRepository<User> userRepository)
        {
            httpContext = httpContextAccessor.HttpContext;
            this.userRepository = userRepository;
        }


        public async Task<User> GetCurrentUserAsync()
        {
            if(currentUserCached is null)
            {
                string userId = httpContext.User.GetId();

                User foundUser = await userRepository.Set().Include(x => x.Wallet)
                                                                .ThenInclude(w => w.Accounts)
                                                             .FirstOrDefaultAsync();

                currentUserCached = foundUser;
            }

            return currentUserCached;
        }
    }
}
