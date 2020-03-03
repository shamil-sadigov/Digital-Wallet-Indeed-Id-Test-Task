using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.Permission
{
    public class PermissionTokenRequestHandler : IRequestHandler<PermissionTokenRequest, string>
    {
        private readonly ITokenFactory tokenFactory;

        public PermissionTokenRequestHandler(ITokenFactory tokenFactory)
            => this.tokenFactory = tokenFactory;
        

        public async Task<string> Handle(PermissionTokenRequest request, CancellationToken cancellationToken)
        {
            string token = await tokenFactory.PermissiondToken.GenerateTokenAsync(request.PermissionNames);

            return token;
        }
    }
}
