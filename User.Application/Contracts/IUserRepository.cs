using User.Domain.Entities;

namespace User.Application.Contracts
{
    public interface IUserRepository
    {
        Task<UserModel?> GetByEmailAsync(string email);
        Task AddAsync(UserModel user);

    }
}
