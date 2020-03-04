using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.Users
{
    class UserAuthenticationTokenHandler : IRequestHandler<UserAuthTokenRequest, (string errorMessage, string token)>
    {
        private readonly IUserService userService;
        private readonly ITokenFactory tokenFactory;

        public UserAuthenticationTokenHandler(IUserService userService,
                                              ITokenFactory tokenFactory)
        {
            this.userService = userService;
            this.tokenFactory = tokenFactory;
        }


        public async Task<(string errorMessage, string token)> Handle(UserAuthTokenRequest request, CancellationToken cancellationToken)
        {
            User user = await userService.FindByEmail(request.Email);

            if (!await userService.PasswordValid(user, request.Password))
                return (errorMessage: "User password is not valid", token: null);

            string token = tokenFactory.UserAuthentication.GenerateToken(user);

            return (errorMessage: null, token: token);
        }
    }
}
