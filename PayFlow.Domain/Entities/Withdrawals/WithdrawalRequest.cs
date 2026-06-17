using PayFlow.Domain.Entities.Wallets;
using PayFlow.Domain.Enums;

namespace PayFlow.Domain.Entities.Withdrawals;

public class WithdrawalRequest
{
    public long Id { get; set; }
    public long WalletId { get; set; }
    public Wallet? Wallet { get; set; }
    public decimal Amount { get; set; }

    public decimal Fee { get; set; }
    public decimal PayableAmount { get; set; }

    public WithdrawalStatus Status { get; set; }

    public string? RejectReason { get; set; }
    public string? TrackingCode { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public DateTime? RejectedAt { get; set; }
    public DateTime? PaidAt { get; set; }
    public DateTime? FailedAt { get; set; }
    private readonly List<WalletTransaction> _walletTransactions = new();

    public IReadOnlyCollection<WalletTransaction> WalletTransactions => _walletTransactions.AsReadOnly();

}
