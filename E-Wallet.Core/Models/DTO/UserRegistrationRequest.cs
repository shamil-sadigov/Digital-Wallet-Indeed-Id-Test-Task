using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models.DTO
{
    public class UserRegistrationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
