using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models.DTO
{
    public class WalletStateRequest:IRequest<AccountDTO[]>
    {
    }
}
