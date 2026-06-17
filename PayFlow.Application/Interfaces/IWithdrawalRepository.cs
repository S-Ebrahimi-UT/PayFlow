using PayFlow.Domain.Entities.Withdrawals;

namespace PayFlow.Application.Interfaces;

public interface IWithdrawalRepository
{
    Task AddAsync(WithdrawalRequest withdrawal);

    Task<WithdrawalRequest?> GetByIdAsync(long id);

    Task<bool> HasOpenRequestAsync(long userId);
}