using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICurrencyHelper currencyHelper;
        private readonly IRepository<Account> accountRepository;

        public WalletStateRequestHandler(ICurrentUserService currentUserService,
                                         ICurrencyHelper currencyHelper,
                                         IRepository<Account> repository)
        {
            this.currentUserService = currentUserService;
            this.currencyHelper = currencyHelper;
            this.accountRepository = repository;
        }


        public async Task<AccountDTO[]> Handle(WalletStateRequest request, CancellationToken cancellationToken)
        {
            User currentUser = await currentUserService.GetCurrentUserAsync();

            var response = await accountRepository.Set()
                                   .Where(x => x.WalletId == currentUser.Wallet.Id)
                                   .Select(x => new AccountDTO()
                                   {
                                       CurrentBalance = x.Balance,
                                       Currency = x.Currency.IsoAlfaCode,
                                       AccountId = x.Id
                                   }).ToArrayAsync();


            return response;
        }
    }
}
