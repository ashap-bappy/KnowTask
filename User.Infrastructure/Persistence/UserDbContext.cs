using KnowTask.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public sealed class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<UserModel> Users => Set<UserModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("users");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
        }

        public Task<int> CommitAsync(CancellationToken ct = default)
        {
            return SaveChangesAsync(ct);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct = default)
        {
            return Database.BeginTransactionAsync(ct);
        }

        public Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken ct = default)
        {
            return transaction.CommitAsync(ct);
        }

        public Task RollbackTransactionAsync(IDbContextTransaction transaction, CancellationToken ct = default)
        {
            return transaction.RollbackAsync(ct);
        }
    }
}
