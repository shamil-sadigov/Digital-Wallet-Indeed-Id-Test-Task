using System;

namespace EWallet.Core.Models.DTO
{
    public class OperationDTO
    {
        public string Id { get; set; }
        public string Direction { get; set; }
        public DateTime OperationDate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
