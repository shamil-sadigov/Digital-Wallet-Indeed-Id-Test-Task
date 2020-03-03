using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.Accounts
{
    public class AccountOperationRequestHandler : IRequestHandler<AccountOperationRequest, (bool succeeded, string errorMessage)>
    {
        private readonly IAccountService accountService;
        private readonly ICurrentUserService currentUserService;

        public AccountOperationRequestHandler(IAccountService accountService,
                                              ICurrentUserService currentUserService)
        {
            this.accountService = accountService;
            this.currentUserService = currentUserService;
        }

        public async Task<(bool succeeded, string errorMessage)> Handle(AccountOperationRequest request, CancellationToken cancellationToken)
        {
            User currentUser = await currentUserService.GetCurrentUserAsync();

            Account userAccount = currentUser.Wallet.Accounts.FirstOrDefault(x => x.Id == request.AccountId);

            if (userAccount is null)
                return (false, "AccountId is not valid");

            (bool succeeded, string errorMessage) = (default, default);

            switch (request.Direction)
            {
                case OperationDirection.In:
                    (succeeded, errorMessage) = await accountService.IncreaseBalanceAsync(userAccount, request.Amount);
                    break;
                case OperationDirection.Out:
                    (succeeded, errorMessage) = await accountService.DecreaseBalanceAsync(userAccount, request.Amount);
                    break;
                default:
                    break;
            }

            if (!succeeded)
                return (false, errorMessage);

            return (true, string.Empty);
        }
    }
}
