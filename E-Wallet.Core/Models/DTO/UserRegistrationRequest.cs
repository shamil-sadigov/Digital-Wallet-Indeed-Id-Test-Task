using EWallet.Core.Models.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models.DTO
{
    public class UserRegistrationRequest : IRequest<(bool succeeded, string errorMessage)>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public static implicit operator User(UserRegistrationRequest request)
            => new User(request.FirstName, request.LastName, request.Email);
    }
}
