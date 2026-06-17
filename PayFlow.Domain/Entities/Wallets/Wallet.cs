using PayFlow.Domain.Entities.Withdrawals;

namespace PayFlow.Domain.Entities.Wallets;

public class Wallet
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    // public ICollection<WalletTransaction> WalletTransactions { get; set; }
    private readonly List<WithdrawalRequest> _withdrawalRequests = new();
    public IReadOnlyCollection<WithdrawalRequest> WithdrawalRequests
        => _withdrawalRequests.AsReadOnly();

    private readonly List<WalletTransaction> _walletTransactions = new();
    public IReadOnlyCollection<WalletTransaction> WalletTransactions
        => _walletTransactions.AsReadOnly();
}
