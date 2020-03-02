using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWallet.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;

        public UserService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public Task GetUserAccountScopedToken()
        {
            throw new NotImplementedException();
        }

        public Task GetUserToken(UserTokenRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<(User user, string errorMessage)> RegisterUserAsync(UserRegistrationRequest request)
        {
            User newUser = request; // implicit operator 

            var result = await userManager.CreateAsync(newUser);

            if (!result.Succeeded)
                return (null, string.Concat(result.Errors.Select(x => x.Description)));

            return (newUser, errorMessage: string.Empty);
        }
    }
}
