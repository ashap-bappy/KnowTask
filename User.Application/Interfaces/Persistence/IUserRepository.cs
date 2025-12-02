using User.Domain.Entities;

namespace User.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task AddAsync(UserModel user, CancellationToken ct = default);
        Task<UserModel?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<UserModel?> GetByEmailAsync(string email, CancellationToken ct = default);
    }
}
