using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public class UserDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<UserModel> Users => Set<UserModel>();
    }
}
