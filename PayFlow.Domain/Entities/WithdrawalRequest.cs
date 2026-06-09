using PayFlow.Domain.Enums;

namespace PayFlow.Domain.Entities;

public class WithdrawalRequest
{
    public long Id { get; set; }
    public long UserId { get; set; }

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
}
