using Microsoft.EntityFrameworkCore;
using User.Application.Contracts;
using User.Domain.Entities;
using User.Infrastructure.Persistence;

namespace User.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public Task<UserModel?> GetByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        }
    }
}
