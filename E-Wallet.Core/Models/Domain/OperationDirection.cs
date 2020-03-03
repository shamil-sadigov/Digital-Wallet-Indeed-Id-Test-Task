namespace EWallet.Core.Models.Domain
{
    /// <summary>
    /// Represent and direction of account funds.
    /// In => can represent funds withdrawal
    /// Out => can represent funds replenishment
    /// </summary>
    public enum OperationDirection
    {
        In, Out
    }
}
