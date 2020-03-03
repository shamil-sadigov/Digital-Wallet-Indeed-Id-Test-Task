using EWallet.Core.Services.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Application.Services
{
    public class TokenFactory: ITokenFactory
    {
        public TokenFactory(IAuthenticationTokenGenerator authenticationTokenGenerator,
                            IPermissionTokenGenerator permissionTokenGenerator)
        {
            UserAuthentication = authenticationTokenGenerator;
            PermissiondToken = permissionTokenGenerator;
        }

        public IAuthenticationTokenGenerator UserAuthentication { get; }
        public IPermissionTokenGenerator PermissiondToken { get; }
    }
}
