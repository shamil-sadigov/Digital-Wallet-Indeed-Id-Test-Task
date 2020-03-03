using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.AccountRequests
{
    public class AccountCreationRequestHandler : IRequestHandler<AccountCreationRequest, (bool succeeded, string errorMessage)>
    {
        private readonly ICurrencyHelper currencyHelper;
        private readonly IAccountService accountService;
        private readonly ICurrentUserService currentUserService;

        public AccountCreationRequestHandler(ICurrencyHelper currencyHelper,
                                             IAccountService accountService,
                                             ICurrentUserService currentUserService)
        {
            this.currencyHelper = currencyHelper;
            this.accountService = accountService;
            this.currentUserService = currentUserService;
        }

        public async Task<(bool succeeded, string errorMessage)> Handle(AccountCreationRequest request, CancellationToken cancellationToken)
        {
            Currency currency = await currencyHelper.ResolveCurrencyName(request.CurrencyIsoName); // validation is done in filter
            User currentUser = await currentUserService.GetCurrentUserAsync();

            (Models.Domain.Account account, string accountErrorMessage) = 
                await accountService.CreateAccountAsync(ops => ops.OnWallet(currentUser.Wallet.Id)
                                                                  .WithBalance(0)
                                                                  .WithCurrency(currency.IsoNumberCode));
            
            if(account is null)
                return (false, accountErrorMessage);

            return (true, string.Empty); 

        }
    }
}
