using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.User_Registration
{
    public class UserRegistrationHandler : IRequestHandler<UserRegistrationRequest, (bool succeeded, string errorMessage)>
    {
        private readonly IUserService userService;
        private readonly IWalletService walletService;
        private readonly IAccountService accountService;

        public UserRegistrationHandler(IUserService userService,
                                       IWalletService walletService,
                                       IAccountService accountService)
        {
            this.userService = userService;
            this.walletService = walletService;
            this.accountService = accountService;
        }

        public async Task<(bool succeeded, string errorMessage)> Handle(UserRegistrationRequest request, CancellationToken cancellationToken)
        {
            #region Register user

            (User user, string userErrorMessage) =
                await userService.RegisterUserAsync(request);

            if (user is null)
                return (false, userErrorMessage);

            #endregion

            #region Create wallet

            (Wallet wallet, string walletErrorMessage) =
                await walletService.CreateWalletAsync(ops => ops.ForUser(user.Id));

            if (wallet is null)
                return (false, walletErrorMessage);

            #endregion

            #region Create default RUB account

            (Account account, string accountErrorMessage) =
                await accountService.CreateAccountAsync(ops => ops.OnWallet(wallet.Id)
                                                                  .WithBalance(0)
                                                                  .WithCurrency(Currency.Names.RUB.ISOCodeNum));

            if (wallet is null)
                return (false, accountErrorMessage);

            return (true, string.Empty);

            #endregion
        }
    }
}
