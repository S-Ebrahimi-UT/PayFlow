using Microsoft.EntityFrameworkCore.Storage;
using PayFlow.Application.Interfaces;
using PayFlow.Infrastructure.Persistence;

namespace PayFlow.Infrastructure.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly PayFlowDbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(PayFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
        if (_transaction != null)
            await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
            await _transaction.RollbackAsync();
    }

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}
