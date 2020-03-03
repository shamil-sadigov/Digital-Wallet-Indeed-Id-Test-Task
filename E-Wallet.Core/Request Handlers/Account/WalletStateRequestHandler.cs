using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.Accounts
{
    class WalletStateRequestHandler : IRequestHandler<WalletStateRequest, AccountDTO[]>
    {
        private readonly ICurrentUserService currentUserService;

        public WalletStateRequestHandler(ICurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;
        }


        public async Task<AccountDTO[]> Handle(WalletStateRequest request, CancellationToken cancellationToken)
        {
            User currentUser = await currentUserService.GetCurrentUserAsync();

            var response = currentUser.Wallet.Accounts.Select(x => new AccountDTO()
            {
                Balance = x.Balance,
                CurrencyIsoName = x.Currency.IsoAlfaCode,
                Id = x.Id
            }).ToArray();


            return response;
        }
    }
}
