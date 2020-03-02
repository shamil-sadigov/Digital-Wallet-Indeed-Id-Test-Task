using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EWallet.Core.Models.Domain;

namespace EWallet.Core.Request_Handlers.Users
{
    class UserAuthenticationTokenHandler : IRequestHandler<UserAuthTokenRequest, string>
    {
        private readonly IUserService userService;
        private readonly ITokenFactory tokenFactory;

        public UserAuthenticationTokenHandler(IUserService userService,
                                              ITokenFactory tokenFactory)
        {
            this.userService = userService;
            this.tokenFactory = tokenFactory;
        }


        public async Task<string> Handle(UserAuthTokenRequest request, CancellationToken cancellationToken)
        {
            User user = await userService.FindByEmail(request.Email);

            string token = tokenFactory.UserAuthentication.GenerateToken(user);

            return token;
        }
    }
}
