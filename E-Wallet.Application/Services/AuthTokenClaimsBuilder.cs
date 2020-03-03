using EWallet.Core.Models;
using EWallet.Core.Models.Domain;
using EWallet.Core.Services.Application;
using System.Security.Claims;

namespace EWallet.Application.Services
{
    public class AuthTokenClaimsBuilder : IBuilder<Claim[]>
    {
        private readonly User user;

        public AuthTokenClaimsBuilder(User user)
        {
            this.user = user;
        }


        public Claim[] Build()
        => new Claim[]
        {
            new Claim(ApplicationClaims.UserId, user.Id),
            new Claim(ApplicationClaims.Email, user.Email)
        };
    }
}
