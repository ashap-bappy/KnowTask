using Microsoft.EntityFrameworkCore.Storage;

namespace KnowTask.Persistence;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken ct = default);

    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct = default);
    Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken ct = default);
    Task RollbackTransactionAsync(IDbContextTransaction transaction, CancellationToken ct = default);
}