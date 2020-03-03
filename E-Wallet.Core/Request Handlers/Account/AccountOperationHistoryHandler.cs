using EWallet.Core.Models.Domain;
using EWallet.Core.Models.DTO;
using EWallet.Core.Services.Application;
using EWallet.Core.Services.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EWallet.Core.Request_Handlers.Accounts
{
    class AccountOperationHistoryHandler : IRequestHandler<AccountOperationHistoryRequest, OperationDTO[]>
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IRepository<Operation> operationRepository;

        public AccountOperationHistoryHandler(ICurrentUserService currentUserService,
                                              IRepository<Operation> operationRepository)
        {
            this.currentUserService = currentUserService;
            this.operationRepository = operationRepository;
        }


        public async Task<OperationDTO[]> Handle(AccountOperationHistoryRequest request, CancellationToken cancellationToken)
        {

            User currentUser = await currentUserService.GetCurrentUserAsync();

            var response = await operationRepository.Set().Include(x => x.Account.Wallet.Id == currentUser.Wallet.Id)
                                        .Select(x => new OperationDTO()
                                        {
                                            Amount = x.Amount,
                                            Currency = x.Account.Currency.IsoAlfaCode,
                                            Direction = x.Direction.ToString(),
                                            OperationDate = x.Date,
                                            Id = x.Id
                                        })
                                        .ToArrayAsync();


            return response;
        }
    }
}
