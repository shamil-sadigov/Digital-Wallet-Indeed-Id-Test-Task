using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models.DTO
{
    public class PermissionTokenRequest:IRequest<string>
    {
        public string[] PermissionNames{ get; set; }
    }
}
