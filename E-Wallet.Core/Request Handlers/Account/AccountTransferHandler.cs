using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.Accounts
{
    public class AccountTransferHandler : IRequestHandler<AccountTransferRequest, (bool succeeded, string errorMessage)>
    {
        private readonly IAccountService accountService;
        private readonly ICurrentUserService currentUserService;

        public AccountTransferHandler(IAccountService accountService,
                                              ICurrentUserService currentUserService)
        {
            this.accountService = accountService;
            this.currentUserService = currentUserService;
        }

        public async Task<(bool succeeded, string errorMessage)> Handle(AccountTransferRequest request, CancellationToken cancellationToken)
        {
            User currentUser = await currentUserService.GetCurrentUserAsync();

            Account accountFrom = currentUser.Wallet.Accounts.FirstOrDefault(x => x.Id == request.FromAccountId);
            Account accountTo = currentUser.Wallet.Accounts.FirstOrDefault(x => x.Id == request.ToAccountId);

            if(accountFrom is null || accountTo is null)
                return (false, "Account Id-s are not valid");


            (bool succeeded, string errorMessage) = await accountService.TransferAmount(accountFrom, accountTo, request.Amount);


            if (!succeeded)
                return (false, errorMessage);

            return (true, string.Empty);

        }
    }
}
