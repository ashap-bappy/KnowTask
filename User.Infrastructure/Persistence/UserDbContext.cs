using Microsoft.EntityFrameworkCore;
using User.Domain.Entities;

namespace User.Infrastructure.Persistence
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserModel> Users => Set<UserModel>();
    }
}
