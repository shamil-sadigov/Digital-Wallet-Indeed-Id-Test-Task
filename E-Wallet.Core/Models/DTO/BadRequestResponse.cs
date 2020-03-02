using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Core.Models.DTO
{
    public class BadRequestResponse
    {
        public string ErrorMessage { get; set; }

        public BadRequestResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
