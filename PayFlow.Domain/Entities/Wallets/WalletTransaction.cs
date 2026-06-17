using PayFlow.Domain.Entities.Withdrawals;
using PayFlow.Domain.Enums;

namespace PayFlow.Domain.Entities.Wallets;

public class WalletTransaction
{
    public long Id { get; set; }

    public long WalletId { get; set; }
    public Wallet? Wallet { get; set; } 
    public long? WithdrawalRequestId { get; set; }
    public WithdrawalRequest? WithdrawalRequest { get; set; }
    public decimal Amount { get; set; }

    public WalletTransactionType Type { get; set; }

    public DateTime CreatedAt { get; set; }
}