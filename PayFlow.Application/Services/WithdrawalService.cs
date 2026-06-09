using PayFlow.Application.DTOs;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Enums;

namespace PayFlow.Application.Services;

public class WithdrawalService(IWithdrawalRepository withdrawalRepository) : IWithdrawalService
{
    public async Task<CreateWithdrawalResponseDto> CreateWithdrawalAsync(CreateWithdrawalRequestDto request)
    {
        var userId = 123;
        if (request.Amount <= 0)
        {
            throw new Exception("Amount must be greater than zero.");
        }
        var hasOpenRequest = await withdrawalRepository.HasOpenRequestAsync(userId);
        if (hasOpenRequest)
        {
            throw new Exception("You have a open withdrawal");
        }
        var withdrawal = new WithdrawalRequest
        {
            Amount = request.Amount,
            CreatedAt = DateTime.UtcNow,
            Status = WithdrawalStatus.Pending,
            UserId = userId
        };
        await withdrawalRepository.AddAsync(withdrawal);
        await withdrawalRepository.SaveChangeAsync();
        return new CreateWithdrawalResponseDto()
        {
            Id = withdrawal.Id
        };
    }

    public async Task<WithdrawalRequestDto> GetWithdrawalAsync(long id)
    {
        var withdrawal = await withdrawalRepository.GetByIdAsync(id);
        if (withdrawal == null)
        {
            throw new Exception("Withdrawal not found");
        }
        return new WithdrawalRequestDto
        {
            Id = withdrawal.Id,
            Amount = withdrawal.Amount,
            CreatedAt = withdrawal.CreatedAt,
            Status = withdrawal.Status,
            TrackingCode = withdrawal.TrackingCode
        };
    }
}
