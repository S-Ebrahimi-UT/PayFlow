using Microsoft.EntityFrameworkCore;
using PayFlow.Application.Interfaces;
using PayFlow.Domain.Entities;
using PayFlow.Domain.Enums;
using PayFlow.Infrastructure.Persistence;

namespace PayFlow.Infrastructure.Repositories;

public class WithdrawalRepository(PayFlowDbContext dbContext) : IWithdrawalRepository
{
    public async Task AddAsync(WithdrawalRequest withdrawal)
    {
        await dbContext.WithdrawalRequests.AddAsync(withdrawal);
    }

    public async Task<WithdrawalRequest?> GetByIdAsync(long id)
    {
        var result = await dbContext.WithdrawalRequests.FindAsync(id);
        return result;
    }

    public async Task<bool> HasOpenRequestAsync(long userId)
    {
        var openStatuses = new[]
            {
                WithdrawalStatus.Pending,
                WithdrawalStatus.Approved
            };

        return await dbContext.WithdrawalRequests.AnyAsync(x =>
            x.UserId == userId &&
            openStatuses.Contains(x.Status));
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
