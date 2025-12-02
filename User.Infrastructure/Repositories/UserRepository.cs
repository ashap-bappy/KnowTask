using Microsoft.EntityFrameworkCore;
using User.Application.Interfaces.Persistence;
using User.Domain.Entities;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class UserRepository(UserDbContext context) : IUserRepository
    {
        public async Task AddAsync(UserModel user, CancellationToken ct = default)
        {
            await context.Users.AddAsync(user, ct);
        }

        public async Task<UserModel?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: ct);
            return user;
        }

        public async Task<UserModel?> GetByEmailAsync(string email, CancellationToken ct = default)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken: ct);
            return user;
        }
    }
}
