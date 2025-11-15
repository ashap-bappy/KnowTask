using User.Domain.Entities;

namespace User.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<UserModel?> GetByEmailAsync(string email);
        Task AddAsync(UserModel user);

    }
}
