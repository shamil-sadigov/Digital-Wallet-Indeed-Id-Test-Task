using EWallet.Core.Models.Domain;
using MediatR;

namespace EWallet.Core.Models.DTO
{
    public class AccountOperationHistoryRequest:IRequest<OperationDTO[]>
    {

    }
}
