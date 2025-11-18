using Microsoft.EntityFrameworkCore;
using User.Application.Interfaces.Persistence;
using User.Domain.Entities;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class UserRepository(UserDbContext context) : IUserRepository
    {
        public async Task AddAsync(UserModel user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public Task<UserModel?> GetByEmailAsync(string email)
        {
            return context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
