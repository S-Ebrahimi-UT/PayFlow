using PayFlow.Domain.Enums;

namespace PayFlow.Application.DTOs;

public class WithdrawalRequestDto
{
    public long Id { get; set; }
    public decimal Amount { get; set; }
    public WithdrawalStatus Status { get; set; }
    public string? RejectReason { get; set; }
    public string? TrackingCode { get; set; }
    public DateTime CreatedAt { get; set; }

}
