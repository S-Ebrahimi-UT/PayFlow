using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Entities.Withdrawals;

namespace PayFlow.Infrastructure.Persistence;

public class PayFlowDbContext : DbContext
{
    public DbSet<WithdrawalRequest> WithdrawalRequests => Set<WithdrawalRequest>();
    public PayFlowDbContext(
        DbContextOptions<PayFlowDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
