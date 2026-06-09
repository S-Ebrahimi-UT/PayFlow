using PayFlow.Application.DTOs;

namespace PayFlow.Application.Interfaces;

public interface IWithdrawalService
{
    Task<CreateWithdrawalResponseDto> CreateWithdrawalAsync(CreateWithdrawalRequestDto request);
    Task<WithdrawalRequestDto> GetWithdrawalAsync(long id);
}
